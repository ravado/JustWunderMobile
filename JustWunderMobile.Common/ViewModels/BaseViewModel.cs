using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;

namespace JustWunderMobile.Common.ViewModels
{
    public class BaseViewModel : MvxViewModel
    {
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


        private void Close()
        {
            base.Close(this);
        }
    }
}
