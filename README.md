# edu-apoyos-api

## Patrones utilizados

- **Clean Architecture**: Separacion logica de negocio de tecnologias, frameworks, etc de terceros.
- **CQRS + Mediator (MediatR)**: Separa las acciones de lectura de las acciones de escritura. Desacopla los endpoints de los handlers.
- **Repository**: Desacopla logica de negocio del origen de datos.
- **Specification**: Encierra criterios de consulta, evitando demasiadas condidiones en repositorios.
- **Result Pattern (ErrorOr)**: Permite controlar respuestas, donde se entrega el dato esperado o en caso de excepcion responder el error.
- **Mapping (Mapster)**: Reduce la codificacion de mapeo entre modelos.
- **Middleware de excepciones centralizado**: Entrega un unico modelo de respuesta en caso de error.


## Servicios de Azuer a usar
- **Azure Blob Storage**: Para centralizar el manejo de archivos y tener mejor rendimiento al gestionar archivos.
- **Azure Key Vault**: Para manejar de manera centralizado, controlada y segura datos que son sensibles.


## Instrucciones de ejecución

Requisitos: Docker y Docker Compose. El repositorio edu-apoyos-web debe estar clonado como carpeta hermana de este edu-apoyos-api, ya que alli se encuentra el `docker-compose.yml` que construye su imagen desde ahí.

Levantar todo el stack (SQL Server, API y Web):

**En ventana de comandos corre:** docker compose up --build

Esto levanta:

- **sqlserver**: SQL Server 2022 en `localhost:1433` (usuario `sa`, password `YourStrong!Passw0rd`).
- **api**: API .NET en `http://localhost:8080` 
- **web**: Frontend Angular (SSR) en `http://localhost:4000`.
Al levantar la aplicación se ejecutan las migraciones y la carga de datos seed automáticamente.


Para detener y eliminar los contenedores:

**En ventana de comandos corre:** docker compose down

Para reiniciar con la base de datos limpia (borra el volumen `sqlserver-data`):

**En ventana de comandos corre:**
docker compose down -v
docker compose up --build

