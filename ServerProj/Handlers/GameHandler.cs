using Domain.Communication;
using Domain.Model;
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

        public GameHandler(Player p1, Player p2)
        {
            player1 = p1;
            player2 = p2;
            stream1 = new NetworkStream(player1.Socket);
            stream2 = new NetworkStream(player2.Socket);
            formatter = new BinaryFormatter();
            

        }

        public void GameCommunication()
        {

        }

        #region Responses

        private void SendSingleResponse(NetworkStream str, Response response) => formatter.Serialize(str, response);
        public void SendResponseToAll(Response response)
        {
            SendSingleResponse(stream1, response);
            SendSingleResponse(stream2, response);
        }

        #endregion
    }
}
