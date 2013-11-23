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

        #region DTO Mapping
        /// <summary>
        /// Maps ReleaseJokeDTO to ReleaseJoke entity.
        /// </summary>
        /// <param name="dto">ReleaseJokeDTO</param>
        /// <returns>ReleaseJoke entity</returns>
        public static ReleaseJoke GetEntity(this SAL.Interfaces.IApiReleaseJoke dto)
        {
            var entity = new ReleaseJoke();
            entity.Id = dto.Id;
            entity.PublishDate = dto.PublishDate;
            entity.Rating = dto.Rating;
            entity.TextJoke = dto.TextJoke;
            entity.UserEmail = dto.UserEmail;
            entity.Censorship = dto.Censorship;

            return entity;
        }

        /// <summary>
        /// Maps ReleaseJoke entity to ReleaseJokeDTO.
        /// </summary>
        /// <param name="entity">ReleaseJoke entity</param>
        /// <returns>ReleaseJoke DTO</returns>
        public static SAL.Interfaces.IApiReleaseJoke GetDTO(this ReleaseJoke entity)
        {
            var dto = new SAL.DTO.ReleaseJoke();
            dto.Id = entity.Id;
            dto.PublishDate = entity.PublishDate;
            dto.Rating = entity.Rating;
            dto.TextJoke = entity.TextJoke;
            dto.UserEmail = entity.UserEmail;
            dto.Censorship = entity.Censorship;

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

        #region DTO Mapping

        /// <summary>
        /// Maps NewJoke entity to NewJoke DTO.
        /// </summary>
        /// <param name="entity">NewJoke entity</param>
        /// <returns>NewJoke DTO</returns>
        public static SAL.Interfaces.IApiInboxJoke GetDTO(this NewJoke entity)
        {
            var dto = new SAL.DTO.InboxJoke();
            dto.Id = entity.Id;
            dto.TextJoke = entity.TextJoke;
            dto.UserEmail = entity.UserEmail;

            return dto;
        }
        #endregion

        #endregion
    }
}