
using JustWunderMobile.Common.DAL.Entities;
using JustWunderMobile.Common.DataModels;

namespace JustWunderMobile.Common
{
    /// <summary>
    /// Class-converter Entity->Model and Model->Entity
    /// </summary>
    public static class EntityExtensions
    {
        #region ReleaseJoke
        /// <summary>
        /// Maps ReleaseJoke to ReleaseJokeDataModel.
        /// </summary>
        /// <param name="entity">ReleaseJoke</param>
        /// <returns>ReleaseJokeDataModel</returns>
        public static ReleaseJokeDataModel GetModel(this ReleaseJoke entity)
        {
            var model = new ReleaseJokeDataModel();
            model.Id = entity.Id;
            model.PublishDate = entity.PublishDate;
            model.Rating = entity.Rating;
            model.TextJoke = entity.TextJoke;
            model.UserEmail = entity.UserEmail;
            model.Censorship = entity.Censorship;

            return model;
        }

        /// <summary>
        /// Maps ReleaseJokeDataModel to ReleaseJoke.
        /// </summary>
        /// <param name="model">ReleaseJokeDataModel</param>
        /// <returns>ReleaseJoke</returns>
        public static ReleaseJoke GetEntity(this ReleaseJokeDataModel model)
        {
            var entity = new ReleaseJoke();
            entity.Id = entity.Id;
            entity.PublishDate = model.PublishDate;
            entity.Rating = model.Rating;
            entity.TextJoke = model.TextJoke;
            entity.UserEmail = model.UserEmail;
            entity.Censorship = model.Censorship;

            return entity;
        }
        #endregion

        #region NewJoke
        /// <summary>
        /// Maps NewJoke to NewJokeDataModel.
        /// </summary>
        /// <param name="entity">NewJoke</param>
        /// <returns>NewJokeDataModel</returns>
        public static NewJokeDataModel GetModel(this NewJoke entity)
        {
            var model = new NewJokeDataModel();
            model.Id = entity.Id;
            model.IsSent = entity.IsSent;
            model.TextJoke = entity.TextJoke;
            model.UserEmail = entity.UserEmail;
            model.DateAdded = entity.DateAdded;

            return model;
        }

        /// <summary>
        /// Maps NewJokeDataModel to NewJoke.
        /// </summary>
        /// <param name="model">NewJokeDataModel</param>
        /// <returns>NewJoke</returns>
        public static NewJoke GetEntity(this NewJokeDataModel model)
        {
            var entity = new NewJoke();
            entity.Id = entity.Id;
            entity.DateAdded = model.DateAdded;
            entity.TextJoke = model.TextJoke;
            entity.UserEmail = model.UserEmail;
            entity.IsSent = model.IsSent;

            return entity;
        }
        #endregion
    }
}