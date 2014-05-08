using System.Diagnostics;
using JustWunderMobile.Common;
using JustWunderMobile.Common.DataModels;
using JustWunderMobile.Common.ViewModels;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;

namespace JustWunderMobile.Phone.Views
{
    public partial class MainView
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
                Dispatcher.BeginInvoke(() => MessageBox.Show(alertEventArgs.Message, "Attention", MessageBoxButton.OK));
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
            base.OnNavigatingFrom(e);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (_viewModel == null)
                _viewModel = ViewModel as MainViewModel;

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

        #region Jokes Maniputaions
        private void NewJokesMultiSelector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // update viewmodel state if now we selecting new jokes or not
            _viewModel.ViewState = NewJokesMultiSelector.SelectedItems.Count > 0 
                    ? MainViewState.NewJokesSelecting 
                    : MainViewState.NewJokes;

            // there is no direct selected items binding ability, so...
            _viewModel.NewJokesSelected.Clear();
            foreach (var selected in NewJokesMultiSelector.SelectedItems.OfType<ReleaseJokeDataModel>())
            {
                _viewModel.NewJokesSelected.Add(selected);
            }
        }
        private void TopJokesMultiSelector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // update viewmodel state if now we selecting top jokes or not
            _viewModel.ViewState = TopJokesMultiSelector.SelectedItems.Count > 0
                    ? MainViewState.TopJokesSelecting
                    : MainViewState.TopJokes;

            // there is no direct selected items binding ability, so...
            _viewModel.TopJokesSelected.Clear();
            foreach (var selected in TopJokesMultiSelector.SelectedItems.OfType<ReleaseJokeDataModel>())
            {
                _viewModel.TopJokesSelected.Add(selected);
            }
        }
        private void FavoriteJokesMultiSelector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // update viewmodel state if now we selecting favorite jokes or not
            _viewModel.ViewState = FavoriteJokesMultiSelector.SelectedItems.Count > 0
                    ? MainViewState.FavoriteJokesSelecting
                    : MainViewState.FavoriteJokes;

            // there is no direct selected items binding ability, so...
            _viewModel.FavoriteJokesSelected.Clear();
            foreach (var selected in FavoriteJokesMultiSelector.SelectedItems.OfType<ReleaseJokeDataModel>())
            {
                _viewModel.FavoriteJokesSelected.Add(selected);
            }
        }
        #endregion
    }
}