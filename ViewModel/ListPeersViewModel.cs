using System;
using ReactiveUI;

namespace CrossCsharp.ViewModel
{
    public class ListPeersViewModel : ReactiveObject
    {
        protected List<string> _peers = new List<string>();

        public List<string> Peers { 
            get => _peers; 
            set {
                _peers = value;
                this.RaisePropertyChanged(nameof(Peers));
            } 
        }
    }
}