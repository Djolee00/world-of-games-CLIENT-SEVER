using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerProj
{
    public partial class ServerForm : Form
    {
        public ServerForm()
        {
            InitializeComponent();
            Server.Instance.CheckServerState();
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Server.Instance.StopTheServer();
            this.Close();
        }

        private void ServerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Server.Instance.StopTheServer();
            Application.Exit();
            
        }
        private void btnPlay_Click(object sender, EventArgs e)
        {
            Server.Instance.StopTheServer();
            
        }
    }
}
