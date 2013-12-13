using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;

namespace JustWunderMobile.Common.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        // commands
        private MvxCommand _refreshCommand;
        private MvxCommand _showSettingsCommand;
        private MvxCommand _showAboutCommand;

        // commands
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
    }
}
