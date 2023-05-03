using Avalonia;
using Avalonia.Interactivity;
using Avalonia.Controls;
using CrossCsharp.ViewModel;
using Avalonia.Markup.Xaml;
using System;
using CrossCsharp.Chat;
using System.Net;
using System.Net.Sockets;

namespace CrossCsharp.User
{
    public partial class ChatLanding : Window
    {
        private ChatService? service;
        public ChatLanding()
        {
            InitializeComponent();
        }

        public void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(this.UsernameInput.Text);
            IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddr = IPAddress.Any;
            IPEndPoint localEndPoint = new IPEndPoint(ipAddr, 11111);
            
            Console.WriteLine(ipHost.HostName + " " + ipAddr.ToString());
            // Creation TCP/IP Socket using
            // Socket Class Constructor
            Socket listener = new Socket(ipAddr.AddressFamily,
                        SocketType.Dgram, ProtocolType.Udp);
            
            listener.Bind(localEndPoint);
            
            string username = this.UsernameInput.Text;
            this.service = new ChatService(listener, username);

            ListPeers wnd = new ListPeers()
            {
                DataContext = new ListPeersViewModel(service),
                service = this.service
            };

            // this.Hide();
            wnd.ShowDialog(this);
        }
    }
}