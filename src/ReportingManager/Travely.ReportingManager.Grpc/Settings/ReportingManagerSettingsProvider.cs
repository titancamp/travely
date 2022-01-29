using Microsoft.Extensions.Options;
using Travely.Common.Grpc;
using Travely.Common.Grpc.Abstraction;
using Travely.ReportingManager.Protos;

namespace Travely.ReportingManager.Grpc.Settings
{
    public class ReportingManagerSettingsProvider : IServiceSettingsProvider<ToDoItemProtoService.ToDoItemProtoServiceClient>
    {

        public ReportingManagerSettingsProvider(IOptions<GrpcSettings<ToDoItemProtoService.ToDoItemProtoServiceClient>> settings)
        {
            Settings = settings.Value;
        }

        public GrpcSettings<ToDoItemProtoService.ToDoItemProtoServiceClient> Settings { get; }
    }
}
