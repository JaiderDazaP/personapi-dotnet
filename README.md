# personapi-dotnet
Integrantes:
Jaider Daza
Camilo Melo
Valentina Lopez

# Person API con .NET 8.0 y SQL Server

Este proyecto es una API REST construida con *ASP.NET Core 8.0* utilizando el patrón *MVC* y *Entity Framework Core* para el acceso a los datos. La base de datos utilizada es *SQL Server 2019, y todo está containerizado usando **Docker*.

## Requisitos previos

Asegúrate de tener lo siguiente instalado en tu máquina:

1. *Docker* (versión 20.10 o superior)
2. *Docker Compose* (versión 1.29 o superior)
3. *.NET 8.0 SDK* (si deseas ejecutar la aplicación localmente sin Docker)

## Estructura del proyecto

- *Dockerfile*: Define cómo construir y ejecutar tanto la base de datos SQL Server como la aplicación .NET.
- *docker-compose.yml*: Orquesta los contenedores de SQL Server y la aplicación ASP.NET Core.
- *entrypoint.sh*: Maneja el inicio de SQL Server y la ejecución del script de inicialización de la base de datos, además de ejecutar la aplicación ASP.NET Core.
- *init.sql*: Script que configura la base de datos, tablas y datos iniciales.
- *Models/Entities*: Carpeta que contiene los modelos de entidad para Entity Framework Core.
- *Controllers*: Carpeta que contiene los controladores de la API para manejar las operaciones CRUD.

## Configuración

La aplicación utiliza una cadena de conexión para conectarse a la base de datos SQL Server, que está configurada en el archivo appsettings.json en la sección ConnectionStrings:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=sqlserver;Database=persona_db;User=sa;Password=Jaider123#;TrustServerCertificate=true"
}

##Compilacion
Para compilarlo ingresa a la carpeta donde esta el proyecto .NET
1. docker-compose up --build
2. localhost:8080/(swagger o entidad)