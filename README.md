# Sistema de Gestión de Clientes, Productos y Ventas

[![.NET Version](https://img.shields.io/badge/.NET-8.0.0-blue.svg)](https://dotnet.microsoft.com/)
[![SQL Server](https://img.shields.io/badge/SQL%20Server-2022-orange.svg)](https://www.microsoft.com/en-us/sql-server)
[![License](https://img.shields.io/badge/license-MIT-green.svg)](https://opensource.org/licenses/MIT)

## Descripción

Este proyecto es un sistema básico de gestión de clientes, productos, ventas y entregas desarrollado en .NET 8 y utilizando SQL Server como base de datos. La API permite realizar operaciones CRUD (Crear, Leer, Actualizar, Eliminar) sobre las tablas de clientes, productos, ventas, notas de crédito y entregas. Además, incluye búsquedas específicas para obtener información de clientes por apellido, NIT, y para listar productos con fechas de vencimiento específicas.

### Características principales:
- **Clientes:** Gestión completa de clientes, incluyendo búsqueda por apellido y NIT.
- **Productos:** Administración de productos, con la posibilidad de filtrar por fecha de vencimiento.
- **Ventas:** Creación y consulta de ventas, incluyendo la posibilidad de gestionar devoluciones y anulaciones mediante notas de crédito.
- **Entregas:** Registro de entregas de productos a clientes, incluyendo el estado y la ubicación de la entrega.

## Tecnologías Utilizadas

- **Backend:**
  - [.NET 8](https://dotnet.microsoft.com/) - Framework para construir la API RESTful.
  - [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/) - ORM para gestionar la base de datos SQL Server.
  
- **Base de Datos:**
  - [SQL Server 2022](https://www.microsoft.com/en-us/sql-server) - Base de datos relacional utilizada para almacenar los datos de clientes, productos, ventas, notas de crédito y entregas.

### configura la cadena de la base de datos
"ConnectionStrings": {
    "DefaultConnection": "Server=tu-servidor;Database=nombre-db;User Id=tu-usuario;Password=tu-contraseña;"
}

Restaura las dependencias y compila el proyecto:
dotnet restore
dotnet build

Corre el proyecto:
dotnet run
