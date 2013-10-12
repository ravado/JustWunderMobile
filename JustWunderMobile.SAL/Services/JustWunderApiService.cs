using System.Collections.Generic;
using JustWunderMobile.SAL.Interfaces;

namespace JustWunderMobile.SAL.Services
{
    /// <summary>
    /// ApiService implementation of JustWunder.com API
    /// </summary>
    public class JustWunderApiService : IApiService
    {
        public IEnumerable<IApiReleaseJoke> GetAllReleasedJokes()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<IApiReleaseJoke> GetNewJokes(int lastJokeId)
        {
            throw new System.NotImplementedException();
        }

        public void PostNewJoke(IApiInboxJoke newJoke)
        {
            throw new System.NotImplementedException();
        }
    }
}