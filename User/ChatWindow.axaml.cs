using Avalonia;
using Avalonia.Interactivity;
using Avalonia.Controls;
using CrossCsharp.ViewModel;
using Avalonia.Markup.Xaml;

namespace CrossCsharp.User
{
    public partial class ChatWindow : Window
    {
        protected ChatWindowViewModel ctx
        {
            get => this.DataContext as ChatWindowViewModel ?? new ChatWindowViewModel();
        }

        public ChatWindow()
        {
            InitializeComponent();
        }

        public override void Show()
        {
            base.Show();
            this.ctx.LoadMessage();
        }

        public void BtnSend_Click(object sender, RoutedEventArgs e)
        {
            this.ctx.SendMessage();
        }
    }
}