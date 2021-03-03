using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travely.IdentityManager.Repository.Abstractions.Entities;
using IdentityServer4.Models;

namespace IdentityManager.DataService.Mappers
{
    public static class PersistedGrantMapper
    {
        static PersistedGrantMapper()
        {
            Mapper = new MapperConfiguration(cfg => cfg.AddProfile<PersistedGrantMapperProfile>())
                .CreateMapper();
        }

        internal static IMapper Mapper { get; }

        /// <summary>
        /// Maps an entity to a model.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public static IdentityServer4.Models.PersistedGrant ToModel(this Travely.IdentityManager.Repository.Abstractions.Entities.PersistedGrant entity)
        {
            return entity == null ? null : Mapper.Map<IdentityServer4.Models.PersistedGrant>(entity);
        }

        /// <summary>
        /// Maps a model to an entity.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public static Travely.IdentityManager.Repository.Abstractions.Entities.PersistedGrant ToEntity(this IdentityServer4.Models.PersistedGrant model)
        {
            return model == null ? null : Mapper.Map<Travely.IdentityManager.Repository.Abstractions.Entities.PersistedGrant>(model);
        }

        /// <summary>
        /// Updates an entity from a model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="entity">The entity.</param>
        public static void UpdateEntity(this IdentityServer4.Models.PersistedGrant model, Travely.IdentityManager.Repository.Abstractions.Entities.PersistedGrant entity)
        {
            Mapper.Map(model, entity);
        }
    }
}
