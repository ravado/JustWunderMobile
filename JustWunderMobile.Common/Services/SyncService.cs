using JustWunderMobile.Common.DAL.Interfaces;
using JustWunderMobile.Common.Mapping;
using JustWunderMobile.SAL.DTO;
using JustWunderMobile.SAL.Interfaces;
using System.Linq;

namespace JustWunderMobile.Common.Services
{
    /// <summary>
    /// Service for posting and retrieving jokes data from server
    /// </summary>
    public class SyncService
    {
        protected IApiService ApiService { get; private set; }
        protected IReleaseJokeRepository ReleaseJokeRepository { get; private set; }
        protected INewJokeRepository NewJokeRepository { get; private set; }

        public SyncService(IApiService apiService, IReleaseJokeRepository releaseJokeRepository, INewJokeRepository newJokeRepository)
        {
            ApiService = apiService;
            ReleaseJokeRepository = releaseJokeRepository;
            NewJokeRepository = newJokeRepository;
        }

        private void LoadJokesFromServer()
        {
            var lastId = GetReleasedJokeLastId();
            var newJokes = ApiService.GetNewJokes(lastId);
            foreach (var newJoke in newJokes)
            {
                ReleaseJokeRepository.Insert(newJoke.GetEntity());
            }
        }

        private void RateJokes()
        {
            var voteJokesContainer = new JokesVoteContainer();
            var ratedJokes = ReleaseJokeRepository.GetAll().Where(j => j.Vote != 0).ToList();

            foreach (var releaseJoke in ratedJokes)
                voteJokesContainer.Jokes.Add(new JokeVote() {JokeId = releaseJoke.Id, Vote = releaseJoke.Vote});

            ApiService.VoteJokes(voteJokesContainer);
        }

        private void PostNewJokeToServer()
        {
            var newJokes = NewJokeRepository.GetAll().Where(j => j.IsSent == false);

            foreach (var newJoke in newJokes)
            {
                ApiService.PostNewJoke(newJoke.GetDTO());
            }
        }

        private int GetReleasedJokeLastId()
        {
            int lastId = -1;
            if (ReleaseJokeRepository.GetAll().Any())
            {
                lastId = ReleaseJokeRepository.GetAll().OrderBy(x => x.Id).Select(x => x.Id).FirstOrDefault();
            }

            return lastId;
        }
    }
}
