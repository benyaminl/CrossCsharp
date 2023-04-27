using System;
using ReactiveUI;

namespace CrossCsharp.ViewModel
{
    public class MainWindowViewModel : ReactiveObject
    {
        protected string _str = "";
        
        public string InputText
        {
            get => _str;
            set
            {
                Console.WriteLine(value);
                _str = value;

                this.RaisePropertyChanged(nameof(InputText));
            }
        }

        protected string _label = "HAI";

        public string LabelText 
        {
            get => _label;
            set {
                _label = _str;
                this.RaisePropertyChanged(nameof(LabelText));
            }
        }
    }
}