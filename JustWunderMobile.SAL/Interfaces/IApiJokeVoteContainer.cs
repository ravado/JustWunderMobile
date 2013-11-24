using System;
using System.Collections.Generic;

namespace JustWunderMobile.SAL.Interfaces
{
    /// <summary>
    /// Interface for container of votes data of joke which will be send to server via api
    /// </summary>
    public interface IApiJokeVoteContainer
    {
        List<IApiVote> Jokes { get; set; }
    }
}
