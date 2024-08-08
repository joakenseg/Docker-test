# Establecer la imagen base
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

# Establecer la imagen base para la compilación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["WebDockerTest.csproj", "./"]
RUN dotnet restore "./WebDockerTest.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "WebDockerTest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebDockerTest.csproj" -c Release -o /app/publish

# Configurar la imagen final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebDockerTest.dll"]
