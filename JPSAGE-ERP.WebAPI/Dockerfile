#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["JPSAGE-ERP.WebAPI/JPSAGE-ERP.WebAPI.csproj", "JPSAGE-ERP.WebAPI/"]
COPY ["JPSAGE-ERP.Application/JPSAGE-ERP.Application.csproj", "JPSAGE-ERP.Application/"]
COPY ["JPSAGE-ERP.Infrastructure.Data/JPSAGE-ERP.Infrastructure.Data.csproj", "JPSAGE-ERP.Infrastructure.Data/"]
COPY ["JPSAGE-ERP.Domain/JPSAGE-ERP.Domain.csproj", "JPSAGE-ERP.Domain/"]
COPY ["JPSAGE-ERP.Infrastructure.IoC/JPSAGE-ERP.Infrastructure.IoC.csproj", "JPSAGE-ERP.Infrastructure.IoC/"]
RUN dotnet restore "JPSAGE-ERP.WebAPI/JPSAGE-ERP.WebAPI.csproj"
COPY . .
WORKDIR "/src/JPSAGE-ERP.WebAPI"
RUN dotnet build "JPSAGE-ERP.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "JPSAGE-ERP.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet JPSAGE-ERP.WebAPI.dll