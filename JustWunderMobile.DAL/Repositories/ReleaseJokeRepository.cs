using JustWunderMobile.DAL.Contracts;
using JustWunderMobile.DAL.Models;
using OpenNETCF.ORM;

namespace JustWunderMobile.DAL.Repositories
{
    public class ReleaseJokeRepository : BaseRepository<ReleaseJoke>
    {
        public ReleaseJokeRepository(SQLStoreBase<SqlEntityInfo> store) : base(store)
        {
        }
    }
}
