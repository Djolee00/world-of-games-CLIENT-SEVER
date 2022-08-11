using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Communication
{
    public class Response
    {
        public string Message { get; set; }
        public bool Flag { get; set; }

        public object Body { get; set; }

        public Response(string message, bool flag, object body)
        {
            Message = message;
            Flag = flag;
            Body = body;
        }
    }
}
