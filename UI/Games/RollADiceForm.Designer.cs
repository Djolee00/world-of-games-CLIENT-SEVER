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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelPlayer1 = new System.Windows.Forms.Panel();
            this.panelPlayer1CurrentScore = new System.Windows.Forms.Panel();
            this.labelPlayer1CurrentScore = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelPlayer1Score = new System.Windows.Forms.Label();
            this.labelPlayer1Name = new System.Windows.Forms.Label();
            this.panelPlayer2 = new System.Windows.Forms.Panel();
            this.panelPlayer2CurrentScore = new System.Windows.Forms.Panel();
            this.labelPlayer2CurrentScore = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelPlayer2Name = new System.Windows.Forms.Label();
            this.labelPlayer2Score = new System.Windows.Forms.Label();
            this.panelGame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelPlayer1.SuspendLayout();
            this.panelPlayer1CurrentScore.SuspendLayout();
            this.panelPlayer2.SuspendLayout();
            this.panelPlayer2CurrentScore.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelGame
            // 
            this.panelGame.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelGame.BackColor = System.Drawing.Color.Black;
            this.panelGame.Controls.Add(this.button1);
            this.panelGame.Controls.Add(this.button2);
            this.panelGame.Controls.Add(this.pictureBox1);
            this.panelGame.Controls.Add(this.panelPlayer1);
            this.panelGame.Controls.Add(this.panelPlayer2);
            this.panelGame.Location = new System.Drawing.Point(127, 75);
            this.panelGame.Name = "panelGame";
            this.panelGame.Size = new System.Drawing.Size(778, 466);
            this.panelGame.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(331, 383);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 36);
            this.button1.TabIndex = 7;
            this.button1.Text = "Hold";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Gray;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(331, 331);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(125, 36);
            this.button2.TabIndex = 8;
            this.button2.Text = "Roll Dice";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(331, 111);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(125, 125);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // panelPlayer1
            // 
            this.panelPlayer1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelPlayer1.BackColor = System.Drawing.Color.White;
            this.panelPlayer1.Controls.Add(this.panelPlayer1CurrentScore);
            this.panelPlayer1.Controls.Add(this.labelPlayer1Score);
            this.panelPlayer1.Controls.Add(this.labelPlayer1Name);
            this.panelPlayer1.Location = new System.Drawing.Point(0, 0);
            this.panelPlayer1.Name = "panelPlayer1";
            this.panelPlayer1.Size = new System.Drawing.Size(389, 466);
            this.panelPlayer1.TabIndex = 0;
            // 
            // panelPlayer1CurrentScore
            // 
            this.panelPlayer1CurrentScore.BackColor = System.Drawing.Color.Coral;
            this.panelPlayer1CurrentScore.Controls.Add(this.labelPlayer1CurrentScore);
            this.panelPlayer1CurrentScore.Controls.Add(this.label1);
            this.panelPlayer1CurrentScore.Location = new System.Drawing.Point(74, 320);
            this.panelPlayer1CurrentScore.Name = "panelPlayer1CurrentScore";
            this.panelPlayer1CurrentScore.Size = new System.Drawing.Size(209, 99);
            this.panelPlayer1CurrentScore.TabIndex = 3;
            // 
            // labelPlayer1CurrentScore
            // 
            this.labelPlayer1CurrentScore.AutoSize = true;
            this.labelPlayer1CurrentScore.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelPlayer1CurrentScore.Location = new System.Drawing.Point(91, 53);
            this.labelPlayer1CurrentScore.Name = "labelPlayer1CurrentScore";
            this.labelPlayer1CurrentScore.Size = new System.Drawing.Size(54, 62);
            this.labelPlayer1CurrentScore.TabIndex = 1;
            this.labelPlayer1CurrentScore.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 54);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current";
            // 
            // labelPlayer1Score
            // 
            this.labelPlayer1Score.AutoSize = true;
            this.labelPlayer1Score.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelPlayer1Score.ForeColor = System.Drawing.Color.Salmon;
            this.labelPlayer1Score.Location = new System.Drawing.Point(156, 111);
            this.labelPlayer1Score.Name = "labelPlayer1Score";
            this.labelPlayer1Score.Size = new System.Drawing.Size(74, 89);
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
            this.labelPlayer1Name.Size = new System.Drawing.Size(286, 89);
            this.labelPlayer1Name.TabIndex = 1;
            this.labelPlayer1Name.Text = "PLayer 1";
            // 
            // panelPlayer2
            // 
            this.panelPlayer2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelPlayer2.BackColor = System.Drawing.Color.RosyBrown;
            this.panelPlayer2.Controls.Add(this.panelPlayer2CurrentScore);
            this.panelPlayer2.Controls.Add(this.labelPlayer2Name);
            this.panelPlayer2.Controls.Add(this.labelPlayer2Score);
            this.panelPlayer2.Location = new System.Drawing.Point(389, 0);
            this.panelPlayer2.Name = "panelPlayer2";
            this.panelPlayer2.Size = new System.Drawing.Size(389, 466);
            this.panelPlayer2.TabIndex = 1;
            // 
            // panelPlayer2CurrentScore
            // 
            this.panelPlayer2CurrentScore.BackColor = System.Drawing.Color.Coral;
            this.panelPlayer2CurrentScore.Controls.Add(this.labelPlayer2CurrentScore);
            this.panelPlayer2CurrentScore.Controls.Add(this.label3);
            this.panelPlayer2CurrentScore.Location = new System.Drawing.Point(108, 320);
            this.panelPlayer2CurrentScore.Name = "panelPlayer2CurrentScore";
            this.panelPlayer2CurrentScore.Size = new System.Drawing.Size(209, 99);
            this.panelPlayer2CurrentScore.TabIndex = 6;
            // 
            // labelPlayer2CurrentScore
            // 
            this.labelPlayer2CurrentScore.AutoSize = true;
            this.labelPlayer2CurrentScore.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelPlayer2CurrentScore.Location = new System.Drawing.Point(91, 53);
            this.labelPlayer2CurrentScore.Name = "labelPlayer2CurrentScore";
            this.labelPlayer2CurrentScore.Size = new System.Drawing.Size(54, 62);
            this.labelPlayer2CurrentScore.TabIndex = 1;
            this.labelPlayer2CurrentScore.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(73, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 54);
            this.label3.TabIndex = 0;
            this.label3.Text = "Current";
            // 
            // labelPlayer2Name
            // 
            this.labelPlayer2Name.AutoSize = true;
            this.labelPlayer2Name.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelPlayer2Name.ForeColor = System.Drawing.Color.Black;
            this.labelPlayer2Name.Location = new System.Drawing.Point(150, 52);
            this.labelPlayer2Name.Name = "labelPlayer2Name";
            this.labelPlayer2Name.Size = new System.Drawing.Size(286, 89);
            this.labelPlayer2Name.TabIndex = 4;
            this.labelPlayer2Name.Text = "PLayer 2";
            // 
            // labelPlayer2Score
            // 
            this.labelPlayer2Score.AutoSize = true;
            this.labelPlayer2Score.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelPlayer2Score.ForeColor = System.Drawing.Color.Red;
            this.labelPlayer2Score.Location = new System.Drawing.Point(190, 111);
            this.labelPlayer2Score.Name = "labelPlayer2Score";
            this.labelPlayer2Score.Size = new System.Drawing.Size(74, 89);
            this.labelPlayer2Score.TabIndex = 5;
            this.labelPlayer2Score.Text = "0";
            // 
            // RollADiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(22F, 54F);
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelPlayer1.ResumeLayout(false);
            this.panelPlayer1.PerformLayout();
            this.panelPlayer1CurrentScore.ResumeLayout(false);
            this.panelPlayer1CurrentScore.PerformLayout();
            this.panelPlayer2.ResumeLayout(false);
            this.panelPlayer2.PerformLayout();
            this.panelPlayer2CurrentScore.ResumeLayout(false);
            this.panelPlayer2CurrentScore.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelGame;
        private Panel panelPlayer1;
        private Label labelPlayer1Name;
        private Panel panelPlayer2;
        private Panel panelPlayer1CurrentScore;
        private Label labelPlayer1CurrentScore;
        private Label label1;
        private Label labelPlayer1Score;
        private Button button1;
        private Panel panelPlayer2CurrentScore;
        private Label labelPlayer2CurrentScore;
        private Label label3;
        private Label labelPlayer2Name;
        private Label labelPlayer2Score;
        private Button button2;
        private PictureBox pictureBox1;
    }
}