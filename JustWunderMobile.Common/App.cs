using Cirrious.CrossCore.IoC;

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