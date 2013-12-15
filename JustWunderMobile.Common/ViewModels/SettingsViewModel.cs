using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;

namespace JustWunderMobile.Common.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        // commands
        private MvxCommand _refreshCommand;
        private MvxCommand showSettingsCommand;



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
                showSettingsCommand = showSettingsCommand ?? new MvxCommand(ShowSettings);
                return showSettingsCommand;
            }
        }

        private void ShowSettings()
        {
            System.Diagnostics.Debug.WriteLine("SETTINGS...");
        }

        private void Refresh()
        {
            System.Diagnostics.Debug.WriteLine("REFRESHING...");
        }
    }
}
