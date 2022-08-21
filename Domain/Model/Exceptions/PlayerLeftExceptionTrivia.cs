using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Exceptions
{
    public class PlayerLeftExceptionTrivia : Exception
    {
        public NetworkStream str { get; set; }
        public PlayerLeftExceptionTrivia(NetworkStream stream)
        {
            str = stream;
        }
    }
}
