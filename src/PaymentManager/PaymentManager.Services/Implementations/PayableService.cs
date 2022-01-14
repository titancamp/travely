using AutoMapper;
using PaymentManager.Services.Models;
using PaymentManager.Repositories;
using PaymentManager.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaymentManager.Shared;
using PaymentManager.Services.Helpers;
using System.Linq.Expressions;

namespace PaymentManager.Services
{
    public class PayableService : IPayableService
    {
        private readonly IMapper _mapper;

        private readonly IPaymentRepository<PayableEntity> _repository;

        private readonly ISortHelper<PayableEntity> _sortHelper;

        private readonly ISearchHelper<PayableEntity> _searchHelper;
        public PayableService(IMapper mapper,
                              IPaymentRepository<PayableEntity> repository,
                              ISortHelper<PayableEntity> sortHelper,
                              ISearchHelper<PayableEntity> searchHelper)
        {
            _mapper = mapper;
            _repository = repository;
            _sortHelper = sortHelper;
            _searchHelper = searchHelper;
        }

        public PayablePage Get(int agencyId, PaymentQueryParameters parameters)
        {
            var query = _repository.GetAll(agencyId, false);

            query = _sortHelper.ApplySort(query, parameters.OrderBy);

            query = _searchHelper.ApplySearch(query, parameters.Search);

            return PayablePage.GetPayablePage(query, _mapper, parameters.Index, parameters.Size);
        }

        public async Task<PayableRead> GetAsync(int agencyId, int id)
        {
            var data = await _repository.GetByIdAsync(agencyId, id);

            return _mapper.Map<PayableRead>(data);
        }

        public async Task<PayableRead> CreateAsync(int agencyId, PayableCreate model)
        {
            var entity = _mapper.Map<PayableEntity>(model);
            entity.AgencyId = agencyId;

            var newModel = await _repository.AddAsync(entity);

            return _mapper.Map<PayableRead>(newModel);
        }

        public async Task CreateRangeAsync(int agencyId, List<PayableCreate> models)
        {
            var entities = _mapper.Map<List<PayableEntity>>(models);
            foreach (var entity in entities)
            {
                entity.AgencyId = agencyId;
            }

            await _repository.AddRangeAsync(entities);
        }

        public async Task<PayableRead> UpdateAsync(int agencyId, int id, PayableUpdate model)
        {
            var entity = await _repository.GetByIdAsync(agencyId, id);
            _mapper.Map<PayableUpdate, PayableEntity>(model, entity);
            var updatedEntity = await _repository.UpdateAsync(entity);
            return _mapper.Map<PayableRead>(updatedEntity);
        }

        public async Task UpdateSupplier(int agencyId, int id, PayableSupplierUpdate model)
        {
            var entityQuery = await _repository.Find(m => m.AgencyId == agencyId && m.SupplierId == model.SupplierId);
            var payables = entityQuery.ToList();

            foreach (var payable in entityQuery)
            {
                payable.SupplierName = model.SupplierName;
            }

            await _repository.UpdateRange(payables);
        }

        public async Task UpdatePayablesTourStatus(int agencyId, int tourId, int tourStatus)
        {
            var payables = await _repository.Find(m => m.AgencyId == agencyId && m.TourId == tourId);
            var model = payables.ToList();
            foreach (var payable in model)
            {
                payable.TourStatus = (TourStatus)tourStatus;
            }

            await _repository.UpdateRange(model);
        }

        public async Task DeleteSupplierFromPayable(int agencyId, int tourId, int supplierId)
        {
            var payables = await this.Find(m => m.AgencyId == agencyId && m.TourId == tourId && m.SupplierId == supplierId);
            if (payables.Count != 1)
            {
                throw new Exception(); //????
            }

            await this.Remove(agencyId, payables[0].Id);
        }

        public async Task Remove(int agencyId, int id)
        {
            var entity = await _repository.GetById(agencyId, id);
            await _repository.Remove(entity);
        }

        public async Task<List<PayableRead>> Find(Expression<Func<PayableEntity, bool>> predicate)
        {
            var payables = await _repository.Find(predicate);

            return _mapper.Map<List<PayableRead>>(payables);
        }
    }
}
