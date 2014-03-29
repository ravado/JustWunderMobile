using JustWunderMobile.Common.Interfaces;
using JustWunderMobile.Common.Resources;

namespace JustWunderMobile.Common.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        #region Fields

        private bool _syncOnStart;

        #region Commands
        #endregion

        private ISettingService SettingService { get; set; }
        
        #endregion

        public SettingsViewModel(ISettingService settingsService, ISpinner spinner) : base(spinner)
        {
            SettingService = settingsService;
        }

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

        #region Commands
        
        #endregion

        #endregion
    }
}
