using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travely.ClientManager.Repository.Abstraction;
using Travely.ClientManager.Repository.Entity.Client;
using Travely.ClientManager.Service.Protos;

namespace Travely.ClientManager.Service.Services
{
    public class ClientService : ClientProtoService.ClientProtoServiceBase
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ClientService> _logger;
        public ClientService(ILogger<ClientService> logger, IClientRepository clientRepository, IMapper mapper)
        {
            _logger = logger;
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        #region Get
        public override async Task<ClientModel> GetClient(GetClientRequest request,
                                                                ServerCallContext context)
        {
            try
            {                
                Client client = await _clientRepository.GetNoTracking(x => x.Id == request.Id).FirstOrDefaultAsync();

                if (client == null)
                {
                    throw new RpcException(new Status(StatusCode.NotFound, $"Client with ID={request.Id} is not found."));
                }

                ClientModel clientModel = _mapper.Map<ClientModel>(client);

                return clientModel;
            }
            catch (Exception ex)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $"Client with ID={request.Id} is not found."));
            }


        }

        public override async Task<ClientWithPreferencesModel> GetClientWithPreferences(GetClientRequest request,
                                                                ServerCallContext context)
        {
            try
            {
                Client client = await _clientRepository.GetNoTracking(x => x.Id == request.Id, "Preferences").FirstOrDefaultAsync();

                if (client == null)
                {
                    throw new RpcException(new Status(StatusCode.NotFound, $"Client with ID={request.Id} is not found."));
                }

                ClientWithPreferencesModel clientPreferencesModel = _mapper.Map<ClientWithPreferencesModel>(client);
                
                return clientPreferencesModel;
            }
            catch (Exception ex)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $"Client with ID={request.Id} is not found."));
            }
        }

        public override async Task GetAllClients(GetAllClientsRequest request,
                                                    IServerStreamWriter<ClientModel> responseStream,
                                                    ServerCallContext context)
        {
            List<Client> clientList = await _clientRepository.GetNoTracking().ToListAsync();

            foreach (var client in clientList)
            {
                try
                {
                    ClientModel clientModel = _mapper.Map<ClientModel>(client);

                    await responseStream.WriteAsync(clientModel);
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
        }
        #endregion

        #region Add
        public override async Task<ClientModel> AddClient(AddClientRequest request, ServerCallContext context)
        {
            Client client = _mapper.Map<Client>(request.Client);

            _clientRepository.Add(client);
            await _clientRepository.SaveChangesAsync();

            var clientModel = request.Client;
            return clientModel;
        }

        public override async Task<AddRangeClientReponse> AddRangeClient(IAsyncStreamReader<ClientModel> requestStream, ServerCallContext context)
        {
            while (await requestStream.MoveNext())
            {
                Client client = _mapper.Map<Client>(requestStream.Current);
                _clientRepository.Add(client);
            }

            var insertCount = await _clientRepository.SaveChangesAsync();

            var response = new AddRangeClientReponse
            {
                Success = insertCount > 0,
                InsertCount = insertCount
            };

            return response;
        }

        #endregion

        #region Update

        public override async Task<ClientModel> UpdateClient(UpdateClientRequest request, ServerCallContext context)
        {
            Client client = _mapper.Map<Client>(request.Client);

            bool isExist = await _clientRepository.Get(x=>x.Id == request.Client.Id).AnyAsync();

            if (!isExist)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $"Client with ID={client.Id} is not found."));
            }

            try
            {
                await _clientRepository.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            ClientModel clientModel = _mapper.Map<ClientModel>(client);
            return clientModel;
        }

        #endregion

        #region Delete
        public override async Task<DeleteClientResponse> DeleteClient(DeleteClientRequest request, ServerCallContext context)
        {
            Client client = await _clientRepository.Get(x=>x.Id == request.Id).FirstOrDefaultAsync();
            if (client == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $"Cleient with ID={request.Id} is not found."));
            }

            _clientRepository.Delete(client);

            var deleteCount = await _clientRepository.SaveChangesAsync();

            var response = new DeleteClientResponse
            {
                Success = deleteCount > 0
            };

            return response;
        }
        #endregion

    }
}
