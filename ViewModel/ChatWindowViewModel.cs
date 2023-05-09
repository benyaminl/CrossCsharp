using System;
using CrossCsharp.Chat;
using ReactiveUI;

namespace CrossCsharp.ViewModel
{
    public class ChatWindowViewModel : ReactiveObject
    {
        protected string _history = "";

        public string ChatHistory { 
            get => _history; 
            set {
                _history = value;
                this.RaisePropertyChanged(nameof(ChatHistory));
            } 
        }


        protected string _chat = "";

        public string ChatBox { 
            get => _chat; 
            set {
                _chat = value;
                this.RaisePropertyChanged(nameof(ChatBox));
            } 
        }

        private ChatService? svc;
        private string? target;
        public ChatWindowViewModel(ChatService? svc = null, string? target = null)
        {
            this.svc = svc;
            this.target = target;
            if (this.svc != null)
                this.svc.receiveChat += LoadMessageListener;
        }

        public void SendMessage()
        {
            this.svc?.SendChat(this.target ?? "255.255.255.255", this._chat);
            // There are no need to reload the message using void directly, as I made
            // A simple C# event listener
            this.ChatBox = "";
        }

        public void LoadMessage()
        {
            this.ChatHistory = this.svc?.GetChatHistoryAsString(this.target ?? "255.255.255.255") ?? "";
        }

        /// <summary>
        /// This is a wrapper for Reload the chat when someone chat us, it update the chat view
        /// Still not perfect, just at least a jump
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void LoadMessageListener(object? sender, EventArgs e)
        {
            this.LoadMessage();
        }
    }
}