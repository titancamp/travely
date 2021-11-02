#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["src/Commons/Travely.Common/Travely.Common.csproj", "src/Commons/Travely.Common/"]
COPY ["src/ClientManager/Travely.ClientManager.Service/Travely.ClientManager.Service.csproj", "src/ClientManager/Travely.ClientManager.Service/"]
COPY ["src/Commons/Travely.Services.Common/Travely.Services.Common.csproj", "src/Commons/Travely.Services.Common/"]
COPY ["src/ClientManager/Travely.ClientManager.Abstraction/Travely.ClientManager.Abstraction.csproj", "src/ClientManager/Travely.ClientManager.Abstraction/"]
COPY ["src/ClientManager/Travely.ClientManager.Repository/Travely.ClientManager.Repository.csproj", "src/ClientManager/Travely.ClientManager.Repository/"]
RUN dotnet restore "src/ClientManager/Travely.ClientManager.Service/Travely.ClientManager.Service.csproj"
COPY . .
WORKDIR "src/ClientManager/Travely.ClientManager.Service"
RUN dotnet build "Travely.ClientManager.Service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Travely.ClientManager.Service.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Travely.ClientManager.Service.dll"]