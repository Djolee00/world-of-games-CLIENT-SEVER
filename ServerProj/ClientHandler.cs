using Domain.Communication;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ServerProj
{
    [Serializable]
    public class ClientHandler
    {
        public Socket socket;
        NetworkStream stream;
        BinaryFormatter formatter = new BinaryFormatter();

        ServerService service;

        public ClientHandler(Socket socket)
        {
            this.socket = socket;
            stream = new NetworkStream(socket);

            service = new ServerService(socket);
        }
        #region Handling requests
        public void ProcessRequests()
        {

            bool isEnd = false;
            while (!isEnd)
            {
                try
                {
                    var request = (Request)formatter.Deserialize(stream);
                    ProcessSingleRequest(request);
                }
                catch(SocketException)
                {
                    socket.Close();
                }
                catch (IOException)
                {
                }
                catch (SerializationException)
                {
                }
                catch (Exception ex)
                {
                    
                }
                finally
                {

                }
            }
        }

        public void ProcessSingleRequest(Request request)
        {
            try
            {
                switch (request.Operation)
                {
                    case OperationRequest.CreateANewPlayer: service.AddANewPlayer(request.Body); break;
                    case OperationRequest.MakeANewLobbyGame: service.MakeANewLobbyGame(); RefreshLobby(); break;
                    case OperationRequest.CreateGameRequest: SendGameRequest(request.Body);break;

                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
        #endregion

        #region Handling responses
        private void SendSingleResponse(NetworkStream str, Response response) => formatter.Serialize(str, response);

        public void SendResponseToAll(Response response)
        {
            foreach (var player in Server.onlineUsers)
            {
                var str = new NetworkStream(player.Socket);
                SendSingleResponse(str, response);
            }
        }

        // mozda ne treba, imamo konstruktor, nek stoji
        private Response CreateResponse(string message, bool flag, OperationResponse operation)
        {
            return new Response
            {
                Message = message,
                Flag = flag,
                Operation = operation
            };
        }
        #endregion

        #region Methods for communication

        public void RefreshLobby()
        {
            string games = service.DisplayAllLobbyGames();
            SendResponseToAll(new Response(games, true, OperationResponse.LobbyGameCreated));
        }


        public void SendGameRequest(string id)
        {
            var temp = service.FindStreamById(id);
            if (temp.Item1 == null)
                return;
            SendSingleResponse(temp.Item1, new Response(temp.Item2,true,OperationResponse.ReceivedGameRequest));
        }
        #endregion
    }
}
