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
        private const int OFFSET_KNOB = 5;
        private bool _isInitialized;

        public MainView()
        {
            Debug.WriteLine("Main View Constructor");
            InitializeComponent();
            Loaded += OnLoaded;
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
            Debug.WriteLine("Main View Loaded");
            NavigationService.RemoveBackEntry();

            if (_viewModel != null && !_isInitialized)
            {
                _viewModel.NeedJokeDisplay = true;
                _viewModel.ShowJokes();
                _isInitialized = true;
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

        private void NewJokesMultiSelector_OnItemRealized(object sender, ItemRealizationEventArgs e)
        {
            //var currentContent = (e.Container.Content as ReleaseJokeDataModel);
            //if (!CanLoadMoreNewJokes() || currentContent == null) return;
            //if (e.ItemKind != LongListSelectorItemKind.Item) return;

            //if (IsNewJokesBufferZoneNear(currentContent))
            //{
            //    Debug.WriteLine("Loading new...");
            //    var page = _viewModel.GetNewJokesCurrentPage() + 1;
            //    Dispatcher.BeginInvoke(() => _viewModel.LoadNewJokes(page));
            //}
        }
        private void TopJokesMultiSelector_OnItemRealized(object sender, ItemRealizationEventArgs e)
        {
            //var currentContent = (e.Container.Content as ReleaseJokeDataModel);
            //if (!CanLoadMoreTopJokes() || currentContent == null) return;
            //if (e.ItemKind != LongListSelectorItemKind.Item) return;

            //if (IsTopJokesBufferZoneNear(currentContent))
            //{
            //    Debug.WriteLine("Loading new...");
            //    var page = _viewModel.GetTopJokesCurrentPage() + 1;
            //    Dispatcher.BeginInvoke(() => _viewModel.LoadTopJokes(page));
            //}
        }
        private void FavoriteJokesMultiSelector_OnItemRealized(object sender, ItemRealizationEventArgs e)
        {
            //var currentContent = (e.Container.Content as ReleaseJokeDataModel);
            //if (!CanLoadMoreFavoriteJokes() || currentContent == null) return;
            //if (e.ItemKind != LongListSelectorItemKind.Item) return;

            //if (IsFavoriteJokesBufferZoneNear(currentContent))
            //{
            //    Debug.WriteLine("Loading new...");
            //    var page = _viewModel.GetFavoriteJokesCurrentPage() + 1;
            //    Dispatcher.BeginInvoke(() => _viewModel.LoadFavoriteJokes(page));
            //}
        }

        #region Helpers
        private bool CanLoadMoreNewJokes()
        {
            return !_viewModel.IsLoading
                   && NewJokesMultiSelector.ItemsSource != null
                   && NewJokesMultiSelector.ItemsSource.Count >= OFFSET_KNOB;
        }
        private bool IsNewJokesBufferZoneNear(ReleaseJokeDataModel itemInList)
        {
            return itemInList.Equals(NewJokesMultiSelector.ItemsSource[NewJokesMultiSelector.ItemsSource.Count - OFFSET_KNOB]);
        }

        private bool CanLoadMoreTopJokes()
        {
            return !_viewModel.IsLoading
                   && TopJokesMultiSelector.ItemsSource != null
                   && TopJokesMultiSelector.ItemsSource.Count >= OFFSET_KNOB;
        }
        private bool IsTopJokesBufferZoneNear(ReleaseJokeDataModel itemInList)
        {
            return itemInList.Equals(TopJokesMultiSelector.ItemsSource[TopJokesMultiSelector.ItemsSource.Count - OFFSET_KNOB]);
        }

        private bool CanLoadMoreFavoriteJokes()
        {
            return !_viewModel.IsLoading
                   && FavoriteJokesMultiSelector.ItemsSource != null
                   && FavoriteJokesMultiSelector.ItemsSource.Count >= OFFSET_KNOB;
        }
        private bool IsFavoriteJokesBufferZoneNear(ReleaseJokeDataModel itemInList)
        {
            return itemInList.Equals(FavoriteJokesMultiSelector.ItemsSource[FavoriteJokesMultiSelector.ItemsSource.Count - OFFSET_KNOB]);
        }
        #endregion

        private void NewJokesMultiSelector_OnItemUnrealized(object sender, ItemRealizationEventArgs e)
        {
            Debug.WriteLine("Unrealized");
        }
    }
}