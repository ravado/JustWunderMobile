
using Cirrious.MvvmCross.Plugins.Sqlite;
using JustWunderMobile.Common.DAL.Entities;

namespace JustWunderMobile.Common.DAL.Repositories
{
    public class NewJokeRepository : BaseRepository<NewJoke>
    {
        public NewJokeRepository(ISQLiteConnectionFactory factory)
            : base(factory)
        {
        }
    }
}
