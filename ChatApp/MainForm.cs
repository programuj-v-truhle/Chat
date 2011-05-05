using System;
using System.Drawing;
using System.Windows.Forms;

using System.Net;
using System.Net.Sockets;
using System.Text;


namespace ChatApp
{
    public partial class MainForm : Form
    {
        public const int Port = 1000;
        public TcpClient Client;
        public NetworkStream Channel;
        
        public bool Connected { get { return Client != null && Client.Connected; } }

        delegate void RCS(); // Delegát nutný pro volání metody tohoto formuláře zevnitř metody NewClientConnected která proběhne v cizím vlákně

        ///////////////////////////////         ZDE ZAČÍNAJÍ METODY        ///////////////////////////////
        public MainForm()
        {
            InitializeComponent();
            Client = null;
            Channel = null;
        }                

        // Obnoví popisky a stav okna podle toho jestli je klient připojen nebo ne
        private void RefreshConnectedState()
        {
            if (Connected)
            {
                AddMessage("Klient připojen!\n", Color.Purple, FontStyle.Italic);
                buttonSend.Enabled = true;
                timer.Enabled = true;
                labelConnection.Text = "Připojen";
                groupMyClient.Enabled = false;
                
                if (Channel == null) Channel = Client.GetStream();
            }
            else
            {
                AddMessage("Klient odpojen!\n", Color.Purple, FontStyle.Italic);
                buttonSend.Enabled = false;
                timer.Enabled = false;
                labelConnection.Text = "Nepřipojen";
                groupMyClient.Enabled = true;
                
                if (Channel != null) Channel.Close();
            }
        }

        // Přidá do záznamu chatu zprávu o dané barvě a stylu písma
        private void AddMessage(string Message, Color Color, FontStyle FStyle)
        {
            int begin = textLog.TextLength;
            textLog.AppendText(Message+"\n");            
            int end = textLog.TextLength;

            // Vyber úsek textu k obarvení
            textLog.Select(begin, end);

            Font TextFont = new Font(FontFamily.GenericSansSerif, 9, FStyle);
            textLog.SelectionColor = Color;
            textLog.SelectionFont = TextFont;

            textLog.SelectionLength = 0; // Zruš výběr textu
        }

        // Tato metoda je zavolána když se připojí klient
        private void NewClientConnected(IAsyncResult State)
        {
            // Volitelný parametr je právě náš Listener
            TcpListener MyListener = (TcpListener)State.AsyncState;

            if (!Connected)
            {
                // Jestliže jsme se mezitím nepřipojili manuálně, použijeme Listenera jej k získání Klienta
                Client = MyListener.EndAcceptTcpClient(State);
            }
            MyListener.Stop();

            // Metodu RefreshConnectedState musíme ale invokovat, protože jsme nyní v cizím vlákně (to je způsobeno charakterem asynchronních volání Begin/End)
            Invoke(new RCS(RefreshConnectedState));
        }

        ///////////////////////////////         ZDE ZAČÍNAJÍ UDÁLOSTI        ///////////////////////////////

        // Spočítej zbývající znaky zprávy
        private void textMessage_TextChanged(object sender, EventArgs e)
        {
            // Spočítej a vypiš kolik zbývá napsat znaků
            labelRemaining.Text = String.Format("Zbývá {0} znaků", textMessage.MaxLength - textMessage.Text.Length);
        }

        // Odešle zprávu klientovi
        private void buttonSend_Click(object sender, EventArgs e)
        {
            byte[] buffer = Encoding.Unicode.GetBytes(textMessage.Text);

            Channel.Write(buffer, 0, buffer.Length);
            AddMessage(textMessage.Text, Color.Navy, FontStyle.Regular);
            
            textMessage.Clear();
        }

        // Časovač volá periodicky ve zvoleném intervalu tuto událost
        private void timer_Tick(object sender, EventArgs e)
        {
            if (Connected)
            {
                byte[] Buffer = new byte[1024];
                while (Channel.DataAvailable) // Jsou-li v kanálu dostupná nějaká data, přečti je
                {
                    int read = Channel.Read(Buffer, 0, 1024);
                    AddMessage(Encoding.Unicode.GetString(Buffer, 0, read), Color.DarkRed, FontStyle.Bold);
                }
            }
            else RefreshConnectedState();
        }

        // Provede řádné ukončení
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Connected && Channel != null)
            {
                Channel.Close();
                Client.Close();
            }
        }

        // Nastává při načtení formuláře (tj. po spuštění aplikace)
        private void MainForm_Load(object sender, EventArgs e)
        {
            TcpListener Listen = new TcpListener(IPAddress.Any, Port);
            try
            {
                Listen.Start();

                // V pozadí čekej na připojení klienta a když se připojí zavolej NewClientConnected s Listenerem jako volitelným parametrem
                Listen.BeginAcceptTcpClient(new AsyncCallback(NewClientConnected), Listen);
            }
            catch (SocketException)
            {
                // Nelze naslouchat, tak umožni pouze připojování k jiným
                Listen = null;   
            }
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            // Jestli jsme už připojeni, nedělej nic
            if (Connected) return;
            
            // Vezmi první dostupnou IP adresu zadaného cíle
            IPAddress MyClientAddr = Dns.GetHostAddresses(textHost.Text)[0];

            Client = new TcpClient();
            Client.Connect(MyClientAddr, Port);

            RefreshConnectedState();
        }

        // Nastává při stisknutí Enteru po zadání textu do pole Zpráva
        private void textMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter && Connected)
                buttonSend.PerformClick(); // Simuluj stisknutí tlačítka Odeslat
        }


    }
}
