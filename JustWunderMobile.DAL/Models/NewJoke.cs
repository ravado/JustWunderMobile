using System;
using OpenNETCF.ORM;

namespace JustWunderMobile.DAL.Models
{
    /// <summary>
    /// Entity model of new jokes stored on local device
    /// </summary>
    [Entity(KeyScheme = KeyScheme.Identity)]
    public class NewJoke
    {
        [Field(IsPrimaryKey = true)]
        public int Id { get; set; }
        [Field]
        public DateTime DateAdded{ get; set; }
        [Field(DefaultValue = false)]
        public bool IsSent { get; set; }
        [Field]
        public string TextJoke { get; set; }
        [Field]
        public string UserEmail { get; set; }
    }
}