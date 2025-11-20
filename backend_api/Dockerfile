# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar csproj y restaurar dependencias
COPY src/MyLabApi/*.csproj ./
RUN dotnet restore

# Copiar código fuente
COPY src/MyLabApi/ ./

# Publicar en Release
RUN dotnet publish -c Release -o /publish

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Herramientas necesarias
RUN apt-get update && apt-get install -y netcat-openbsd && rm -rf /var/lib/apt/lists/*

COPY --from=build /publish ./

EXPOSE 5000

# ENTRYPOINT que espera a PostgreSQL antes de iniciar
ENTRYPOINT ["sh", "-c", "\
  echo 'Esperando a PostgreSQL...' && \
  until nc -z postgres 5432; do sleep 1; done && \
  echo 'PostgreSQL listo. Aplicando migraciones...' && \
  dotnet MyLabApi.dll \
"]
