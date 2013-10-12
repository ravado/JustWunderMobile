using System.Collections.Generic;
using JustWunderMobile.DAL.Contracts;
using JustWunderMobile.DAL.Models;
using JustWunderMobile.DataModels;

namespace JustWunderMobile.Common.Services
{
    public class NewJokesService : BaseService<NewJokeDataModel, NewJoke>
    {
        public NewJokesService(IRepository<NewJoke> repository) : base(repository)
        {
        }

        public override IEnumerable<NewJokeDataModel> Read(System.Func<NewJokeDataModel, bool> predicate)
        {
            //return Repository.GetAll(true).Select(o => o.GetModel()).Where(predicate).ToArray();
            throw new System.NotImplementedException();
        }

        public override bool Update(NewJokeDataModel modelToUpdate)
        {
            throw new System.NotImplementedException();
        }

        public override bool Remove(NewJokeDataModel modelToRemove)
        {
            throw new System.NotImplementedException();
        }
    }
}