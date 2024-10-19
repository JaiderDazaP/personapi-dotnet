## ==============================
# Build stage for ASP.NET Core
# ==============================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar el archivo .csproj y restaurar dependencias
COPY *.csproj ./
RUN dotnet restore

# Copiar todo el código fuente y compilar la aplicación
COPY . ./
RUN dotnet publish -c Release -o out

# ==============================
# SQL Server Setup Stage
# ==============================
FROM mcr.microsoft.com/mssql/server:2019-latest AS sqlserver
USER root

# Install prerequisites
RUN apt-get update && \
    apt-get install -y curl apt-transport-https gnupg && \
    curl https://packages.microsoft.com/keys/microsoft.asc | apt-key add - && \
    curl https://packages.microsoft.com/config/ubuntu/20.04/prod.list > /etc/apt/sources.list.d/mssql-release.list && \
    apt-get update && \
    ACCEPT_EULA=Y apt-get install -y msodbcsql17 mssql-tools && \
    echo 'export PATH="$PATH:/opt/mssql-tools/bin"' >> ~/.bashrc && \
    apt-get clean && \
    rm -rf /var/lib/apt/lists/*

# Copiar el script de inicialización
COPY entrypoint.sh /entrypoint.sh
RUN chmod +x /entrypoint.sh

# Switch back to the mssql user for running the server
USER mssql

# ==============================
# Runtime stage for ASP.NET Core
# ==============================
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copiar los archivos generados por la etapa de compilación
COPY --from=build /app/out .

# Exponer el puerto de la aplicación ASP.NET Core
EXPOSE 80

# Copiar el archivo entrypoint.sh y configuraciones de SQL Server
COPY --from=sqlserver /entrypoint.sh /entrypoint.sh
RUN chmod +x /entrypoint.sh

# Ejecutar el SQL Server y la aplicación ASP.NET Core
ENTRYPOINT ["/entrypoint.sh"]

