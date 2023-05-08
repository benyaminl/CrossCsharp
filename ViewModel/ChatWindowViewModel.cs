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
        }

        public async void SendMessage()
        {
            this.svc?.SendChat(this.target ?? "255.255.255.255", this._chat);
            await Task.Delay(200);
            this.LoadMessage();
            this.ChatBox = "";
        }

        public void LoadMessage()
        {
            this.ChatHistory = this.svc?.GetChatHistoryAsString(this.target ?? "255.255.255.255") ?? "";
        }
    }
}