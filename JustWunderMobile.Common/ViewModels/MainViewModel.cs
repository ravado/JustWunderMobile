using Cirrious.MvvmCross.ViewModels;
using System.Windows.Input;
using JustWunderMobile.Common.Resources;

namespace JustWunderMobile.Common.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region Fields

        #region Commands
        private MvxCommand _refreshCommand;
        private MvxCommand _showSettingsCommand;
        private MvxCommand _showAboutCommand;
        #endregion

        #endregion

        #region Properties

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
        #endregion

        #endregion

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
            System.Diagnostics.Debug.WriteLine("REFRESHING...");
        }

        #endregion
    }
}
