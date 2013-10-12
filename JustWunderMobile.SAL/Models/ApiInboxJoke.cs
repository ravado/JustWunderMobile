using System;
using JustWunderMobile.SAL.Interfaces;
using ProtoBuf;

namespace JustWunderMobile.SAL.Models
{
    /// <summary>
    /// Representation of new joke wich will be send to server via api
    /// </summary>
    [ProtoContract]
    public class ApiInboxJoke:IApiInboxJoke
    {
        [ProtoMember(1)]
        public int Id { get; set; }
        [ProtoMember(2)]
        public DateTime SentDate { get; set; }
        [ProtoMember(3)]
        public string TextJoke { get; set; }
        [ProtoMember(4)]
        public string UserEmail { get; set; }
        
    }
}