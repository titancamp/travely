using Microsoft.Extensions.Options;

namespace Travely.Common.Grpc.Abstraction
{
    public interface IServiceSettingsProvider<T> where T : class
    {
        GrpcSettings<T> Settings { get; }
    }
}
