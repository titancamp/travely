using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Travely.SupplierManager.API.Models;
using Travely.SupplierManager.Repository;
using Travely.SupplierManager.Repository.Entities;
using Travely.SupplierManager.Repository.Filters;
using Travely.SupplierManager.Service.Models;

namespace Travely.SupplierManager.Service
{
    public class SupplierService<TModel, TEntity, TFilter> : ISupplierService<TModel, TFilter>
        where TModel : class
        where TEntity : class, IEntity
        where TFilter : Filter<TEntity>
    {
        private readonly IMapper _mapper;
        private readonly ISupplierRepository<TEntity> _supplierRepository;

        public SupplierService(IMapper mapper,
            ISupplierRepository<TEntity> supplierRepository)
        {
            _mapper = mapper;
            _supplierRepository = supplierRepository;
        }
        
        public SupplierPage<TModel> Get(int agencyId, SupplierQueryParams parameters, TFilter filters)
        {
            var query = _supplierRepository.GetAll(agencyId, filters);
            
            return SupplierPage<TModel>.GetPagedSuppliers<TEntity>(query, _mapper, parameters);
        }

        public async Task<TModel> GetAsync(int agencyId, int id)
        {
            var data = await _supplierRepository.GetByIdAsync(agencyId, id);

            return _mapper.Map<TModel>(data);
        }

        public async Task<TModel> CreateAsync(int agencyId, TModel model)
        {
            var entity = _mapper.Map<TEntity>(model);
            entity.AgencyId = agencyId;

            var newModel = await _supplierRepository.AddAsync(entity);

            return _mapper.Map<TModel>(newModel);
        }

        public async Task<TModel> UpdateAsync(int agencyId, int id, TModel model)
        {
            var entity = await _supplierRepository.GetByIdAsync(agencyId, id);
            
            if (entity == null)
            {
                return _mapper.Map<TModel>(entity);
            }
            
            _mapper.Map<TModel, TEntity>(model, entity);
            var updatedEntity = await _supplierRepository.UpdateAsync(entity);
            return _mapper.Map<TModel>(updatedEntity);
        }

        public async Task RemoveAsync(int agencyId, int id)
        {
            var entity = await _supplierRepository.GetByIdAsync(agencyId, id);
            await _supplierRepository.RemoveAsync(entity);
        }
    }
}