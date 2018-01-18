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
        public int RoundNumber = 10;
        List<Image> listOfPicture;
        public int[] ID = {0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16};
        public string[,] Card = {
            { "A1","D","0","0"},
            { "D","0","A1","0"},
            {"0","A1","D","0" },
            {"A1","A1","0","0" },
            {"0","A1","A1","0" },
            {"0","A2","0","0" },
            {"A2","0","0","0" },
            {"0","0","A2","0" },
            {"D","D","0","0" },
            {"0","D","D","0" },
            {"D","D","D","0" },
            {"0","A4","0","-1" },
            {"A1","A1","A1","-1" },
            {"D","0","0","+1" },
            {"0","D","0","+1" },
            {"0","0","D","+1" }
        };
        private bool gameStarted = false;

        public Form1()
        {
            InitializeComponent();
            radioButton1.Checked = true;
           
        }

        private void ShowGame()
        {
            groupBox3_Game.Visible = true;
            groupBox4_Hand.Visible = true;
            groupBoxConnection.Visible = false;
            playerUsedCard.Image = projekt.Properties.Resources.rewers;
            OpponentUsedCard.Image = projekt.Properties.Resources.rewers;

           // Application.VisualStyleState = System.Windows.Forms.VisualStyles.VisualStyleState.NoneEnabled;

        }

        private void updateRound()
        {
            if (RoundNumber > 1)
            {
                RoundNumber = RoundNumber - 1;
                label_NumberRound.Text = "To end game left: " + RoundNumber + " round";
            }
            else
            {
                RoundNumber = RoundNumber - 1;
                label_NumberRound.Text = "This is last round";
            }

        }

        private void loadListOfPicture()
        {
            card1.Visible = true;
            
            listOfPicture = new List<Image>();
            listOfPicture.Add(projekt.Properties.Resources._1);
            listOfPicture.Add(projekt.Properties.Resources._2);
            listOfPicture.Add(projekt.Properties.Resources._3);
            listOfPicture.Add(projekt.Properties.Resources._4);
            listOfPicture.Add(projekt.Properties.Resources._5);
            listOfPicture.Add(projekt.Properties.Resources._6);
            listOfPicture.Add(projekt.Properties.Resources._7);
            listOfPicture.Add(projekt.Properties.Resources._8);
            listOfPicture.Add(projekt.Properties.Resources._9);
            listOfPicture.Add(projekt.Properties.Resources._10);
            listOfPicture.Add(projekt.Properties.Resources._11);
            listOfPicture.Add(projekt.Properties.Resources._12);
            listOfPicture.Add(projekt.Properties.Resources._13);
            listOfPicture.Add(projekt.Properties.Resources._14);
            listOfPicture.Add(projekt.Properties.Resources._15);
            listOfPicture.Add(projekt.Properties.Resources._16);
            


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
            if (!backgroundWorker2.IsBusy)
            {
                backgroundWorker2.RunWorkerAsync();
            }
            else
            {
                backgroundWorker3.RunWorkerAsync();
            }
        }

        private void sendSystemMsg(string msg)      //wyslanie wiadomosci systemowej
        {
            TextToSend = string.Concat("S", msg);
            if (!backgroundWorker2.IsBusy)
            {
                backgroundWorker2.RunWorkerAsync();
            }
            else
            {
                backgroundWorker3.RunWorkerAsync();
            }
            this.Invoke(new MethodInvoker(delegate
            {
                ChatScreentextBox.AppendText("SysSend:" + msg + "\n");  //tylko do debugowania
            }));
        }

        private void startGame()    //rozpoczecie gry
        {  // card1.Image = listOfPicture[0];             //pokaz karte id=0
           // card1.Image.Tag = "0";

            if (playerNumber == 1)       //tylko serwer wysyla komunikat game start
            {
                sendSystemMsg("GST");            //Game Start
            }
            this.Invoke(new MethodInvoker(delegate
            {
                playerReadyButton.Text = "Zagraj kartę";
                playerReadyButton.Enabled = false;
                groupBoxConnection.Enabled = false;
                playerReadyBox.Checked = false;
                opponentReadyBox.Checked = false;
                ChatScreentextBox.AppendText("System: Gra rozpoczęta!" + "\n");
            }));
            gameStarted = true;
            ShowGame();
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
                    }));
                    if (playerNumber == 1)  //serwer sprawdza czy obaj gracze są gotowi
                    {  
                        if (playerReadyBox.Checked && opponentReadyBox.Checked)
                        {
                            startGame();
                        }
                    }    
                }
            }

            if (msg.Substring(0, 3) == "GST")        //wiadomosc dotyczy polecenia rozpoczecia gry od serwera
            {
                if(playerNumber == 2)
                {
                    startGame();
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
                        this.Invoke(new MethodInvoker(delegate
                        {
                            ChatScreentextBox.AppendText("SysRcv:" + recieve + "\n");  //tylko do debugowania
                        }));
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
                backgroundWorker3.WorkerSupportsCancellation = true;
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
                        backgroundWorker3.WorkerSupportsCancellation = true;
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

        private void playerReadyButton_Click(object sender, EventArgs e)        //tu trzeba dodac obsluge konca tury 
        {
            playerReadyBox.Checked = true;  //zaznacz gotowosc gracza do rozpoczecia lub kolejnej tury
            if (!gameStarted)   //jezeli gra nierozpoczeta, wyslij komunikat o gotowosci
            {
                
                if (playerNumber == 1)  //serwer sprawdza czy obaj gracze są gotowi
                {
                    if (playerReadyBox.Checked && opponentReadyBox.Checked) //jezeli obaj gotowi, zacznij gre
                    {
                        startGame();
                    }
                    else    //jezeli przeciwnik niegotowy, wyslij mu komunikat o swojej gotowosci
                    {
                        sendSystemMsg("RDY" + playerNumber);
                    }
                }
                else    //klient jedynie zglasza swoja gotowosc i czeka na odpowiedz serwera
                {
                    sendSystemMsg("RDY" + playerNumber);
                }
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
            choosecard1.BackColor = Color.DarkGray;
            choosecard2.BackColor = Color.Transparent;
            choosecard3.BackColor = Color.Transparent;
            // textBox1.Visible = true;
            //textBox1.Text = "Numer karty:"+ card1.Image.Tag.ToString();

        }

        private void card2_Click(object sender, EventArgs e)
        {
            choosecard1.BackColor = Color.Transparent;
            choosecard2.BackColor = Color.DarkGray;
            choosecard3.BackColor = Color.Transparent;
        }

        private void card3_Click(object sender, EventArgs e)
        {
            choosecard1.BackColor = Color.Transparent;
            choosecard2.BackColor = Color.Transparent;
            choosecard3.BackColor = Color.DarkGray;
        }

        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)         //dodatkowy proces wysylanie w tle gdyby pierwszy byl zajety
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
            backgroundWorker3.CancelAsync();
        }
    }
}
