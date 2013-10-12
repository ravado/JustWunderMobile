using System;

namespace JustWunderMobile.DataModels
{
    public class ReleaseJokeDataModel
    {
        public int Id { get; set; }
        public DateTime PublishDate { get; set; }
        public string TextJoke { get; set; }
        public string UserEmail { get; set; }
        public int Rating { get; set; }
        public bool Censorship { get; set; }
    }
}