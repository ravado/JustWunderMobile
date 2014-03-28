﻿using JustWunderMobile.Common.DAL.Contracts;
using JustWunderMobile.Common.DAL.Entities;
using JustWunderMobile.Common.DAL.Repositories;
using JustWunderMobile.Common.DataModels;
using JustWunderMobile.Common.Interfaces;
using System.Collections.Generic;
using System.Linq;
using JustWunderMobile.Common.Mapping;

namespace JustWunderMobile.Common.Services
{
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
        
        public IEnumerable<ReleaseJokeDataModel> GetTopJokes(int count, int offset)
        {
            var top = ReleaseJokeRepository.GetAll().OrderBy(o => o.Rating).Skip(offset).Take(count).Select(o => o.GetModel());
            return top;
        }

        public IEnumerable<ReleaseJokeDataModel> GetLastJokes(int count, int offset)
        {
            var last = ReleaseJokeRepository.GetAll().OrderBy(o => o.PublishDate).Skip(offset).Take(count).Select(o => o.GetModel());
            return last;
        }

        public IEnumerable<ReleaseJokeDataModel> GetFavoriteJokes(int count, int offset)
        {
            return new List<ReleaseJokeDataModel>();
        }

        #endregion
    }
}