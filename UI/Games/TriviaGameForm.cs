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

        internal void ShowQuestion(string question)
        {

            var questionInfo = question.Split(';');
            labelQuestion.Text = questionInfo[1];
            btnA.Text = questionInfo[2];
            btnB.Text = questionInfo[3];
            btnC.Text = questionInfo[4];
            btnD.Text = questionInfo[5];
        }

        private void btnA_Click(object sender, EventArgs e)
        {
            User.User.Instance.SendRequest(OperationRequest.None, btnA.Text);
        }
    }
}
