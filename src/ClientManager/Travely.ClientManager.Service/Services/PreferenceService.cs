using AutoMapper;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Travely.ClientManager.Abstraction.Abstraction.Repository;
using Travely.ClientManager.Abstraction.Entity;
using Travely.ClientManager.Service.Protos;

namespace Travely.ClientManager.Service.Services
{
    public class PreferenceService : PreferenceProtoService.PreferenceProtoServiceBase
    {
        private readonly IPreferenceRepository _preferenceRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<PreferenceService> _logger;
        public PreferenceService(ILogger<PreferenceService> logger, IPreferenceRepository preferenceRepository, IMapper mapper)
        {
            _logger = logger;
            _preferenceRepository = preferenceRepository;
            _mapper = mapper;
        }

        #region GET

        public override async Task<PreferenceModel> GetPreference(GetPreferenceRequest request,
                                                                ServerCallContext context)
        {
            try
            {
                Preference preference = await _preferenceRepository.GetNoTracking(x => x.Id == request.Id).FirstOrDefaultAsync();
                if (preference == null)
                {
                    throw new RpcException(new Status(StatusCode.NotFound, $"Preference with ID={request.Id} is not found."));
                }

                PreferenceModel preferenceModel = _mapper.Map<PreferenceModel>(preference);

                return preferenceModel;
            }
            catch (Exception)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $"Preference with ID={request.Id} is not found."));
            }

        }

        public override async Task GetPreferencesLikePattern(GetPreferencesLikePatternRequest request,
                                                            IServerStreamWriter<PreferenceModel> responseStream,
                                                            ServerCallContext context)
        {
            try
            {
                List<Preference> preferences = await _preferenceRepository.GetNoTracking(x => x.Note.Contains(request.Pattern)).ToListAsync();
                foreach (var preference in preferences)
                {
                    PreferenceModel preferenceModel = _mapper.Map<PreferenceModel>(preference);

                    await responseStream.WriteAsync(preferenceModel);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override async Task GetAllPreferences(GetAllPreferencesRequest request,
                                                    IServerStreamWriter<PreferenceModel> responseStream,
                                                    ServerCallContext context)
        {
            try
            {
                List<Preference> preferences = await _preferenceRepository.GetNoTracking().ToListAsync();
                foreach (var preference in preferences)
                {
                    PreferenceModel preferenceModel = _mapper.Map<PreferenceModel>(preference);

                    await responseStream.WriteAsync(preferenceModel);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region CREATE

        public override async Task<PreferenceModel> CreatePreference(CreatePreferenceRequest request, ServerCallContext context)
        {
            Preference preference = _mapper.Map<Preference>(request.Preference);
            preference.Id = default;

            _preferenceRepository.Add(preference);
            await _preferenceRepository.SaveChangesAsync();

            var preferenceModel = request.Preference;
            return preferenceModel;
        }

        #endregion

        #region UPDATE

        public override async Task<PreferenceModel> UpdatePreference(UpdatePreferenceRequest request, ServerCallContext context)
        {
            Preference preference = _mapper.Map<Preference>(request.Preference);

            bool isExist = await _preferenceRepository.Get(x => x.Id == request.Preference.Id).AnyAsync();
            if (!isExist)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $"Preference with ID={preference.Id} is not found."));
            }

            try
            {
                _preferenceRepository.Update(preference);
                await _preferenceRepository.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            PreferenceModel preferenceModel = _mapper.Map<PreferenceModel>(preference);
            return preferenceModel;
        }

        #endregion

        #region DELETE

        public override async Task<DeletePreferenceResponse> DeletePreference(DeletePreferenceRequest request, ServerCallContext context)
        {
            Preference preference = await _preferenceRepository.Get(x => x.Id == request.Id).FirstOrDefaultAsync();
            if (preference == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $"Preference with ID={request.Id} is not found."));
            }

            _preferenceRepository.Delete(preference);

            var deleteCount = await _preferenceRepository.SaveChangesAsync();

            var response = new DeletePreferenceResponse
            {
                Success = deleteCount > 0
            };

            return response;
        }

        #endregion

    }
}
