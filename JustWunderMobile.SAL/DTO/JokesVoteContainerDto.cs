using System.Collections.Generic;
using JustWunderMobile.SAL.Interfaces;
using ProtoBuf;

namespace JustWunderMobile.SAL.DTO
{
    [ProtoContract]
    public class JokesVoteContainerDto : IApiJokeVoteContainer
    {
        [ProtoMember(100)]
        public List<IApiVote> Jokes { get; set; }

        public JokesVoteContainerDto()
        {
            Jokes = new List<IApiVote>();
        }
    }
}
