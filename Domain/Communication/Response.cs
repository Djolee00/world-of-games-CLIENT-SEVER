using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Communication
{
    [Serializable]
    public class Response
    {
        public string Message { get; set; }
        public bool Flag { get; set; }

        public string Body { get; set; }

    }
}
