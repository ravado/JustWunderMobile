using System;
using Cirrious.MvvmCross.Plugins.Sqlite;

namespace JustWunderMobile.Common.DAL.Entities
{
    /// <summary>
    /// Entity model of new jokes stored on local device
    /// </summary>
    public class NewJoke
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime DateAdded{ get; set; }
        public bool IsSent { get; set; }
        public string TextJoke { get; set; }        
        public string UserEmail { get; set; }
    }
}