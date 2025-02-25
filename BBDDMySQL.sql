-- Crear base de datos
CREATE DATABASE servicios_atemtia;
USE servicios_atemtia;

-- Tabla: Centros
CREATE TABLE Centros (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    NOMBRE VARCHAR(255) NOT NULL UNIQUE,
    DIRECCION VARCHAR(255) NOT NULL
);

-- Tabla: Servicios
CREATE TABLE Servicios (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    NOMBRE VARCHAR(255) NOT NULL,
    PRECIO DECIMAL(10, 2) NOT NULL
);

-- Tabla intermedia: ServiciosCentros (Relación N a N)
CREATE TABLE ServiciosCentros (
    ID_SERVICIO INT NOT NULL,
    IdCentro INT NOT NULL,
    PRIMARY KEY (ID_SERVICIO, IdCentro),
    CONSTRAINT FK_ServiciosCentros_Servicio FOREIGN KEY (ID_SERVICIO) REFERENCES Servicios(ID) ON DELETE CASCADE,
    CONSTRAINT FK_ServiciosCentros_Centro FOREIGN KEY (IdCentro) REFERENCES Centros(ID) ON DELETE CASCADE
);

-- Tabla: Empleados
CREATE TABLE Empleados (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    NOMBRE VARCHAR(255) NOT NULL,
    DNI VARCHAR(9) NOT NULL UNIQUE,
    JornadaTotalHoras INT,
    USERNAME VARCHAR(255) NOT NULL UNIQUE,
    PASSWORD VARCHAR(255) NOT NULL,
    ROL ENUM('EMPLEADO') NOT NULL DEFAULT 'EMPLEADO'
);

-- Tabla: Usuarios
CREATE TABLE Usuarios (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    NOMBRE VARCHAR(255) NOT NULL,
    DNI VARCHAR(9) NOT NULL UNIQUE,
    CodigoFacturacion VARCHAR(10) NOT NULL
);

-- Tabla intermedia: UsuariosCentros (Relación N a N)
CREATE TABLE UsuariosCentros (
    ID_USUARIO INT NOT NULL,
    ID_CENTRO INT NOT NULL,
    PRIMARY KEY (ID_USUARIO, ID_CENTRO),
    CONSTRAINT FK_UsuariosCentros_Usuarios FOREIGN KEY (ID_USUARIO) REFERENCES Usuarios(ID) ON DELETE CASCADE,
    CONSTRAINT FK_UsuariosCentros_Centros FOREIGN KEY (ID_CENTRO) REFERENCES Centros(ID) ON DELETE CASCADE
);

-- Tabla: Tutores
CREATE TABLE Tutores (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    NOMBRE VARCHAR(255) NOT NULL,
    DNI VARCHAR(9) NOT NULL UNIQUE,
    EMAIL VARCHAR(255),
    USERNAME VARCHAR(255),
    PASSWORD VARCHAR(255),
    ACTIVO TINYINT(1) NOT NULL,
    ROL ENUM('TUTOR') NOT NULL DEFAULT 'TUTOR'
);

-- Tabla intermedia: UsuariosTutores (Relación N a N)
CREATE TABLE UsuariosTutores (
    ID_USUARIO INT NOT NULL,
    ID_TUTOR INT NOT NULL,
    PRIMARY KEY (ID_USUARIO, ID_TUTOR),
    CONSTRAINT FK_Usuarios_Tutores_Usuarios FOREIGN KEY (ID_USUARIO) REFERENCES Usuarios(ID) ON DELETE CASCADE,
    CONSTRAINT FK_Usuarios_Tutores_Tutores FOREIGN KEY (ID_TUTOR) REFERENCES Tutores(ID) ON DELETE CASCADE
);

-- Tabla: Sesiones
CREATE TABLE Sesiones (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    FECHA DATETIME NOT NULL,
    ID_USUARIO INT NOT NULL,
    ID_EMPLEADO INT NOT NULL,
    ID_SERVICIO INT NOT NULL,
    FACTURAR TINYINT(1) NOT NULL,
    CONSTRAINT FK_Sesiones_Usuarios FOREIGN KEY (ID_USUARIO) REFERENCES Usuarios(ID),
    CONSTRAINT FK_Sesiones_Empleados FOREIGN KEY (ID_EMPLEADO) REFERENCES Empleados(ID),
    CONSTRAINT FK_Sesiones_Servicios FOREIGN KEY (ID_SERVICIO) REFERENCES Servicios(ID)
);

-- Tabla intermedia: EmpleadosCentros (Relación N a N)
CREATE TABLE EmpleadosCentros (
    ID_EMPLEADO INT NOT NULL,
    ID_CENTRO INT NOT NULL,
    PRIMARY KEY (ID_EMPLEADO, ID_CENTRO),
    CONSTRAINT FK_EmpleadosCentros_Empleado FOREIGN KEY (ID_EMPLEADO) REFERENCES Empleados(ID) ON DELETE CASCADE,
    CONSTRAINT FK_EmpleadosCentros_Centro FOREIGN KEY (ID_CENTRO) REFERENCES Centros(ID) ON DELETE CASCADE
);

-- Insertar Centros
INSERT INTO Centros (NOMBRE, DIRECCION)
VALUES ('Espacio Atemtia', 'C/ Castilla, 2, 50009 Zaragoza'),
       ('San Martin de Porres', 'C/ Octavio de Toledo, 2, 50007 Zaragoza');

-- Insertar Servicios
INSERT INTO Servicios (NOMBRE, PRECIO)
VALUES ('Servicios Atemtia. Evaluacion (Pruebas E Informe)', 140.00),
       ('Servicios Atemtia. Evaluacion', 75.00),
       ('Servicios Atemtia. Informes', 65.00),
       ('Atemtia. Comunicación Y Lenguaje', 25.00),
       ('Atemtia. Fisioterapia', 45.00);

-- Relación Servicios-Centros
INSERT INTO ServiciosCentros (ID_SERVICIO, IdCentro)
VALUES (1, 1), 
       (1, 2), 
       (2, 1), 
       (3, 1), 
       (4, 2), 
       (5, 2);

-- Insertar Empleados
INSERT INTO Empleados (NOMBRE, DNI, JornadaTotalHoras, USERNAME, PASSWORD, ROL)
VALUES ('Ballesteros Rodriguez Ana', '47562374T', 40, 'aballesteros', 'password', 'EMPLEADO'),
       ('Villuendas Sierra Rosana', '87736475R', 30, 'rvilluendas', 'password', 'EMPLEADO'),
       ('Aliaga Andres Esther', '58375846F', 35, 'ealiaga', 'password', 'EMPLEADO');

-- Insertar Usuarios
INSERT INTO Usuarios (NOMBRE, DNI, CodigoFacturacion)
VALUES ('Ruth Pellicer Horna (Eneko Gonzalo)', '12345678Z', '101453');

-- Relación Usuarios-Centros
INSERT INTO UsuariosCentros (ID_USUARIO, ID_CENTRO)
VALUES (1, 1), 
       (1, 2);

-- Insertar Tutores
INSERT INTO Tutores (NOMBRE, DNI, EMAIL, USERNAME, PASSWORD, ACTIVO, ROL)
VALUES ('Ruth Pellicer Horna', '48572634Q', 'ruth@tutors.com', 'username', 'password', 1, 'TUTOR');

-- Relación Usuarios-Tutores
INSERT INTO UsuariosTutores (ID_USUARIO, ID_TUTOR)
VALUES (1, 1);

-- Insertar Sesiones
INSERT INTO Sesiones (FECHA, ID_USUARIO, ID_EMPLEADO, ID_SERVICIO, FACTURAR)
VALUES ('2024-12-17 09:00:00', 1, 3, 1, 1),
       ('2024-12-17 09:00:00', 1, 2, 2, 1);

-- Relación Empleados-Centros
INSERT INTO EmpleadosCentros (ID_EMPLEADO, ID_CENTRO)
VALUES (1, 1), 
       (1, 2), 
       (2, 1), 
       (3, 2);


