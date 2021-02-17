using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace IdentityManager.WebApi.Identity
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
