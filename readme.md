# Reto Tecnico

- Este reto técnico evalúa tus habilidades en backend con .NET, frontend con React, arquitectura limpia, seguridad, patrones de resiliencia y buenas prácticas profesionales, mediante la construcción de una aplicación end-to-end.

## Requerimientos:

- [x] Conexion a una BD (PostgreSQL).
- [x] Gestión completa (CRUD) de Pedidos.
- [x] El número de pedido debe ser único

## Paquetes:

- Microsoft.AspNetCore.OpenApi
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Tools
- Npgsql.EntityFrameworkCore.PostgreSQL
- Npgsql
- Swashbuckle.AspNetCore
- Swashbuckle.AspNetCore.Swagger

## Base de Datos:

- Creacion de tablas.

```sql
CREATE TABLE pedidos (
    id SERIAL PRIMARY KEY,
    numeroPedido VARCHAR(50) NOT NULL UNIQUE,
	dni_cliente CHAR(8) NOT NULL,
    cliente VARCHAR(150) NOT NULL,
    fecha DATE NOT NULL,
    total DECIMAL(10,2) NOT NULL,
    estado CHAR(20) NOT NULL
);
```