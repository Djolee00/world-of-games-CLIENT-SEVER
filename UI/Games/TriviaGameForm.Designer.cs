namespace UI.Games
{
    partial class TriviaGameForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TriviaGameForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelQuestion = new System.Windows.Forms.Label();
            this.btnA = new System.Windows.Forms.Button();
            this.btnB = new System.Windows.Forms.Button();
            this.btnC = new System.Windows.Forms.Button();
            this.btnD = new System.Windows.Forms.Button();
            this.pnlWaiting = new System.Windows.Forms.Panel();
            this.lblText = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.pnlWaiting.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelQuestion);
            this.panel1.Location = new System.Drawing.Point(110, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(622, 229);
            this.panel1.TabIndex = 0;
            // 
            // labelQuestion
            // 
            this.labelQuestion.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelQuestion.Location = new System.Drawing.Point(32, 19);
            this.labelQuestion.Name = "labelQuestion";
            this.labelQuestion.Size = new System.Drawing.Size(558, 192);
            this.labelQuestion.TabIndex = 0;
            this.labelQuestion.Text = "Trivia question";
            this.labelQuestion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnA
            // 
            this.btnA.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnA.BackColor = System.Drawing.Color.Transparent;
            this.btnA.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnA.FlatAppearance.BorderSize = 2;
            this.btnA.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(192)))), ((int)(((byte)(193)))));
            this.btnA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnA.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnA.ForeColor = System.Drawing.Color.White;
            this.btnA.Location = new System.Drawing.Point(110, 325);
            this.btnA.Name = "btnA";
            this.btnA.Size = new System.Drawing.Size(240, 68);
            this.btnA.TabIndex = 9;
            this.btnA.Text = "Answer A";
            this.btnA.UseVisualStyleBackColor = false;
            this.btnA.Click += new System.EventHandler(this.btnA_Click);
            // 
            // btnB
            // 
            this.btnB.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnB.BackColor = System.Drawing.Color.Transparent;
            this.btnB.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnB.FlatAppearance.BorderSize = 2;
            this.btnB.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(192)))), ((int)(((byte)(193)))));
            this.btnB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnB.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnB.ForeColor = System.Drawing.Color.White;
            this.btnB.Location = new System.Drawing.Point(492, 325);
            this.btnB.Name = "btnB";
            this.btnB.Size = new System.Drawing.Size(240, 68);
            this.btnB.TabIndex = 10;
            this.btnB.Text = "Answer B";
            this.btnB.UseVisualStyleBackColor = false;
            // 
            // btnC
            // 
            this.btnC.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnC.BackColor = System.Drawing.Color.Transparent;
            this.btnC.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnC.FlatAppearance.BorderSize = 2;
            this.btnC.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(192)))), ((int)(((byte)(193)))));
            this.btnC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnC.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnC.ForeColor = System.Drawing.Color.White;
            this.btnC.Location = new System.Drawing.Point(110, 414);
            this.btnC.Name = "btnC";
            this.btnC.Size = new System.Drawing.Size(240, 68);
            this.btnC.TabIndex = 11;
            this.btnC.Text = "Answer C";
            this.btnC.UseVisualStyleBackColor = false;
            // 
            // btnD
            // 
            this.btnD.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnD.BackColor = System.Drawing.Color.Transparent;
            this.btnD.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnD.FlatAppearance.BorderSize = 2;
            this.btnD.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(192)))), ((int)(((byte)(193)))));
            this.btnD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnD.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnD.ForeColor = System.Drawing.Color.White;
            this.btnD.Location = new System.Drawing.Point(492, 414);
            this.btnD.Name = "btnD";
            this.btnD.Size = new System.Drawing.Size(240, 68);
            this.btnD.TabIndex = 12;
            this.btnD.Text = "Answer D";
            this.btnD.UseVisualStyleBackColor = false;
            // 
            // pnlWaiting
            // 
            this.pnlWaiting.BackColor = System.Drawing.Color.White;
            this.pnlWaiting.Controls.Add(this.lblText);
            this.pnlWaiting.Location = new System.Drawing.Point(200, 144);
            this.pnlWaiting.Name = "pnlWaiting";
            this.pnlWaiting.Size = new System.Drawing.Size(447, 222);
            this.pnlWaiting.TabIndex = 1;
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblText.ForeColor = System.Drawing.Color.Black;
            this.lblText.Location = new System.Drawing.Point(62, 94);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(350, 41);
            this.lblText.TabIndex = 0;
            this.lblText.Text = "Waiting for opponent...";
            // 
            // TriviaGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(861, 515);
            this.ControlBox = false;
            this.Controls.Add(this.pnlWaiting);
            this.Controls.Add(this.btnD);
            this.Controls.Add(this.btnC);
            this.Controls.Add(this.btnB);
            this.Controls.Add(this.btnA);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TriviaGameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TriviaGameForm";
            this.panel1.ResumeLayout(false);
            this.pnlWaiting.ResumeLayout(false);
            this.pnlWaiting.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Button btnA;
        private Button btnB;
        private Button btnC;
        private Button btnD;
        private Label labelQuestion;
        private Panel pnlWaiting;
        private Label lblText;
    }
}