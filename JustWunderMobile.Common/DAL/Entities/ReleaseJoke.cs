using System;
using Cirrious.MvvmCross.Plugins.Sqlite;

namespace JustWunderMobile.Common.DAL.Entities
{
    /// <summary>
    /// Entity model of jokes stored on local device
    /// Note: while adding some prop don`t forget to update MappingExtensions.cs
    /// </summary>
    public class ReleaseJoke
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime PublishDate { get; set; }
        public string TextJoke { get; set; }
        public string UserEmail { get; set; }
        public int Rating { get; set; }
        public bool Censorship { get; set; }

        /// <summary>
        /// Count of votes which user gave to the joke
        /// </summary>
        public int Vote { get; set; }
    }
}