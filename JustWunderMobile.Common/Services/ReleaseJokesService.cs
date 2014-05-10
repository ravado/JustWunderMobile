using JustWunderMobile.Common.DAL.Contracts;
using JustWunderMobile.Common.DAL.Entities;
using JustWunderMobile.Common.DataModels;
using JustWunderMobile.Common.Interfaces;
using JustWunderMobile.Common.Mapping;
using System.Collections.Generic;
using System.Linq;

namespace JustWunderMobile.Common.Services
{
    /// <summary>
    /// Service contains all business logic for released jokes
    /// </summary>
    public class ReleaseJokesService : IReleasedJokeService<ReleaseJokeDataModel>
    {
        #region Fields

        private readonly IRepository<ReleaseJoke> _releaseJokeRepository;

        #endregion

        #region Properties

        protected IRepository<ReleaseJoke> ReleaseJokeRepository
        {
            get { return _releaseJokeRepository; }
        }

        #endregion

        #region Constructors
        
        public ReleaseJokesService(IRepository<ReleaseJoke> releaseJokeRepository)
        {
            _releaseJokeRepository = releaseJokeRepository;
        }
        
        #endregion

        #region Methods

        public void UpdateJokes(IEnumerable<ReleaseJokeDataModel> jokes)
        {
            foreach (var joke in jokes)
            {
                ReleaseJokeRepository.Update(joke.GetEntity());    
            }
        }

        public IEnumerable<ReleaseJokeDataModel> GetTopJokes(int count, int offset)
        {
            var top = ReleaseJokeRepository.GetAll()
                .OrderByDescending(o => o.Rating)
                .Skip(offset)
                .Take(count)
                .Select(o => o.GetModel());

            return top;
        }

        public IEnumerable<ReleaseJokeDataModel> GetLastJokes(int count, int offset)
        {
            var last = ReleaseJokeRepository.GetAll()
                .OrderByDescending(o => o.PublishDate)
                .Skip(offset)
                .Take(count)
                .Select(o => o.GetModel());

            return last;
        }

        public IEnumerable<ReleaseJokeDataModel> GetFavoriteJokes(int count, int offset)
        {
            var favorite = ReleaseJokeRepository.GetAll()
                .OrderByDescending(o => o.PublishDate)
                .Where(o=>o.Favorite)
                .Skip(offset)
                .Take(count)
                .Select(o => o.GetModel());

            return favorite;
        }

        public void RemoveJokes(IEnumerable<ReleaseJokeDataModel> jokesToRemove)
        {
            foreach (var joke in jokesToRemove)
            {
                ReleaseJokeRepository.Delete(joke.GetEntity());
            }
        }

        public void RemoveAllJokes()
        {
            ReleaseJokeRepository.DeleteAll();
        }

        #endregion


        public int GetTopJokesCount()
        {
            return ReleaseJokeRepository.GetAll().Count();
        }

        public int GetLastJokesCount()
        {
            return ReleaseJokeRepository.GetAll().Count();
        }

        public int GetFavoriteJokesCount()
        {
            return ReleaseJokeRepository.GetAll().Count(o => o.Favorite);
        }
    }
}