FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SynchronizationService.API/SynchronizationService.API.csproj", "SynchronizationService.API/"]
COPY ["SynchronizationService.Core.API/SynchronizationService.Core.API.csproj", "SynchronizationService.Core.API/"]
COPY ["SynchronizationService.DataLayer/SynchronizationService.DataLayer.csproj", "SynchronizationService.DataLayer/"]
RUN dotnet restore "SynchronizationService.API/SynchronizationService.API.csproj"
COPY . .
WORKDIR "/src/SynchronizationService.API"
RUN dotnet build "SynchronizationService.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SynchronizationService.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SynchronizationService.API.dll"]