using AutoMapper;
using PaymentManager.Services.Models;
using PaymentManager.Repositories;
using PaymentManager.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaymentManager.Extensions.DependencyInjection.Extensions;
using PaymentManager.Repositories.Filters;
using PaymentManager.Repositories.Models;
using PaymentManager.Shared;

namespace PaymentManager.Services
{
    public class ReceivableService : IReceivableService
    {
        private readonly IMapper _mapper;

        private readonly IPaymentRepository<ReceivableEntity> _repository;


        public ReceivableService(IMapper mapper,
                                 IPaymentRepository<ReceivableEntity> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public ReceivablePage Get(int agencyId, PaymentQueryParameters parameters, ReceivableFilter filter)
        {
            var query = _repository.GetAll(agencyId, false, parameters, filter);

            return query.GetReceivablePage(_mapper, parameters.Index, parameters.Size);
        }

        public async Task<ReceivableRead> GetAsync(int agencyId, int id)
        {
            var data = await _repository.GetByIdAsync(agencyId, id);

            return _mapper.Map<ReceivableRead>(data);
        }

        public async Task<ReceivableRead> CreateAsync(int agencyId, ReceivableCreate model)
        {
            var entity = _mapper.Map<ReceivableEntity>(model);
            entity.AgencyId = agencyId;

            var newModel = await _repository.AddAsync(entity);

            return _mapper.Map<ReceivableRead>(newModel);
        }

        public async Task CreateRangeAsync(int agencyId, List<ReceivableCreate> models)
        {
            var entities = _mapper.Map<List<ReceivableEntity>>(models);
            foreach (var entity in entities)
            {
                entity.AgencyId = agencyId;
            }

            await _repository.AddRangeAsync(entities);
        }

        public async Task<ReceivableRead> UpdateAsync(int agencyId, int id, ReceivableUpdate model)
        {
            var entity = await _repository.GetByIdAsync(agencyId, id);
            _mapper.Map<ReceivableUpdate, ReceivableEntity>(model, entity);
            var updatedEntity = await _repository.UpdateAsync(entity);
            return _mapper.Map<ReceivableRead>(updatedEntity);
        }
    }
}
