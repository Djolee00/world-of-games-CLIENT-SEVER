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
            User.User.Instance.StartNewThread();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            
        }

        private void CreateNewGame()
        {
           

        }
    }
}
