using Avalonia;
using Avalonia.Interactivity;
using Avalonia.Controls;
using CrossCsharp.ViewModel;
using Avalonia.Markup.Xaml;
using CrossCsharp.Chat;
using System.Timers;

namespace CrossCsharp.User
{
    public partial class ListPeers : Window
    {
        protected ListPeersViewModel ctx
        {
            get => this.DataContext as ListPeersViewModel ?? new ListPeersViewModel();
        }

        public ChatService? service;

        public ListPeers()
        {
            InitializeComponent();
        }

        public void PeersClick(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(sender);
        }
    }
}