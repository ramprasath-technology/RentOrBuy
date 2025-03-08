#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["RentOrBuy/RentOrBuy.Home.API.csproj", "RentOrBuy/"]
COPY ["RentOrBuy.Home.Business/RentOrBuy.Home.Business.csproj", "RentOrBuy.Home.Business/"]
COPY ["CommonExtensions/CommonExtensions.csproj", "CommonExtensions/"]
COPY ["RentOrBuy.Home.DataModel/RentOrBuy.Home.DataModel.csproj", "RentOrBuy.Home.DataModel/"]
RUN dotnet restore "./RentOrBuy/./RentOrBuy.Home.API.csproj"
COPY . .
WORKDIR "/src/RentOrBuy"
RUN dotnet build "./RentOrBuy.Home.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./RentOrBuy.Home.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RentOrBuy.Home.API.dll"]