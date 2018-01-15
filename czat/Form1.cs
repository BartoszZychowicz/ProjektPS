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
            radioButton1.Checked = true;
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
                        ChatScreentextBox.AppendText("Przeciwnik:" + recieve + "\n");
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
            if (radioButton1.Checked && !(radioButton2.Checked))    //jezeli wybrano serwer
            {
                TcpListener listener = new TcpListener(IPAddress.Any, int.Parse(PorttextBox.Text));
                listener.Start();
                client = listener.AcceptTcpClient();
                ChatScreentextBox.AppendText("Client" + ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString() + " just connected!" + "\n");
                STR = new StreamReader(client.GetStream());
                STW = new StreamWriter(client.GetStream());
                STW.AutoFlush = true;
                backgroundWorker1.RunWorkerAsync();
                backgroundWorker2.WorkerSupportsCancellation = true;
            }
            else if (!(radioButton1.Checked) && radioButton2.Checked)       //jezeli wybrano klient
            {
                client = new TcpClient();
                IPEndPoint IpEnd = new IPEndPoint(IPAddress.Parse(IPtextBox.Text), int.Parse(PorttextBox.Text));
                try
                {
                    client.Connect(IpEnd);
                    if (client.Connected)
                    {
                        ChatScreentextBox.AppendText("Connected to Server " + IpEnd + "\n");
                        STR = new StreamReader(client.GetStream());
                        STW = new StreamWriter(client.GetStream());
                        STW.AutoFlush = true;
                        backgroundWorker1.RunWorkerAsync();
                        backgroundWorker2.WorkerSupportsCancellation = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            if (client.Connected)
            {
                STW.WriteLine(TextToSend);
                this.ChatScreentextBox.Invoke(new MethodInvoker(delegate
                {
                    ChatScreentextBox.AppendText("Ja:" + TextToSend + "\n");
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

        private void ServerPorttextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)   //podaj swoje IP, jesli jestes serwerem
            {
                IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());
                foreach (IPAddress address in localIP)
                {
                    if (address.AddressFamily == AddressFamily.InterNetwork)
                    {
                        IPtextBox.Text = address.ToString();
                    }
                }
                Startbutton.Text = "Utwórz";
            }
            else
            {
                IPtextBox.Text = String.Empty;
                Startbutton.Text = "Połącz";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            
        }
    }
}
