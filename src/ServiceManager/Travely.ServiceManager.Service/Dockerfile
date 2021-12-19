#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/ServiceManager/Travely.ServiceManager.Service/Travely.ServiceManager.Service.csproj", "src/ServiceManager/Travely.ServiceManager.Service/"]
COPY ["src/Commons/Travely.Common.Swagger/Travely.Common.Swagger.csproj", "src/Commons/Travely.Common.Swagger/"]
COPY ["src/ServiceManager/Travely.ServiceManager.Grpc/Travely.ServiceManager.Grpc.csproj", "src/ServiceManager/Travely.ServiceManager.Grpc/"]
COPY ["src/Commons/Travely.Common.Grpc/Travely.Common.Grpc.csproj", "src/Commons/Travely.Common.Grpc/"]
COPY ["src/Commons/Travely.Common/Travely.Common.csproj", "src/Commons/Travely.Common/"]
COPY ["src/Commons/Travely.Common.ServiceDiscovery/Travely.Common.ServiceDiscovery.csproj", "src/Commons/Travely.Common.ServiceDiscovery/"]
COPY ["src/ServiceManager/Travely.ServiceManager.Abstraction/Travely.ServiceManager.Abstraction.csproj", "src/ServiceManager/Travely.ServiceManager.Abstraction/"]
COPY ["src/ServiceManager/Travely.ServiceManager.DAL/Travely.ServiceManager.DAL.csproj", "src/ServiceManager/Travely.ServiceManager.DAL/"]
COPY ["src/Commons/Travely.Common.Api/Travely.Common.Api.csproj", "src/Commons/Travely.Common.Api/"]
COPY ["src/Shared/IdentityClient/Travely.Shared.IdentityClient.Authorization.csproj", "src/Shared/IdentityClient/"]
RUN dotnet restore "src/ServiceManager/Travely.ServiceManager.Service/Travely.ServiceManager.Service.csproj"
COPY . .
WORKDIR "/src/src/ServiceManager/Travely.ServiceManager.Service"
RUN dotnet build "Travely.ServiceManager.Service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Travely.ServiceManager.Service.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Travely.ServiceManager.dll"]