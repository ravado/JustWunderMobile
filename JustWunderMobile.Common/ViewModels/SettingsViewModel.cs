﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;

namespace JustWunderMobile.Common.ViewModels
{
    public class SettingsViewModel : MvxViewModel
    {
        // commands
        private MvxCommand _refreshCommand;
        private MvxCommand showSettingsCommand;
        private MvxCommand _closeCommand;




        // commands
        public ICommand BackCommand
    {
            get
            {
                //_closeCommand = new MvxClosePresentationHint(this);
                _closeCommand = _closeCommand ?? new MvxCommand(Close);
                return _closeCommand;
            }
    }

        private void Close()
        {
            Close(this);
        }

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

        public object Some { get; set; }
    }
}
