using Domain.Model;
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

        public static List<Player> onlineUsers = new List<Player>();
        public static List<LobbyGame> availableGames = new List<LobbyGame>();
        private List<ClientHandler> clientHandlers = new List<ClientHandler>();
     

        public static int id = 1;

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
                Task.Run(() => ListenForConnections());
                //new Thread(ListenForConnections).Start();
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
                foreach (var player in onlineUsers)
                    player.Socket.Close(); // promeniti posle u close socket metodu TO DO

                foreach(var clientHandler in clientHandlers)
                    clientHandler.StopClientHandler();

                socketListener.Close();
                

                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("StopTheServer Server");

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

                   // MessageBox.Show(userSocket.RemoteEndPoint.ToString());
                    var handler = new ClientHandler(userSocket);
                    clientHandlers.Add(handler);
                    //new Thread(handler.ProcessRequests).Start();
                    var task = Task.Run(() => handler.ProcessRequests());
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Server has been lost");
                StopTheServer();
                Application.Exit();
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
