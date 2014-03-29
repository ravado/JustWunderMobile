using System;
using JustWunderMobile.SAL.Interfaces;

namespace JustWunderMobile.FakeData
{
    public class FakeApiService : IApiService
    {
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
    }
}