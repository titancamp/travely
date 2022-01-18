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
    public class PayableService : IPayableService
    {
        private readonly IMapper _mapper;

        private readonly IPaymentRepository<PayableEntity> _repository;

        public PayableService(IMapper mapper,
                              IPaymentRepository<PayableEntity> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public PayablePage Get(int agencyId, PaymentQueryParameters parameters, PayableFilter filter)
        {
            var query = _repository.GetAll(agencyId, false, parameters, filter);

            return query.GetPayablePage(_mapper, parameters.Index, parameters.Size);
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
    }
}
