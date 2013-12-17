﻿using System.Collections.ObjectModel;
using Cirrious.MvvmCross.ViewModels;
using System.Windows.Input;
using JustWunderMobile.Common.DataModels;
using JustWunderMobile.Common.Resources;

namespace JustWunderMobile.Common.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region Fields

        #region Commands
        private MvxCommand _refreshCommand;
        private MvxCommand _showSettingsCommand;
        private MvxCommand _showAboutCommand;
        #endregion

        private ObservableCollection<ReleaseJokeDataModel> _newJokes;
        private ObservableCollection<ReleaseJokeDataModel> _topJokes;
        private ObservableCollection<ReleaseJokeDataModel> _favoriteJokes;

        #endregion

        #region Properties


        public override string PageName
        {
            get { return UILabels.MainPage_Name; }
        }
        public string TopJokesLabel
        {
            get { return UILabels.MainPage_TopJokes; }
        }
        public string NewJokesLabel
        {
            get { return UILabels.MainPage_NewJokes; }
        }
        public string FavoriteJokesLabel
        {
            get { return UILabels.MainPage_FavoriteJokes; }
        }
        public string MenuSettingsLabel
        {
            get { return UILabels.MainPage_Menu_Settings; }
        }
        public string MenuAboutLabel
        {
            get { return UILabels.MainPage_Menu_About; }
        }
        public string MenuRefreshLabel
        {
            get { return UILabels.MainPage_Menu_Refresh; }
        }

        public ObservableCollection<ReleaseJokeDataModel> NewJokes
        {
            get { return _newJokes ?? (_newJokes = new ObservableCollection<ReleaseJokeDataModel>()); }
            set
            {
                _newJokes = value;
                RaisePropertyChanged(() => NewJokes);

            }
        }
        public ObservableCollection<ReleaseJokeDataModel> TopJokes
        {
            get { return _topJokes ?? (_topJokes = new ObservableCollection<ReleaseJokeDataModel>()); }
            set
            {
                _topJokes = value;
                RaisePropertyChanged(() => TopJokes);

            }
        }
        public ObservableCollection<ReleaseJokeDataModel> FavoriteJokes
        {
            get { return _favoriteJokes ?? (_favoriteJokes = new ObservableCollection<ReleaseJokeDataModel>()); }
            set
            {
                _favoriteJokes = value;
                RaisePropertyChanged(() => FavoriteJokes);

            }
        }


        #region Commands
        public ICommand RefreshCommand
        {
            get
            {
                _refreshCommand = _refreshCommand ?? new MvxCommand(Refresh);
                return _refreshCommand;
            }
        }
        public ICommand ShowSettingsCommand
        {
            get
            {
                _showSettingsCommand = _showSettingsCommand ?? new MvxCommand(ShowSettings);
                return _showSettingsCommand;
            }
        }
        public ICommand ShowAboutCommand
        {
            get
            {
                _showAboutCommand = _showAboutCommand ?? new MvxCommand(ShowAbout);
                return _showAboutCommand;
            }
        }
        #endregion

        #endregion

        public MainViewModel()
        {
            LoadFakeData();
        }

        #region Methods

        private void ShowAbout()
        {
            ShowViewModel<AboutViewModel>();
        }
        private void ShowSettings()
        {
            ShowViewModel<SettingsViewModel>();
        }
        private void Refresh()
        {
            System.Diagnostics.Debug.WriteLine("REFRESHING...");
        }

        private void LoadFakeData()
        {
            #region NewJokes
            NewJokes.Add(new ReleaseJokeDataModel()
            {
                TextJoke = "Я родом из Орехово-Зуево. И я просто ненавижу русскую раскладку за то, что буквы З и Х расположены рядом."
            });
            NewJokes.Add(new ReleaseJokeDataModel()
            {
                TextJoke = "Когда-то давно я посадила в горшок орех из Рафаэлло. Прошло 11 лет, а я до сих пор надеюсь, что из него вырастет Рафаэлловое дерево :)"
            });
            NewJokes.Add(new ReleaseJokeDataModel()
            {
                TextJoke = "Это просто вопрос времени, когда к моему имени и фамилии добавят слово «синдром»."
            });
            NewJokes.Add(new ReleaseJokeDataModel()
            {
                TextJoke = "Отец так хотел, чтобы его сын стал физиком, что бил его не ремнем, а током."
            });
            NewJokes.Add(new ReleaseJokeDataModel()
            {
                TextJoke = "Скажи мне, сколько языков программирования ты знаешь, и я скажу, носишь ли ты сандали с носками."
            });
            NewJokes.Add(new ReleaseJokeDataModel()
            {
                TextJoke = "Ищу девушку с квартирой для очень серьёзных отношений, машина у меня уже есть от предыдущей жены."
            });
            NewJokes.Add(new ReleaseJokeDataModel()
            {
                TextJoke = "Мальчик, которого воспитали бараны, без проблем адаптировался в современном обществе."
            });
            NewJokes.Add(new ReleaseJokeDataModel()
            {
                TextJoke = "Если ты, когда-нибудь, лежа на девушке, заметишь, что глаза ее лихорадочно блестят, губы влажны и чувственны, а тело дрожит как осиновый лист на ветру - слазь с нее и беги... Это - малярия!"
            });
            NewJokes.Add(new ReleaseJokeDataModel()
            {
                TextJoke = "Коллеги, сегодня я вас всех собрал, потому что вы - пазл."
            }); NewJokes.Add(new ReleaseJokeDataModel()
            {
                TextJoke = "Маша любила петь... eё рекорд был 40 Петь в месяц."
            });
            #endregion

            #region TopJokes
            TopJokes.Add(new ReleaseJokeDataModel()
            {
                TextJoke = "Я родом из Орехово-Зуево. И я просто ненавижу русскую раскладку за то, что буквы З и Х расположены рядом."
            });
            TopJokes.Add(new ReleaseJokeDataModel()
            {
                TextJoke = "Когда-то давно я посадила в горшок орех из Рафаэлло. Прошло 11 лет, а я до сих пор надеюсь, что из него вырастет Рафаэлловое дерево :)"
            });
            TopJokes.Add(new ReleaseJokeDataModel()
            {
                TextJoke = "Это просто вопрос времени, когда к моему имени и фамилии добавят слово «синдром»."
            });
            TopJokes.Add(new ReleaseJokeDataModel()
            {
                TextJoke = "Отец так хотел, чтобы его сын стал физиком, что бил его не ремнем, а током."
            });
            TopJokes.Add(new ReleaseJokeDataModel()
            {
                TextJoke = "Скажи мне, сколько языков программирования ты знаешь, и я скажу, носишь ли ты сандали с носками."
            });
            TopJokes.Add(new ReleaseJokeDataModel()
            {
                TextJoke = "Ищу девушку с квартирой для очень серьёзных отношений, машина у меня уже есть от предыдущей жены."
            });
            TopJokes.Add(new ReleaseJokeDataModel()
            {
                TextJoke = "Мальчик, которого воспитали бараны, без проблем адаптировался в современном обществе."
            });
            TopJokes.Add(new ReleaseJokeDataModel()
            {
                TextJoke = "Если ты, когда-нибудь, лежа на девушке, заметишь, что глаза ее лихорадочно блестят, губы влажны и чувственны, а тело дрожит как осиновый лист на ветру - слазь с нее и беги... Это - малярия!"
            });
            TopJokes.Add(new ReleaseJokeDataModel()
            {
                TextJoke = "Коллеги, сегодня я вас всех собрал, потому что вы - пазл."
            });
            TopJokes.Add(new ReleaseJokeDataModel()
            {
                TextJoke = "Маша любила петь... eё рекорд был 40 Петь в месяц."
            });
            #endregion

            #region TopJokes
            FavoriteJokes.Add(new ReleaseJokeDataModel()
            {
                TextJoke = "Я родом из Орехово-Зуево. И я просто ненавижу русскую раскладку за то, что буквы З и Х расположены рядом."
            });
            FavoriteJokes.Add(new ReleaseJokeDataModel()
            {
                TextJoke = "Когда-то давно я посадила в горшок орех из Рафаэлло. Прошло 11 лет, а я до сих пор надеюсь, что из него вырастет Рафаэлловое дерево :)"
            });
            FavoriteJokes.Add(new ReleaseJokeDataModel()
            {
                TextJoke = "Это просто вопрос времени, когда к моему имени и фамилии добавят слово «синдром»."
            });
            FavoriteJokes.Add(new ReleaseJokeDataModel()
            {
                TextJoke = "Отец так хотел, чтобы его сын стал физиком, что бил его не ремнем, а током."
            });
            FavoriteJokes.Add(new ReleaseJokeDataModel()
            {
                TextJoke = "Скажи мне, сколько языков программирования ты знаешь, и я скажу, носишь ли ты сандали с носками."
            });
            FavoriteJokes.Add(new ReleaseJokeDataModel()
            {
                TextJoke = "Ищу девушку с квартирой для очень серьёзных отношений, машина у меня уже есть от предыдущей жены."
            });
            FavoriteJokes.Add(new ReleaseJokeDataModel()
            {
                TextJoke = "Мальчик, которого воспитали бараны, без проблем адаптировался в современном обществе."
            });
            FavoriteJokes.Add(new ReleaseJokeDataModel()
            {
                TextJoke = "Если ты, когда-нибудь, лежа на девушке, заметишь, что глаза ее лихорадочно блестят, губы влажны и чувственны, а тело дрожит как осиновый лист на ветру - слазь с нее и беги... Это - малярия!"
            });
            FavoriteJokes.Add(new ReleaseJokeDataModel()
            {
                TextJoke = "Коллеги, сегодня я вас всех собрал, потому что вы - пазл."
            });
            FavoriteJokes.Add(new ReleaseJokeDataModel()
            {
                TextJoke = "Маша любила петь... eё рекорд был 40 Петь в месяц."
            });
            #endregion
        }
        #endregion
    }
}
