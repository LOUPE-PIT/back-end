#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["LogHandler.Microservice.csproj", "LogHandler.Microservice/"]
COPY ../SharedLibrary/LogHandler.SharedLibrary.csproj SharedLibrary/ 
#ADD "LOUPE_Backend/SharedLibrary/LogHandler.SharedLibrary.csproj" "/SharedLibrary"
RUN dotnet restore "LogHandler.Microservice/LogHandler.Microservice.csproj"
RUN dotnet restore "SharedLibrary/LogHandler.SharedLibrary.csproj"
COPY . .
#WORKDIR "/src/LogHandler.Microservice"
COPY LOUPE_Backend/LogHandler.Microservice ./LogHandler.Microservice
COPY LOUPE_Backend/SharedLibrary ./SharedLibrary
RUN dotnet build "LogHandler.Microservice/LogHandler.Microservice.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LogHandler.Microservice/LogHandler.Microservice.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LogHandler.Microservice.dll"]