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
            CheckForIllegalCrossThreadCalls = false;
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            User.User.Instance.SendRequest(OperationRequest.MakeANewLobbyGame, "");
        }

        private void LobbyForm_Load(object sender, EventArgs e)
        {
            User.User.Instance.frm = this;
        }

        public  void RefreshDataGrid(string games)
        {
            try
            {
                dataGridView1.Invoke(delegate
                {
                    dataGridView1.Rows.Clear();
                });

                var split = games.Split(';');

                foreach (var game in split)
                {
                    var row = game.Split(' ');
                    if (row[0] != "")
                    dataGridView1.Invoke(delegate
                    {
                        dataGridView1.Rows.Add(row[0], row[2]);
                    });
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("OVDE");
            }
        }
    }
}
