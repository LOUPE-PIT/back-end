FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["FeedbackService.API.csproj", "FeedbackService.API/"]
COPY ["./FeedbackService.Core.API/FeedbackService.Core.API.csproj", "FeedbackService.Core.API/"]
COPY ["FeedbackService.DAL.csproj", "FeedbackService.DAL/"]
RUN dotnet restore "FeedbackService.API/FeedbackService.API.csproj"

WORKDIR "/src/FeedbackService.API"
COPY . .
RUN dotnet build "FeedbackService.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FeedbackService.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FeedbackService.API.dll"]
