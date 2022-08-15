using Domain.Communication;
using Domain.Model.Roll_a_Dice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerProj.Services
{
    public class DiceService
    {
        DiceGame diceGame;
        int diceNumber;

        public DiceService()
        {
            diceGame = new DiceGame();
        }

        public bool ProcessPlayerTurn(Request request,bool playerOneTurn)
        {
            if(request.Body == "roll")
            {
                 diceNumber = RollADice();
                if (diceNumber != 1)
                {
                    ChangeCurrentScore(diceNumber);
                    return false;
                }
                else
                {
                    diceGame.CurrentScore = 0;
                    return true;
                }
            }
            else if(request.Body == "hold")
            {
                if (playerOneTurn)
                    diceGame.Score1 += diceGame.CurrentScore;
                else
                    diceGame.Score2 += diceGame.CurrentScore;


                diceGame.CurrentScore = 0;
                diceNumber = 0;

                if (diceGame.Score1 >= DiceGame.FinalScore || diceGame.Score2 >= DiceGame.FinalScore)
                    diceGame.Winner = true;

                return true;
            }

            return false;
        }

        private int RollADice() =>  (new Random()).Next(1, 7);
        
        private void ChangeCurrentScore(int score) =>  diceGame.CurrentScore += score;

        public string GetScores() => $"{diceGame.CurrentScore};{diceGame.Score1};{diceGame.Score2};{diceNumber}";

        public bool IsGameFinished() => diceGame.Winner;
    }
}
