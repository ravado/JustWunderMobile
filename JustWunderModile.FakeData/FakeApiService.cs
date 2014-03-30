using System;
using JustWunderMobile.SAL.Interfaces;

namespace JustWunderMobile.FakeData
{
    public class FakeApiService : IApiService
    {
        private static Random _random;

        public System.Collections.Generic.IEnumerable<IApiReleaseJoke> GetAllReleasedJokes()
        {
            return JokeMock.GetJokes();
        }

        public System.Collections.Generic.IEnumerable<IApiReleaseJoke> GetNewJokes(int lastJokeId)
        {
            var some = "";
            for (int i = 0; i < 1000000; i++)
            {
                some += i.ToString();
                if (some.Length > 1000)
                    some = "";
            }
            return JokeMock.GetNewJokes();
        }

        public bool PostNewJoke(IApiInboxJoke newJoke)
        {
            var rand = new Random().Next() % 2 == 0 ? true : false;

            return rand;
        }

        public void VoteJokes(IApiJokeVoteContainer voteJokesContainer)
        {
            throw new NotImplementedException();
        }

        private int GetRandom()
        {
            if (_random == null)
                _random = new Random(2000);

            return _random.Next(0, 5000);
        }

        private DateTime RandomDay()
        {
            var start = new DateTime(2010, 1, 1);

            int range = (DateTime.Today - start).Days;
            var val = start.AddDays(_random.Next(range));
            val = val.AddHours(_random.Next(24));
            val = val.AddMinutes(_random.Next(60));
            val = val.AddSeconds(_random.Next(60));
            return val;
        }
    }
}