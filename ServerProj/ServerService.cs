using Domain.Communication;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerProj
{
    public class ServerService
    {
        private Socket socket;
        private Player localPlayer;

        public ServerService(Socket socket)
        {
            this.socket = socket;
        }

        #region Creating new player

        private Player CreateAPlayer(string name, Socket socket)
        {
            return new Player()
            {
                Name = name,
                Socket = socket,
                Score = 0,
                Id = (Server.id++).ToString()
            };
        }

        public Response AddANewPlayer(object body)
        {
            var name = body.ToString();
            var player = CreateAPlayer(name, socket);

            Server.onlineUsers.Add(player);

            Response response = new Response { Message = "Player is created", Flag = true };
            return response;
        }

        #endregion

        #region New room


        
        
        #endregion

    }
}
