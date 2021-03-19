using Grpc.Net.Client;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TourManager.Clients.Abstraction.ClientManager;
using TourManager.Clients.Abstraction.Settings;
using TourManager.Service.Model;
using Travely.ClientManager.Service.Protos;
using static TourManager.Clients.Implementation.Mappers.Mapping;

namespace TourManager.Clients.Implementation.ClientManager
{
	public class ClientManagerServiceClient : IClientManagerServiceClient
	{
		private ClientProtoService.ClientProtoServiceClient _grpcClient;
		private readonly IServiceSettingsProvider _settingsProvider;

		public ClientManagerServiceClient(IServiceSettingsProvider settingsProvider)
		{
			_settingsProvider = settingsProvider;

			var channel = GrpcChannel.ForAddress(settingsProvider.ComposeClientServiceUrl());
			_grpcClient = new ClientProtoService.ClientProtoServiceClient(channel);
		}

		public async Task<IEnumerable<Client>> GetClientsAsync()
		{
			var clients = await _grpcClient.GetAllClientsAsync(new GetAllClientsRequest());
			return clients.Clients_.Select(c => Mapper.Map<Client>(c));
		}

		public async Task<Client> GetClientAsync(int clientId)
		{

			var client = await _grpcClient.GetClientAsync(new GetClientRequest { Id = clientId });
			return Mapper.Map<ClientModel, Client>(client);
		}

		public async Task<Client> CreateClientAsync(Client client)
		{
			var newClient = Mapper.Map<Client, ClientModel>(client);

			var addedClient = await _grpcClient.CreateClientAsync(new CreateClientRequest
			{
				Client = newClient,
			});

			return Mapper.Map<ClientModel, Client>(addedClient);
		}

		public async Task<Client> EditClientAsync(Client client)
		{

			var clientModel = Mapper.Map<Client, ClientModel>(client);

			var result = await _grpcClient.UpdateClientAsync(new UpdateClientRequest { Client = clientModel });

			return Mapper.Map<ClientModel, Client>(result);
		}

		public async Task<bool> DeleteClientAsync(int clientId)
		{
			var result = await _grpcClient.DeleteClientAsync(new DeleteClientRequest { Id = clientId });
			return result.Success;
		}
	}
}
