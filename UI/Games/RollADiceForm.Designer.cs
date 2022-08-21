namespace UI.Games
{
    partial class RollADiceForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RollADiceForm));
            this.panelGame = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelNotification = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelCurrentScore = new System.Windows.Forms.Panel();
            this.labelCurrentScore = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.panelPlayer1 = new System.Windows.Forms.Panel();
            this.labelPlayer1Score = new System.Windows.Forms.Label();
            this.labelPlayer1Name = new System.Windows.Forms.Label();
            this.panelPlayer2 = new System.Windows.Forms.Panel();
            this.labelPlayer2Name = new System.Windows.Forms.Label();
            this.labelPlayer2Score = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panelGame.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelCurrentScore.SuspendLayout();
            this.panelPlayer1.SuspendLayout();
            this.panelPlayer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelGame
            // 
            this.panelGame.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelGame.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelGame.Controls.Add(this.panel1);
            this.panelGame.Controls.Add(this.button1);
            this.panelGame.Controls.Add(this.pictureBox1);
            this.panelGame.Controls.Add(this.panelCurrentScore);
            this.panelGame.Controls.Add(this.button2);
            this.panelGame.Controls.Add(this.panelPlayer1);
            this.panelGame.Controls.Add(this.panelPlayer2);
            this.panelGame.Location = new System.Drawing.Point(127, 75);
            this.panelGame.Name = "panelGame";
            this.panelGame.Size = new System.Drawing.Size(778, 466);
            this.panelGame.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.labelNotification);
            this.panel1.Location = new System.Drawing.Point(255, 108);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(281, 221);
            this.panel1.TabIndex = 3;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(220)))), ((int)(((byte)(222)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.Location = new System.Drawing.Point(96, 175);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(77, 36);
            this.button3.TabIndex = 8;
            this.button3.Text = "Start";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(57, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Go to next game!";
            // 
            // labelNotification
            // 
            this.labelNotification.ForeColor = System.Drawing.Color.Black;
            this.labelNotification.Location = new System.Drawing.Point(45, 13);
            this.labelNotification.Name = "labelNotification";
            this.labelNotification.Size = new System.Drawing.Size(198, 114);
            this.labelNotification.TabIndex = 0;
            this.labelNotification.Text = "label1";
            this.labelNotification.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(220)))), ((int)(((byte)(222)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(331, 293);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 36);
            this.button1.TabIndex = 7;
            this.button1.Text = "Hold";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::UI.Properties.Resources.dice1;
            this.pictureBox1.Location = new System.Drawing.Point(331, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(125, 125);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // panelCurrentScore
            // 
            this.panelCurrentScore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(220)))), ((int)(((byte)(222)))));
            this.panelCurrentScore.Controls.Add(this.labelCurrentScore);
            this.panelCurrentScore.Controls.Add(this.label);
            this.panelCurrentScore.ForeColor = System.Drawing.Color.Black;
            this.panelCurrentScore.Location = new System.Drawing.Point(255, 348);
            this.panelCurrentScore.Name = "panelCurrentScore";
            this.panelCurrentScore.Size = new System.Drawing.Size(281, 99);
            this.panelCurrentScore.TabIndex = 3;
            // 
            // labelCurrentScore
            // 
            this.labelCurrentScore.AutoSize = true;
            this.labelCurrentScore.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelCurrentScore.Location = new System.Drawing.Point(126, 53);
            this.labelCurrentScore.Name = "labelCurrentScore";
            this.labelCurrentScore.Size = new System.Drawing.Size(23, 25);
            this.labelCurrentScore.TabIndex = 1;
            this.labelCurrentScore.Text = "0";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(91, 11);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(107, 21);
            this.label.TabIndex = 0;
            this.label.Text = "Current score:";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(220)))), ((int)(((byte)(222)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(331, 250);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(125, 36);
            this.button2.TabIndex = 8;
            this.button2.Text = "Roll Dice";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panelPlayer1
            // 
            this.panelPlayer1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelPlayer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(115)))), ((int)(((byte)(117)))));
            this.panelPlayer1.Controls.Add(this.labelPlayer1Score);
            this.panelPlayer1.Controls.Add(this.labelPlayer1Name);
            this.panelPlayer1.Location = new System.Drawing.Point(0, 0);
            this.panelPlayer1.Name = "panelPlayer1";
            this.panelPlayer1.Size = new System.Drawing.Size(389, 466);
            this.panelPlayer1.TabIndex = 0;
            // 
            // labelPlayer1Score
            // 
            this.labelPlayer1Score.AutoSize = true;
            this.labelPlayer1Score.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelPlayer1Score.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(228)))), ((int)(((byte)(232)))));
            this.labelPlayer1Score.Location = new System.Drawing.Point(147, 108);
            this.labelPlayer1Score.Name = "labelPlayer1Score";
            this.labelPlayer1Score.Size = new System.Drawing.Size(32, 37);
            this.labelPlayer1Score.TabIndex = 2;
            this.labelPlayer1Score.Text = "0";
            // 
            // labelPlayer1Name
            // 
            this.labelPlayer1Name.AutoSize = true;
            this.labelPlayer1Name.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelPlayer1Name.ForeColor = System.Drawing.Color.Black;
            this.labelPlayer1Name.Location = new System.Drawing.Point(116, 52);
            this.labelPlayer1Name.Name = "labelPlayer1Name";
            this.labelPlayer1Name.Size = new System.Drawing.Size(117, 37);
            this.labelPlayer1Name.TabIndex = 1;
            this.labelPlayer1Name.Text = "PLayer 1";
            // 
            // panelPlayer2
            // 
            this.panelPlayer2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelPlayer2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(228)))), ((int)(((byte)(232)))));
            this.panelPlayer2.Controls.Add(this.btnCancel);
            this.panelPlayer2.Controls.Add(this.labelPlayer2Name);
            this.panelPlayer2.Controls.Add(this.labelPlayer2Score);
            this.panelPlayer2.Location = new System.Drawing.Point(389, 0);
            this.panelPlayer2.Name = "panelPlayer2";
            this.panelPlayer2.Size = new System.Drawing.Size(389, 466);
            this.panelPlayer2.TabIndex = 1;
            // 
            // labelPlayer2Name
            // 
            this.labelPlayer2Name.AutoSize = true;
            this.labelPlayer2Name.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelPlayer2Name.ForeColor = System.Drawing.Color.Black;
            this.labelPlayer2Name.Location = new System.Drawing.Point(150, 52);
            this.labelPlayer2Name.Name = "labelPlayer2Name";
            this.labelPlayer2Name.Size = new System.Drawing.Size(117, 37);
            this.labelPlayer2Name.TabIndex = 4;
            this.labelPlayer2Name.Text = "PLayer 2";
            // 
            // labelPlayer2Score
            // 
            this.labelPlayer2Score.AutoSize = true;
            this.labelPlayer2Score.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelPlayer2Score.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(115)))), ((int)(((byte)(117)))));
            this.labelPlayer2Score.Location = new System.Drawing.Point(185, 108);
            this.labelPlayer2Score.Name = "labelPlayer2Score";
            this.labelPlayer2Score.Size = new System.Drawing.Size(32, 37);
            this.labelPlayer2Score.TabIndex = 5;
            this.labelPlayer2Score.Text = "0";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(228)))), ((int)(((byte)(232)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(115)))), ((int)(((byte)(117)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(340, 4);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(45, 45);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "X";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // RollADiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1029, 607);
            this.ControlBox = false;
            this.Controls.Add(this.panelGame);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RollADiceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "RollADiceForm";
            this.Load += new System.EventHandler(this.RollADiceForm_Load);
            this.panelGame.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelCurrentScore.ResumeLayout(false);
            this.panelCurrentScore.PerformLayout();
            this.panelPlayer1.ResumeLayout(false);
            this.panelPlayer1.PerformLayout();
            this.panelPlayer2.ResumeLayout(false);
            this.panelPlayer2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelGame;
        private Panel panelCurrentScore;
        private Label labelCurrentScore;
        private Label label;
        private Button button2;
        private Button button1;
        private Panel panelPlayer2;
        private Label labelPlayer2Name;
        private Label labelPlayer2Score;
        private PictureBox pictureBox1;
        private Panel panelPlayer1;
        private Label labelPlayer1Score;
        private Label labelPlayer1Name;
        private Panel panel1;
        private Label labelNotification;
        private Label label1;
        private Button button3;
        private Button btnCancel;
    }
}