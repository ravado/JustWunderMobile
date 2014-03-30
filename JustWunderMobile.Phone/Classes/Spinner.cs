using JustWunderMobile.Common.Interfaces;
using Microsoft.Phone.Shell;
using System.Windows;

namespace JustWunderMobile.Phone.Classes
{
    class Spinner:ISpinner
    {
        public Spinner()
        {
            
        }

        public void SetProgressIndicator(bool visible, string message = "")
        {
            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                if (SystemTray.ProgressIndicator == null)
                    SystemTray.ProgressIndicator = new ProgressIndicator();

                SystemTray.ProgressIndicator.IsIndeterminate = visible;
                SystemTray.ProgressIndicator.IsVisible = visible;
                SystemTray.ProgressIndicator.Text = message;
            });
        }
    }
}
