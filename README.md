ExamenHexagonal – Arquitectura Hexagonal con .NET 8, MySQL y EF Core

Este proyecto implementa una API REST bajo el patrón Arquitectura Hexagonal (Ports & Adapters) usando:

.NET 8 / .NET 10 compatible

Entity Framework Core

Pomelo MySQL Provider

MySQL 8

Swagger / OpenAPI

El dominio incluye Usuarios y Proyectos, completamente desacoplados del resto de capas, siguiendo buenas prácticas de Clean Architecture.

🧩 Estructura del Proyecto
ExamenHexagonal/
│
├── ExamenHexagonal.Domain/          → Entidades (Domain Models) y Puertos (Interfaces)
│
├── ExamenHexagonal.Application/     → Casos de Uso (Services)
│
├── ExamenHexagonal.Infrastructure/  → MySQL + EF Core (DbContext, Repositorios)
│
└── ExamenHexagonal.Api/             → Web API (Controllers, Swagger, Program.cs)


La regla principal es:

👉 La capa de dominio no depende de ninguna otra.
Las demás capas dependen del dominio, nunca al revés.

🛠️ Tecnologías Utilizadas
Tecnología	Versión	Uso
.NET SDK	8 / 10	Base del proyecto
Entity Framework Core	8.x	ORM para MySQL
Pomelo.EntityFrameworkCore.MySql	8.x	Conector MySQL
Swashbuckle.AspNetCore	10.x	Swagger UI
MySQL Server	8.x	Base de datos
🗄️ Base de Datos (MySQL)

Ejecuta estas sentencias antes de iniciar el proyecto:

CREATE DATABASE examen_hexagonal;
USE examen_hexagonal;

CREATE TABLE usuarios (
    id              BIGINT AUTO_INCREMENT PRIMARY KEY,
    nombre_completo VARCHAR(150) NOT NULL,
    email           VARCHAR(120) NOT NULL UNIQUE,
    rol             VARCHAR(50)  NOT NULL,
    estado          TINYINT      NOT NULL DEFAULT 1,
    fecha_registro  DATETIME     NOT NULL DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE proyectos (
    id              BIGINT AUTO_INCREMENT PRIMARY KEY,
    nombre          VARCHAR(150) NOT NULL,
    descripcion     TEXT,
    fecha_inicio    DATE,
    fecha_fin       DATE,
    estado          VARCHAR(50) NOT NULL,
    id_responsable  BIGINT,
    CONSTRAINT fk_proyectos_usuarios
        FOREIGN KEY (id_responsable)
        REFERENCES usuarios(id)
        ON DELETE SET NULL
        ON UPDATE CASCADE
);

⚙️ Configuración (appsettings.json)
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;Database=examen_hexagonal;User=root;Password=Daniel260722;TreatTinyAsBoolean=true;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}

▶️ Cómo Ejecutar el Proyecto
1. Restaurar dependencias y compilar
dotnet build ExamenHexagonal.slnx

2. Ejecutar la API
dotnet run --project ExamenHexagonal.Api

3. Abrir Swagger
http://localhost:5154/swagger

🌐 Endpoints Disponibles
🧑‍💼 Usuarios (/api/Usuarios)
✔ GET – Obtener todos los usuarios
GET /api/Usuarios

✔ GET – Obtener usuario por ID
GET /api/Usuarios/{id}

✔ POST – Crear usuario
{
  "nombreCompleto": "Juan Pérez",
  "email": "juan@correo.com",
  "rol": "ADMIN",
  "estado": 1
}

✔ PUT – Actualizar usuario
PUT /api/Usuarios/{id}

✔ DELETE – Eliminar usuario
DELETE /api/Usuarios/{id}

📁 Proyectos (/api/Proyectos)
✔ GET – Obtener proyectos
✔ POST – Crear proyecto
✔ PUT – Modificar proyecto
✔ DELETE – Eliminar proyecto

Ejemplo de creación:

{
  "nombre": "Sistema de Gestión",
  "descripcion": "Proyecto académico",
  "fechaInicio": "2025-12-01",
  "fechaFin": "2026-01-30",
  "estado": "EN_PROGRESO",
  "idResponsable": 1
}

✨ Características Clave

API totalmente documentada con Swagger

Patrón Hexagonal real (Puertos y Adaptadores)

Separación estricta entre lógica de negocio, infraestructura y presentación

Repositorios desacoplados mediante interfaces

EF Core con MySQL optimizado

📦 Comandos Git para actualizar el repositorio

Cuando quieras subir cambios:

git add .
git commit -m "Actualización del proyecto Hexagonal"
git push

📣 Autor

Jesús Daniel Quintana Santander
Proyecto académico – Arquitectura Hexagonal en .NET

