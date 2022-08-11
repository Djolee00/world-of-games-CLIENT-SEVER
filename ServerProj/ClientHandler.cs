using Domain.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ServerProj
{
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

        public void ProcessTheRequest(Operation operation)
        {

            switch (operation)
            {
               
            }
        }

    }
}
