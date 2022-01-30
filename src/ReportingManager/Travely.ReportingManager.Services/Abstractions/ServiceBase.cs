using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using Travely.Common;
using Travely.ReportingManager.Services.Extensions;

namespace Travely.ReportingManager.Services.Abstractions
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
