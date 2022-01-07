using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Travely.SupplierManager.API.Models;
using Travely.SupplierManager.Repository;
using Travely.SupplierManager.Repository.Entities;
using Travely.SupplierManager.Service.Helpers;
using Travely.SupplierManager.Service.Models;

namespace Travely.SupplierManager.Service
{
    public class SupplierService<TModel, TEntity> : ISupplierService<TModel>
        where TModel : class
        where TEntity : class, IEntity
    {
        private readonly IMapper _mapper;
        private readonly ISupplierRepository<TEntity> _supplierRepository;
        private readonly ISearchHelper<TEntity> _searchHelper;
        private readonly ISortHelper<TEntity> _sortHelper;

        public SupplierService(IMapper mapper,
            ISupplierRepository<TEntity> supplierRepository,
            ISearchHelper<TEntity> searchHelper,
            ISortHelper<TEntity> sortHelper )
        {
            _mapper = mapper;
            _supplierRepository = supplierRepository;
            _searchHelper = searchHelper;
            _sortHelper = sortHelper;
        }
        
        public async Task<SupplierPage<TModel>> Get(int agencyId, SupplierQueryParams parameters)
        {
            var query = await _supplierRepository.GetAll(agencyId);
            query = _searchHelper.Search(query, parameters.Search);
            query = _sortHelper.Order(query, parameters.OrderBy);
            
            return SupplierPage<TModel>.GetPagedSuppliers<TEntity>(query, _mapper, parameters);
        }

        public async Task<List<TModel>> GetAll(int agencyId)
        {
            var data = await _supplierRepository.GetAll(agencyId);
            
            return _mapper.Map<List<TModel>>(data);
        }

        public async Task<TModel> Get(int agencyId, int id)
        {
            var data = await _supplierRepository.GetById(agencyId, id);

            return _mapper.Map<TModel>(data);
        }

        public async Task<TModel> Create(int agencyId, TModel model)
        {
            var entity = _mapper.Map<TEntity>(model);
            entity.AgencyId = agencyId;

            var newModel = await _supplierRepository.Add(entity);

            return _mapper.Map<TModel>(newModel);
        }

        public async Task<TModel> Update(int agencyId, int id, TModel model)
        {
            var entity = await _supplierRepository.GetById(agencyId, id);
            
            if (entity == null)
            {
                return _mapper.Map<TModel>(entity);
            }
            
            _mapper.Map<TModel, TEntity>(model, entity);
            var updatedEntity = await _supplierRepository.Update(entity);
            return _mapper.Map<TModel>(updatedEntity);
        }

        public async Task Remove(int agencyId, int id)
        {
            var entity = await _supplierRepository.GetById(agencyId, id);
            await _supplierRepository.Remove(entity);
        }
    }
}