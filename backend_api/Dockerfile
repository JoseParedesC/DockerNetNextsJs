# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar el proyecto y restaurar dependencias
COPY src/MyLabApi/MyLabApi.csproj .
RUN dotnet restore

# Copiar el resto del código fuente
COPY src/MyLabApi/ ./
RUN dotnet publish -c Release -o /publish

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /publish ./

EXPOSE 8080
ENTRYPOINT ["dotnet", "MyLabApi.dll"]
