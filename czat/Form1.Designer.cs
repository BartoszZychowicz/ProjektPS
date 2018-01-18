namespace projekt
{
    partial class Form1
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
            this.IPtextBox = new System.Windows.Forms.TextBox();
            this.PorttextBox = new System.Windows.Forms.TextBox();
            this.ChatScreentextBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.Startbutton = new System.Windows.Forms.Button();
            this.PORT = new System.Windows.Forms.Label();
            this.IP = new System.Windows.Forms.Label();
            this.Sendbutton = new System.Windows.Forms.Button();
            this.MessagetextBox = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.playerReadyButton = new System.Windows.Forms.Button();
            this.opponentReadyBox = new System.Windows.Forms.CheckBox();
            this.playerReadyBox = new System.Windows.Forms.CheckBox();
            this.card1 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.card2 = new System.Windows.Forms.PictureBox();
            this.card3 = new System.Windows.Forms.PictureBox();
            this.groupBox4_Hand = new System.Windows.Forms.GroupBox();
            this.OpponentUsedCard = new System.Windows.Forms.PictureBox();
            this.ProgressBarOpponentHp = new System.Windows.Forms.ProgressBar();
            this.ProgressBarPlayerHp = new System.Windows.Forms.ProgressBar();
            this.playerUsedCard = new System.Windows.Forms.PictureBox();
            this.groupBox3_Game = new System.Windows.Forms.GroupBox();
            this.label_NumberRound = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.card1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.card2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.card3)).BeginInit();
            this.groupBox4_Hand.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OpponentUsedCard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerUsedCard)).BeginInit();
            this.groupBox3_Game.SuspendLayout();
            this.SuspendLayout();
            // 
            // IPtextBox
            // 
            this.IPtextBox.Location = new System.Drawing.Point(655, 16);
            this.IPtextBox.Name = "IPtextBox";
            this.IPtextBox.Size = new System.Drawing.Size(122, 20);
            this.IPtextBox.TabIndex = 0;
            this.IPtextBox.TextChanged += new System.EventHandler(this.ServerIPtextBox_TextChanged);
            // 
            // PorttextBox
            // 
            this.PorttextBox.Location = new System.Drawing.Point(852, 17);
            this.PorttextBox.Name = "PorttextBox";
            this.PorttextBox.Size = new System.Drawing.Size(136, 20);
            this.PorttextBox.TabIndex = 1;
            this.PorttextBox.TextChanged += new System.EventHandler(this.ServerPorttextBox_TextChanged);
            // 
            // ChatScreentextBox
            // 
            this.ChatScreentextBox.Location = new System.Drawing.Point(6, 19);
            this.ChatScreentextBox.Multiline = true;
            this.ChatScreentextBox.Name = "ChatScreentextBox";
            this.ChatScreentextBox.Size = new System.Drawing.Size(219, 441);
            this.ChatScreentextBox.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Controls.Add(this.Startbutton);
            this.groupBox2.Controls.Add(this.PORT);
            this.groupBox2.Controls.Add(this.IP);
            this.groupBox2.Controls.Add(this.PorttextBox);
            this.groupBox2.Controls.Add(this.IPtextBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1100, 59);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Połączenie";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(137, 36);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(51, 17);
            this.radioButton2.TabIndex = 6;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Klient";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(137, 13);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(58, 17);
            this.radioButton1.TabIndex = 5;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Serwer";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // Startbutton
            // 
            this.Startbutton.Location = new System.Drawing.Point(1004, 17);
            this.Startbutton.Name = "Startbutton";
            this.Startbutton.Size = new System.Drawing.Size(75, 23);
            this.Startbutton.TabIndex = 4;
            this.Startbutton.Text = "Utwórz";
            this.Startbutton.UseVisualStyleBackColor = true;
            this.Startbutton.Click += new System.EventHandler(this.Startbutton_Click);
            // 
            // PORT
            // 
            this.PORT.AutoSize = true;
            this.PORT.Location = new System.Drawing.Point(800, 19);
            this.PORT.Name = "PORT";
            this.PORT.Size = new System.Drawing.Size(37, 13);
            this.PORT.TabIndex = 3;
            this.PORT.Text = "PORT";
            // 
            // IP
            // 
            this.IP.AutoSize = true;
            this.IP.Location = new System.Drawing.Point(621, 19);
            this.IP.Name = "IP";
            this.IP.Size = new System.Drawing.Size(17, 13);
            this.IP.TabIndex = 2;
            this.IP.Text = "IP";
            // 
            // Sendbutton
            // 
            this.Sendbutton.Location = new System.Drawing.Point(150, 510);
            this.Sendbutton.Name = "Sendbutton";
            this.Sendbutton.Size = new System.Drawing.Size(75, 23);
            this.Sendbutton.TabIndex = 7;
            this.Sendbutton.Text = "SEND";
            this.Sendbutton.UseVisualStyleBackColor = true;
            this.Sendbutton.Click += new System.EventHandler(this.Sendbutton_Click);
            // 
            // MessagetextBox
            // 
            this.MessagetextBox.Location = new System.Drawing.Point(6, 484);
            this.MessagetextBox.Name = "MessagetextBox";
            this.MessagetextBox.Size = new System.Drawing.Size(219, 20);
            this.MessagetextBox.TabIndex = 8;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Sendbutton);
            this.groupBox1.Controls.Add(this.MessagetextBox);
            this.groupBox1.Controls.Add(this.ChatScreentextBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 77);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(240, 539);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Czat";
            // 
            // playerReadyButton
            // 
            this.playerReadyButton.Location = new System.Drawing.Point(980, 561);
            this.playerReadyButton.Name = "playerReadyButton";
            this.playerReadyButton.Size = new System.Drawing.Size(111, 41);
            this.playerReadyButton.TabIndex = 10;
            this.playerReadyButton.Text = "gotowy!";
            this.playerReadyButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.playerReadyButton.UseVisualStyleBackColor = true;
            this.playerReadyButton.Click += new System.EventHandler(this.playerReadyButton_Click);
            // 
            // opponentReadyBox
            // 
            this.opponentReadyBox.AutoSize = true;
            this.opponentReadyBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.opponentReadyBox.Enabled = false;
            this.opponentReadyBox.Location = new System.Drawing.Point(980, 538);
            this.opponentReadyBox.Name = "opponentReadyBox";
            this.opponentReadyBox.Size = new System.Drawing.Size(77, 17);
            this.opponentReadyBox.TabIndex = 11;
            this.opponentReadyBox.Text = "Przeciwnik";
            this.opponentReadyBox.UseVisualStyleBackColor = true;
            this.opponentReadyBox.CheckedChanged += new System.EventHandler(this.opponentReadyBox_CheckedChanged_1);
            // 
            // playerReadyBox
            // 
            this.playerReadyBox.AutoSize = true;
            this.playerReadyBox.Enabled = false;
            this.playerReadyBox.Location = new System.Drawing.Point(980, 515);
            this.playerReadyBox.Name = "playerReadyBox";
            this.playerReadyBox.Size = new System.Drawing.Size(37, 17);
            this.playerReadyBox.TabIndex = 12;
            this.playerReadyBox.Text = "Ja";
            this.playerReadyBox.UseVisualStyleBackColor = true;
            // 
            // card1
            // 
            this.card1.Location = new System.Drawing.Point(94, 8);
            this.card1.Name = "card1";
            this.card1.Size = new System.Drawing.Size(124, 168);
            this.card1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.card1.TabIndex = 15;
            this.card1.TabStop = false;
            this.card1.Click += new System.EventHandler(this.card1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(60, 20);
            this.textBox1.TabIndex = 16;
            this.textBox1.Visible = false;
            // 
            // card2
            // 
            this.card2.Location = new System.Drawing.Point(291, 7);
            this.card2.Name = "card2";
            this.card2.Size = new System.Drawing.Size(124, 168);
            this.card2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.card2.TabIndex = 17;
            this.card2.TabStop = false;
            // 
            // card3
            // 
            this.card3.Location = new System.Drawing.Point(491, 7);
            this.card3.Name = "card3";
            this.card3.Size = new System.Drawing.Size(124, 168);
            this.card3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.card3.TabIndex = 18;
            this.card3.TabStop = false;
            // 
            // groupBox4_Hand
            // 
            this.groupBox4_Hand.Controls.Add(this.card1);
            this.groupBox4_Hand.Controls.Add(this.card2);
            this.groupBox4_Hand.Controls.Add(this.card3);
            this.groupBox4_Hand.Controls.Add(this.textBox1);
            this.groupBox4_Hand.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.groupBox4_Hand.Location = new System.Drawing.Point(270, 421);
            this.groupBox4_Hand.Name = "groupBox4_Hand";
            this.groupBox4_Hand.Size = new System.Drawing.Size(704, 181);
            this.groupBox4_Hand.TabIndex = 24;
            this.groupBox4_Hand.TabStop = false;
            this.groupBox4_Hand.Text = "Hand";
            this.groupBox4_Hand.Visible = false;
            // 
            // OpponentUsedCard
            // 
            this.OpponentUsedCard.Location = new System.Drawing.Point(651, 91);
            this.OpponentUsedCard.Name = "OpponentUsedCard";
            this.OpponentUsedCard.Size = new System.Drawing.Size(124, 168);
            this.OpponentUsedCard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.OpponentUsedCard.TabIndex = 20;
            this.OpponentUsedCard.TabStop = false;
            // 
            // ProgressBarOpponentHp
            // 
            this.ProgressBarOpponentHp.ForeColor = System.Drawing.Color.Crimson;
            this.ProgressBarOpponentHp.Location = new System.Drawing.Point(451, 28);
            this.ProgressBarOpponentHp.Maximum = 6;
            this.ProgressBarOpponentHp.Name = "ProgressBarOpponentHp";
            this.ProgressBarOpponentHp.Size = new System.Drawing.Size(164, 23);
            this.ProgressBarOpponentHp.TabIndex = 22;
            this.ProgressBarOpponentHp.Value = 5;
            // 
            // ProgressBarPlayerHp
            // 
            this.ProgressBarPlayerHp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ProgressBarPlayerHp.Location = new System.Drawing.Point(181, 28);
            this.ProgressBarPlayerHp.Maximum = 6;
            this.ProgressBarPlayerHp.Name = "ProgressBarPlayerHp";
            this.ProgressBarPlayerHp.Size = new System.Drawing.Size(164, 23);
            this.ProgressBarPlayerHp.TabIndex = 21;
            this.ProgressBarPlayerHp.Value = 3;
            // 
            // playerUsedCard
            // 
            this.playerUsedCard.Location = new System.Drawing.Point(18, 91);
            this.playerUsedCard.Name = "playerUsedCard";
            this.playerUsedCard.Size = new System.Drawing.Size(124, 168);
            this.playerUsedCard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.playerUsedCard.TabIndex = 19;
            this.playerUsedCard.TabStop = false;
            // 
            // groupBox3_Game
            // 
            this.groupBox3_Game.Controls.Add(this.label_NumberRound);
            this.groupBox3_Game.Controls.Add(this.playerUsedCard);
            this.groupBox3_Game.Controls.Add(this.ProgressBarPlayerHp);
            this.groupBox3_Game.Controls.Add(this.ProgressBarOpponentHp);
            this.groupBox3_Game.Controls.Add(this.OpponentUsedCard);
            this.groupBox3_Game.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.groupBox3_Game.Location = new System.Drawing.Point(270, 77);
            this.groupBox3_Game.Name = "groupBox3_Game";
            this.groupBox3_Game.Size = new System.Drawing.Size(795, 338);
            this.groupBox3_Game.TabIndex = 23;
            this.groupBox3_Game.TabStop = false;
            this.groupBox3_Game.Text = "Game";
            // 
            // label_NumberRound
            // 
            this.label_NumberRound.AutoSize = true;
            this.label_NumberRound.Location = new System.Drawing.Point(654, 30);
            this.label_NumberRound.Name = "label_NumberRound";
            this.label_NumberRound.Size = new System.Drawing.Size(135, 13);
            this.label_NumberRound.TabIndex = 23;
            this.label_NumberRound.Text = "To end game left: 10 round";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1124, 628);
            this.Controls.Add(this.groupBox4_Hand);
            this.Controls.Add(this.playerReadyBox);
            this.Controls.Add(this.opponentReadyBox);
            this.Controls.Add(this.playerReadyButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3_Game);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.card1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.card2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.card3)).EndInit();
            this.groupBox4_Hand.ResumeLayout(false);
            this.groupBox4_Hand.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OpponentUsedCard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerUsedCard)).EndInit();
            this.groupBox3_Game.ResumeLayout(false);
            this.groupBox3_Game.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox IPtextBox;
        private System.Windows.Forms.TextBox PorttextBox;
        private System.Windows.Forms.TextBox ChatScreentextBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button Startbutton;
        private System.Windows.Forms.Label PORT;
        private System.Windows.Forms.Label IP;
        private System.Windows.Forms.Button Sendbutton;
        private System.Windows.Forms.TextBox MessagetextBox;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button playerReadyButton;
        private System.Windows.Forms.CheckBox opponentReadyBox;
        private System.Windows.Forms.CheckBox playerReadyBox;
        private System.Windows.Forms.PictureBox card1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox card2;
        private System.Windows.Forms.PictureBox card3;
        private System.Windows.Forms.GroupBox groupBox4_Hand;
        private System.Windows.Forms.PictureBox OpponentUsedCard;
        private System.Windows.Forms.ProgressBar ProgressBarOpponentHp;
        private System.Windows.Forms.ProgressBar ProgressBarPlayerHp;
        private System.Windows.Forms.PictureBox playerUsedCard;
        private System.Windows.Forms.GroupBox groupBox3_Game;
        private System.Windows.Forms.Label label_NumberRound;
    }
}

