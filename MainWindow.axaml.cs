using Avalonia.Controls;
using Avalonia.Interactivity;
using System;
using CrossCsharp.ViewModel;
using CrossCsharp.User;

namespace CrossCsharp
{
    public partial class MainWindow : Window
    {

        protected MainWindowViewModel ctx
        {
            get => this.DataContext as MainWindowViewModel ?? new MainWindowViewModel();
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        public void BtnHello_Click(object sender, RoutedEventArgs e)
        {
            var btn = (Button) sender;
            btn.Content = "Berubah!";
        }

        public void BtnNewWindow_Click(object sender, RoutedEventArgs e)
        {
            var btn = (Button) sender;
            btn.Content = "New Window Opened!!";
            
            var win = new Coba();
            win.Show();
        }

        public void BtnNewWindowChat_Click(object sender, RoutedEventArgs e)
        {
            var btn = (Button) sender;
            btn.Content = "New Window Opened!!";
            
            var win = new ChatWindow(){
                DataContext = new ChatWindowViewModel()
            };
            win.ShowDialog(this);
        }

        public void BtnAlert_Click(object sender, RoutedEventArgs e)
        {
            ctx.LabelText = ctx.InputText;
            Console.WriteLine(ctx.InputText);
        }

        public void BtnShowLogin_Click(object sender, RoutedEventArgs e)
        {
            var win = new ChatLanding();
            win.ShowDialog(this);
        }
 
    }
}
