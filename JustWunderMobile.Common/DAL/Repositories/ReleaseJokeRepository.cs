
using Cirrious.MvvmCross.Plugins.Sqlite;
using JustWunderMobile.Common.DAL.Entities;

namespace JustWunderMobile.Common.DAL.Repositories
{
    public class ReleaseJokeRepository : BaseRepository<ReleaseJoke>
    {
        public ReleaseJokeRepository(ISQLiteConnectionFactory factory)
            : base(factory)
        {
        }
    }
}
