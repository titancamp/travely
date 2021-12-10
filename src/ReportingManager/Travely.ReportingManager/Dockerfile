#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/ReportingManager/Travely.ReportingManager/Travely.ReportingManager.csproj", "src/ReportingManager/Travely.ReportingManager/"]
COPY ["src/Commons/Travely.Services.Common/Travely.Services.Common.csproj", "src/Commons/Travely.Services.Common/"]
COPY ["src/ReportingManager/Travely.ReportingManager.Services/Travely.ReportingManager.Services.csproj", "src/ReportingManager/Travely.ReportingManager.Services/"]
COPY ["src/ReportingManager/Travely.ReportingManager.Data/Travely.ReportingManager.Data.csproj", "src/ReportingManager/Travely.ReportingManager.Data/"]
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