FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["LOUPE_Backend/FeedbackService.API/FeedbackService.API.csproj", "FeedbackService.API/"]
COPY ["FeedbackService.DAL/FeedbackService.DAL.csproj", "FeedbackService.DAL/"]
COPY ["FeedbackService.Api.Core/FeedbackService.Api.Core.csproj", "FeedbackService.Api.Core/"]
RUN dotnet restore "FeedbackService.API/FeedbackService.API.csproj"
COPY . .

WORKDIR "/src/FeedbackService.API"
RUN dotnet build "FeedbackService.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FeedbackService.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FeedbackService.API.dll"]
