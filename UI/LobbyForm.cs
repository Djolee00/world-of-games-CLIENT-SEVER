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
            CheckForIllegalCrossThreadCalls = false;
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            User.User.Instance.SendRequest(OperationRequest.MakeANewRoom, "");
        }

        private void LobbyForm_Load(object sender, EventArgs e)
        {

        }

        public  void RefreshDataGrid(string rooms)
        {
            try
            {
                dataGridView1.Invoke(delegate
                {
                    dataGridView1.Rows.Clear();
                });

                 // da li zbog ovoga puca?
                var split = rooms.Split(';');

                foreach (var room in split)
                {
                    var row = room.Split(' ');
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
