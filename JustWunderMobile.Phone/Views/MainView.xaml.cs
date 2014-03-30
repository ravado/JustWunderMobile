using System;
using System.Threading.Tasks;
using System.Windows.Controls;
using Cirrious.MvvmCross.WindowsPhone.Views;
using System.Windows;
using System.Windows.Navigation;
using JustWunderMobile.Common.ViewModels;
using Microsoft.Phone.Shell;

namespace JustWunderMobile.Phone.Views
{
    public partial class MainView : MvxPhonePage
    {
        private MainViewModel _viewModel;
        public MainView()
        {
            InitializeComponent();
            Loaded  += OnLoaded;
        }

        private void ViewModelOnOnMessageDisplay(object sender, AlertEventArgs alertEventArgs)
        {
            if (alertEventArgs != EventArgs.Empty)
            {
                Dispatcher.BeginInvoke(() =>
                {
//                    var toast = new ShellToast();
//                    toast.Title = "[title]";
//                    toast.Content = alertEventArgs.Message;
//                    toast.Show();
                    MessageBox.Show("Message", "Caption", MessageBoxButton.OK);
                });
            }
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            NavigationService.RemoveBackEntry();

            if (_viewModel != null)
            {
                _viewModel.NeedJokeDisplay = true;
                _viewModel.ShowJokes();
            }

            if (_viewModel != null)
            {
                _viewModel.OnMessageDisplay -= ViewModelOnOnMessageDisplay;
                _viewModel.OnMessageDisplay += ViewModelOnOnMessageDisplay;
            }
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            _viewModel.Spinner.SetProgressIndicator(false);
            _viewModel.CancelRenderingJokes();
            _viewModel.ClearAllJokes();
            base.OnNavigatingFrom(e);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (_viewModel == null)
                _viewModel = base.ViewModel as MainViewModel;

        }
    }
}