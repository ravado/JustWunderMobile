using System;
using JustWunderMobile.SAL.Interfaces;

namespace JustWunderMobile.SAL.Models
{
    /// <summary>
    /// Representation of published joke from api server
    /// </summary>
    public class ApiReleaseJoke : IApiReleaseJoke
    {
        public int Id { get; set; }
        public DateTime PublishDate { get; set; }
        public string TextJoke { get; set; }
        public string UserEmail { get; set; }
        public int Rating { get; set; }
        public bool Censorship { get; set; }
    }
}