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
using UI.Games;

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
            User.User.Instance.frmLobby = this;

            User.User.Instance.SendRequest(OperationRequest.WelcomeLobby, "");

            panel1.Visible = false;
        }

        #region Game request logic

        public void ShowGameRequest(string player)
        {
            var username = player.Split(';')[0];
            var id = player.Split(';')[1];

            ShowPanelForGameRequest(true, $"Do you accept the challange of {username}?");
            lblId.Text = id;
        }

        private void ShowPanelForGameRequest(bool show, string labelText)
        {
            panel1.Visible = true;
            btnYes.Visible = btnNo.Visible = show;
            btnOk.Visible = !show;

            lblPanel.Text = labelText;
        }

        public void ReceiveRejectNotification()
        {
            ShowPanelForGameRequest(false, "The player didn't accept your challange.");
        }

        #endregion

        #region DataGridView
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = "";
            dataGridView1.Invoke(delegate
            {
               id  = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            });
            User.User.Instance.SendRequest(OperationRequest.CreateGameRequest, id);
        }

        public void RefreshDataGrid(string games)
        {
            try
            {
                dataGridView1.BeginInvoke(delegate
                {
                    dataGridView1.Rows.Clear();
                });

                var split = games.Split(';');

                foreach (var game in split)
                {
                    var row = game.Split('*');
                    if (row[0] != "")
                        dataGridView1.BeginInvoke(delegate
                        {
                            dataGridView1.Rows.Add(row[0], row[1], "Challange", row[2]);
                        });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("RefreshDataGrid");
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Panel button's events
        private void btnNo_Click(object sender, EventArgs e)
        {
            User.User.Instance.SendRequest(OperationRequest.GameRejected, lblId.Text);
            panel1.Visible = false;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;

            User.User.Instance.SendRequest(OperationRequest.GameAccepted, lblId.Text);

        }
        public void PrekiniMeKaoHladnaVoda()
        {
            User.User.Instance.SendRequest(OperationRequest.BreakThread, "");
        }

        #endregion

        public void StartNewGame(string players)
        {
            var player1 = players.Split(";")[0];
            var player2 = players.Split(";")[1];
            
            this.Close();


            var diceForm = new RollADiceForm(player1, player2);
            User.User.Instance.frmDice = diceForm;

            Thread _thread = new Thread(() =>
            {
                Application.Run(diceForm);
            });

            _thread.SetApartmentState(ApartmentState.STA);
            _thread.Start();

        }


    }
}
