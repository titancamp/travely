#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Commons/Travely.Common/Travely.Common.csproj", "Commons/Travely.Common/"]
COPY ["src/IdentityManager/WebApi/IdentityManager.WebApi.csproj", "IdentityManager/WebApi/"]
COPY ["src/IdentityManager/Service/IdentityManager.Service.csproj", "IdentityManager/Service/"]
COPY ["src/IdentityManager/Packages.props", "IdentityManager/"]
COPY ["src/IdentityManager/Directory.Build.props", "IdentityManager/"]
COPY ["src/IdentityManager/Directory.Build.targets", "IdentityManager/"]
RUN dotnet restore "IdentityManager/WebApi/IdentityManager.WebApi.csproj"
COPY "src/IdentityManager" "IdentityManager"
WORKDIR "/src/IdentityManager/WebApi"
RUN dotnet build "IdentityManager.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IdentityManager.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IdentityManager.WebApi.dll"]