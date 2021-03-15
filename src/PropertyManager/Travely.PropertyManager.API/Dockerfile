#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/PropertyManager/Travely.PropertyManager.API/Travely.PropertyManager.API.csproj", "src/PropertyManager/Travely.PropertyManager.API/"]
COPY ["src/PropertyManager/Travely.PropertyManager.Service/Travely.PropertyManager.Service.csproj", "src/PropertyManager/Travely.PropertyManager.Service/"]
COPY ["src/PropertyManager/Travely.PropertyManager.Data/Travely.PropertyManager.Data.csproj", "src/PropertyManager/Travely.PropertyManager.Data/"]
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
