using System.Threading;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;

namespace JustWunderMobile.Common.ViewModels
{
    public class SplashViewModel 
		: MvxViewModel
    {
        #region Fields

        // commands
        private MvxCommand _showMainViewCommand;
        #endregion


        #region Properties

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





        //example of props
        private string _hello = "Hello MvvmCross";
        public string Hello
		{ 
			get { return _hello; }
			set { _hello = value; RaisePropertyChanged(() => Hello); }
		}
    }
}
