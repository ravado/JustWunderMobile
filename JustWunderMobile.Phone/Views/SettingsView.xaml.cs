using JustWunderMobile.Common.ViewModels;
using System;
using System.Windows;
using System.Windows.Navigation;

namespace JustWunderMobile.Phone.Views
{
    public partial class SettingsView
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
                Dispatcher.BeginInvoke(() => MessageBox.Show(e.Message, "Attention", MessageBoxButton.OK));
            }
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (_viewModel == null)
                _viewModel = ViewModel as SettingsViewModel;

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