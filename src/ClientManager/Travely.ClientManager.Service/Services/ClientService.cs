using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travely.ClientManager.Abstraction.Abstraction.Repository;
using Travely.ClientManager.Abstraction.Entity;
using Travely.ClientManager.Service.Protos;

namespace Travely.ClientManager.Service.Services
{
    public class ClientService : ClientProtoService.ClientProtoServiceBase
    {
        private readonly ITouristRepository _touristRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ClientService> _logger;
        public ClientService(ILogger<ClientService> logger, ITouristRepository turistRepository, IMapper mapper)
        {
            _logger = logger;
            _touristRepository = turistRepository;
            _mapper = mapper;
        }

        #region GET
        public override async Task<ClientModel> GetClient(GetClientRequest request,
                                                                ServerCallContext context)
        {
            try
            {
                Tourist client = await _touristRepository.GetNoTracking(x => x.Id == request.Id).FirstOrDefaultAsync();

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
                Tourist client = await _touristRepository.GetNoTracking(x => x.Id == request.Id, "Preferences").FirstOrDefaultAsync();

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
            List<Tourist> clientList = await _touristRepository.GetNoTracking().ToListAsync();

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

        #region CREATE
        public override async Task<ClientModel> CreateClient(CreateClientRequest request, ServerCallContext context)
        {
            Tourist client = _mapper.Map<Tourist>(request.Client);
            client.Id = default;

            _touristRepository.Add(client);
            await _touristRepository.SaveChangesAsync();

            var clientModel = request.Client;
            return clientModel;
        }

        public override async Task<AddRangeClientReponse> AddRangeClient(IAsyncStreamReader<ClientModel> requestStream, ServerCallContext context)
        {
            while (await requestStream.MoveNext())
            {
                Tourist client = _mapper.Map<Tourist>(requestStream.Current);
                _touristRepository.Add(client);
            }

            var insertCount = await _touristRepository.SaveChangesAsync();

            var response = new AddRangeClientReponse
            {
                Success = insertCount > 0,
                InsertCount = insertCount
            };

            return response;
        }

        #endregion

        #region UPDATE

        public override async Task<ClientModel> UpdateClient(UpdateClientRequest request, ServerCallContext context)
        {
            Tourist client = _mapper.Map<Tourist>(request.Client);

            bool isExist = await _touristRepository.Get(x=>x.Id == request.Client.Id).AnyAsync();

            if (!isExist)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $"Client with ID={client.Id} is not found."));
            }

            try
            {
                _touristRepository.Update(client);
                await _touristRepository.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            ClientModel clientModel = _mapper.Map<ClientModel>(client);
            return clientModel;
        }

        #endregion

        #region DELETE
        public override async Task<DeleteClientResponse> DeleteClient(DeleteClientRequest request, ServerCallContext context)
        {
            Tourist client = await _touristRepository.Get(x=>x.Id == request.Id).FirstOrDefaultAsync();
            if (client == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $"Cleient with ID={request.Id} is not found."));
            }

            _touristRepository.Delete(client);

            var deleteCount = await _touristRepository.SaveChangesAsync();

            var response = new DeleteClientResponse
            {
                Success = deleteCount > 0
            };

            return response;
        }
        #endregion

    }
}
