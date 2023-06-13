FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["./GroupingService.Api/GroupingService.Api.csproj", "GroupingService.Api/"]
COPY ["./GroupingService.DataAccessLayer/GroupingService.DataAccessLayer.csproj", "GroupingService.DataAccessLayer/"]
COPY ["./GroupingService.Core.Api/GroupingService.Core.Api.csproj", "GroupingService.Core.Api/"]
RUN dotnet restore "GroupingService.Api/GroupingService.Api.csproj"
COPY . .
WORKDIR "/src/GroupingService.Api"
RUN dotnet build "GroupingService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GroupingService.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GroupingService.Api.dll"]