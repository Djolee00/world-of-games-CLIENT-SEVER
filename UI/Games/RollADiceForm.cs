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
        public RollADiceForm(string player1,string player2)
        {
            InitializeComponent();
            labelPlayer1Name.Text = player1;
            labelPlayer2Name.Text = player2;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void RollADiceForm_Load(object sender, EventArgs e)
        {
            User.User.Instance.frmDice = this;
        }
    }
}
