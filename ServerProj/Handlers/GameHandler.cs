﻿using Domain.Communication;
using Domain.Model;
using Domain.Model.Exceptions;
using ServerProj.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ServerProj.Handlers
{
    public class GameHandler
    {
        Player player1, player2;
        NetworkStream stream1, stream2;
        BinaryFormatter formatter;

        DiceService diceService;
        TriviaService triviaService;

        bool playerOneTurn = true;
        int numberOfPlayersInTriviaGame = 0;
        bool lastTurnCorrect = true;

        Task<string>? playerOneClick = null;
        Task<string> playerTwoClick = null;

        public GameHandler(Player p1, Player p2)
        {
            player1 = p1;
            player2 = p2;
            stream1 = new NetworkStream(player1.Socket);
            stream2 = new NetworkStream(player2.Socket);
            formatter = new BinaryFormatter();

            diceService = new DiceService();
            
        }

        public async void GameCommunication()
        {
            // DICE GAME 
            try
            {
                GameDiceInit();
                bool end = false;
                while (!end)
                {
                    DisablePlayer();
                    end = PlayerTurn();
                    ChangePlayerTurn();
                }

                var taskPlayerOne = Task.Run(() => ListenForPLayerResponseTrivia(player1.Socket));
                var taskPlayerTwo = Task.Run(() => ListenForPLayerResponseTrivia(player2.Socket));

                Task.WaitAll(new Task[] { taskPlayerOne, taskPlayerTwo });

                // TRIVIA GAME 

                stream1 = new NetworkStream(player1.Socket);
                stream2 = new NetworkStream(player2.Socket);

                await GameTriviaHandler();

                if (playerOneClick != null && !playerOneClick.IsCompleted && playerTwoClick != null && !playerTwoClick.IsCompleted)
                    SendResponseToAll(new Response("", true, OperationResponse.DummyResponse));
                else
                {
                    if (playerOneClick != null && !playerOneClick.IsCompleted)
                        SendSingleResponse(stream1, new Response("", true, OperationResponse.DummyResponse));

                    if (playerTwoClick != null && !playerTwoClick.IsCompleted)
                        SendSingleResponse(stream2, new Response("", true, OperationResponse.DummyResponse));

                }


                DisplayTheWinner();

                var clientHandler = new ClientHandler(player1.Socket);
                Task.Run(() => clientHandler.ProcessRequests());

                var clientHandler2 = new ClientHandler(player2.Socket);
                Task.Run(() => clientHandler2.ProcessRequests());

                Server.clientHandlers.AddRange(new ClientHandler[] { clientHandler, clientHandler2 });

                player1.Score = player2.Score = 0;
            
            }
            catch (PlayerLeftException ex)
            {
                stream1.Close();
                stream1.Socket.Close();
            }
            catch(PlayerLeftExceptionTrivia ex)
            {
                var str = ex.str == stream1 ? stream2 : stream1;

                ex.str.Close();
                ex.str.Socket.Close();


                var clientHandler = new ClientHandler(str.Socket);
                Server.clientHandlers.Add(clientHandler);
                Task.Run(() => clientHandler.ProcessRequests());
            }
            catch (Exception e)
            {
                stream1.Close();
                stream2.Close();
                player1.Socket.Close();
                player2.Socket.Close();
            }

        }


        private  async Task ListenForPLayerResponseTrivia(Socket socket)
        {
            var request = (Request)formatter.Deserialize(new NetworkStream(socket));
            numberOfPlayersInTriviaGame++;

            if (numberOfPlayersInTriviaGame == 2)
               SendResponseToAll(new Response("", true, OperationResponse.TriviaGameStart));
        }

        private async Task GameTriviaHandler()
        {
            triviaService = new TriviaService();

            var isEnd = false;
            var questionNumber = 1;

            while (!isEnd)
            {
                try
                {
                    var question = triviaService.GetAQuestion();
                    var correctAnswer = triviaService.GetAAnswer();

                    SendResponseToAll(new Response(question, true, OperationResponse.QuestionReceived));

                    var responseAnswer = new Response();
                    
                    if(playerOneClick == null || playerOneClick.IsCompleted)
                    {
                        playerOneClick = Task.Run(() => GetAUserClick(stream1,stream2));
                    }


                    if (playerTwoClick == null || playerTwoClick.IsCompleted)
                    {
                        playerTwoClick = Task.Run(() => GetAUserClick(stream2,stream1));
                    }

                    CancellationTokenSource ts = new CancellationTokenSource();
                    var ct = ts.Token;

                    var timer = Task.Run(async () =>
                    {
                        for (int i = 10; i >= 0; i--)
                        {
                            if (ct.IsCancellationRequested)
                                break;

                            SendResponseToAll(new Response(i.ToString(), true, OperationResponse.TimerOperation));
                            await Task.Delay(1000);
                        }
                    },ct);


                    var result = Task.WaitAny(playerOneClick, playerTwoClick,timer);
                    var result2 = 2;

                    if (questionNumber++ == 10) isEnd = true;

                    if (result == 2) continue;

                    ts.Cancel();


                    var givenAnswer = (result == 0 ? playerOneClick.Result.ToString() : playerTwoClick.Result.ToString());
                    var isAnwerCorrect = correctAnswer == givenAnswer;

                    var responseMessage = "";

                    if (isAnwerCorrect)
                    {
                        if(result == 0)
                            player1.Score += 5;
                        else
                            player2.Score += 5;

                        responseMessage = $"{player1.Name};{player1.Score};{player2.Name};{player2.Score};{givenAnswer}";
                        SendResponseToAll(new Response(responseMessage, true, OperationResponse.CorrectAnwer));
                    }
                    else
                    {
                        bool isFirstPlayer = false;

                        if (result == 0)
                        {
                            player1.Score -= 3;
                            isFirstPlayer = true;
                            SendSingleResponse(stream1, new Response("", true, OperationResponse.DisablePlayerAfterFalseAnswer));
                        }
                        else
                        {
                            player2.Score -= 3;
                            SendSingleResponse(stream2, new Response("", true, OperationResponse.DisablePlayerAfterFalseAnswer));
                        }

                        responseMessage = $"{player1.Name};{player1.Score};{player2.Name};{player2.Score};{givenAnswer}";

                        SendResponseToAll(new Response(responseMessage, true, OperationResponse.FalseAnswer));


                        CancellationTokenSource ts2 = new CancellationTokenSource();
                        var ct2 = ts2.Token;

                        var timerSecond = Task.Run(async () =>
                        {
                            for (int i = 5; i >= 0; i--)
                            {
                                if (ct2.IsCancellationRequested)
                                    break;

                                SendResponseToAll(new Response(i.ToString(), true, OperationResponse.TimerOperation));
                                await Task.Delay(1000);
                            }
                        }, ct2);


                        if (result == 0)
                          result2 =  Task.WaitAny(timerSecond, playerTwoClick);
                        else
                           result2 =  Task.WaitAny(timerSecond, playerOneClick);

                        if (result2 == 0) continue;

                        ts2.Cancel();

                        var givenSecondAnswer = "";

                        if (isFirstPlayer)
                        {
                            givenSecondAnswer = playerTwoClick.Result.ToString();
                            if (correctAnswer == givenSecondAnswer) 
                                player2.Score += 5;
                            else
                                player2.Score -= 3;
                        }
                        else
                        {
                            givenSecondAnswer = playerOneClick.Result.ToString();
                            if (correctAnswer == givenSecondAnswer)
                                player1.Score += 5;
                            else
                                player1.Score -= 3;
                        }


                        responseMessage = $"{player1.Name};{player1.Score};{player2.Name};{player2.Score};{givenSecondAnswer}";

                        if (givenSecondAnswer == correctAnswer)
                            SendResponseToAll(new Response(responseMessage, true, OperationResponse.CorrectAnwer));
                        else
                            SendResponseToAll(new Response(responseMessage, true, OperationResponse.FalseAnswer));

                    }

                    if (result2 != 2) lastTurnCorrect = false;
                    else lastTurnCorrect = true;

                    await Task.Delay(3000);
                }
                catch (System.AggregateException ex)
                {

                    isEnd = true;
                    PlayerLeftExceptionTrivia e = (PlayerLeftExceptionTrivia)ex.InnerException;
                    throw new PlayerLeftExceptionTrivia(e.str);   
                }
                catch(SocketException ex)
                {
                    isEnd = true;
                }
                catch(SerializationException ex)
                {
                    isEnd = true;
                }
            }
        }

        private async Task<string> GetAUserClick(NetworkStream stream, NetworkStream stream2)
        {
            var request = (Request)formatter.Deserialize(stream);

            if(request.Operation == OperationRequest.PlayerLeftGame)
            {
                OpponentLeftGame(stream2, "trivia");
                SendSingleResponse(stream2, new Response("",true,OperationResponse.DummyResponse));
                
                throw new PlayerLeftExceptionTrivia(stream);
            }

            return request.Body;
        }

        #region Responses

        private void SendSingleResponse(NetworkStream str, Response response) => formatter.Serialize(str, response);
        public void SendResponseToAll(Response response)
        {
            SendSingleResponse(stream1, response);
            SendSingleResponse(stream2, response);
        }

        #endregion


        private void GameDiceInit()
        {
            SendResponseToAll(new Response(player1.Name+";"+player2.Name,true,OperationResponse.DiceGameStarted));
        }

        private void DisablePlayer()
        {
            SendSingleResponse(stream2, new Response($"{(playerOneTurn ? "prvi" : "false")}", false, OperationResponse.DisablePlayer));
        }

        private bool PlayerTurn()
        {
            bool end = false;
            bool isFinished = false;
            while(!end)
            {
                    var request = (Request)formatter.Deserialize(stream1);
                    if (request.Operation == OperationRequest.PlayerLeftGame)
                    {
                    OpponentLeftGame(stream2,"dice");
                    var clientHandler = new ClientHandler(stream2.Socket);
                    Task.Run(() => clientHandler.ProcessRequests());
                    Server.clientHandlers.Add(clientHandler);
                    throw new PlayerLeftException();
                    }
                    end = diceService.ProcessPlayerTurn(request, playerOneTurn);
                    var sr = diceService.GetScores();
                    SendResponseToAll(new Response(sr, true, OperationResponse.ChangeScores));

                     isFinished = CheckWinner();
            }

            return isFinished;
        }

        private void OpponentLeftGame(NetworkStream streamm,string message)
        {
            SendSingleResponse(streamm, new Response(message, true, OperationResponse.OpponentLeftGame));
        }

        private bool CheckWinner()
        {
            if (diceService.IsGameFinished())
            {
                var messageWinner = "Congratulations.\nYou won!\nYour score after this game: ";
                var messageLost = "Sadly, you lost.\nBe better in next game.\nYour score after this game: ";

                if (playerOneTurn)
                {
                    player1.Score += 15;
                    messageWinner += $"{player1.Score}";
                    messageLost += $"{player2.Score}";
                }
                else
                {
                    player2.Score += 15;
                    messageWinner += $"{player2.Score}";
                    messageLost += $"{player1.Score}";
                }

                SendSingleResponse(stream1, new Response(messageWinner, true, OperationResponse.RollADiceGameFinished));
                SendSingleResponse(stream2, new Response(messageLost, true, OperationResponse.RollADiceGameFinished));

                return true;
            }

            return false;
        }

        private void ChangePlayerTurn()
        {
            var temp = stream1;
            stream1 = stream2;
            stream2 = temp;
            playerOneTurn = !playerOneTurn;


            SendSingleResponse(stream1, new Response($"{(playerOneTurn ? "prvi" : "drugi")}", false, OperationResponse.EnablePlayer));
        }

        private void DisplayTheWinner()
        {
            var winner = $"{(player1.Score > player2.Score ? "player1" : $"{(player2.Score > player1.Score ? "player2" : "draw")}")}";
            var responseMessage = winner + $";{player1.Name};{player1.Score};{player2.Name};{player2.Score}";

            SendResponseToAll(new Response(responseMessage, true, OperationResponse.TriviaGameFinished));
        }
    }
}
