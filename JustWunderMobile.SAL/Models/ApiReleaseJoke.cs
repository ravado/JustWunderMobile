using System;
using JustWunderMobile.SAL.Interfaces;
using ProtoBuf;

namespace JustWunderMobile.SAL.Models
{
    /// <summary>
    /// Representation of published joke from api server
    /// </summary>
    [ProtoContract]
    public class ApiReleaseJoke : IApiReleaseJoke
    {
        [ProtoMember(1)]
        public int Id { get; set; }
        [ProtoMember(2)]
        public DateTime PublishDate { get; set; }
        [ProtoMember(3)]
        public string TextJoke { get; set; }
        [ProtoMember(4)]
        public string UserEmail { get; set; }
        [ProtoMember(5)]
        public int Rating { get; set; }
        [ProtoMember(6)]
        public bool Censorship { get; set; }
    }
}