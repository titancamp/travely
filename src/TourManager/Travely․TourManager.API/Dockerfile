#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["TourManager/Travely․TourManager.API/Travely․TourManager.API.csproj", "TourManager/Travely․TourManager.API/"]
RUN dotnet restore "TourManager/Travely․TourManager.API/Travely․TourManager.API.csproj"
COPY . .
WORKDIR "/src/TourManager/Travely․TourManager.API"
RUN dotnet build "Travely․TourManager.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Travely․TourManager.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Travely․TourManager.API.dll"]