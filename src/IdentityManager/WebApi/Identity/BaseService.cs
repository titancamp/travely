using AutoMapper;


namespace Travely.IdentityManager.WebApi.Identity
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
