using System.Globalization;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using JustWunderMobile.Common.DataModels;
using JustWunderMobile.Common.Interfaces;
using JustWunderMobile.Common.Resources;

namespace JustWunderMobile.Common.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        #region Fields

        #region Commands

        private ICommand _removeAllJokesCommand;
        private IReleasedJokeService<ReleaseJokeDataModel> _releasedJokeService;
        #endregion

        private ISettingService SettingService { get; set; }
        
        #endregion

        #region Properties

        public bool SyncOnStart
        {
            get { return SettingService.SyncOnStart; }
            set { SettingService.SyncOnStart = value; RaisePropertyChanged(() => SyncOnStart); }
        }

        public override string PageName
        {
            get { return UILabels.SettingsPage_Name; }
        }
        public string MenuBackLabel
        {
            get { return UILabels.SettingsPage_Menu_Back; }
        }

        private IReleasedJokeService<ReleaseJokeDataModel> ReleasedJokeService { get { return _releasedJokeService; } }

        #region Commands
        public ICommand RemoveAllJokesCommand
        {
            get
            {
                _removeAllJokesCommand = _removeAllJokesCommand ?? new MvxCommand(RemoveAllJokes);
                return _removeAllJokesCommand;
            }
        }
        #endregion

        #endregion
       

       

        public SettingsViewModel(ISettingService settingsService, IReleasedJokeService<ReleaseJokeDataModel> releasedJokeService, ISpinner spinner) : base(spinner)
        {
            SettingService = settingsService;
            _releasedJokeService = releasedJokeService;
        }

        #region Methods
        private void RemoveAllJokes()
        {
            ReleasedJokeService.RemoveAllJokes();
        }
        #endregion

       
    }
}
