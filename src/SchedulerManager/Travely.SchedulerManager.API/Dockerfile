#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["src/SchedulerManager/Travely.SchedulerManager.API/Travely.SchedulerManager.API.csproj", "src/SchedulerManager/Travely.SchedulerManager.API/"]
COPY ["src/SchedulerManager/Travely.SchedulerManager.Job/Travely.SchedulerManager.Job.csproj", "src/SchedulerManager/Travely.SchedulerManager.Job/"]
COPY ["src/SchedulerManager/Travely.SchedulerManager.Abstraction/Travely.SchedulerManager.Abstraction.csproj", "src/SchedulerManager/Travely.SchedulerManager.Abstraction/"]
COPY ["src/SchedulerManager/Travely.SchedulerManager.Common/Travely.SchedulerManager.Common.csproj", "src/SchedulerManager/Travely.SchedulerManager.Common/"]
COPY ["src/SchedulerManager/Travely.SchedulerManager.Repository/Travely.SchedulerManager.Repository.csproj", "src/SchedulerManager/Travely.SchedulerManager.Repository/"]
COPY ["src/SchedulerManager/Travely.SchedulerManager.Notifier/Travely.SchedulerManager.Notifier.csproj", "src/SchedulerManager/Travely.SchedulerManager.Notifier/"]
COPY ["src/Shared/IdentityClient/Travely.Shared.IdentityClient.Authorization.csproj", "src/Shared/IdentityClient/"]
COPY ["src/SchedulerManager/Travely.SchedulerManager.Service/Travely.SchedulerManager.Service.csproj", "src/SchedulerManager/Travely.SchedulerManager.Service/"]
RUN dotnet restore "src/SchedulerManager/Travely.SchedulerManager.API/Travely.SchedulerManager.API.csproj"
COPY . .
WORKDIR "/src/src/SchedulerManager/Travely.SchedulerManager.API"
RUN dotnet build "Travely.SchedulerManager.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Travely.SchedulerManager.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Travely.SchedulerManager.API.dll"]