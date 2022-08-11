using Domain.Communication;
using ServerProj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace UI.User
{
    [Serializable]
    public class User
    {
        Socket userSocket;
        NetworkStream stream;
        BinaryFormatter formatter = new BinaryFormatter();



        private User() { }
        private static User instance;

        public static User Instance
        {
            get
            {
                if (instance is null) instance = new User();
                return instance;
            }
        }

        public bool ConnectToTheServer()
        {
            try
            {
                userSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                userSocket.Connect("localhost", 9000);
                stream = new NetworkStream(userSocket);
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Failed to connect to the server.");
                return false;
            }
        }

        public bool DisconnectUser()
        {
            try
            {
                Server.onlineUsers.Remove(userSocket);
                userSocket.Close();
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public Response SendRequestGetResponse(Operation operation, object obj)
        {
            try
            {
                formatter.Serialize(stream, new Request(operation, obj));
                return formatter.Deserialize(stream) as Response;
            }
            catch(Exception ex)
            {
                return null;
            }
        }


    }
}
