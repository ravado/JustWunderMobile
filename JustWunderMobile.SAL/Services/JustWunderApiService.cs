using System.Collections.Generic;
using JustWunderMobile.SAL.Interfaces;

namespace JustWunderMobile.SAL.Services
{
    /// <summary>
    /// ApiService implementation of JustWunder.com API
    /// </summary>
    public class JustWunderApiService : IApiService
    {
        #region Properties
        public string ApiUrl { get; set; }
        #endregion

        #region Constructors
        public JustWunderApiService(string apiUrl)
        {
            ApiUrl = apiUrl;
        }
        #endregion

        #region IApiService implementation
        public IEnumerable<IApiReleaseJoke> GetAllReleasedJokes()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<IApiReleaseJoke> GetNewJokes(int lastJokeId)
        {
            throw new System.NotImplementedException();
        }

        public bool PostNewJoke(IApiInboxJoke newJoke)
        {
            throw new System.NotImplementedException();
        }

        public void VoteJokes(IApiJokeVoteContainer voteJokesContainer)
        {
            throw new System.NotImplementedException();
        }
        #endregion


    }
}