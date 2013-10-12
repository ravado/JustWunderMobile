﻿using System;
using OpenNETCF.ORM;

namespace JustWunderMobile.DAL.Models
{
    /// <summary>
    /// Entity model of jokes stored on local device
    /// </summary>
    [Entity(KeyScheme = KeyScheme.None)]
    public class ReleaseJoke
    {
        [Field(IsPrimaryKey = true)]
        public int Id { get; set; }
        [Field]
        public DateTime PublishDate { get; set; }
        [Field]
        public string TextJoke { get; set; }
        [Field]
        public string UserEmail { get; set; }
        [Field]
        public int Rating { get; set; }
        [Field]
        public bool Censorship { get; set; }
    }
}