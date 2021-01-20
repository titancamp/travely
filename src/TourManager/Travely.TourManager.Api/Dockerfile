#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["src/TourManager/Travely.TourManager.Api/Travely.TourManager.Api.csproj", "src/TourManager/Travely.TourManager.Api/"]
RUN dotnet restore "src/TourManager/Travely.TourManager.Api/Travely.TourManager.Api.csproj"
COPY . .
WORKDIR "/src/src/TourManager/Travely.TourManager.Api"
RUN dotnet build "Travely.TourManager.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Travely.TourManager.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Travely.TourManager.Api.dll"]