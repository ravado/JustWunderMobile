using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cirrious.MvvmCross.ViewModels;
using JustWunderMobile.Common.DataModels;
using JustWunderMobile.Common.Interfaces;
using JustWunderMobile.Common.Resources;
using JustWunderMobile.Common.Services;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace JustWunderMobile.Common.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region Fields

        private Random _random;
        private readonly SyncService _syncService;
        private readonly IReleasedJokeService<ReleaseJokeDataModel> _releasedJokeService;
        private bool _needJokeDisplay = true;

        #region Commands
        private MvxCommand _refreshCommand;
        private MvxCommand _showSettingsCommand;
        private MvxCommand _showAboutCommand;
        private MvxCommand _addToFavoriteCommand;
        private MvxCommand _removeFromFavoriteCommand;
        #endregion

        private ObservableCollection<ReleaseJokeDataModel> _newJokes;
        private ObservableCollection<ReleaseJokeDataModel> _newJokesSelected;
        private ObservableCollection<ReleaseJokeDataModel> _topJokes;
        private ObservableCollection<ReleaseJokeDataModel> _topJokesSelected;
        private ObservableCollection<ReleaseJokeDataModel> _favoriteJokes;
        private ObservableCollection<ReleaseJokeDataModel> _favoriteJokesSelected;

        private MainViewState _viewState;

        #endregion

        #region Properties

        public ObservableCollection<ReleaseJokeDataModel> NewJokes
        {
            get { return _newJokes ?? (_newJokes = new ObservableCollection<ReleaseJokeDataModel>()); }
            set
            {
                _newJokes = value;
                RaisePropertyChanged(() => NewJokes);

            }
        }
        public ObservableCollection<ReleaseJokeDataModel> NewJokesSelected
        {
            get { return _newJokesSelected ?? (_newJokesSelected = new ObservableCollection<ReleaseJokeDataModel>()); }
            set
            {
                _newJokesSelected = value;
                RaisePropertyChanged(() => NewJokesSelected);

            }
        }
        public ObservableCollection<ReleaseJokeDataModel> TopJokes
        {
            get { return _topJokes ?? (_topJokes = new ObservableCollection<ReleaseJokeDataModel>()); }
            set
            {
                _topJokes = value;
                RaisePropertyChanged(() => TopJokes);

            }
        }
        public ObservableCollection<ReleaseJokeDataModel> TopJokesSelected
        {
            get { return _topJokesSelected ?? (_topJokesSelected = new ObservableCollection<ReleaseJokeDataModel>()); }
            set
            {
                _topJokesSelected = value;
                RaisePropertyChanged(() => TopJokesSelected);

            }
        }
        public ObservableCollection<ReleaseJokeDataModel> FavoriteJokes
        {
            get { return _favoriteJokes ?? (_favoriteJokes = new ObservableCollection<ReleaseJokeDataModel>()); }
            set
            {
                _favoriteJokes = value;
                RaisePropertyChanged(() => FavoriteJokes);

            }
        }
        public ObservableCollection<ReleaseJokeDataModel> FavoriteJokesSelected
        {
            get { return _favoriteJokesSelected ?? (_favoriteJokesSelected = new ObservableCollection<ReleaseJokeDataModel>()); }
            set
            {
                _favoriteJokesSelected = value;
                RaisePropertyChanged(() => FavoriteJokesSelected);

            }
        }

        public MainViewState ViewState
        {
            get { return _viewState; }
            set
            {
                _viewState = value;
                RaisePropertyChanged(() => ViewState);
            }
        }

        public bool NeedJokeDisplay
        {
            get { return _needJokeDisplay; }
            set { _needJokeDisplay = value; }
        }

        public SyncService SyncService { get { return _syncService; } }
        public IReleasedJokeService<ReleaseJokeDataModel> ReleasedJokeService { get { return _releasedJokeService; } }
        
        #region Labels
        public override string PageName
        {
            get { return UILabels.MainPage_Name; }
        }
        public string TopJokesLabel
        {
            get { return UILabels.MainPage_TopJokes; }
        }
        public string NewJokesLabel
        {
            get { return UILabels.MainPage_NewJokes; }
        }
        public string FavoriteJokesLabel
        {
            get { return UILabels.MainPage_FavoriteJokes; }
        }

        public string MenuSettingsLabel
        {
            get { return UILabels.MainPage_Menu_Settings; }
        }
        public string MenuAboutLabel
        {
            get { return UILabels.MainPage_Menu_About; }
        }
        public string MenuRefreshLabel
        {
            get { return UILabels.MainPage_Menu_Refresh; }
        }
        public string MenuAddFavoriteLabel
        {
            get { return UILabels.MainPage_Menu_AddFavorite; }
        }
        public string MenuRemoveFavoriteLabel
        {
            get { return UILabels.MainPage_Menu_RemoveFavorite; }
        }
        public string MenuAddNewJokeLabel
        {
            get { return UILabels.MainPage_Menu_AddNewJoke; }
        }
        #endregion

        #region Commands
        public ICommand RefreshCommand
        {
            get
            {
                _refreshCommand = _refreshCommand ?? new MvxCommand(Refresh);
                return _refreshCommand;
            }
        }
        public ICommand ShowSettingsCommand
        {
            get
            {
                _showSettingsCommand = _showSettingsCommand ?? new MvxCommand(ShowSettings);
                return _showSettingsCommand;
            }
        }
        public ICommand ShowAboutCommand
        {
            get
            {
                _showAboutCommand = _showAboutCommand ?? new MvxCommand(ShowAbout);
                return _showAboutCommand;
            }
        }
        public ICommand AddToFavoriteCommand
        {
            get
            {
                _addToFavoriteCommand = _addToFavoriteCommand ?? new MvxCommand(AddToFavorite);
                return _addToFavoriteCommand;
            }
        }
        public ICommand RemoveFromFavoriteCommand
        {
            get
            {
                _removeFromFavoriteCommand = _removeFromFavoriteCommand ?? new MvxCommand(RemoveFromFavorite);
                return _removeFromFavoriteCommand;
            }
        }
        #endregion

        #endregion

        public MainViewModel(SyncService syncService, IReleasedJokeService<ReleaseJokeDataModel> releasedJokeService, ISpinner spinner)
            : base(spinner)
        {
            _syncService = syncService;//new SyncService(Mvx.Resolve<IApiService>(), Mvx.Resolve<IRepository<ReleaseJoke>>(), Mvx.Resolve<IRepository<NewJoke>>());
            _releasedJokeService = releasedJokeService;
            _viewState = MainViewState.NewJokes;
            //LoadFakeData();
            Initialize();
        }

        private void Initialize()
        {
            if (SyncService.NeedSync() && SyncService.CanSync())
            {
                Refresh();
            }
        }

        #region Methods

        private void ShowAbout()
        {
            ShowViewModel<AboutViewModel>();
        }
        private void ShowSettings()
        {
            ShowViewModel<SettingsViewModel>();
        }
        private void Refresh()
        {
            NeedJokeDisplay = true;
            Spinner.SetProgressIndicator(true, "Loading from server...");
            Task.Factory.StartNew(SyncService.LoadNewJokesFromServer)
                .ContinueWith(result =>
                {
                    Spinner.SetProgressIndicator(false);
                    ShowJokes();
                    throw new Exception("Fuck Off!");
                }).ContinueWith(r =>
                {
                    if (r.Exception != null)
                        ShowMessage(r.Exception.InnerException.Message);
                });


            System.Diagnostics.Debug.WriteLine("REFRESHING...");
        }

        private void UpdateFavoriteStatus(bool isFavorite)
        {
            foreach (var updated in NewJokes.Intersect(NewJokesSelected))
            {
                updated.Favorite = isFavorite;
            }
            NewJokes = NewJokes.ToObservableCollection();
        }
        private void AddToFavorite()
        {
            UpdateFavoriteStatus(true);
        }
        private void RemoveFromFavorite()
        {
            UpdateFavoriteStatus(false);
        }

        #region Public Methods
        public void CancelRenderingJokes()
        {
            NeedJokeDisplay = false;
        }
        public void ClearAllJokes()
        {
            NewJokes.Clear();
            TopJokes.Clear();
            FavoriteJokes.Clear();
        }
        public void ShowJokes()
        {
            Task.Factory.StartNew(() =>
            {
                try
                {
                    if (NeedJokeDisplay)
                    {
                        Spinner.SetProgressIndicator(true, "Rendering items...");
                        NewJokes = ReleasedJokeService.GetLastJokes(10, 0).ToObservableCollection();
                        TopJokes = ReleasedJokeService.GetTopJokes(10, 0).ToObservableCollection();
                        FavoriteJokes = ReleasedJokeService.GetFavoriteJokes(10, 0).ToObservableCollection();
                    }
                }
                finally
                {
                    Spinner.SetProgressIndicator(false);
                }
            });
        }
        #endregion

        #endregion
    }
}
