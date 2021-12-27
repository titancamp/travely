using System.Collections.Generic;
using System.Threading.Tasks;

namespace Travely.ClientManager.Grpc.Client.Abstraction
{
    public interface IClientManagerServiceClient
    {
        Task<Models.Client> GetClientAsync(int clientId);
        Task<IEnumerable<Models.Client>> GetClientsAsync();
        Task<Models.Client> CreateClientAsync(Models.Client client);
        Task<Models.Client> EditClientAsync(Models.Client client);
        Task<bool> DeleteClientAsync(int clientId);
        public Task<IEnumerable<Models.Client>> CreateClients(int agencyId, IEnumerable<Models.Client> clients);
    }
}
