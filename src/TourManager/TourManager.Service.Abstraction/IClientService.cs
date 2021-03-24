using System.Collections.Generic;
using System.Threading.Tasks;
using TourManager.Service.Model;

namespace TourManager.Service.Abstraction
{
    /// <summary>
    /// The clients service interface
    /// </summary>
    public interface IClientService
    {
        /// <summary>
        /// Get the clients by tenant
        /// </summary>
        /// <param name="tenantId">The tenant id</param>
        /// <returns></returns>
        public Task<List<Client>> GetClients(int tenantId);

        /// <summary>
        /// Get specific client by id 
        /// </summary>
        /// <param name="clientId">The client id</param>
        /// <returns></returns>
        public Task<Client> GetClientById(int clientId);

        /// <summary>
        /// Create new client
        /// </summary>
        /// <param name="client">The client to create</param>
        /// <returns></returns>
        public Task CreateClient(Client client);

        /// <summary>
        /// Update the specific client
        /// </summary>
        /// <param name="client">The client to update</param>
        /// <returns></returns>
        public Task UpdateClient(Client client);

        /// <summary>
        /// Remove specific client by id
        /// </summary>
        /// <param name="clientId">The client id to remove</param>
        /// <returns></returns>
        public Task RemoveClient(int clientId);

        /// <summary>
        /// Create several clients
        /// </summary>
        /// <param name="clients">The client list to create</param>
        /// <returns>created clients</returns>
        Task CreateClients(int tenantId, int tourId, IEnumerable<Client> clients);
    }
}