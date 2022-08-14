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
    public class LobbyService
    {
        private Socket socket;
        private Player? localPlayer;

        public Player LocalPlayer => localPlayer;

        public LobbyService(Socket socket)
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

        public bool MakeANewLobbyGame() // lepse nesto za ove nullable porukice
        {
            var game = new LobbyGame
            {
                Owner = localPlayer?.Name ?? "",
                OwnerId = Int32.Parse(localPlayer?.Id ?? "1"),
                Status = localPlayer?.Status ?? true
            };

            if (Server.availableGames.FirstOrDefault(g => g.OwnerId == game.OwnerId) != null)
                return false;

           Server.availableGames.Add(game);
           return true;
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
            var player = FindAPlayerById(id);

            //check if player who made lobby clicked his lobby
            if (player == localPlayer)
                return (null, null);

            return (new NetworkStream(player.Socket), localPlayer.Name+';'+localPlayer.Id);
        }

        public Player FindAPlayerById(string id) => Server.onlineUsers.FirstOrDefault(p => p.Id == id);

        
    }
}
