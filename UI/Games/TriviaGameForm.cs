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
    public partial class TriviaGameForm : Form
    {
        public TriviaGameForm()
        {
            InitializeComponent();
           User.User.Instance.frmTrivia = this;
        }

        public void InitGameScene()
        {
            pnlWaiting.Visible = false;

        }

        internal void MsgBox(string message)
        {
            MessageBox.Show(message);
        }

        public void ShowQuestion(string question)
        {
            RefreshScene();

            var questionInfo = question.Split(';');
            questionInfo = questionInfo.Where(x => !string.IsNullOrEmpty(x)).ToArray();

            labelQuestion.Text = questionInfo[1];
            btnA.Text = questionInfo[2];

            btnB.Text = questionInfo[3];
            btnC.Text = questionInfo[4];
            btnD.Text = questionInfo[5];

        }

        public void ChangeTimerOnScreen(string i)
        {
            label1.Text = i;

        }

        private void RefreshScene()
        {
            btnA.Enabled = btnB.Enabled = btnC.Enabled = btnD.Enabled =  true;
            btnA.BackColor = btnB.BackColor = btnC.BackColor = btnD.BackColor = Color.Transparent;
        }

        public void CorrectAnswer(string response)
        {
            var splitResponse = ShowPlayersPoints(response);

            ChangeButtonsColor(Color.Green, splitResponse[4]);
        }

        public void FalseAnswer(string response)
        {
            var splitResponse =  ShowPlayersPoints(response);

            ChangeButtonsColor(Color.Red, splitResponse[4]);
        }

        private string[] ShowPlayersPoints(string players)
        {
            var splitResponse = players.Split(';');

            this.Text = $"{splitResponse[0]} : {splitResponse[1]} points. {splitResponse[2]} : {splitResponse[3]} points.";

            return splitResponse;
        }

        private void ChangeButtonsColor(Color color, string answer)
        {
            foreach (var button in this.Controls.OfType<Button>())
            {
                if (button.Text == answer)
                    button.BackColor = color;
            }
        }
        private void btnA_Click(object sender, EventArgs e)
        {
            User.User.Instance.SendRequest(OperationRequest.None, btnA.Text);
        }

        private void btnB_Click(object sender, EventArgs e)
        {
            User.User.Instance.SendRequest(OperationRequest.None, btnB.Text);
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            User.User.Instance.SendRequest(OperationRequest.None, btnC.Text);
        }

        private void btnD_Click(object sender, EventArgs e)
        {
            User.User.Instance.SendRequest(OperationRequest.None, btnD.Text);
        }

        public void DisablePlayerAfterFalse()
        {
            foreach (var button in this.Controls.OfType<Button>())
            {
                button.Enabled = false;
            }
        }
    }
}
