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

        public async Task<PayablePage> Get(int agencyId, PaymentQueryParameters parameters)
        {
            var query = await _repository.GetAll(agencyId);

            query = _sortHelper.ApplySort(query, parameters.OrderBy);

            query = _searchHelper.ApplySearch(query, parameters.Search);

            return PayablePage.GetPayablePage(query, _mapper, parameters.Index, parameters.Size);
        }

        public async Task<PayableRead> Get(int agencyId, int id)
        {
            var data = await _repository.GetById(agencyId, id);

            return _mapper.Map<PayableRead>(data);
        }

        public async Task<PayableRead> Create(int agencyId, PayableCreate model)
        {
            var entity = _mapper.Map<PayableEntity>(model);
            entity.AgencyId = agencyId;

            var newModel = await _repository.Add(entity);

            return _mapper.Map<PayableRead>(newModel);
        }

        public async Task CreateRange(int agencyId, List<PayableCreate> models)
        {
            var entities = _mapper.Map<List<PayableEntity>>(models);
            foreach (var entity in entities)
            {
                entity.AgencyId = agencyId;
            }

            await _repository.AddRange(entities);
        }

        public async Task<PayableRead> Update(int agencyId, int id, PayableUpdate model)
        {
            var entity = await _repository.GetById(agencyId, id);
            _mapper.Map<PayableUpdate, PayableEntity>(model, entity);
            //entity.AgencyId = agencyId;
            var updatedEntity = await _repository.Update(entity);
            return _mapper.Map<PayableRead>(updatedEntity);
        }

        public async Task Remove(int agencyId, int id)
        {
            var entity = await _repository.GetById(agencyId, id);
            await _repository.Remove(entity);
        }

        public async Task<List<PayableRead>> Find(int agencyId, int tourId)
        {
            var payables = await _repository.Find(m => m.TourId == tourId && m.AgencyId == agencyId);

            return _mapper.Map<List<PayableRead>>(payables);
        }
    }
}
