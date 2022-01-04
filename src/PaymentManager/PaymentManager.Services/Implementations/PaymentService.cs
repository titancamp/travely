using AutoMapper;
using PaymentManager.Services.Models;
using PaymentManager.Repositories;
using PaymentManager.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentManager.Services
{
    public class PaymentService : IPayableService
    {
        private readonly IMapper _mapper;

        private readonly IPayableRepository _repository;

        public PaymentService(IMapper mapper, IPayableRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<List<PayableRead>> GetAll(int agencyId)
        {
            var data = await _repository.GetAll(agencyId);

            return _mapper.Map<List<PayableRead>>(data);
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
    }
}
