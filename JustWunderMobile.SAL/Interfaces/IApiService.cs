using System;
using System.Collections.Generic;

namespace JustWunderMobile.SAL.Interfaces
{
    /// <summary>
    /// Interface for available api server methods
    /// </summary>
    public interface IApiService
    {
        /// <summary>
        /// Receive all jokes from server which already approved by administrator
        /// </summary>
        /// <returns>Collection of all approved jokes</returns>
        IEnumerable<IApiReleaseJoke> GetAllReleasedJokes();

        /// <summary>
        /// Receive all jokes which was approved after last sync
        /// </summary>
        /// <param name="lastJokeId">The last id of joke which was get after last sync</param>
        /// <returns>Collection of ne jokes</returns>
        IEnumerable<IApiReleaseJoke> GetNewJokes(int lastJokeId); // TODO: need to clarify how to get only new jokes

        /// <summary>
        /// Post new joke from application to server
        /// </summary>
        /// <param name="newJoke">Joke object</param>
        /// <returns>true if posted, otherwise false</returns>
        bool PostNewJoke(IApiInboxJoke newJoke);
    }
}
