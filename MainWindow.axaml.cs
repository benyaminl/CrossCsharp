using Avalonia.Controls;
using Avalonia.Interactivity;
using System;
using CrossCsharp.ViewModel;

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

        public void BtnAlert_Click(object sender, RoutedEventArgs e)
        {
            ctx.LabelText = ctx.InputText;
            Console.WriteLine(ctx.InputText);
        }
 
    }
}
