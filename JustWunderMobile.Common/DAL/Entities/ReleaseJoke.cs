using System;
using Cirrious.MvvmCross.Plugins.Sqlite;

namespace JustWunderMobile.Common.DAL.Entities
{
    /// <summary>
    /// Entity model of jokes stored on local device
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
    }
}