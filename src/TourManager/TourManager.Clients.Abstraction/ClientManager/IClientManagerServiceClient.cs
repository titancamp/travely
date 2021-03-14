using System.Collections.Generic;
using System.Threading.Tasks;
using TourManager.Service.Model;

namespace TourManager.Clients.Abstraction.ClientManager
{
	public interface IClientManagerServiceClient
	{
		Task<Client> GetClientAsync(int clientId);
		Task<IEnumerable<Client>> GetClientsAsync();
		Task<Client> CreateClientAsync(Client client);
		Task<Client> EditClientAsync(Client client);
		Task<bool> DeleteClientAsync(int clientId);
	}
}
