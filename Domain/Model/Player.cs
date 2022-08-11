using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Player
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }

        public Player(string id, string name, int score)
        {
            Id = id;
            Name = name;
            Score = score;
        }
    }
}
