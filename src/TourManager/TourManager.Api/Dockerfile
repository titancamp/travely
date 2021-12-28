#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/TourManager/TourManager.Api/TourManager.Api.csproj", "src/TourManager/TourManager.Api/"]
COPY ["src/Commons/Travely.Common.Swagger/Travely.Common.Swagger.csproj", "src/Commons/Travely.Common.Swagger/"]
COPY ["src/SchedulerManager/Travely.SchedulerManager.Grpc/Travely.SchedulerManager.Grpc.csproj", "src/SchedulerManager/Travely.SchedulerManager.Grpc/"]
COPY ["src/Commons/Travely.Common.Grpc/Travely.Common.Grpc.csproj", "src/Commons/Travely.Common.Grpc/"]
COPY ["src/Commons/Travely.Common/Travely.Common.csproj", "src/Commons/Travely.Common/"]
COPY ["src/TourManager/TourManager.Repository.EfCore/TourManager.Repository.EfCore.csproj", "src/TourManager/TourManager.Repository.EfCore/"]
COPY ["src/TourManager/TourManager.Repository.Abstraction/TourManager.Repository.Abstraction.csproj", "src/TourManager/TourManager.Repository.Abstraction/"]
COPY ["src/ServiceManager/Travely.ServiceManager.Grpc/Travely.ServiceManager.Grpc.csproj", "src/ServiceManager/Travely.ServiceManager.Grpc/"]
COPY ["src/TourManager/TourManager.Service.Model/TourManager.Service.Model.csproj", "src/TourManager/TourManager.Service.Model/"]
COPY ["src/ClientManager/Travely.ClientManager.Grpc/Travely.ClientManager.Grpc.csproj", "src/ClientManager/Travely.ClientManager.Grpc/"]
COPY ["src/Commons/Travely.Common.ServiceDiscovery/Travely.Common.ServiceDiscovery.csproj", "src/Commons/Travely.Common.ServiceDiscovery/"]
COPY ["src/Shared/IdentityClient/Travely.Shared.IdentityClient.Authorization.csproj", "src/Shared/IdentityClient/"]
COPY ["src/TourManager/TourManager.Service.Implementation/TourManager.Service.Implementation.csproj", "src/TourManager/TourManager.Service.Implementation/"]
COPY ["src/TourManager/TourManager.Service.Abstraction/TourManager.Service.Abstraction.csproj", "src/TourManager/TourManager.Service.Abstraction/"]
COPY ["src/Commons/Travely.Common.Api/Travely.Common.Api.csproj", "src/Commons/Travely.Common.Api/"]
COPY ["src/PropertyManager/Travely.PropertyManager.Grpc/Travely.PropertyManager.Grpc.csproj", "src/PropertyManager/Travely.PropertyManager.Grpc/"]
COPY ["src/TourManager/TourManager.Repository.EfCore.MsSql/TourManager.Repository.EfCore.MsSql.csproj", "src/TourManager/TourManager.Repository.EfCore.MsSql/"]
COPY ["src/Shared/TourModels/TourModels.csproj", "src/Shared/TourModels/"]
RUN dotnet restore "src/TourManager/TourManager.Api/TourManager.Api.csproj"
COPY . .
WORKDIR "/src/src/TourManager/TourManager.Api"
RUN dotnet build "TourManager.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TourManager.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TourManager.Api.dll"]