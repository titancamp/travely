#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["src/Commons/Travely.Common/Travely.Common.csproj", "src/Commons/Travely.Common/"]
COPY ["src/TourManager/TourManager.Api/TourManager.Api.csproj", "src/TourManager/TourManager.Api/"]
COPY ["src/TourManager/TourManager.Clients.Implementation/TourManager.Clients.Implementation.csproj", "src/TourManager/TourManager.Clients.Implementation/"]
COPY ["src/Commons/Travely.Services.Common/Travely.Services.Common.csproj", "src/Commons/Travely.Services.Common/"]
COPY ["src/TourManager/TourManager.Common/TourManager.Common.csproj", "src/TourManager/TourManager.Common/"]
COPY ["src/TourManager/TourManager.Service.Model/TourManager.Service.Model.csproj", "src/TourManager/TourManager.Service.Model/"]
COPY ["src/TourManager/TourManager.Clients.Abstraction/TourManager.Clients.Abstraction.csproj", "src/TourManager/TourManager.Clients.Abstraction/"]
COPY ["src/TourManager/TourManager.Repository.EfCore/TourManager.Repository.EfCore.csproj", "src/TourManager/TourManager.Repository.EfCore/"]
COPY ["src/TourManager/TourManager.Repository.Abstraction/TourManager.Repository.Abstraction.csproj", "src/TourManager/TourManager.Repository.Abstraction/"]
COPY ["src/Shared/IdentityClient/Travely.Shared.IdentityClient.Authorization.csproj", "src/Shared/IdentityClient/"]
COPY ["src/TourManager/TourManager.Service.Implementation/TourManager.Service.Implementation.csproj", "src/TourManager/TourManager.Service.Implementation/"]
COPY ["src/TourManager/TourManager.Service.Abstraction/TourManager.Service.Abstraction.csproj", "src/TourManager/TourManager.Service.Abstraction/"]
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