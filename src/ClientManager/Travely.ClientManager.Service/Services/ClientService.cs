using AutoMapper;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Travely.ClientManager.Abstraction.Abstraction.Repository;
using Travely.ClientManager.Abstraction.Entity;
using Travely.ClientManager.Service.Protos;
using Travely.Services.Common.CustomExceptions;

namespace Travely.ClientManager.Service.Services
{
	public class ClientService : ClientProtoService.ClientProtoServiceBase
	{
		private readonly ITouristRepository _touristRepository;

		private readonly IMapper _mapper;

		private readonly ILogger<ClientService> _logger;

		public ClientService(ILogger<ClientService> logger, ITouristRepository touristRepository, IMapper mapper)
		{
			_logger = logger;
			_touristRepository = touristRepository;
			_mapper = mapper;
		}

		public override async Task<ClientModel> GetClient(GetClientRequest request,
																ServerCallContext context)
		{
			Tourist client = await _touristRepository.GetNoTracking(x => x.Id == request.Id).FirstOrDefaultAsync();

			if (client == null)
			{
				throw new NotFoundException(nameof(Tourist), request.Id);
			}

			ClientModel clientModel = _mapper.Map<ClientModel>(client);

			return clientModel;
		}

		public async override Task<Clients> GetAllClients(GetAllClientsRequest request, ServerCallContext context)
		{
			List<ClientModel> clientsList = _mapper.Map<List<ClientModel>>(await _touristRepository.GetNoTracking().ToListAsync());
			var clients = new Clients();
			clients.Clients_.AddRange(clientsList);
			return clients;
		}

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

		public override async Task<ClientModel> UpdateClient(UpdateClientRequest request, ServerCallContext context)
		{
			Tourist client = _mapper.Map<Tourist>(request.Client);

			bool isExist = await _touristRepository.Get(x => x.Id == request.Client.Id).AnyAsync();

			if (!isExist)
			{
				throw new NotFoundException(nameof(Tourist), request.Client.Id);
			}


			_touristRepository.Update(client);
			await _touristRepository.SaveChangesAsync();

			ClientModel clientModel = _mapper.Map<ClientModel>(client);
			return clientModel;
		}

		public override async Task<DeleteClientResponse> DeleteClient(DeleteClientRequest request, ServerCallContext context)
		{
			Tourist client = await _touristRepository.Get(x => x.Id == request.Id).FirstOrDefaultAsync();
			if (client == null)
			{
				throw new NotFoundException(nameof(Tourist), request.Id);
			}

			_touristRepository.Delete(client);

			var deleteCount = await _touristRepository.SaveChangesAsync();

			var response = new DeleteClientResponse
			{
				Success = deleteCount > 0
			};

			return response;
		}
	}
}
