using IdentityManager.DataService.Mappers;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Stores;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travely.IdentityManager.Repository.Abstractions;

namespace IdentityManager.DataService.IdentityServices
{
    public class PersistedGrantStore : IPersistedGrantStore
    {
        IPersistGrantRepository _persistGrantRepository;
        IUnitOfWork _unitOfWork;
        ILogger _logger;
        public PersistedGrantStore(ILogger logger, IPersistGrantRepository persistGrantRepository, IUnitOfWork unitOfWork)
        {
            _persistGrantRepository = persistGrantRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<IEnumerable<PersistedGrant>> GetAllAsync(PersistedGrantFilter filter)
        {
            filter.Validate();

            var persistedGrants = await Filter(_persistGrantRepository.GetAll(), filter).ToArrayAsync();
            persistedGrants = Filter(persistedGrants.AsQueryable(), filter).ToArray();

            var model = persistedGrants.Select(x => x.ToModel());

            _logger.LogDebug("{persistedGrantCount} persisted grants found for {@filter}", persistedGrants.Length, filter);

            return model;
        }

        public async Task<PersistedGrant> GetAsync(string key)
        {
            var persistedGrant = (await _persistGrantRepository.GetAll().Where(x => x.Key == key).ToArrayAsync())
               .SingleOrDefault(x => x.Key == key);
            var model = persistedGrant?.ToModel();

            _logger.LogDebug("{persistedGrantKey} found in database: {persistedGrantKeyFound}", key, model != null);

            return model;
        }

        public async Task RemoveAllAsync(PersistedGrantFilter filter)
        {
            filter.Validate();

            var persistedGrants = await Filter(_persistGrantRepository.GetAll(), filter).ToArrayAsync();
            persistedGrants = Filter(persistedGrants.AsQueryable(), filter).ToArray();

            _logger.LogDebug("removing {persistedGrantCount} persisted grants from database for {@filter}", persistedGrants.Length, filter);



            foreach (var item in persistedGrants)
            {
                _persistGrantRepository.Remove(item);
            }


            await _unitOfWork.SaveChangesAsync();

        }

        public async Task RemoveAsync(string key)
        {
            var persistedGrant = (await _persistGrantRepository.GetAll().Where(x => x.Key == key).ToArrayAsync())
               .SingleOrDefault(x => x.Key == key);
            if (persistedGrant != null)
            {
                _logger.LogDebug("removing {persistedGrantKey} persisted grant from database", key);

                _persistGrantRepository.Remove(persistedGrant);


                await _unitOfWork.SaveChangesAsync();

            }
            else
            {
                _logger.LogDebug("no {persistedGrantKey} persisted grant found in database", key);
            }
        }

        public async Task StoreAsync(PersistedGrant grant)
        {
            var existing = (await _persistGrantRepository.GetAll().Where(x => x.Key == grant.Key).ToArrayAsync())
                .SingleOrDefault(x => x.Key == grant.Key);
            if (existing == null)
            {
                _logger.LogDebug("{persistedGrantKey} not found in database", grant.Key);

                var persistedGrant = grant.ToEntity();// map to db model
                _persistGrantRepository.Add(persistedGrant);
            }
            else
            {
                _logger.LogDebug("{persistedGrantKey} found in database", grant.Key);



                grant.UpdateEntity(existing);
            }


            await _unitOfWork.SaveChangesAsync();

        }

        private IQueryable<Travely.IdentityManager.Repository.Abstractions.Entities.PersistedGrant> Filter(IQueryable<Travely.IdentityManager.Repository.Abstractions.Entities.PersistedGrant> query, PersistedGrantFilter filter)
        {
            if (!String.IsNullOrWhiteSpace(filter.ClientId))
            {
                query = query.Where(x => x.ClientId == filter.ClientId);
            }
            //if (!String.IsNullOrWhiteSpace(filter.SessionId))
            //{
            //    query = query.Where(x => x.SessionId == filter.SessionId);
            //}
            if (!String.IsNullOrWhiteSpace(filter.SubjectId))
            {
                query = query.Where(x => x.SubjectId == filter.SubjectId);
            }
            if (!String.IsNullOrWhiteSpace(filter.Type))
            {
                query = query.Where(x => x.Type == filter.Type);
            }

            return query;
        }
    }
}
