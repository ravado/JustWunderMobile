using System;
using JustWunderMobile.SAL.Interfaces;

namespace JustWunderMobile.SAL.Models
{
    /// <summary>
    /// Representation of new joke wich will be send to server via api
    /// </summary>
    public class ApiInboxJoke:IApiInboxJoke
    {
        public int Id { get; set; }
        public DateTime SentDate { get; set; }
        public string TextJoke { get; set; }
        public string UserEmail { get; set; }
        
    }
}