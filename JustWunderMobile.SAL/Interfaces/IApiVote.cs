using System;

namespace JustWunderMobile.SAL.Interfaces
{
    /// <summary>
    /// Interface for votes data of joke which will be send to server via api
    /// </summary>
    public interface IApiVote
    {
        int JokeId { get; set; }
        int Vote { get; set; }
    }
}
