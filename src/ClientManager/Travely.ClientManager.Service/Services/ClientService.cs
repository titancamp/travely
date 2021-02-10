﻿using AutoMapper;
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
        private readonly ITuristRepository _turistRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ClientService> _logger;
        public ClientService(ILogger<ClientService> logger, ITuristRepository turistRepository, IMapper mapper)
        {
            _logger = logger;
            _turistRepository = turistRepository;
            _mapper = mapper;
        }

        #region GET
        public override async Task<ClientModel> GetClient(GetClientRequest request,
                                                                ServerCallContext context)
        {
            try
            {
                Turist client = await _turistRepository.GetNoTracking(x => x.Id == request.Id).FirstOrDefaultAsync();

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
                Turist client = await _turistRepository.GetNoTracking(x => x.Id == request.Id, "Preferences").FirstOrDefaultAsync();

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
            List<Turist> clientList = await _turistRepository.GetNoTracking().ToListAsync();

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
            Turist client = _mapper.Map<Turist>(request.Client);
            client.Id = default;

            _turistRepository.Add(client);
            await _turistRepository.SaveChangesAsync();

            var clientModel = request.Client;
            return clientModel;
        }

        public override async Task<AddRangeClientReponse> AddRangeClient(IAsyncStreamReader<ClientModel> requestStream, ServerCallContext context)
        {
            while (await requestStream.MoveNext())
            {
                Turist client = _mapper.Map<Turist>(requestStream.Current);
                _turistRepository.Add(client);
            }

            var insertCount = await _turistRepository.SaveChangesAsync();

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
            Turist client = _mapper.Map<Turist>(request.Client);

            bool isExist = await _turistRepository.Get(x=>x.Id == request.Client.Id).AnyAsync();

            if (!isExist)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $"Client with ID={client.Id} is not found."));
            }

            try
            {
                _turistRepository.Update(client);
                await _turistRepository.SaveChangesAsync();
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
            Turist client = await _turistRepository.Get(x=>x.Id == request.Id).FirstOrDefaultAsync();
            if (client == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $"Cleient with ID={request.Id} is not found."));
            }

            _turistRepository.Delete(client);

            var deleteCount = await _turistRepository.SaveChangesAsync();

            var response = new DeleteClientResponse
            {
                Success = deleteCount > 0
            };

            return response;
        }
        #endregion

    }
}
