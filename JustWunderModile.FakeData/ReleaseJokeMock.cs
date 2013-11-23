using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JustWunderMobile.SAL.DTO;
using JustWunderMobile.SAL.Interfaces;

namespace JustWunderMobile.FakeData
{
    public class JokeMock
    {
        public static IEnumerable<IApiReleaseJoke> GetJokes()
        {
            var jokes = new List<IApiReleaseJoke>()
            {
                new ReleaseJoke()
                {
                    Id = 0,
                    Censorship = false,
                    PublishDate = DateTime.Now,
                    Rating = 100,
                    TextJoke = @"Заходил ко мне Тарас. Это раз. Сообщил, что встреча в три. Это два.",
                    UserEmail = "ravadog@gmail.com"
                },
                new ReleaseJoke()
                {
                    Id = 1,
                    Censorship = false,
                    PublishDate = DateTime.Now,
                    Rating = 100,
                    TextJoke = @"Дорогой дедушка Мороз. Пишет тебе мальчик Антон. Прошу, дочитай это письмо до конца. Это не спам, это реальная возможность заработать...",
                    UserEmail = "ravadog@gmail.com"
                },
                new ReleaseJoke()
                {
                    Id = 2,
                    Censorship = false,
                    PublishDate = DateTime.Now,
                    Rating = 100,
                    TextJoke = @"Медным тазом накрылась Дюймовочка и уснула. Звонкий храп раздался по округе.",
                    UserEmail = "ravadog@gmail.com"
                },
                new ReleaseJoke()
                {
                    Id = 3,
                    Censorship = false,
                    PublishDate = DateTime.Now,
                    Rating = 100,
                    TextJoke = @"Каждый день я покупаю водку. Я шопоголик?",
                    UserEmail = "ravadog@gmail.com"
                },
                new ReleaseJoke()
                {
                    Id = 4,
                    Censorship = false,
                    PublishDate = DateTime.Now,
                    Rating = 100,
                    TextJoke = @"Волжский автомобильный завод преступил к разработке автомобиля предыдущего поколения.",
                    UserEmail = "ravadog@gmail.com"
                },
                
            };

            return jokes;
        }

        public static IEnumerable<IApiReleaseJoke> GetNewJokes()
        {
            var jokes = new List<IApiReleaseJoke>()
            {
                new ReleaseJoke()
                {
                    Id = 10,
                    Censorship = false,
                    PublishDate = DateTime.Now,
                    Rating = 150,
                    TextJoke = @"Вчера в автобусе наркоман в сумку залез, я сначала не заметила, потом сумку открываю – сидит.",
                    UserEmail = "ravadog@gmail.com"
                },
                new ReleaseJoke()
                {
                    Id = 11,
                    Censorship = false,
                    PublishDate = DateTime.Now,
                    Rating = 105,
                    TextJoke = @"Если приложить раскаленную морскую ракушку к уху, можно услышать собственный крик.",
                    UserEmail = "ravadog@gmail.com"
                },
                new ReleaseJoke()
                {
                    Id = 12,
                    Censorship = false,
                    PublishDate = DateTime.Now,
                    Rating = 155,
                    TextJoke = @"Я такой милый, что Бемби по сравнению со мной — просто олень.",
                    UserEmail = "ravadog@gmail.com"
                }
            };

            return jokes;
        }
    }
}
