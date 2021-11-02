using AutoMapper;
using System;

namespace TourManager.Clients.Implementation.Mappers
{
	public static class Mapping
	{
		private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
		{
			var config = new MapperConfiguration(cfg =>
			{
				// This line ensures that internal properties are also mapped over.
				cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
				cfg.AddProfile<ActivityClientProfile>();
				cfg.AddProfile<PropertyClientProfile>();
				cfg.AddProfile<ClientManagerClientProfile>();
				cfg.AddProfile<SchedulerClientProfile>();
			});
			var mapper = config.CreateMapper();
			return mapper;
		});

		public static IMapper Mapper => Lazy.Value;
	}
}
