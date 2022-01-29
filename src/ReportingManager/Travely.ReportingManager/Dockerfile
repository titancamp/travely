#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/ReportingManager/Travely.ReportingManager/Travely.ReportingManager.csproj", "src/ReportingManager/Travely.ReportingManager/"]
COPY ["src/Commons/Travely.Common.Swagger/Travely.Common.Swagger.csproj", "src/Commons/Travely.Common.Swagger/"]
COPY ["src/Commons/Travely.Common/Travely.Common.csproj", "src/Commons/Travely.Common/"]
COPY ["src/Commons/Travely.Common.ServiceDiscovery/Travely.Common.ServiceDiscovery.csproj", "src/Commons/Travely.Common.ServiceDiscovery/"]
COPY ["src/ReportingManager/Travely.ReportingManager.Services/Travely.ReportingManager.Services.csproj", "src/ReportingManager/Travely.ReportingManager.Services/"]
COPY ["src/ReportingManager/Travely.ReportingManager.Data/Travely.ReportingManager.Data.csproj", "src/ReportingManager/Travely.ReportingManager.Data/"]
COPY ["src/ReportingManager/Travely.ReportingManager.Grpc/Travely.ReportingManager.Grpc.csproj", "src/ReportingManager/Travely.ReportingManager.Grpc/"]
COPY ["src/Commons/Travely.Common.Grpc/Travely.Common.Grpc.csproj", "src/Commons/Travely.Common.Grpc/"]
COPY ["src/Commons/Travely.Common.Api/Travely.Common.Api.csproj", "src/Commons/Travely.Common.Api/"]
COPY ["src/Shared/IdentityClient/Travely.Shared.IdentityClient.Authorization.csproj", "src/Shared/IdentityClient/"]
RUN dotnet restore "src/ReportingManager/Travely.ReportingManager/Travely.ReportingManager.csproj"
COPY . .
WORKDIR "/src/src/ReportingManager/Travely.ReportingManager"
RUN dotnet build "Travely.ReportingManager.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Travely.ReportingManager.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Travely.ReportingManager.dll"]