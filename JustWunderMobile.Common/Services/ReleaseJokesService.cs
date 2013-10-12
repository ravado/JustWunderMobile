using System.Collections.Generic;
using JustWunderMobile.DAL.Contracts;
using JustWunderMobile.DAL.Models;
using JustWunderMobile.DataModels;

namespace JustWunderMobile.Common.Services
{
    public class ReleaseJokesService : BaseService<ReleaseJokeDataModel, ReleaseJoke>
    {
        public ReleaseJokesService(IRepository<ReleaseJoke> repository) : base(repository)
        {
        }

        public override IEnumerable<ReleaseJokeDataModel> Read(System.Func<ReleaseJokeDataModel, bool> predicate)
        {
            //return Repository.GetAll(true).Select(o => o.GetModel()).Where(predicate).ToArray();
            throw new System.NotImplementedException();
        }

        public override bool Update(ReleaseJokeDataModel modelToUpdate)
        {
            throw new System.NotImplementedException();
        }

        public override bool Remove(ReleaseJokeDataModel modelToRemove)
        {
            throw new System.NotImplementedException();
        }
    }
}