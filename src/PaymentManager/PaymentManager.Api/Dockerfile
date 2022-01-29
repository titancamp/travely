#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/PaymentManager/PaymentManager.Api/PaymentManager.Api.csproj", "src/PaymentManager/PaymentManager.Api/"]
COPY ["src/Commons/Travely.Common.Swagger/Travely.Common.Swagger.csproj", "src/Commons/Travely.Common.Swagger/"]
COPY ["src/PaymentManager/PaymentManager.Services/PaymentManager.Services.csproj", "src/PaymentManager/PaymentManager.Services/"]
COPY ["src/PaymentManager/PaymentManager.Repositories/PaymentManager.Repositories.csproj", "src/PaymentManager/PaymentManager.Repositories/"]
COPY ["src/PaymentManager/PaymentManager.Shared/PaymentManager.Shared.csproj", "src/PaymentManager/PaymentManager.Shared/"]
COPY ["src/Commons/Travely.Common.ServiceDiscovery/Travely.Common.ServiceDiscovery.csproj", "src/Commons/Travely.Common.ServiceDiscovery/"]
COPY ["src/Commons/Travely.Common.Api/Travely.Common.Api.csproj", "src/Commons/Travely.Common.Api/"]
COPY ["src/Shared/IdentityClient/Travely.Shared.IdentityClient.Authorization.csproj", "src/Shared/IdentityClient/"]
COPY ["src/Commons/Travely.Common/Travely.Common.csproj", "src/Commons/Travely.Common/"]
RUN dotnet restore "src/PaymentManager/PaymentManager.Api/PaymentManager.Api.csproj"
COPY . .
WORKDIR "/src/src/PaymentManager/PaymentManager.Api"
RUN dotnet build "PaymentManager.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PaymentManager.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PaymentManager.Api.dll"]