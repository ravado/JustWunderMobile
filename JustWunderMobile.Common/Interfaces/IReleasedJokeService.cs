using System.Collections.Generic;

namespace JustWunderMobile.Common.Interfaces
{
    /// <summary>
    /// Interface which declare all functionality for working with approved jokes on application
    /// </summary>
    /// <typeparam name="TModel">Approved joke data model</typeparam>
    public interface IReleasedJokeService<TModel>
    {
        IEnumerable<TModel> GetTopJokes(int count, int offset);
        IEnumerable<TModel> GetLastJokes(int count, int offset);
        IEnumerable<TModel> GetFavoriteJokes(int count, int offset);
    }
}
