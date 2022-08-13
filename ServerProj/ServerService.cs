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
        private Player? localPlayer;

        public ServerService(Socket socket)
        {
            this.socket = socket;
        }

        #region Creating new player

        private Player CreateAPlayer(string name, Socket socket) => new Player()
            {
                Name = name,
                Socket = socket,
                Score = 0,
                Id = (Server.id++).ToString()
            };
        

        public void AddANewPlayer(string body)
        {
            var name = body.ToString();
            localPlayer = CreateAPlayer(name, socket);

            Server.onlineUsers.Add(localPlayer);
        }

        #endregion

        #region Lobby games

        public void MakeANewLobbyGame() // lepse nesto za ove nullable porukice
        {
            var game = new LobbyGame
            {
                Owner = localPlayer?.Name ?? "",
                OwnerId = Int32.Parse(localPlayer?.Id ?? "1"),
                Status = localPlayer?.Status ?? true
            };

            Server.availableGames.Add(game);
        }

        public string DisplayAllLobbyGames()
        {
            string games = "";
            foreach (var game in Server.availableGames)
                games += $"{game.Owner} {game.OwnerId} {(game.Status ? "Available" : "In game")};";

            return games;
        }

        #endregion


        public (NetworkStream,string) FindStreamById(string id)
        {
            var player = Server.onlineUsers.First(x => x.Id == id);
            if (player == localPlayer)
                //check if player who made lobby clicked his lobby
                return (null, null);
            return (new NetworkStream(player.Socket), localPlayer.Name);
        }
    }
}
