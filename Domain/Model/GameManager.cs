using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class GameManager
    {
        public Player Player1 { get; set; }

        public Player Player2 { get; set; }

        public GameManager(Player player1, Player player2)
        {
            Player1 = player1;
            Player2 = player2;
        }
    }
}
