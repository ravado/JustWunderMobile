using JustWunderMobile.Common.DAL.Contracts;
using JustWunderMobile.Common.DAL.Entities;
using JustWunderMobile.Common.Interfaces;
using JustWunderMobile.Common.Mapping;
using JustWunderMobile.SAL.DTO;
using JustWunderMobile.SAL.Interfaces;
using System.Linq;

namespace JustWunderMobile.Common.Services
{
    /// <summary>
    /// Service for posting and retrieving jokes data from server
    /// </summary>
    public class SyncService : ISyncService
    {
        protected IApiService ApiService { get; private set; }
        protected IRepository<ReleaseJoke> ReleaseJokeRepository { get; private set; }
        protected IRepository<NewJoke> NewJokeRepository { get; private set; }

        public SyncService(IApiService apiService, IRepository<ReleaseJoke> releaseJokeRepository, IRepository<NewJoke> newJokeRepository)
        {
            ApiService = apiService;
            ReleaseJokeRepository = releaseJokeRepository;
            NewJokeRepository = newJokeRepository;
        }

        public void LoadNewJokesFromServer()
        {
            var lastId = GetReleasedJokeLastId();
            var newJokes = ApiService.GetNewJokes(lastId);
            foreach (var joke in newJokes.Select(newJoke => newJoke.GetEntity()))
            {
                joke.Favorite = Extentions.MakeRandom();
                ReleaseJokeRepository.Insert(joke);
            }
        }

        private void RateJokes()
        {
            var voteJokesContainer = new JokesVoteContainerDto();
            var ratedJokes = ReleaseJokeRepository.GetAll().Where(j => j.Vote != 0).ToList();

            foreach (var releaseJoke in ratedJokes)
                voteJokesContainer.Jokes.Add(new JokeVoteDto {JokeId = releaseJoke.Id, Vote = releaseJoke.Vote});

            ApiService.VoteJokes(voteJokesContainer);
        }

        private void PostNewJokeToServer()
        {
            var newJokes = NewJokeRepository.GetAll().Where(j => j.IsSend == false);

            foreach (var newJoke in newJokes)
            {
                ApiService.PostNewJoke(newJoke.GetDto());
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
