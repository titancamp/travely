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
using Travely.Services.Common.CustomExceptions;

namespace Travely.ClientManager.Service.Services
{
	public class ClientService : ClientProtoService.ClientProtoServiceBase
	{
		private readonly ITouristRepository _turistRepository;
		private readonly IMapper _mapper;
		private readonly ILogger<ClientService> _logger;
		public ClientService(ILogger<ClientService> logger, ITouristRepository turistRepository, IMapper mapper)
		{
			_logger = logger;
			_turistRepository = turistRepository;
			_mapper = mapper;
		}

		#region GET
		public override async Task<ClientModel> GetClient(GetClientRequest request,
																ServerCallContext context)
		{
			Tourist client = await _turistRepository.GetNoTracking(x => x.Id == request.Id).FirstOrDefaultAsync();

			if (client == null)
			{
				throw new NotFoundException(nameof(Tourist), request.Id);
			}

			ClientModel clientModel = _mapper.Map<ClientModel>(client);

			return clientModel;
		}

		public override async Task<ClientWithPreferencesModel> GetClientWithPreferences(GetClientRequest request,
																ServerCallContext context)
		{
			Tourist client = await _turistRepository.GetNoTracking(x => x.Id == request.Id, "Preferences").FirstOrDefaultAsync();

			if (client == null)
			{
				throw new NotFoundException(nameof(Tourist), request.Id);
			}

			ClientWithPreferencesModel clientPreferencesModel = _mapper.Map<ClientWithPreferencesModel>(client);

			return clientPreferencesModel;
		}

		public override async Task GetAllClients(GetAllClientsRequest request,
													IServerStreamWriter<ClientModel> responseStream,
													ServerCallContext context)
		{
			List<Tourist> clientList = await _turistRepository.GetNoTracking().ToListAsync();

			foreach (var client in clientList)
			{
				ClientModel clientModel = _mapper.Map<ClientModel>(client);

				await responseStream.WriteAsync(clientModel);
			}
		}
		#endregion

		#region CREATE
		public override async Task<ClientModel> CreateClient(CreateClientRequest request, ServerCallContext context)
		{
			Tourist client = _mapper.Map<Tourist>(request.Client);
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
				Tourist client = _mapper.Map<Tourist>(requestStream.Current);
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
			Tourist client = _mapper.Map<Tourist>(request.Client);

			bool isExist = await _turistRepository.Get(x => x.Id == request.Client.Id).AnyAsync();

			if (!isExist)
			{
				throw new NotFoundException(nameof(Tourist), request.Client.Id);
			}


			_turistRepository.Update(client);
			await _turistRepository.SaveChangesAsync();

			ClientModel clientModel = _mapper.Map<ClientModel>(client);
			return clientModel;
		}

		#endregion

		#region DELETE
		public override async Task<DeleteClientResponse> DeleteClient(DeleteClientRequest request, ServerCallContext context)
		{
			Tourist client = await _turistRepository.Get(x => x.Id == request.Id).FirstOrDefaultAsync();
			if (client == null)
			{
				throw new NotFoundException(nameof(Tourist), request.Id);
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
