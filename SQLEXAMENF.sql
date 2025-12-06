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
