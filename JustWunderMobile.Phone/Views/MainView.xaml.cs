using System;
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
                    var toast = new ShellToast();
                    toast.Title = "[title]";
                    toast.Content = alertEventArgs.Message;
                    toast.Show();
                });
            }
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            NavigationService.RemoveBackEntry();

            _viewModel = base.ViewModel as MainViewModel;

            if (_viewModel != null)
                _viewModel.OnMessageDisplay += ViewModelOnOnMessageDisplay;
        }
    }
}