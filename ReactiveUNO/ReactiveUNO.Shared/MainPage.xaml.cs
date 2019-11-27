using ReactiveUI;
using ReactiveUNO.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reactive.Disposables;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ReactiveUNO
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page, IViewFor<MainPageViewModel>
    {
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty
            .Register(nameof(ViewModel), typeof(MainPageViewModel), typeof(MainPage), new PropertyMetadata(null));

        public MainPage()
        {
            this.InitializeComponent();

            ViewModel = new MainPageViewModel();

            this.WhenActivated(disposable =>
            {
                this.Bind(ViewModel, x => x.TheText, x => x.TheTextBox.Text)
                    .DisposeWith(disposable);
                this.OneWayBind(ViewModel, x => x.TheText, x => x.TheTextBlock.Text)
                    .DisposeWith(disposable);
                this.BindCommand(ViewModel, x => x.TheTextCommand, x => x.TheTextButton)
                    .DisposeWith(disposable);
            });
        }

        public MainPageViewModel ViewModel
        {
            get => (MainPageViewModel)GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (MainPageViewModel)value;
        }
    }
}
