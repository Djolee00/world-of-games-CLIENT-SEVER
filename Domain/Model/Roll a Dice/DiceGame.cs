using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Roll_a_Dice
{
    public class DiceGame
    {
        public static int FinalScore = 20;

        public int CurrentScore { get; set; }
        public int Score1 { get; set; }
        public int Score2 { get; set; }
        public bool Winner{ get; set; }

       

        public DiceGame(int currentScore, int score1, int score2)
        {
            CurrentScore = currentScore;
            Score1 = score1;
            Score2 = score2;
            Winner = false;
        }

        public DiceGame()
        { }
    }
}
