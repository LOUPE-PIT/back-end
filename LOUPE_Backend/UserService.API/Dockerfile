FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["UserService.API/UserService.API.csproj", "UserService.API/"]
COPY ["UserService.DAL/UserService.DAL.csproj", "UserService.DAL/"]
COPY ["UserService.Core.API/UserService.Core.API.csproj", "UserService.Core.API/"]
RUN dotnet restore "UserService.API/UserService.API.csproj"
COPY . .

WORKDIR "/src/UserService.API"
RUN dotnet build "UserService.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UserService.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UserService.API.dll"]
