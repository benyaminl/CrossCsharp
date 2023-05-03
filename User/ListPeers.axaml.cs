using Avalonia;
using Avalonia.Interactivity;
using Avalonia.Controls;
using CrossCsharp.ViewModel;
using Avalonia.Markup.Xaml;
using CrossCsharp.Chat;

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
            ctx.Peers.Add("ABC");
            ctx.Peers.Add("DEF");

            if (this.service != null)
            {    
                this.service.GetListOfPeers().ForEach(d => {
                    ctx.Peers.Add(d.ipAddress);
                    ctx.Peers = ctx.Peers;
                });
            }
        }
    }
}