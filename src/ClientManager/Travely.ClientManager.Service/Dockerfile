#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/ClientManager/Travely.ClientManager.Service/Travely.ClientManager.Service.csproj", "src/ClientManager/Travely.ClientManager.Service/"]
COPY ["src/Commons/Travely.Common.Swagger/Travely.Common.Swagger.csproj", "src/Commons/Travely.Common.Swagger/"]
COPY ["src/ClientManager/Travely.ClientManager.Abstraction/Travely.ClientManager.Abstraction.csproj", "src/ClientManager/Travely.ClientManager.Abstraction/"]
COPY ["src/Commons/Travely.Common/Travely.Common.csproj", "src/Commons/Travely.Common/"]
COPY ["src/Commons/Travely.Common.ServiceDiscovery/Travely.Common.ServiceDiscovery.csproj", "src/Commons/Travely.Common.ServiceDiscovery/"]
COPY ["src/ClientManager/Travely.ClientManager.Repository/Travely.ClientManager.Repository.csproj", "src/ClientManager/Travely.ClientManager.Repository/"]
COPY ["src/ClientManager/Travely.ClientManager.Grpc.Client/Travely.ClientManager.Grpc.csproj", "src/ClientManager/Travely.ClientManager.Grpc.Client/"]
COPY ["src/Commons/Travely.Common.Grpc/Travely.Common.Grpc.csproj", "src/Commons/Travely.Common.Grpc/"]
COPY ["src/Commons/Travely.Common.Api/Travely.Common.Api.csproj", "src/Commons/Travely.Common.Api/"]
COPY ["src/Shared/IdentityClient/Travely.Shared.IdentityClient.Authorization.csproj", "src/Shared/IdentityClient/"]
RUN dotnet restore "src/ClientManager/Travely.ClientManager.Service/Travely.ClientManager.Service.csproj"
COPY . .
WORKDIR "/src/src/ClientManager/Travely.ClientManager.Service"
RUN dotnet build "Travely.ClientManager.Service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Travely.ClientManager.Service.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Travely.ClientManager.Service.dll"]