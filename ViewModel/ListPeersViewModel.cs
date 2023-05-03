using System;
using System.Timers;
using CrossCsharp.Chat;
using DynamicData;
using DynamicData.Binding;
using ReactiveUI;

namespace CrossCsharp.ViewModel
{
    public class ListPeersViewModel : ReactiveObject
    {
        // This collection using Reactive Source List is sad... 
        // @see https://stackoverflow.com/a/53709090/4906348
        // @see https://www.reactiveui.net/docs/handbook/collections/#using-dynamicdata-with-reactiveui
        public SourceList<string> _peers { get; } = new SourceList<string>();

        public IObservableCollection<string> Peers { get;  } = new ObservableCollectionExtended<string>();
        protected ChatService? service;
        protected System.Timers.Timer? t;

        public ListPeersViewModel(ChatService? svc = null)
        {
            this.service = svc;
            if (this.service != null)
            {    
                this.service.GetListOfPeers().ForEach(d => {
                    this._peers.Add(d.ipAddress);
                });

                this._peers.Connect()
                    .Bind(Peers)
                    .Subscribe();
                
                t = new System.Timers.Timer(2000);
                t.Elapsed += TimerTick;
                t.Enabled = true;
                t.AutoReset = true;
            }
        }

        public void TimerTick(Object? source = null, ElapsedEventArgs? e = null)
        {
            this._peers.Clear();

            this.service?.GetListOfPeers().ForEach(d => {
                this._peers.Add(d.ipAddress);
            });
        }
    }
}