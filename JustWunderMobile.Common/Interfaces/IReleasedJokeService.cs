using System.Collections.Generic;

namespace JustWunderMobile.Common.Interfaces
{
    /// <summary>
    /// Interface which declare all functionality for working with approved jokes on application
    /// </summary>
    /// <typeparam name="TModel">Approved joke data model</typeparam>
    public interface IReleasedJokeService<TModel>
    {
        void UpdateJokes(IEnumerable<TModel> jokes);
        void RemoveJokes(IEnumerable<TModel> jokesToRemove);
        void RemoveAllJokes();
        IEnumerable<TModel> GetTopJokes(int count, int offset);
        int GetTopJokesCount();
        IEnumerable<TModel> GetLastJokes(int count, int offset);
        int GetLastJokesCount();
        IEnumerable<TModel> GetFavoriteJokes(int count, int offset);
        int GetFavoriteJokesCount();
    }
}
