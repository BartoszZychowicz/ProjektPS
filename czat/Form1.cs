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
        public int idPlayerCard = -1;       //na poczatku gry zadne karty nie byly jeszcze wybrane, stan neutralny to id = -1
        public int idOpponentCard = -1;       
        public int TurnLeft = 10;
        public int RoundNumber = 1;
        static public int maxHp = 8;           //startowe i maksymalne zycie graczy
        public int playerLife = maxHp;
        public int opponentLife = maxHp;
        public bool debugModeOn = false;
        List<Image> listOfPicture;
        public int[] ID = {0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15};
        public int[] playerDeck = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
        //public int[] opponentDeck = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
        public string[,] Card = {       //lista kart w talii
            { "A1","D","0","0"},        // id 0
            { "D","0","A1","0"},        // 1
            {"0","A1","D","0" },        // 2
            {"A1","A1","0","0" },       // 3
            {"0","A1","A1","0" },       // 4
            {"0","A2","0","0" },        // 5 
            {"A2","0","0","0" },        // 6
            {"0","0","A2","0" },        // 7
            {"D","D","0","0" },         // 8
            {"0","D","D","0" },         // 9
            {"D","D","D","0" },         // 10
            {"0","A4","0","-1" },       // 11
            {"A1","A1","A1","-1" },     // 12
            {"D","0","0","+1" },        // 13
            {"0","D","0","+1" },        // 14
            {"0","0","D","+1" }         // 15
        };
        private bool gameStarted = false;

/// <summary>
/// //////////////////////////////////////////////////////////Funkcje////////////////////////////////////////////////////////
/// </summary>
        public Form1()
        {
            InitializeComponent();
            radioButton1.Checked = true;
            playerDeck = shuffle(ID);
            loadListOfPicture();
            loadHand(playerDeck);
            startingHp();
        }

        private void startingHp()
        {
            playerLifeLabel.Text = maxHp.ToString();
            opponentLifeLabel.Text = maxHp.ToString();
            ProgressBarPlayerHp.Maximum = maxHp;
            ProgressBarPlayerHp.Value = maxHp;
            ProgressBarOpponentHp.Maximum = maxHp;
            ProgressBarOpponentHp.Value = maxHp;   
        }

        private string CheckEndGameCondition()    //sprawdzenie warunku zakonczenia gry
        {  
                if(playerLife == 0 && opponentLife == 0)
                {
                    return "DR";    //DRaw
                }
                else if (opponentLife == 0 && playerLife != 0)
                {
                    return "SW";    //Server Wins
                }
                else if(playerLife == 0 && opponentLife != 0)
                {
                    return "CW";    //Client wins
                }
                if(TurnLeft == -1 && (playerLife > opponentLife))
                {
                    return "SW";
                }
                else if(TurnLeft == -1 && (playerLife < opponentLife))
                {
                    return "CW";
                }
                else if (TurnLeft == -1 && (playerLife == opponentLife))
                {
                    return "DR";
                }
            else
            {
                return "00";    //gra trwa dalej
            }
        }

        private void endGame(string result)
        {
            this.Invoke(new MethodInvoker(delegate
            {
                card1.Enabled = false;
                card2.Enabled = false;
                card3.Enabled = false;
                playerReadyButton.Enabled = false;
                GameResultLabel.Visible = true;
           
            
            if (result == "SW")
            {
                if(playerNumber == 1)
                {
                    GameResultLabel.Text = "Koniec gry. Wygrałeś!";
                }
                else
                {
                    GameResultLabel.Text = "Koniec gry. Przegrałeś!";
                }
            }
            if (result == "CW")
            {
                if (playerNumber == 2)
                {
                    GameResultLabel.Text = "Koniec gry. Wygrałeś!";
                }
                else
                {
                    GameResultLabel.Text = "Koniec gry. Przegrałeś!";
                }
            }
            if (result == "DR")
            {            
                    GameResultLabel.Text = "Koniec gry. Remis!";           
            }
            }));
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
            if (TurnLeft > 1)       //licznik wyswietlany graczom
            {
                TurnLeft = TurnLeft - 1;
                label_NumberRound.Text = TurnLeft + " turns left";
            }
            else
            {
                TurnLeft = TurnLeft - 1;
                label_NumberRound.Text = "Last round";
            }
            RoundNumber++;      //licznik na potrzeby wybierania nowych kart
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
            if (debugModeOn) { 
                this.Invoke(new MethodInvoker(delegate
                {
                    ChatScreentextBox.AppendText("SysSend:" + msg + "\n");  //tylko do debugowania
                }));
            }
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
                playerReadyButton.Text = "Play selected card";
                playerReadyButton.Enabled = false;
                groupBoxConnection.Enabled = false;
                playerReadyBox.Checked = false;
                opponentReadyBox.Checked = false;
                ShowGame();
                ChatScreentextBox.AppendText("System: Game started!" + "\n");
            }));
            gameStarted = true;
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

            if(msg.Substring(0, 3) == "CDR")        //serwer zglasza klientowi, ze wybral juz swoja karte
            {
                if(playerNumber == 2)
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        opponentReadyBox.Checked = true;
                    }));
                }
            }

            if (msg.Substring(0, 3) == "CPI")        //klient wysyla serwerowi wybrana przez siebie karte
            {
                if (playerNumber == 1)
                {
                    if(msg.Length == 5)
                    {
                        idOpponentCard = Int32.Parse(msg.Substring(3, 2));      
                    }
                    else if(msg.Length == 4)
                    {
                        idOpponentCard = Int32.Parse(msg.Substring(3, 1));
                    }
                   
                    this.Invoke(new MethodInvoker(delegate
                    {
                        opponentReadyBox.Checked = true;
                    }));
                    if (playerReadyBox.Checked == true && opponentReadyBox.Checked == true)  //jezeli obaj gotowi, serwer finalizuje ture
                    {
                        processTurnResult();
                    }
                }
            }

            //sendSystemMsg("TST" + serverCardIdFull + clientCardIdFull + serverLifeFull + clientLifeFull);

            if (msg.Substring(0, 3) == "TST")        //wiadomosc dotyczy stanu gry po tej turze
            {
                if(playerNumber == 2)       //tylko klient otrzymuje takie wiadomosci, serwer sam oblicza stan gry
                {
                    idPlayerCard = int.Parse(msg.Substring(5, 2));
                    idOpponentCard = int.Parse(msg.Substring(3, 2));
                    playerLife = int.Parse(msg.Substring(9, 2));
                    opponentLife = int.Parse(msg.Substring(7,2));

                    this.Invoke(new MethodInvoker(delegate
                    {
                        ProgressBarPlayerHp.Value = playerLife;
                        playerLifeLabel.Text = playerLife.ToString();
                        ProgressBarOpponentHp.Value = opponentLife;
                        opponentLifeLabel.Text = opponentLife.ToString();
                        showPlayerUsedCard(idPlayerCard);
                        showOpponentrUsedCard(idOpponentCard);
                        loadNewCard(playerDeck);
                        updateRound();
                        uncheckCards();
                        playerReadyBox.Checked = false;
                        opponentReadyBox.Checked = false;
                        playerReadyButton.Enabled = true;
                        if(msg.Substring(11, 2) != "00")
                        {
                            endGame(msg.Substring(11, 2));
                        }
                    }));
                }
            }
        }

        private bool actionIsAttack(string action)
        {
            if(action.Substring(0,1) == "A")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool actionIsDefense(string action)
        {
            if (action.Substring(0, 1) == "D")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private int getAttackStrength(string action)
        {
            return int.Parse(action.Substring(1, 1));
        }

        private void processTurnResult()       
        {
            string[] serverCard = {"0", "0", "0", "0"};
            string[] clientCard = {"0", "0", "0", "0"};
            
            for (int i = 0; i < 4; i++)
            {
                serverCard[i] = Card[idPlayerCard, i];
                clientCard[i] = Card[idOpponentCard, i];
            }
            
            for(int j=0 ; j < 3 ; j++)      //ataki gora, przod, dol
            {
                if (actionIsAttack(serverCard[j]) && !(actionIsDefense(clientCard[j])))     //jezeli serwer wyprowadzil nieobroniony atak
                {
                    opponentLife -= getAttackStrength(serverCard[j]);
                }
                if (actionIsAttack(clientCard[j]) && !(actionIsDefense(serverCard[j])))     //jezeli serwer wyprowadzil nieobroniony atak
                {
                    playerLife -= getAttackStrength(clientCard[j]);
                }
            }
            if(serverCard[3] == "+1")   //zdolnosci specjalne
            {
                playerLife += 1;
            }
            if (serverCard[3] == "-1")
            {
                playerLife -= 1;
            }
            if (clientCard[3] == "+1")
            {
                opponentLife += 1;
            }
            if (clientCard[3] == "-1")
            {
                opponentLife -= 1;
            }

            playerLife = ((playerLife > 0) ? playerLife : 0);                   //ograniczenia na gorna i dolna ilosc zycia
            playerLife = ((playerLife <= maxHp) ? playerLife : maxHp);
            opponentLife = ((opponentLife > 0) ? opponentLife : 0);
            opponentLife = ((opponentLife <= maxHp) ? opponentLife : maxHp);

            this.Invoke(new MethodInvoker(delegate
            {
                ProgressBarPlayerHp.Value = playerLife;
                playerLifeLabel.Text = playerLife.ToString();
                ProgressBarOpponentHp.Value = opponentLife;
                opponentLifeLabel.Text = opponentLife.ToString();
                showPlayerUsedCard(idPlayerCard);
                showOpponentrUsedCard(idOpponentCard);
                loadNewCard(playerDeck);
                updateRound();
                uncheckCards();
                playerReadyBox.Checked = false;
                opponentReadyBox.Checked = false;
                playerReadyButton.Enabled = true;
            }));

            string serverCardIdFull = ((idPlayerCard < 10) ? string.Concat("0" , idPlayerCard.ToString()) : idPlayerCard.ToString());     //dopelnienie do 2 znakow
            string clientCardIdFull = ((idOpponentCard < 10) ? string.Concat("0", idOpponentCard.ToString()) : idOpponentCard.ToString());
            string serverLifeFull = ((playerLife < 10) ? string.Concat("0", playerLife.ToString()) : playerLife.ToString());
            string clientLifeFull = ((opponentLife < 10) ? string.Concat("0", opponentLife.ToString()) : opponentLife.ToString());

            string res = CheckEndGameCondition();

            if (res != "00")
            {
                endGame(res);
            }

            sendSystemMsg("TST" + serverCardIdFull + clientCardIdFull + serverLifeFull + clientLifeFull + res);           //Turn STate

            //tutaj dodac wysylanie komunikatu o stanie gry do klienta


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
                            ChatScreentextBox.AppendText("Opponent: " + truncateFirstSign(recieve) + "\n");
                        }));
                    }
                    else
                    {
                        if (debugModeOn)
                        {
                            this.Invoke(new MethodInvoker(delegate
                            {
                                ChatScreentextBox.AppendText("SysRcv:" + recieve + "\n");  //tylko do debugowania
                            }));
                        }
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
                playerReadyButton.Enabled = true;
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
                        playerReadyButton.Enabled = true;
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
                        ChatScreentextBox.AppendText("Me: " + truncateFirstSign(TextToSend) + "\n");
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
                Startbutton.Text = "Create";
            }
            else
            {
                IPtextBox.Text = String.Empty;
                Startbutton.Text = "Connect";
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
            else    //jezeli gra rozpoczeta, przycisk zatwierdza wykonanie ruchu
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    playerReadyBox.Checked = true;
                    playerReadyButton.Enabled = false;
                    
                }));

                if (playerNumber == 2)  //klient przesyla id wybranej karty
                {
                    idPlayerCard = whichCardIsUsed(playerDeck);
                    sendSystemMsg("CPI" + idPlayerCard);                                    //Card Played Id   
                    
                }
                else if(playerNumber == 1)
                {
                    idPlayerCard = whichCardIsUsed(playerDeck);
                    if(playerReadyBox.Checked == true && opponentReadyBox.Checked == true)  //jezeli obaj gotowi, serwer finalizuje ture
                    {
                        processTurnResult();
                    }
                    else            //jezeli klient niegotowy, serwer wysyla informacje o gotowosci i czeka
                    {
                        sendSystemMsg("CDR");               //CarD Ready
                    }
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
            playerReadyButton.Enabled = true;

            // textBox1.Visible = true;
            //textBox1.Text = "Numer karty:"+ card1.Image.Tag.ToString();

        }

        private void card2_Click(object sender, EventArgs e)
        {
            choosecard1.BackColor = Color.Transparent;
            choosecard2.BackColor = Color.DarkGray;
            choosecard3.BackColor = Color.Transparent;
            playerReadyButton.Enabled = true;
        }

        private void card3_Click(object sender, EventArgs e)
        {
            choosecard1.BackColor = Color.Transparent;
            choosecard2.BackColor = Color.Transparent;
            choosecard3.BackColor = Color.DarkGray;
            playerReadyButton.Enabled = true;
        }
        private void uncheckCards()
        {
            choosecard1.BackColor = Color.Transparent;
            choosecard2.BackColor = Color.Transparent;
            choosecard3.BackColor = Color.Transparent;
       
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
                        ChatScreentextBox.AppendText("Me: " + truncateFirstSign(TextToSend) + "\n");
                    }));
                }
            }
            else
            {
                MessageBox.Show("Sending failed");

            }
            backgroundWorker3.CancelAsync();
        }

        private void ProgressBarPlayerHp_Click(object sender, EventArgs e)
        {

        }

        private void opponentLifeLabel_Click(object sender, EventArgs e)
        {

        }

        public int[] shuffle(int[] table) // przyklad uzycia playerDeck = shuffle(ID);
        {
            Random rnd = new Random();
            int[] tableafter = table.OrderBy(x => rnd.Next()).ToArray();            
            return tableafter;
        }

        public void loadHand(int[] table)
        {
            card1.Image = listOfPicture[table[0]];
            card1.Image.Tag = "0";
            card2.Image = listOfPicture[table[1]];
            card2.Image.Tag = "1";
            card3.Image = listOfPicture[table[2]];
            card3.Image.Tag = "2";
        }

        public int whichCardIsUsed(int[] table)
        {

            int idUsedCard;
            if (choosecard1.BackColor == Color.DarkGray)
            {
                idUsedCard = table[Convert.ToInt16(card1.Image.Tag)];               
            }
            else if (choosecard2.BackColor == Color.DarkGray)
            {
                idUsedCard = table[Convert.ToInt16(card2.Image.Tag)];        
            }
            else
            {
                idUsedCard = table[Convert.ToInt16(card3.Image.Tag)];                
            }


            return idUsedCard; 
        }

        public void loadNewCard(int[] table)
        {
            if(choosecard1.BackColor==Color.DarkGray)
            {
                
                card1.Image = listOfPicture[table[RoundNumber + 2]];
                card1.Image.Tag = Convert.ToString(RoundNumber + 2);
               
            }
            else if (choosecard2.BackColor == Color.DarkGray)
            {
               
                card2.Image = listOfPicture[table[RoundNumber + 2]];
                card2.Image.Tag = Convert.ToString(RoundNumber + 2);
                
            }
            else if (choosecard3.BackColor == Color.DarkGray)
            {
               
                card3.Image = listOfPicture[table[RoundNumber + 2]];
                card3.Image.Tag = Convert.ToString(RoundNumber + 2);
               
            }

        }
        private void showPlayerUsedCard(int id)
        {
            
            playerUsedCard.Image = listOfPicture[id];
        }
        private void showOpponentrUsedCard(int id)
        {
            OpponentUsedCard.Image = listOfPicture[id];
        }

        private void button1_Click(object sender, EventArgs e) //obrazowa kolejnosc jednej tury 
        {            
 
        }
    }
}
