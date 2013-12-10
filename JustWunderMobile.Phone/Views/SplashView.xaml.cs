using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Cirrious.MvvmCross.WindowsPhone.Views;
using JustWunderMobile.Common.ViewModels;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace JustWunderMobile.Phone.Views
{
    public partial class SplashView : MvxPhonePage
    {
        public SplashView()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            Task.Run(() =>
            {
                Thread.Sleep(5000);

            }).ContinueWith(x =>
            {
                Dispatcher.BeginInvoke(() => (ViewModel as SplashViewModel).ShowMainViewCommand.Execute(null));
            });
            
            
        }
    }
}