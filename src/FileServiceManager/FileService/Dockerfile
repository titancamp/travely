#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/FileServiceManager/FileService/FileService.csproj", "src/FileServiceManager/FileService/"]
COPY ["src/FileServiceManager/Models/Models.csproj", "src/FileServiceManager/Models/"]
COPY ["src/Commons/Travely.Common.Swagger/Travely.Common.Swagger.csproj", "src/Commons/Travely.Common.Swagger/"]
RUN dotnet restore "src/FileServiceManager/FileService/FileService.csproj"
COPY . .
WORKDIR "/src/src/FileServiceManager/FileService"
RUN dotnet build "FileService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FileService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FileService.dll"]