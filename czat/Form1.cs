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

namespace projekt
{

    public partial class Form1 : Form
    {

        private TcpClient client;
        public StreamReader STR;
        public StreamWriter STW;
        public string recieve;
        public string TextToSend;
        public int playerNumber;
        public int opponentNumber;
        List<Image> listOfPicture;
        private bool gameStarted = false;
        public Form1()
        {
            InitializeComponent();
            radioButton1.Checked = true;
            }

        private void loadListOfPicture()
        {
            card1.Visible = true;
            
            listOfPicture = new List<Image>();
            listOfPicture.Add(projekt.Properties.Resources.w1);
            listOfPicture.Add(projekt.Properties.Resources.w2);

        }
        private bool isSystemMsg(string msg)        //sprawdza czy wiadomosc jest systemowa czy pochodzi z czatu
        {
            if (msg.Substring(0, 1) == "S")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private string truncateFirstSign(string msg)    //usuniecie pierwszego znaku
        {
            return msg.Substring(1, msg.Length - 1);
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void sendChatMsg(string msg)        //wyslanie wiadomosci na chat
        {
            TextToSend = string.Concat("C", msg);
            backgroundWorker2.RunWorkerAsync();
        }

        private void sendSystemMsg(string msg)      //wyslanie wiadomosci systemowej
        {
            TextToSend = string.Concat("S", msg);
            backgroundWorker2.RunWorkerAsync();
        }

        private void interpretSystemMsg(string msg)
        {
            if (msg.Substring(0,3) == "RDY")        //wiadomosc dotyczy gotowosci do rozpoczecia gry
            {
                if(Int32.Parse(msg.Substring(3, 1))  == opponentNumber)
                {
                    this.opponentReadyBox.Invoke(new MethodInvoker(delegate
                    {
                        opponentReadyBox.Checked = true;
                        if (playerReadyBox.Checked && opponentReadyBox.Checked) //jesli oboje gotowi
                        {
                            MessageBox.Show("Czas rozpocząć walkę"); 
                            loadListOfPicture();
                            card1.Image = listOfPicture[0];             //pokaz karte id=0
                            card1.Image.Tag = "0";
                        }
                    }));
                    
                }
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)     //backgroundworker1 odpowiada za odbieranie w tle
        {
            while(client.Connected)
            {
                try
                {
                    recieve = STR.ReadLine();
                    if (!(isSystemMsg(recieve))) { //jezeli komenda nie jest systemowa, wyswietla ja na czacie
                        this.ChatScreentextBox.Invoke(new MethodInvoker(delegate ()
                        {
                            ChatScreentextBox.AppendText("Przeciwnik: " + truncateFirstSign(recieve) + "\n");
                        }));
                    }
                    else
                    {
                        interpretSystemMsg(truncateFirstSign(recieve));
                    }
                    recieve = "";
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void Startbutton_Click(object sender, EventArgs e)      //przycisk rozpoczecia polaczenia
        {
            if (radioButton1.Checked && !(radioButton2.Checked))    //jezeli wybrano serwer
            {
                TcpListener listener = new TcpListener(IPAddress.Any, int.Parse(PorttextBox.Text));
                listener.Start();  
                ChatScreentextBox.AppendText("Server is up and running!" + "\n");
                client = listener.AcceptTcpClient();                // blokuje program do uzyskania polaczenia, moze warto by to zmienic/robic to w tle?  
                ChatScreentextBox.AppendText("Client " + ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString() + " just connected!" + "\n");
                playerNumber = 1;       //gracz serwer ma numer 1
                opponentNumber = 2;
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
                        playerNumber = 2;
                        opponentNumber = 1;
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

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)     //backgroundworker2 odpowiada za wysyłanie w tle
        {
            if (client.Connected)
            {
                STW.WriteLine(TextToSend);
                if (!isSystemMsg(TextToSend))   //jesli nie jest wiadomoscia systemowa, pokaz na czacie
                {
                    this.ChatScreentextBox.Invoke(new MethodInvoker(delegate
                    {
                        ChatScreentextBox.AppendText("Ja: " + truncateFirstSign(TextToSend) + "\n");
                    }));
                }
            }
            else
            {
                MessageBox.Show("Sending failed");

            }
            backgroundWorker2.CancelAsync();
        }

        private void Sendbutton_Click(object sender, EventArgs e)
        {
            if(MessagetextBox.Text != "")
            {
                sendChatMsg(MessagetextBox.Text);
            }
            MessagetextBox.Text = "";
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

        private void playerReadyButton_Click(object sender, EventArgs e)
        {
            playerReadyBox.Checked = true;
            sendSystemMsg("RDY" + playerNumber);

            if (playerReadyBox.Checked && opponentReadyBox.Checked)
            {
                MessageBox.Show("Czas rozpocząć walkę");
                loadListOfPicture();

                card1.Image = listOfPicture[1];
                card1.Image.Tag = "1";
                
            }
        }

        private void opponentReadyBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void opponentReadyBox_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void card1_Click(object sender, EventArgs e)
        {
            textBox1.Visible = true;
            textBox1.Text = "Numer karty:"+ card1.Image.Tag.ToString();
            
        }
    }
}
