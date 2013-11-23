using System;

namespace JustWunderMobile.Common.DataModels
{
    /// <summary>
    /// Data representation for new joke
    /// </summary>
    public class NewJokeDataModel
    {
        public int Id { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsSent { get; set; }
        public string TextJoke { get; set; }
        public string UserEmail { get; set; } 
    }
}