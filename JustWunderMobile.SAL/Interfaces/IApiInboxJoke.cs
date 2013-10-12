using System;

namespace JustWunderMobile.SAL.Interfaces
{
    /// <summary>
    /// Interface for new jokes wich will send to server via api
    /// </summary>
    public interface IApiInboxJoke
    {
        int Id { get; set; }
        DateTime SentDate { get; set; }
        string TextJoke { get; set; }
        string UserEmail { get; set; }
    }
}
