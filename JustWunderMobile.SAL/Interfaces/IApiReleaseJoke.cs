using System;

namespace JustWunderMobile.SAL.Interfaces
{
    /// <summary>
    /// Interface for accepted jokes from server
    /// </summary>
    public interface IApiReleaseJoke
    {
        int Id { get; set; }
        DateTime PublishDate { get; set; }
        string TextJoke { get; set; }
        string UserEmail { get; set; }
        int Rating { get; set; }
        bool Censorship { get; set; }
    }
}
