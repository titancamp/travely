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
    public class ReceivableService : IReceivableService
    {
        private readonly IMapper _mapper;

        private readonly IPaymentRepository<ReceivableEntity> _repository;

        private readonly ISortHelper<ReceivableEntity> _sortHelper;

        private readonly ISearchHelper<ReceivableEntity> _searchHelper;
        public ReceivableService(IMapper mapper,
                                 IPaymentRepository<ReceivableEntity> repository,
                                 ISortHelper<ReceivableEntity> sortHelper,
                                 ISearchHelper<ReceivableEntity> searchHelper)
        {
            _mapper = mapper;
            _repository = repository;
            _sortHelper = sortHelper;
            _searchHelper = searchHelper;
        }

        public async Task<ReceivablePage> Get(int agencyId, PaymentQueryParameters parameters)
        {
            var query = await _repository.GetAll(agencyId);

            query = _sortHelper.ApplySort(query, parameters.OrderBy);

            query = _searchHelper.ApplySearch(query, parameters.Search);

            return ReceivablePage.GetReceivablePage(query, _mapper, parameters.Index, parameters.Size);
        }

        public async Task<ReceivableRead> Get(int agencyId, int id)
        {
            var data = await _repository.GetById(agencyId, id);

            return _mapper.Map<ReceivableRead>(data);
        }

        public async Task<ReceivableRead> Create(int agencyId, ReceivableCreate model)
        {
            var entity = _mapper.Map<ReceivableEntity>(model);
            entity.AgencyId = agencyId;

            var newModel = await _repository.Add(entity);

            return _mapper.Map<ReceivableRead>(newModel);
        }

        public async Task CreateRange(int agencyId, List<ReceivableCreate> models)
        {
            var entities = _mapper.Map<List<ReceivableEntity>>(models);
            foreach (var entity in entities)
            {
                entity.AgencyId = agencyId;
            }

            await _repository.AddRange(entities);
        }

        public async Task<ReceivableRead> Update(int agencyId, int id, ReceivableUpdate model)
        {
            var entity = await _repository.GetById(agencyId, id);
            _mapper.Map<ReceivableUpdate, ReceivableEntity>(model, entity);
            //entity.AgencyId = agencyId;
            var updatedEntity = await _repository.Update(entity);
            return _mapper.Map<ReceivableRead>(updatedEntity);
        }

        public async Task Remove(int agencyId, int id)
        {
            var entity = await _repository.GetById(agencyId, id);
            await _repository.Remove(entity);
        }
    }
}
