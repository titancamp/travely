using AutoMapper;

using Travely.IdentityManager.Service.Abstractions;

namespace Travely.IdentityManager.Service
{
    public class BaseService: IBaseService
    {
        protected readonly IMapper Mapper;
        /// <summary>
        /// BaseService
        /// </summary>
        /// <param name="mapper"></param>
        public BaseService(IMapper mapper)
        {
            Mapper = mapper;
        }
    }
}
