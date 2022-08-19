using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class LobbyGame
    {
        public string Owner { get; set; }
        public string OwnerId { get; set; }
        public bool Status { get; set; }

        public string Opponent { get; set; }
        public string OpponentId { get; set; }

    }
}
