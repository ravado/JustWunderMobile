using JustWunderMobile.Common.DAL.Entities;
using JustWunderMobile.Common.DataModels;

namespace JustWunderMobile.Common.Mapping
{
    /// <summary>
    /// Class-converter Entity->DataModel, DataModel->Entity, DTO->Entity and Entity->DTO
    /// </summary>
    public static class MappingExtensions
    {
        #region ReleaseJoke
        /// <summary>
        /// Maps ReleaseJoke to ReleaseJokeDataModel.
        /// </summary>
        /// <param name="entity">ReleaseJoke</param>
        /// <returns>ReleaseJokeDataModel</returns>
        public static ReleaseJokeDataModel GetModel(this ReleaseJoke entity)
        {
            var model = new ReleaseJokeDataModel
            {
                Id = entity.Id,
                PublishDate = entity.PublishDate,
                Rating = entity.Rating,
                TextJoke = entity.TextJoke,
                UserEmail = entity.UserEmail,
                Censorship = entity.Censorship,
                Vote = entity.Vote,
                Favorite = entity.Favorite
            };

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
            entity.Vote = model.Vote;
            entity.Favorite = model.Favorite;

            return entity;
        }

        #region DTO Mapping
        /// <summary>
        /// Maps ReleaseJokeDTO to ReleaseJoke entity.
        /// </summary>
        /// <param name="dto">ReleaseJokeDTO</param>
        /// <returns>ReleaseJoke entity</returns>
        public static ReleaseJoke GetEntity(this SAL.Interfaces.IApiReleaseJoke dto)
        {
            var entity = new ReleaseJoke
            {
                Id = dto.Id,
                PublishDate = dto.PublishDate,
                Rating = dto.Rating,
                TextJoke = dto.TextJoke,
                UserEmail = dto.UserEmail,
                Censorship = dto.Censorship
            };

            return entity;
        }

        /// <summary>
        /// Maps ReleaseJoke entity to ReleaseJokeDTO.
        /// </summary>
        /// <param name="entity">ReleaseJoke entity</param>
        /// <returns>ReleaseJoke DTO</returns>
        public static SAL.Interfaces.IApiReleaseJoke GetDto(this ReleaseJoke entity)
        {
            var dto = new SAL.DTO.ReleaseJokeDto
            {
                Id = entity.Id,
                PublishDate = entity.PublishDate,
                Rating = entity.Rating,
                TextJoke = entity.TextJoke,
                UserEmail = entity.UserEmail,
                Censorship = entity.Censorship
            };

            return dto;
        }
        #endregion

        #endregion

        #region NewJoke
        /// <summary>
        /// Maps NewJoke to NewJokeDataModel.
        /// </summary>
        /// <param name="entity">NewJoke</param>
        /// <returns>NewJokeDataModel</returns>
        public static NewJokeDataModel GetModel(this NewJoke entity)
        {
            var model = new NewJokeDataModel
            {
                Id = entity.Id,
                IsSent = entity.IsSend,
                TextJoke = entity.TextJoke,
                UserEmail = entity.UserEmail,
                DateAdded = entity.DateAdded
            };

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
            entity.IsSend = model.IsSent;

            return entity;
        }

        #region DTO Mapping

        /// <summary>
        /// Maps NewJoke entity to NewJoke DTO.
        /// </summary>
        /// <param name="entity">NewJoke entity</param>
        /// <returns>NewJoke DTO</returns>
        public static SAL.Interfaces.IApiInboxJoke GetDto(this NewJoke entity)
        {
            var dto = new SAL.DTO.InboxJokeDto
            {
                Id = entity.Id,
                TextJoke = entity.TextJoke,
                UserEmail = entity.UserEmail
            };

            return dto;
        }
        #endregion

        #endregion
    }
}