using Cirrious.CrossCore;
using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.WindowsPhone.Platform;
using JustWunderMobile.Common.Interfaces;
using JustWunderMobile.Common.Services;
using JustWunderMobile.FakeData;
using JustWunderMobile.Phone.Classes;
using JustWunderMobile.SAL.Interfaces;
using Microsoft.Phone.Controls;

namespace JustWunderMobile.Phone
{
    public class Setup : MvxPhoneSetup
    {
        public Setup(PhoneApplicationFrame rootFrame) : base(rootFrame)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            //Mvx.RegisterType<IApiService, FakeApiService>();
            Mvx.RegisterSingleton<IApiService>(new FakeApiService());
            Mvx.RegisterSingleton<ISettingService>(new SettingServise());
            Mvx.RegisterSingleton<ISpinner>(new Spinner());
            Mvx.RegisterType<SyncService, SyncService>();
            return new Common.App();
        }
		
        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }
    }
}