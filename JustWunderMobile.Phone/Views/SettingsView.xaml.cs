using System;
using System.Windows;
using System.Windows.Navigation;
using Cirrious.MvvmCross.WindowsPhone.Views;
using JustWunderMobile.Common.ViewModels;

namespace JustWunderMobile.Phone.Views
{
    public partial class SettingsView : MvxPhonePage
    {
        private SettingsViewModel _viewModel;
        public SettingsView()
        {
            InitializeComponent();
            Loaded += OnLoaded;
        }
        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            
            if (_viewModel != null)
            {
                _viewModel.OnMessageDisplay -= ViewModelOnOnMessageDisplay;
                _viewModel.OnMessageDisplay += ViewModelOnOnMessageDisplay;
            }
        }

        private void ViewModelOnOnMessageDisplay(object sender, AlertEventArgs e)
        {
            if (e != EventArgs.Empty)
            {
                Dispatcher.BeginInvoke(() => MessageBox.Show("Message", "Caption", MessageBoxButton.OK));
            }
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (_viewModel == null)
                _viewModel = base.ViewModel as SettingsViewModel;

        }
        private void RemoveAllJokesButton_OnClick(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Удалить", "Опасно", MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                _viewModel.RemoveAllJokesCommand.Execute(this);
            }
        }
    }
}