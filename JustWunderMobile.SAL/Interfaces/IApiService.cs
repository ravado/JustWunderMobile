using System;
using System.Collections.Generic;

namespace JustWunderMobile.SAL.Interfaces
{
    /// <summary>
    /// Interface for available api server methods
    /// </summary>
    public interface IApiService
    {
        IEnumerable<IApiReleaseJoke> GetAllReleasedJokes();
        IEnumerable<IApiReleaseJoke> GetNewJokes(int lastJokeId); // TODO: need to clarify how to get only new jokes
        void PostNewJoke(IApiInboxJoke newJoke);
    }
}
