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
            localPlayer = CreateAPlayer(name, socket);

            Server.onlineUsers.Add(localPlayer);

            Response response = new Response { Message = "Player is created", Flag = true };
            return response;
        }

        #endregion

        #region New room

        public Response MakeANewRoom()
        {
            var game = new LobbyGame
            {
                Owner = localPlayer.Name,
                OwnerId = Int32.Parse(localPlayer.Id),
                Status = localPlayer.Status
            };

            Server.availableGames.Add(game);

            return new Response
            {
                Message = "New room",
                Flag = true,
                Operation = OperationResponse.RoomCreated
            };
        }
        
        private void RefreshLobby()
        {
            
        }
        
        #endregion

    }
}
