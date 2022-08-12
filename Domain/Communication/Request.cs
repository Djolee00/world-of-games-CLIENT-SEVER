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
        public OperationRequest Operation { get; set; }
        public string Body { get; set; }

        public Request(OperationRequest operation, string body)
        {
            Operation = operation;
            Body = body;
        }

        public Request()
        {

        }
    }
}
