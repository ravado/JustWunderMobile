﻿using JustWunderMobile.Common.Interfaces;
using JustWunderMobile.Common.Resources;

namespace JustWunderMobile.Common.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        #region Fields

        #region Commands
        #endregion

        private ISettingService _settingsStoredge;
        #endregion

        public SettingsViewModel(ISettingService settingsStoredge)
        {
            _settingsStoredge = settingsStoredge;
        }

        #region Properties

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
