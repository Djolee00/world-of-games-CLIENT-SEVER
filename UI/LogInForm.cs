using Domain.Communication;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class LogInForm : Form
    {
        public LogInForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            var response = User.User.Instance.SendRequestGetResponse(Operation.CreateANewPlayer,textBox1.Text);
            MessageBox.Show(response.Message);

            var lobby = new LobbyForm();
            lobby.Show();
        }
    }
}
