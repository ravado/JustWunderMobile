using JustWunderMobile.Common.Resources;

namespace JustWunderMobile.Common.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        #region Fields

        #region Commands
        #endregion

        #endregion

        #region Properties

        public override string PageName
        {
            get { return UILabels.AboutPage_Name; }
        }
        public string MenuBackLabel
        {
            get { return UILabels.AboutPage_Menu_Back; }
        }
        #region Commands

        #endregion

        #endregion

    }
}
