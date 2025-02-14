-- Active: 1739544464478@@127.0.0.1@3306@servicios_atemtia
CREATE DATABASE servicios_atemtia;
USE servicios_atemtia;


-- Tabla: Servicios
CREATE TABLE Servicios (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    NOMBRE VARCHAR(255) NOT NULL,
    PRECIO DECIMAL(10, 2) NOT NULL
);


-- Tabla: Empleados
CREATE TABLE Empleados (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    NOMBRE VARCHAR(255) NOT NULL,
    DNI VARCHAR(9) NOT NULL,
    JornadaTotalHoras INT,
    ROL ENUM('EMPLEADO') NOT NULL DEFAULT 'EMPLEADO'
);


-- Tabla: Usuarios
CREATE TABLE Usuarios (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    NOMBRE VARCHAR(255) NOT NULL,
    DNI VARCHAR(9) NOT NULL,
    CodigoFacturacion VARCHAR(10) NOT NULL
);


-- Tabla: Tutores
CREATE TABLE Tutores (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    NOMBRE VARCHAR(255) NOT NULL,
    DNI VARCHAR(9) NOT NULL,
    EMAIL VARCHAR(255),
    USERNAME VARCHAR(255),
    PASSWORD VARCHAR(255),
    ACTIVO ENUM('S', 'N') NOT NULL,
    ROL ENUM('TUTOR') NOT NULL DEFAULT 'TUTOR'
);


-- Tabla intermedia: Usuarios_Tutores (Relación N a N)
CREATE TABLE Usuarios_Tutores (
    ID_USUARIO INT NOT NULL,
    ID_TUTOR INT NOT NULL,
    PRIMARY KEY (ID_USUARIO, ID_TUTOR),
    CONSTRAINT FK_Usuarios_Tutores_Usuarios FOREIGN KEY (ID_USUARIO) REFERENCES Usuarios (ID) ON DELETE CASCADE,
    CONSTRAINT FK_Usuarios_Tutores_Tutores FOREIGN KEY (ID_TUTOR) REFERENCES Tutores (ID) ON DELETE CASCADE
);


-- Tabla: Sesiones
CREATE TABLE Sesiones (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    FECHA DATETIME NOT NULL,
    ID_USUARIO INT NOT NULL,
    ID_EMPLEADO INT NOT NULL,
    ID_SERVICIO INT NOT NULL,
    FACTURAR ENUM('S', 'N') NOT NULL,
    CONSTRAINT FK_Sesiones_Usuarios FOREIGN KEY (ID_USUARIO) REFERENCES Usuarios (ID),
    CONSTRAINT FK_Sesiones_Empleados FOREIGN KEY (ID_EMPLEADO) REFERENCES Empleados (ID),
    CONSTRAINT FK_Sesiones_Servicios FOREIGN KEY (ID_SERVICIO) REFERENCES Servicios (ID)
);


-- Inserciones de ejemplo para cada tabla


-- Servicios
INSERT INTO Servicios (NOMBRE, PRECIO) VALUES
('Servicios Atemtia. Evaluacion (Pruebas E Informe)', 140.00),
('Servicios Atemtia. Evaluacion', 75.00),
('Servicios Atemtia. Informes', 65.00),
('Atemtia. Comunicación Y Lenguaje', 25.00),
('Atemtia. Fisioterapia', 45.00);


-- Empleados
INSERT INTO Empleados (NOMBRE, DNI, JornadaTotalHoras, ROL) VALUES
('Ballesteros Rodriguez Ana', '47562374T', 40, 'EMPLEADO'),
('Villuendas Sierra Rosana', '87736475R', 30, 'EMPLEADO'),
('Aliaga Andres Esther', '58375846F', 35, 'EMPLEADO');

-- Usuarios
INSERT INTO Usuarios (NOMBRE, DNI, CodigoFacturacion) VALUES
('Ruth Pellicer Horna (Eneko Gonzalo)', '12345678Z', '101453');


INSERT INTO Tutores (NOMBRE, DNI, EMAIL, USERNAME, PASSWORD, ACTIVO, ROL) VALUES
('Ruth Pellicer Horna', '48572634Q', 'ruth@tutors.com', 'username', 'password', 'S', 'TUTOR');


-- Relación Usuarios_Tutores
INSERT INTO Usuarios_Tutores (ID_USUARIO, ID_TUTOR) VALUES
(1, 1);


-- Sesiones
INSERT INTO Sesiones (FECHA, ID_USUARIO, ID_EMPLEADO, ID_SERVICIO, FACTURAR) VALUES
('2024-12-17 09:00:00', 1, 3, 1, 'S'),
('2024-12-17 09:00:00', 1, 2, 2, 'S');
