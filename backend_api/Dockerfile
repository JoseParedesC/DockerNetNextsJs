# Etapa 1: SDK → Build + EF migrations
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar csproj
COPY src/MyLabApi/*.csproj .
RUN dotnet restore

# Copiar todo el código
COPY src/MyLabApi/ .

# Instalar EF como herramienta local
RUN dotnet tool restore

# Crear migraciones si no existen
RUN if [ ! -d "./Migrations" ]; then \
      dotnet tool run dotnet-ef migrations add InitialCreate; \
    fi

# Publicar app
RUN dotnet publish -c Release -o /out


# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

RUN apt-get update && apt-get install -y netcat-openbsd && rm -rf /var/lib/apt/lists/*

COPY --from=build /out .

EXPOSE 5000

ENTRYPOINT ["sh", "-c", "\
  echo 'Esperando a PostgreSQL...' && \
  until nc -z postgres 5432; do sleep 1; done && \
  echo 'PostgreSQL listo. Aplicando migraciones...' && \
  dotnet MyLabApi.dll \
"]
