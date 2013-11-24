using System;

namespace JustWunderMobile.Common.DataModels
{
    /// <summary>
    /// Data representation for approved joke
    /// </summary>
    public class ReleaseJokeDataModel
    {
        public int Id { get; set; }
        public DateTime PublishDate { get; set; }
        public string TextJoke { get; set; }
        public string UserEmail { get; set; }
        public int Rating { get; set; }
        public bool Censorship { get; set; }
        public int Vote { get; set; }
    }
}