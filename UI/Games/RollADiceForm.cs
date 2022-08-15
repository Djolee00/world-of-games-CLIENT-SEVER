using Domain.Communication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Games
{
    public partial class RollADiceForm : Form
    {
        Bitmap[] images;

        public RollADiceForm(string str, string str2)
        {
            InitializeComponent();
            GameFormInit(str, str2);

        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            User.User.Instance.SendRequest(OperationRequest.None, "hold");
        }

        private void RollADiceForm_Load(object sender, EventArgs e)
        {
            images = new Bitmap[6];

            images[0] = Properties.Resources.dice1;
            images[1] = Properties.Resources.dice2;
            images[2] = Properties.Resources.dice3;
            images[3] = Properties.Resources.dice4;
            images[4] = Properties.Resources.dice5;
            images[5] = Properties.Resources.dice6;
        }

        private void ChangeColorOnTurnForActivePlayer()
        {
            panelPlayer1.BackColor = labelPlayer2Score.ForeColor =  Color.FromArgb(185, 115, 117);
            panelPlayer2.BackColor = labelPlayer1Score.ForeColor = Color.FromArgb(241, 228, 232);
        }

        private void ChangeColorOnTurnForNonActivePlayer()
        {
            panelPlayer2.BackColor = labelPlayer1Score.ForeColor = Color.FromArgb(185, 115, 117);
            panelPlayer1.BackColor = labelPlayer2Score.ForeColor = Color.FromArgb(241, 228, 232);
        }


        public void GameFormInit(string player1,string player2)
        {
            labelPlayer1Name.Text = player1;
            labelPlayer2Name.Text = player2;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            User.User.Instance.SendRequest(OperationRequest.None, "roll");
        }

        public void DisableForm(string message)
        {
            button1.Enabled = button2.Enabled = false;

            if(message == "prvi" )
                ChangeColorOnTurnForActivePlayer();
            else
                ChangeColorOnTurnForNonActivePlayer();
        }

        public void EnableForm(string message)
        {
            button1.Enabled = button2.Enabled = true;

            if (message == "prvi")
                ChangeColorOnTurnForActivePlayer();
            else
                ChangeColorOnTurnForNonActivePlayer();

        }

        public void ChangeScores(string message)
        {
            var scores = message.Split(";");
            labelCurrentScore.Text = scores[0];
            labelPlayer1Score.Text = scores[1];
            labelPlayer2Score.Text = scores[2];

            if(scores[3]!="0") ChanegDiceNumber(scores[3]);
        }

        private void ChanegDiceNumber(string diceNumber)
        {
            pictureBox1.Image = images[Convert.ToInt32(diceNumber) - 1];
        }

        public void DisplayAWinner(string winner)
        {
            MessageBox.Show($"Player {winner.Split(';')[0]} is a winner.");
        }
    }
}
