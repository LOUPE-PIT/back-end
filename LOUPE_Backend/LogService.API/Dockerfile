FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["LogService.Api/LogService.Api.csproj", "LogService.Api/"]
COPY ["LogService.DataAccessLayer/LogService.DataAccessLayer.csproj", "LogService.DataAccessLayer/"]
COPY ["LogService.Core.Api/LogService.Core.Api.csproj", "LogService.Core.Api/"]
RUN dotnet restore "LogService.Api/LogService.Api.csproj"
COPY . .

WORKDIR "/src/LogService.Api"
RUN dotnet build "LogService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LogService.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LogService.Api.dll"]
