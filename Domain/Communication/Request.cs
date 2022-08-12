using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Communication
{
 [Serializable]
    public class Request
    {
        public Operation Operation { get; set; }
        public string Body { get; set; }

        public Request(Operation operation, string body)
        {
            Operation = operation;
            Body = body;
        }
    }
}
