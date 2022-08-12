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

        public ClientHandler(Socket socket)
        {
            this.socket = socket;
            stream = new NetworkStream(socket);
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
                    isEnd = true;
                    socket.Close();
                }
            }
        }

        

        public Response ProcessSingleRequest(Request request)
        {
            try
            {
                switch (request.Operation)
                {
                    case Operation.CreateANewPlayer: return AddANewPlayer(request.Body); break;
                }

                return new Response("", false, "");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        public Response CreateNewLobbyGame()
        {
            //foreach(var handler in Server.onlineUsers)
            //    return new Response("Message za tebe", false, null);   

            return null;
        }


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

        private Response AddANewPlayer(object body)
        {
            var name = body.ToString();
            var player = CreateAPlayer(name,socket);

            return new Response("New player created",true, "");
        }


    }
}
