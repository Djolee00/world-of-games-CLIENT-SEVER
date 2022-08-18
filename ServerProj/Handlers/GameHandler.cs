using Domain.Communication;
using Domain.Model;
using ServerProj.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
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

        public GameHandler(Player p1, Player p2)
        {
            player1 = p1;
            player2 = p2;
            stream1 = new NetworkStream(player1.Socket);
            stream2 = new NetworkStream(player2.Socket);
            formatter = new BinaryFormatter();

            diceService = new DiceService();
            
        }

        public void GameCommunication()
        {
            // DICE GAME 

            GameDiceInit();
            bool end = false;
            while (!end)
            {
                try {
                    DisablePlayer();
                    end = PlayerTurn();
                    ChangePlayerTurn();
                }catch(Exception e)
                {
                    MessageBox.Show("GameCommunication Exception GameHandler");
                }

            }

            var taskPlayerOne = Task.Run(() => ListenForPLayerResponseTrivia(player1.Socket));
            var taskPlayerTwo = Task.Run(() => ListenForPLayerResponseTrivia(player2.Socket));

            Task.WaitAll(new Task[] { taskPlayerOne, taskPlayerTwo });

            // TRIVIA GAME 

            stream1 = new NetworkStream(player1.Socket);
            stream2 = new NetworkStream(player2.Socket);

            GameTriviaHandler();

        }

        private  async Task ListenForPLayerResponseTrivia(Socket socket)
        {
            var request = (Request)formatter.Deserialize(new NetworkStream(socket));
            numberOfPlayersInTriviaGame++;

            if (numberOfPlayersInTriviaGame == 2)
                SendResponseToAll(new Response("",true,OperationResponse.TriviaGameStart));
        }

        private async void GameTriviaHandler()
        {
            triviaService = new TriviaService();

            Task<string> playerOneClick = null;
            Task<string> playerTwoClick = null;
            

            bool isEnd = false;
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
                        playerOneClick = Task.Run(() => GetAUserClick(stream1));
                    }


                    if (playerTwoClick == null || playerTwoClick.IsCompleted)
                    {
                        playerTwoClick = Task.Run(() => GetAUserClick(stream2));
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

                        int result2;

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


                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private async Task<string> GetAUserClick(NetworkStream stream)
        {
            var request = (Request)formatter.Deserialize(stream);

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
                try {
                    
                    var request = (Request)formatter.Deserialize(stream1);
                    end = diceService.ProcessPlayerTurn(request, playerOneTurn);
                    var sr = diceService.GetScores();
                    SendResponseToAll(new Response(sr, true, OperationResponse.ChangeScores));

                     isFinished = CheckWinner();


                }catch(Exception e)
                {
                    MessageBox.Show(e.Message);
                    return false;
                }
               
            }

            return isFinished;
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

    }
}
