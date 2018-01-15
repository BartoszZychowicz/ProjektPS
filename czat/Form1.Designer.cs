namespace czat
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
            this.ServerIPtextBox = new System.Windows.Forms.TextBox();
            this.ServerPorttextBox = new System.Windows.Forms.TextBox();
            this.ClientIPtextBox = new System.Windows.Forms.TextBox();
            this.ClientPorttextBox = new System.Windows.Forms.TextBox();
            this.ChatScreentextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Connectbutton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Startbutton = new System.Windows.Forms.Button();
            this.PORT = new System.Windows.Forms.Label();
            this.IP = new System.Windows.Forms.Label();
            this.Sendbutton = new System.Windows.Forms.Button();
            this.MessegetextBox = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ServerIPtextBox
            // 
            this.ServerIPtextBox.Location = new System.Drawing.Point(63, 34);
            this.ServerIPtextBox.Name = "ServerIPtextBox";
            this.ServerIPtextBox.Size = new System.Drawing.Size(122, 20);
            this.ServerIPtextBox.TabIndex = 0;
            this.ServerIPtextBox.TextChanged += new System.EventHandler(this.ServerIPtextBox_TextChanged);
            // 
            // ServerPorttextBox
            // 
            this.ServerPorttextBox.Location = new System.Drawing.Point(318, 34);
            this.ServerPorttextBox.Name = "ServerPorttextBox";
            this.ServerPorttextBox.Size = new System.Drawing.Size(136, 20);
            this.ServerPorttextBox.TabIndex = 1;
            // 
            // ClientIPtextBox
            // 
            this.ClientIPtextBox.Location = new System.Drawing.Point(64, 32);
            this.ClientIPtextBox.Name = "ClientIPtextBox";
            this.ClientIPtextBox.Size = new System.Drawing.Size(121, 20);
            this.ClientIPtextBox.TabIndex = 2;
            // 
            // ClientPorttextBox
            // 
            this.ClientPorttextBox.Location = new System.Drawing.Point(314, 32);
            this.ClientPorttextBox.Name = "ClientPorttextBox";
            this.ClientPorttextBox.Size = new System.Drawing.Size(136, 20);
            this.ClientPorttextBox.TabIndex = 3;
            // 
            // ChatScreentextBox
            // 
            this.ChatScreentextBox.Location = new System.Drawing.Point(31, 205);
            this.ChatScreentextBox.Multiline = true;
            this.ChatScreentextBox.Name = "ChatScreentextBox";
            this.ChatScreentextBox.Size = new System.Drawing.Size(613, 168);
            this.ChatScreentextBox.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Connectbutton);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ClientPorttextBox);
            this.groupBox1.Controls.Add(this.ClientIPtextBox);
            this.groupBox1.Location = new System.Drawing.Point(31, 112);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(613, 70);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CLIENT";
            // 
            // Connectbutton
            // 
            this.Connectbutton.Location = new System.Drawing.Point(516, 30);
            this.Connectbutton.Name = "Connectbutton";
            this.Connectbutton.Size = new System.Drawing.Size(75, 23);
            this.Connectbutton.TabIndex = 6;
            this.Connectbutton.Text = "CONNECT";
            this.Connectbutton.UseVisualStyleBackColor = true;
            this.Connectbutton.Click += new System.EventHandler(this.Connectbutton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(272, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "PORT";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "IP";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Startbutton);
            this.groupBox2.Controls.Add(this.PORT);
            this.groupBox2.Controls.Add(this.IP);
            this.groupBox2.Controls.Add(this.ServerPorttextBox);
            this.groupBox2.Controls.Add(this.ServerIPtextBox);
            this.groupBox2.Location = new System.Drawing.Point(31, 26);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(613, 75);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "SERVER";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // Startbutton
            // 
            this.Startbutton.Location = new System.Drawing.Point(515, 37);
            this.Startbutton.Name = "Startbutton";
            this.Startbutton.Size = new System.Drawing.Size(75, 23);
            this.Startbutton.TabIndex = 4;
            this.Startbutton.Text = "START";
            this.Startbutton.UseVisualStyleBackColor = true;
            this.Startbutton.Click += new System.EventHandler(this.Startbutton_Click);
            // 
            // PORT
            // 
            this.PORT.AutoSize = true;
            this.PORT.Location = new System.Drawing.Point(274, 36);
            this.PORT.Name = "PORT";
            this.PORT.Size = new System.Drawing.Size(37, 13);
            this.PORT.TabIndex = 3;
            this.PORT.Text = "PORT";
            // 
            // IP
            // 
            this.IP.AutoSize = true;
            this.IP.Location = new System.Drawing.Point(28, 30);
            this.IP.Name = "IP";
            this.IP.Size = new System.Drawing.Size(17, 13);
            this.IP.TabIndex = 2;
            this.IP.Text = "IP";
            // 
            // Sendbutton
            // 
            this.Sendbutton.Location = new System.Drawing.Point(597, 411);
            this.Sendbutton.Name = "Sendbutton";
            this.Sendbutton.Size = new System.Drawing.Size(75, 23);
            this.Sendbutton.TabIndex = 7;
            this.Sendbutton.Text = "SEND";
            this.Sendbutton.UseVisualStyleBackColor = true;
            this.Sendbutton.Click += new System.EventHandler(this.Sendbutton_Click);
            // 
            // MessegetextBox
            // 
            this.MessegetextBox.Location = new System.Drawing.Point(32, 412);
            this.MessegetextBox.Name = "MessegetextBox";
            this.MessegetextBox.Size = new System.Drawing.Size(552, 20);
            this.MessegetextBox.TabIndex = 8;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 465);
            this.Controls.Add(this.MessegetextBox);
            this.Controls.Add(this.Sendbutton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ChatScreentextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ServerIPtextBox;
        private System.Windows.Forms.TextBox ServerPorttextBox;
        private System.Windows.Forms.TextBox ClientIPtextBox;
        private System.Windows.Forms.TextBox ClientPorttextBox;
        private System.Windows.Forms.TextBox ChatScreentextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button Connectbutton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Startbutton;
        private System.Windows.Forms.Label PORT;
        private System.Windows.Forms.Label IP;
        private System.Windows.Forms.Button Sendbutton;
        private System.Windows.Forms.TextBox MessegetextBox;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
    }
}

