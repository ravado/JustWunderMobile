using System.Threading;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using JustWunderMobile.Common.Resources;

namespace JustWunderMobile.Common.ViewModels
{
    public class SplashViewModel : BaseViewModel
    {
        #region Fields

        #region Commands
        private MvxCommand _showMainViewCommand;
        #endregion

        #endregion

        #region Properties

        public override string PageName
        {
            get { return UILabels.SplashScreen_Name; }
        }

        #region Commands

        public ICommand ShowMainViewCommand
        {
            get
            {
                _showMainViewCommand = _showMainViewCommand ?? new MvxCommand(OpenMainView);
                return _showMainViewCommand;
            }
        }

        #endregion

        #endregion

        #region Constructors

        public SplashViewModel()
        {
            
        }
        #endregion

        #region Methods

        private void OpenMainView()
        {
            ShowViewModel<MainViewModel>();
        }

        #endregion

    }
}
