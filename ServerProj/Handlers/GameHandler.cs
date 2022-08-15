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
        bool playerOneTurn = true;

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
            GameDiceInit();
            bool end = false;
            while (!end)
            {
                try {
                    DisablePlayer();
                    PlayerTurn();
                    ChangePlayerTurn();
                }catch(Exception e)
                {
                    MessageBox.Show("GameCommunication Exception GameHandler");
                }

            }
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
            SendSingleResponse(stream2, new Response("biloSta", false, OperationResponse.DisablePlayer));
        }

        private void PlayerTurn()
        {
            bool end = false;
            while(!end)
            {
                try {
                    
                    var request = (Request)formatter.Deserialize(stream1);
                    end = diceService.ProcessPlayerTurn(request, playerOneTurn);
                    var sr = diceService.GetScores();
                    SendResponseToAll(new Response(sr, true, OperationResponse.ChangeScores));

                }catch(Exception e)
                {
                    MessageBox.Show(e.Message);
                }
               
            }
        }

        private void ChangePlayerTurn()
        {
            var temp = stream1;
            stream1 = stream2;
            stream2 = temp;
            playerOneTurn = !playerOneTurn;
        }
    }
}
