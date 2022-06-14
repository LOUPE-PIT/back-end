#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["LOUPE_BACKEND/LogHandler.WebApplicationSender/LogHandler.WebApplicationSender.csproj", "LogHandler.WebApplicationSender/"]
COPY ["LOUPE_BACKEND/SharedLibrary/LogHandler.SharedLibrary.csproj", "SharedLibrary/"]
RUN dotnet restore "LogHandler.WebApplicationSender/LogHandler.WebApplicationSender.csproj"
COPY . .
WORKDIR "/src/LogHandler.WebApplicationSender"
RUN dotnet build "LogHandler.WebApplicationSender.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LogHandler.WebApplicationSender.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LogHandler.WebApplicationSender.dll"]