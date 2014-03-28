using Cirrious.CrossCore;
using Cirrious.CrossCore.IoC;
using JustWunderMobile.Common.DAL.Contracts;
using JustWunderMobile.Common.DAL.Entities;
using JustWunderMobile.Common.DAL.Repositories;
using JustWunderMobile.Common.Interfaces;

namespace JustWunderMobile.Common
{
    public class App : Cirrious.MvvmCross.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();
            CreatableTypes()
                .EndingWith("Repository")
                .AsInterfaces()
                .RegisterAsLazySingleton();
            //CreatableTypes()
            //   .EndingWith("Storedge")
            //   .AsInterfaces()
            //   .RegisterAsLazySingleton();
            //Mvx.ConstructAndRegisterSingleton<IRepository<ReleaseJoke>, ReleaseJokeRepository>();
            //Mvx.ConstructAndRegisterSingleton<IRepository<NewJoke>, NewJokeRepository>(); 
            RegisterAppStart<ViewModels.SplashViewModel>();
        }
    }
}