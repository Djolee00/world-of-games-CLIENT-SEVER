using Domain.Communication;
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
        Socket socket;
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
                //switch (request.Operation)
                //{
                   
                //}

                return new Response("", false, null);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }



    }
}
