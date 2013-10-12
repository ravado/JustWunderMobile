using JustWunderMobile.DAL.Contracts;
using JustWunderMobile.DAL.Models;
using OpenNETCF.ORM;

namespace JustWunderMobile.DAL.Repositories
{
    public class NewJokeRepository : BaseRepository<NewJoke>
    {
        public NewJokeRepository(SQLStoreBase<SqlEntityInfo> store) : base(store)
        {
        }
    }
}
