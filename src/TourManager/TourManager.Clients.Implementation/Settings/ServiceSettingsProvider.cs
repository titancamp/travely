namespace TourManager.Clients.Implementation.Settings
{
	using Microsoft.Extensions.Options;
	using TourManager.Clients.Abstraction.Settings;
	using TourManager.Common.Settings;

	public class ServiceSettingsProvider : IServiceSettingsProvider
	{
		private readonly IOptions<GrpcServiceSettings> _grpcServiceSettings;

		public ServiceSettingsProvider(IOptions<GrpcServiceSettings> grpcServiceSettings)
		{
			_grpcServiceSettings = grpcServiceSettings;
		}

		public string ComposeActivityServiceUrl()
		{
			return _grpcServiceSettings.Value.ActivityServiceUrl;
		}

		public string ComposePropertyServiceUrl()
		{
			return _grpcServiceSettings.Value.PropertyServiceUrl;
		}

		public string ComposeClientServiceUrl()
		{
			return _grpcServiceSettings.Value.ClientServiceUrl;
		}
	}
}
