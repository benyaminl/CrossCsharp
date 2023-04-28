using System;
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
    }
}