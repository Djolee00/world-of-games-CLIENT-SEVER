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

        public void ProcessRequests()
        {

            bool isEnd = false;
            while (!isEnd)
            {
                try
                {
                    var request = (Request)formatter.Deserialize(stream);
                    var response = ProcessSingleRequest(request);
                    formatter.Serialize(stream, response);
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

        public Response ProcessSingleRequest(Request request)
        {
            try
            {
                switch (request.Operation)
                {
                    case OperationRequest.CreateANewPlayer: return service.AddANewPlayer(request.Body);
                    case OperationRequest.MakeANewRoom:  service.MakeANewRoom(); RefreshLobby(); return new Response();
                }

                return new Response();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private Response CreateResponse(string message, bool flag, OperationResponse operation)
        {
            return new Response
            {
                Message = message,
                Flag = flag,
                Operation = operation
            };
        }

        public Response SendResponse(string message, OperationResponse operation)
        {
            var response = CreateResponse(message, true, operation);

            foreach (var player in Server.onlineUsers)
            {
                if (player.Socket == socket) continue;

                var str = new NetworkStream(player.Socket);
                formatter.Serialize(str, response);
            }

            formatter.Serialize(stream, response);

            return response ;
        }

        public void RefreshLobby()
        {
            string rooms = DisplayAllRooms();
            var response = SendResponse(rooms, OperationResponse.RoomCreated);

        }

        private string DisplayAllRooms()
        {
            string response = "";
            foreach (var room in Server.availableGames)
                response += $"{room.Owner} {room.OwnerId} {(room.Status ? "Available" : "In game")};";

            return response;
        }


    }
}
