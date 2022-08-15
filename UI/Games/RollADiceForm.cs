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
        public RollADiceForm()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User.User.Instance.SendRequest(OperationRequest.None, "hold");
        }

        private void RollADiceForm_Load(object sender, EventArgs e)
        {
            User.User.Instance.frmDice = this;
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

        public void DisableForm()
        {
            //button1.Enabled = button2.Enabled = false;
            //button1.BackColor = Color.Red;
        }

        public void ChangeScores(string message)
        {
            var scores = message.Split(";");
            labelPlayer1CurrentScore.Text = scores[0];
            labelPlayer1Score.Text = scores[1];
            labelPlayer2Score.Text = scores[2];
            MessageBox.Show(scores[3]);
        }
    }
}
