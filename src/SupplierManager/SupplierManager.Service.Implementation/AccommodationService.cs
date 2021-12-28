using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using SupplierManager.Repository.Abstraction.Abstraction;
using SupplierManager.Repository.Abstraction.Entities;
using SupplierManager.Service.Abstraction;
using SupplierManager.Service.Models;

namespace SupplierManager.Service.Implementation
{
    public class AccommodationService : ISupplierService<Accommodation>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AccommodationEntity> _repository;

        public AccommodationService(IMapper mapper, IRepository<AccommodationEntity> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<List<Accommodation>> GetAll()
        {
            var data = await _repository.GetAll();

            return _mapper.Map<List<Accommodation>>(data);
        }

        public async Task<Accommodation> Get(int id)
        {
            var data = await _repository.GetById(id);

            return _mapper.Map<Accommodation>(data);
        }

        public async Task<Accommodation> Create(Accommodation model)
        {
            var entity = _mapper.Map<AccommodationEntity>(model);

            var newModel = await _repository.Add(entity);

            return _mapper.Map<Accommodation>(newModel);
        }

        public async Task<Accommodation> Update(int id, Accommodation model)
        {
            var entity = _mapper.Map<AccommodationEntity>(model);
            entity.Id = id;
            var updatedEntity = await _repository.Update(entity);

            return _mapper.Map<Accommodation>(updatedEntity);
        }

        public async Task Remove(int id)
        {
            var entity = await _repository.GetById(id);
            await _repository.Remove(entity);
        }
    }
}