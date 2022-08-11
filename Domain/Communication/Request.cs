using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Communication
{
    public class Request
    {
        public Operation Operation { get; set; }
        public object Body { get; set; }

        public Request(Operation operation, object body)
        {
            Operation = operation;
            Body = body;
        }
    }
}
