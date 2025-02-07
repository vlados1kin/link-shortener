FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Presentation/LinkShortener.API/LinkShortener.API.csproj", "Presentation/LinkShortener.API/"]
RUN dotnet restore "Presentation/LinkShortener.API/LinkShortener.API.csproj"
COPY . .
WORKDIR "/src/Presentation/LinkShortener.API"
RUN dotnet build "LinkShortener.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "LinkShortener.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LinkShortener.API.dll"]
