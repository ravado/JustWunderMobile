using System.Windows.Controls;
using Cirrious.MvvmCross.WindowsPhone.Views;
using System.Windows;
using System.Windows.Navigation;

namespace JustWunderMobile.Phone.Views
{
    public partial class AboutView : MvxPhonePage
    {
        public AboutView()
        {
            InitializeComponent();
            Loaded  += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            NavigationService.RemoveBackEntry();

        }
    }
}