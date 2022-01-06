#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/PropertyManager/Travely.PropertyManager.API/Travely.PropertyManager.API.csproj", "src/PropertyManager/Travely.PropertyManager.API/"]
COPY ["src/Commons/Travely.Common.Swagger/Travely.Common.Swagger.csproj", "src/Commons/Travely.Common.Swagger/"]
COPY ["src/Commons/Travely.Common/Travely.Common.csproj", "src/Commons/Travely.Common/"]
COPY ["src/Commons/Travely.Common.ServiceDiscovery/Travely.Common.ServiceDiscovery.csproj", "src/Commons/Travely.Common.ServiceDiscovery/"]
COPY ["src/PropertyManager/Travely.PropertyManager.Service/Travely.PropertyManager.Service.csproj", "src/PropertyManager/Travely.PropertyManager.Service/"]
COPY ["src/PropertyManager/Travely.PropertyManager.Data/Travely.PropertyManager.Data.csproj", "src/PropertyManager/Travely.PropertyManager.Data/"]
COPY ["src/PropertyManager/Travely.PropertyManager.Grpc/Travely.PropertyManager.Grpc.csproj", "src/PropertyManager/Travely.PropertyManager.Grpc/"]
COPY ["src/Commons/Travely.Common.Grpc/Travely.Common.Grpc.csproj", "src/Commons/Travely.Common.Grpc/"]
COPY ["src/Commons/Travely.Common.Api/Travely.Common.Api.csproj", "src/Commons/Travely.Common.Api/"]
COPY ["src/Shared/IdentityClient/Travely.Shared.IdentityClient.Authorization.csproj", "src/Shared/IdentityClient/"]
RUN dotnet restore "src/PropertyManager/Travely.PropertyManager.API/Travely.PropertyManager.API.csproj"
COPY . .
WORKDIR "/src/src/PropertyManager/Travely.PropertyManager.API"
RUN dotnet build "Travely.PropertyManager.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Travely.PropertyManager.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Travely.PropertyManager.API.dll"]