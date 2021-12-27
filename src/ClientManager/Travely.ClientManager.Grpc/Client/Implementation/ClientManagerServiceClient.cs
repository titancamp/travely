using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travely.ClientManager.Grpc.Client.Abstraction;
using Travely.Common.Grpc;
using Travely.Common.Grpc.Abstraction;

namespace Travely.ClientManager.Grpc.Client.Implementation
{
    public class ClientManagerServiceClient : GrpcClientBase<ClientProtoService.ClientProtoServiceClient>, IClientManagerServiceClient
    {
        private readonly IMapper _mapper;

        public ClientManagerServiceClient(
            IServiceSettingsProvider<ClientProtoService.ClientProtoServiceClient> serviceSettingsProvider,
            IMapper mapper)
            : base(serviceSettingsProvider)
        {
            _mapper = mapper;
        }

        public Task<IEnumerable<Models.Client>> GetClientsAsync()
        {
            return HandleAsync(async (grpcClient) =>
            {
                var clients = await grpcClient.GetAllClientsAsync(new GetAllClientsRequest());
                return clients.Clients_.Select(c => _mapper.Map<Models.Client>(c));
            });
        }

        public Task<Models.Client> GetClientAsync(int clientId)
        {
            return HandleAsync(async (grpcClient) =>
            {
                var response = await grpcClient.GetClientAsync(new GetClientRequest { Id = clientId });
                return _mapper.Map<ClientModel, Models.Client>(response);
            });
        }

        public Task<Models.Client> CreateClientAsync(Models.Client client)
        {
            return HandleAsync(async (grpcClient) =>
            {
                var newClient = _mapper.Map<Models.Client, ClientModel>(client);

                var addedClient = await grpcClient.CreateClientAsync(new CreateClientRequest
                {
                    Client = newClient,
                });

                return _mapper.Map<ClientModel, Models.Client>(addedClient);
            });
        }

        public Task<Models.Client> EditClientAsync(Models.Client client)
        {
            return HandleAsync(async (grpcClient) =>
            {
                var clientModel = _mapper.Map<Models.Client, ClientModel>(client);

                var result = await grpcClient.UpdateClientAsync(new UpdateClientRequest { Client = clientModel });

                return _mapper.Map<ClientModel, Models.Client>(result);
            });
        }

        public Task<bool> DeleteClientAsync(int clientId)
        {
            return HandleAsync(async (grpcClient) =>
            {
                var result = await grpcClient.DeleteClientAsync(new DeleteClientRequest { Id = clientId });
                return result.Success;
            });
        }

        public Task<IEnumerable<Models.Client>> CreateClients(int agencyId, IEnumerable<Models.Client> clients)
        {
            return HandleAsync(async (grpcClient) =>
            {
                var newClients = _mapper.Map<IEnumerable<Models.Client>, IEnumerable<ClientModel>>(clients).ToList();
                var list = new List<ClientModel>();
                foreach (var client in newClients)
                {
                    client.AgencyId = agencyId;
                    var response = await grpcClient.CreateClientAsync(new CreateClientRequest
                    {
                        Client = client
                    });

                    list.Add(response);
                }

                return _mapper.Map<IEnumerable<Models.Client>>(list);
            });
        }
    }
}
