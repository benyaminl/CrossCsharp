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

        public override void Show()
        {
            base.Show();
        }

        public void OnClick(object sender, RoutedEventArgs e)
        {
            ctx._peers.Edit(d => d.Add("aaa"));
        }
    }
}