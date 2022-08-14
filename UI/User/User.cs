using Domain.Communication;
using Domain.Model;
using ServerProj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using UI.Games;

namespace UI.User
{
    [Serializable]
    public class User
    {
        Socket userSocket;
        NetworkStream stream;
        BinaryFormatter formatter = new BinaryFormatter();

        public LobbyForm frmLobby;
        public RollADiceForm frmDice;


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

        #region Server settings
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

        // TO DO
        //public bool DisconnectUser()
        //{
        //    try
        //    {
        //        Server.onlineUsers.Remove();
        //        userSocket.Close();
        //        return true;
        //    }
        //    catch(Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //        return false;
        //    }
        //}

        #endregion

        #region Handling requests

        private Request CreateRequest(OperationRequest operation, string obj)
        {
            var request = new Request(operation, obj);
            return request;
        }
        public void SendRequest(OperationRequest operation, string obj)
        {
            var request = CreateRequest(operation, obj);
            
            formatter.Serialize(stream, request);
            
        }

        public Response SendRequestGetResponse(OperationRequest operation, string obj)
        {
            try
            {
                SendRequest(operation, obj);
        
                var response =  (Response)formatter.Deserialize(stream);
                return response;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

        #region Listening for server news and responding

        public void StartNewThread()
        {
            Task.Run(() => ListenAndAcceptForServerMessage());
            //new Thread(ListenAndAcceptForServerMessage).Start();
        }

        private void ListenAndAcceptForServerMessage()
        {

            bool isEnd = false;
            while (!isEnd)
            {
                try
                {
                    var response = (Response)formatter.Deserialize(stream);

                    switch (response.Operation)
                    {
                        case OperationResponse.RefreshLobby: frmLobby.RefreshDataGrid(response.Message); break;
                        case OperationResponse.ReceivedGameRequest:frmLobby.ShowGameRequest(response.Message); break;
                        case OperationResponse.GameRejectedNotification: frmLobby.ReceiveRejectNotification(); break;
                        case OperationResponse.DiceGameStarted:frmLobby.StartNewGame(response.Message); break;
                    }

                }
                catch (SerializationException ex)
                {
                    
                    isEnd = true;
                    stream.Close();
                    userSocket.Close();
                    MessageBox.Show("Server has been lost");
                    
                }
            }
        }

        #endregion

    }
}
