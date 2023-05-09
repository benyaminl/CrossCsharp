using System;
using System.Timers;
using Avalonia.Controls.Selection;
using CrossCsharp.Chat;
using CrossCsharp.User;
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
        protected SourceList<string> _peers { get; } = new SourceList<string>();

        public IObservableCollection<string> Peers { get;  } = new ObservableCollectionExtended<string>();
        protected ChatService? service;
        protected System.Timers.Timer? t;

        protected SelectionModel<String> Selection { get; }

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

            Selection = new SelectionModel<String>();
            Selection.SelectionChanged += SelectionChanged;
        }

        public void TimerTick(Object? source = null, ElapsedEventArgs? e = null)
        {
            this._peers.Clear();

            this.service?.GetListOfPeers().ForEach(d => {
                this._peers.Add(d.ipAddress + " - " + d.username);
            });
        }

        int selectedIndex;

        public int SelectedIndex
        {
            get => selectedIndex;
            set => this.RaiseAndSetIfChanged(ref selectedIndex, value);
        }

        Dictionary<string, ChatWindow> chatWindows = new Dictionary<string, ChatWindow>();

        /// <summary>
        /// This is the event of change items, as MVVM, binded to selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectionChanged(object sender, SelectionModelSelectionChangedEventArgs e)
        {
            Console.WriteLine(e.SelectedItems[0]);
            ChatWindow window;
            string ip = e.SelectedItems[0].ToString().Split(" - ")[0];
            if (this.chatWindows.Where(d => d.Key.Equals(e.SelectedItems[0].ToString())).Count() > 0)
            {
                window = chatWindows[ip];
            } 
            else
            {
                window = new ChatWindow()
                {
                    DataContext = new ChatWindowViewModel(this.service, ip)
                };
    
            }
            
            window.Show();
        }
    }
}