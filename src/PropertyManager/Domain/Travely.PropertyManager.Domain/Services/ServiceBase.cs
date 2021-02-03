using AutoMapper;
using Microsoft.Extensions.Logging;

namespace Travely.PropertyManager.Domain.Services
{
    public abstract class ServiceBase
    {
        protected ServiceBase(ILogger logger, IMapper mapper)
        {
            Logger = logger;
            Mapper = mapper;
        }

        protected ILogger Logger { get; }

        protected IMapper Mapper { get; }
    }
}
