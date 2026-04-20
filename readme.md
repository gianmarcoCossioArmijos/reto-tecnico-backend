# Reto Tecnico

- Este reto técnico evalúa tus habilidades en backend con .NET, frontend con React, arquitectura limpia, seguridad, patrones de resiliencia y buenas prácticas profesionales, mediante la construcción de una aplicación end-to-end.

## Link de Video de Muestra:

- https://drive.google.com/file/d/1Dis9WwTCvMaQd4MsNkL75OTP5PuTP-ny/view?usp=sharing

## Requerimientos:

- [x] Conexion a una BD (PostgreSQL)
- [x] Login y gestion de accesos
- [x] Gestión completa (CRUD) de Pedidos
- [x] Uso de Entity Framework
- [x] Autenticación y autorización con JWT (tokens con expiración)
- [x] Validación de credenciales contra base de datos
- [x] Generación de JWT Bearer Token con claims
- [x] Protección de endpoints con [Authorize]
- [x] El número de pedido debe ser único

## Endpoints:

### Login/User

- /api/v1/User/signin (POST)

### Pedidos

- /api/v1/Pedido/pedidos (GET)
- /api/v1/Pedido/buscar/{id} (GET)
- /api/v1/Pedido/registrar (POST)
- /api/v1/Pedido/modificar/{id} (PUT)
- /api/v1/Pedido/eliminar/{id} (DELETE)

## Requisitos de Proyecto:

- .NET 9
- PostgresSQL 16.0

### Packetes para Proyecto

- Microsoft.AspNetCore.OpenApi
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Tools
- Npgsql.EntityFrameworkCore.PostgreSQL
- Npgsql
- Swashbuckle.AspNetCore
- Swashbuckle.AspNetCore.Swagger
- Newtonsoft.Json

### Base de datos

- Para el proyecto se debe crear una base de datos en Postgres y enlazarla al proyecto, no sera necesario crear la talblas ya que se usara Entity
- Debemos crear entidades y ejecutar los comando de migracion y actualizacion para ver reflejadas las tablas en la DB

`Comando de Migracion y Actualizacion: `
 
 ```sh
	Add-Migration "init"
	Update-Database
 ```