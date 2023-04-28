using Avalonia;
using Avalonia.Interactivity;
using Avalonia.Controls;
using CrossCsharp.ViewModel;
using Avalonia.Markup.Xaml;
using System;

namespace CrossCsharp.User
{
    public partial class ChatLanding : Window
    {
        public ChatLanding()
        {
            InitializeComponent();
        }

        public void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(this.UsernameInput.Text);
        }
    }
}