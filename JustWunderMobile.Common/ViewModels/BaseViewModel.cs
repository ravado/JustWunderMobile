using Cirrious.MvvmCross.ViewModels;
using JustWunderMobile.Common.Interfaces;
using JustWunderMobile.Common.Resources;
using System;
using System.Windows.Input;

namespace JustWunderMobile.Common.ViewModels
{
    public class BaseViewModel : MvxViewModel
    {
        public ISpinner Spinner { get; protected set; }

        public string AppName
        {
            get
            {
                return UILabels.App_Name;
            }
        }
        public virtual string PageName
        {
            get
            {
                return String.Empty;
            }
        }

        public event EventHandler<AlertEventArgs> OnMessageDisplay;

        public void ShowMessage(string message)
        {
            if(OnMessageDisplay != null) 
                OnMessageDisplay(this, new AlertEventArgs(message));
        }

        private ICommand _backCommand;

        // commands
        public ICommand BackCommand
        {
            get
            {
                //_closeCommand = new MvxClosePresentationHint(this);
                _backCommand = _backCommand ?? new MvxCommand(Close);
                return _backCommand;
            }
        }

        public BaseViewModel(ISpinner spinner)
        {
            Spinner = spinner;
        }

        private void Close()
        {
            base.Close(this);
        }
    }

    public class AlertEventArgs : EventArgs
    {
        public string Message { get; private set; }

        public AlertEventArgs(string message)
        {
            Message = message;
        }
        
    }
}
