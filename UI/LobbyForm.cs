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
    public partial class LobbyForm : Form
    {

        public LobbyForm()
        {
            InitializeComponent();
            User.User.Instance.frm = this;
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            User.User.Instance.SendRequest(OperationRequest.MakeANewRoom, "");
        }

        private void LobbyForm_Load(object sender, EventArgs e)
        {

        }

        public  void ChangeLabel()
        {
            label1.Invoke((MethodInvoker)delegate
            {
                // Running on the UI thread
                label1.Text = "PROMENA";
            });
        }
    }
}
