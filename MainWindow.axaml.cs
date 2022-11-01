using Avalonia.Controls;
using Avalonia.Interactivity;

namespace CrossCsharp
{
    public partial class MainWindow : Window
    {
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
 
    }
}
