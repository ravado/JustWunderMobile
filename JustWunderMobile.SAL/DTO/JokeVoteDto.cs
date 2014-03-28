using JustWunderMobile.SAL.Interfaces;
using ProtoBuf;

namespace JustWunderMobile.SAL.DTO
{
    [ProtoContract]
    public class JokeVoteDto : IApiVote
    {
        [ProtoMember(1)]
        public int JokeId { get; set; }
        [ProtoMember(2)]
        public int Vote { get; set; }
    }
}
