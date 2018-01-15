using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace czat
{
    public partial class Form1 : Form
    {

        private TcpClient client;
        public StreamReader STR;
        public StreamWriter STW;
        public string recieve;
        public string TextToSend;
        public Form1()
        {
            InitializeComponent();
            IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress address in localIP)
            {
                if(address.AddressFamily==AddressFamily.InterNetwork)
                {
                    ServerIPtextBox.Text = address.ToString();
                }
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while(client.Connected)
            {
                try
                {
                    recieve = STR.ReadLine();
                    this.ChatScreentextBox.Invoke(new MethodInvoker(delegate ()
                    {
                        ChatScreentextBox.AppendText("You:" + recieve + "\n");
                    }));
                    recieve = "";
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void Startbutton_Click(object sender, EventArgs e)
        {
            TcpListener listener = new TcpListener(IPAddress.Any, int.Parse(ServerPorttextBox.Text));
            listener.Start();
            client = listener.AcceptTcpClient();
            STR = new StreamReader(client.GetStream());
            STW = new StreamWriter(client.GetStream());
            STW.AutoFlush = true;
            backgroundWorker1.RunWorkerAsync();
            backgroundWorker2.WorkerSupportsCancellation = true;
        }

        private void Connectbutton_Click(object sender, EventArgs e)
        {
            client = new TcpClient();
            IPEndPoint IpEnd = new IPEndPoint(IPAddress.Parse(ClientIPtextBox.Text), int.Parse(ClientPorttextBox.Text));
            try
            {
                client.Connect(IpEnd);
                if(client.Connected)
                {
                    ChatScreentextBox.AppendText("Connected to Server" + "\n");
                    STR = new StreamReader(client.GetStream());
                    STW = new StreamWriter(client.GetStream());
                    STW.AutoFlush = true;
                    backgroundWorker1.RunWorkerAsync();
                    backgroundWorker2.WorkerSupportsCancellation = true;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            if (client.Connected)
            {
                STW.WriteLine(TextToSend);
                this.ChatScreentextBox.Invoke(new MethodInvoker(delegate
                {
                    ChatScreentextBox.AppendText("Me:" + TextToSend + "\n");
                }));
            }
            else
            {
                MessageBox.Show("Sending failed");

            }
            backgroundWorker2.CancelAsync();
        }

        private void Sendbutton_Click(object sender, EventArgs e)
        {
            if(MessegetextBox.Text != "")
            {
                TextToSend = MessegetextBox.Text;
                backgroundWorker2.RunWorkerAsync();
                MessegetextBox.Text = "";
            }
        }

        private void ServerIPtextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
