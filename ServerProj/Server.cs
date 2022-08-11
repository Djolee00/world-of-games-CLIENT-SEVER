using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerProj
{
    public class Server
    {
        Socket socketListener;
        public static List<Socket> onlineUsers = new List<Socket>();

        // Singleton pattern 
        public static Server instance;
        private Server()
        {

        }
        public static Server Instance
        {
            get
            {
                if (instance is null) instance = new Server();
                return instance;
            }
        }

        public bool StartTheServer()
        {
            try
            {
                socketListener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint port = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9000);
                socketListener.Bind(port);
                socketListener.Listen(5);

                new Thread(ListenForConnections).Start();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public bool StopTheServer()
        {
            try
            {
                foreach (var socket in onlineUsers)
                    socket.Close();

                socketListener.Close();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void ListenForConnections()
        {
            bool isEnd = false;
            try
            {
                while (!isEnd)
                {
                    Socket userSocket = socketListener.Accept();
                    onlineUsers.Add(userSocket);
<<<<<<< HEAD

                   // MessageBox.Show(userSocket.RemoteEndPoint.ToString());

                    var handler = new ClientHandler(userSocket);
                    // new Thread(handler.).Start();
=======
                    // zapocni novu nit 
>>>>>>> origin/master
                }


            }
            catch(SocketException ex)
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void CheckServerState()
        {
            try
            {
                if (Instance.StartTheServer())
                    MessageBox.Show("Server is online.", "Connected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Server is offline. You can't connect.", "Connection failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
