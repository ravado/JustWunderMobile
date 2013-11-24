using System.Collections.Generic;
using JustWunderMobile.SAL.Interfaces;
using ProtoBuf;

namespace JustWunderMobile.SAL.DTO
{
    [ProtoContract]
    public class JokesVoteContainer : IApiJokeVoteContainer
    {
        [ProtoMember(100)]
        public List<IApiVote> Jokes { get; set; }

        public JokesVoteContainer()
        {
            Jokes = new List<IApiVote>();
        }
    }
}
