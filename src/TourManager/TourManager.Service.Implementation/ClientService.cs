using System.Collections.Generic;
using System.Threading.Tasks;
using TourManager.Repository.Abstraction;
using TourManager.Service.Abstraction;
using TourManager.Service.Implementation.Mappers;
using TourManager.Service.Model;

namespace TourManager.Service.Implementation
{
    /// <summary>
    /// The bookings service interface
    /// </summary>
    public class ClientService : IClientService
    {
        /// <summary>
        /// The client repository
        /// </summary>
        private readonly IClientRepository clientRepository;

        /// <summary>
        ///  Create new instance of client service
        /// </summary>
        /// <param name="clientRepository">The client repository</param>
        public ClientService(IClientRepository clientRepository)
        {
            this.clientRepository = clientRepository;
        }

        /// <summary>
        /// Get the clients of a tour
        /// </summary>
        /// <param name="tourId">The tour id</param>
        /// <returns></returns>
        public async Task<List<Client>> GetClients(int tourId)
        {
            var result = await this.clientRepository.GetAll(tourId);

            return ClientMapper.MapFrom(result);
        }

        /// <summary>
        /// Get specific client by id 
        /// </summary>
        /// <param name="clientId">The client id</param>
        /// <returns></returns>
        public async Task<Client> GetClientById(int clientId)
        {
            var result = await this.clientRepository.GetById(clientId);

            return ClientMapper.MapFromSingle(result);
        }

        /// <summary>
        /// Create new client
        /// </summary>
        /// <param name="client">The client to create</param>
        /// <returns></returns>
        public async Task CreateClient(Client client)
        {
            await this.clientRepository.Add(ClientMapper.MapToSingle(client));
        }

        /// <summary>
        /// Update the specific client
        /// </summary>
        /// <param name="client">The client to update</param>
        /// <returns></returns>
        public async Task UpdateClient(Client client)
        {
            await this.clientRepository.Update(ClientMapper.MapToSingle(client));
        }

        /// <summary>
        /// Remove specific client by id
        /// </summary>
        /// <param name="clientId">The client id to remove</param>
        /// <returns></returns>
        public async Task RemoveClient(int clientId)
        {
            var result = await this.clientRepository.GetById(clientId);

            await this.clientRepository.Remove(result);
        }
    }
}