using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Cirrious.MvvmCross.WindowsPhone.Views;
using JustWunderMobile.Common;
using JustWunderMobile.Common.DataModels;
using JustWunderMobile.Common.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

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

        private void NewJokesMultiSelector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // update viewmodel state if now we selecting new jokes or not
            if (NewJokesMultiSelector.SelectedItems.Count > 0)
                _viewModel.ViewState = MainViewState.NewJokesSelecting;
            else
                _viewModel.ViewState = MainViewState.NewJokes;

            // there is no direct selected items binding ability, so...
            _viewModel.NewJokesSelected.Clear();
            foreach (var selected in NewJokesMultiSelector.SelectedItems.OfType<ReleaseJokeDataModel>())
            {
                _viewModel.NewJokesSelected.Add(selected);
            }

            
                
        }

        private void MainPivot_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // update viemodel state depending on selected pivot item
            switch (MainPivot.SelectedIndex)
            {
                case 0: _viewModel.ViewState = MainViewState.NewJokes; break;
                case 1: _viewModel.ViewState = MainViewState.TopJokes; break;
                case 2: _viewModel.ViewState = MainViewState.FavoriteJokes; break;
                default: _viewModel.ViewState = MainViewState.NewJokes; break;
            }
        }
    }
}