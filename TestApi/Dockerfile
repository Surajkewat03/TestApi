# Base runtime image (Linux-based)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["TestApi/TestApi.csproj", "TestApi/"]
RUN dotnet restore "./TestApi/TestApi.csproj"
COPY . .
WORKDIR "/src/TestApi"
RUN dotnet build "./TestApi.csproj" -c Release -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish "./TestApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Final runtime stage
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestApi.dll"]
