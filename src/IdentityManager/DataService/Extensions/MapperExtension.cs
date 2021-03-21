using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entityModel = Travely.IdentityManager.Repository.Abstractions.Entities;
using identityModel = IdentityServer4.Models;

namespace IdentityManager.DataService.Extensions
{
    public static class MapperExtension
    {
        /// <summary>
        /// Maps an entity to a model.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public static identityModel.PersistedGrant ToModel(this entityModel.PersistedGrant entity, IMapper mapper)
        {
            return entity == null ? null : mapper.Map<identityModel.PersistedGrant>(entity);
        }

        /// <summary>
        /// Maps a model to an entity.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public static entityModel.PersistedGrant ToEntity(this identityModel.PersistedGrant model, IMapper mapper)
        {
            return model == null ? null : mapper.Map<entityModel.PersistedGrant>(model);
        }

        /// <summary>
        /// Updates an entity from a model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="entity">The entity.</param>
        public static void UpdateEntity(this identityModel.PersistedGrant model, entityModel.PersistedGrant entity, IMapper mapper)
        {
            mapper.Map(model, entity);
        }
    }
}
