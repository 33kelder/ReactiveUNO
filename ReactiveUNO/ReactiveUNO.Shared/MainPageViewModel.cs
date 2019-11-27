using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReactiveUNO.Shared
{
    public class MainPageViewModel : ReactiveObject
    {
        private string theText = string.Empty;
        public string TheText
        {
            get => theText;
            set => this.RaiseAndSetIfChanged(ref theText, value);
        }

        public ReactiveCommand<Unit, Unit> TheTextCommand { get; set; }

        public MainPageViewModel()
        {
            TheTextCommand = ReactiveCommand
                .CreateFromObservable(ExecuteTextCommand);
        }

        private IObservable<Unit> ExecuteTextCommand()
        {
            TheText = "Hello ReactiveUI";
            return Observable.Return(Unit.Default);
        }
    }
}
