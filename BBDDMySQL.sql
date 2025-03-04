-- Active: 1741101830375@@127.0.0.1@3307@servicios_atemtia
-- Crear base de datos
CREATE DATABASE servicios_atemtia;
USE servicios_atemtia;

-- Tabla: Centros
CREATE TABLE Centros (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    NOMBRE VARCHAR(255) NOT NULL UNIQUE,
    DIRECCION VARCHAR(255) NOT NULL
);

CREATE TABLE Empleados (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    NOMBRE VARCHAR(255) NOT NULL,
    DNI VARCHAR(9) NOT NULL UNIQUE,
    JornadaTotalHoras INT,
    USERNAME VARCHAR(255) NOT NULL UNIQUE,
    PASSWORD VARCHAR(255) NOT NULL,
    ROL ENUM('EMPLEADO') NOT NULL DEFAULT 'EMPLEADO'
);

CREATE TABLE Usuarios (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    NOMBRE VARCHAR(255) NOT NULL,
    DNI VARCHAR(9) NOT NULL UNIQUE,
    CodigoFacturacion VARCHAR(10) NOT NULL
);

CREATE TABLE Tutores (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    NOMBRE VARCHAR(255) NOT NULL,
    DNI VARCHAR(9) NOT NULL UNIQUE,
    EMAIL VARCHAR(255),
    USERNAME VARCHAR(255) UNIQUE, 
    PASSWORD VARCHAR(255),
    ACTIVO TINYINT(1) NOT NULL DEFAULT 1,
    ROL ENUM('TUTOR') NOT NULL DEFAULT 'TUTOR'
);

CREATE TABLE Anuncios (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    TITULO VARCHAR(255) NOT NULL,
    DESCRIPCION TEXT NOT NULL,
    IMAGENURL TEXT,
    FECHA_PUBLICACION DATETIME NOT NULL,
    ACTIVO TINYINT(1) NOT NULL
);

CREATE TABLE Servicios (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    NOMBRE VARCHAR(255) NOT NULL,
    DESCRIPCION VARCHAR(1500) NOT NULL,
    ACTIVO TINYINT(1) DEFAULT TRUE,
    ID_EMPLEADO INT NOT NULL,
    CONSTRAINT FK_ServiciosEmpleados_Empleados FOREIGN KEY (ID_EMPLEADO) REFERENCES Empleados(ID) ON DELETE CASCADE
);

CREATE TABLE ServiciosCentros (
    ID_SERVICIO INT NOT NULL,
    IdCentro INT NOT NULL,
    PRIMARY KEY (ID_SERVICIO, IdCentro),
    CONSTRAINT FK_ServiciosCentros_Servicio FOREIGN KEY (ID_SERVICIO) REFERENCES Servicios(ID) ON DELETE CASCADE,
    CONSTRAINT FK_ServiciosCentros_Centro FOREIGN KEY (IdCentro) REFERENCES Centros(ID) ON DELETE CASCADE
);

CREATE TABLE UsuariosCentros (
    ID_USUARIO INT NOT NULL,
    ID_CENTRO INT NOT NULL,
    PRIMARY KEY (ID_USUARIO, ID_CENTRO),
    CONSTRAINT FK_UsuariosCentros_Usuarios FOREIGN KEY (ID_USUARIO) REFERENCES Usuarios(ID) ON DELETE CASCADE,
    CONSTRAINT FK_UsuariosCentros_Centros FOREIGN KEY (ID_CENTRO) REFERENCES Centros(ID) ON DELETE CASCADE
);

CREATE TABLE UsuariosTutores (
    ID_USUARIO INT NOT NULL,
    ID_TUTOR INT NOT NULL,
    PRIMARY KEY (ID_USUARIO, ID_TUTOR),
    CONSTRAINT FK_Usuarios_Tutores_Usuarios FOREIGN KEY (ID_USUARIO) REFERENCES Usuarios(ID) ON DELETE CASCADE,
    CONSTRAINT FK_Usuarios_Tutores_Tutores FOREIGN KEY (ID_TUTOR) REFERENCES Tutores(ID) ON DELETE CASCADE
);

CREATE TABLE Sesiones (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    FECHA DATETIME NOT NULL,
    ID_USUARIO INT NOT NULL,
    ID_EMPLEADO INT NOT NULL,
    ID_SERVICIO INT NOT NULL,
    ID_CENTRO INT NOT NULL,
    FACTURAR TINYINT(1) NOT NULL,
    CONSTRAINT FK_Sesiones_Usuarios FOREIGN KEY (ID_USUARIO) REFERENCES Usuarios(ID),
    CONSTRAINT FK_Sesiones_Empleados FOREIGN KEY (ID_EMPLEADO) REFERENCES Empleados(ID),
    CONSTRAINT FK_Sesiones_Servicios FOREIGN KEY (ID_SERVICIO) REFERENCES Servicios(ID),
    CONSTRAINT FK_Sesiones_Centros FOREIGN KEY (ID_CENTRO) REFERENCES Centros(ID)
);

CREATE TABLE EmpleadosCentros (
    ID_EMPLEADO INT NOT NULL,
    ID_CENTRO INT NOT NULL,
    PRIMARY KEY (ID_EMPLEADO, ID_CENTRO),
    CONSTRAINT FK_EmpleadosCentros_Empleado FOREIGN KEY (ID_EMPLEADO) REFERENCES Empleados(ID) ON DELETE CASCADE,
    CONSTRAINT FK_EmpleadosCentros_Centro FOREIGN KEY (ID_CENTRO) REFERENCES Centros(ID) ON DELETE CASCADE
);

CREATE TABLE OpcionesServicio (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    IDSERVICIO INT NOT NULL,
    SESIONESPORSEMANA INT DEFAULT 0, 
    DURACIONMINUTOS INT DEFAULT 0,  
    PRECIO DECIMAL(10, 2) NOT NULL CHECK(PRECIO >= 0), 
    DESCRIPCION VARCHAR(255),
    CONSTRAINT FK_OpcionesServicio_Servicio FOREIGN KEY (IDSERVICIO) REFERENCES Servicios(ID) ON DELETE CASCADE
);


-- Insertar Centros
INSERT INTO Centros (NOMBRE, DIRECCION)
VALUES ('Espacio Atemtia', 'C/ Castilla, 2, 50009 Zaragoza'),
       ('San Martin de Porres', 'C/ Octavio de Toledo, 2, 50007 Zaragoza');

-- Insertar Empleados
INSERT INTO Empleados (NOMBRE, DNI, JornadaTotalHoras, USERNAME, PASSWORD, ROL)
VALUES ('Ballesteros Rodriguez Ana', '47562374T', 40, 'aballesteros', 'password', 'EMPLEADO'),
       ('Villuendas Sierra Rosana', '87736475R', 30, 'rvilluendas', 'password', 'EMPLEADO'),
       ('Aliaga Andres Esther', '58375846F', 35, 'ealiaga', 'password', 'EMPLEADO');

-- Insertar Servicios
INSERT INTO Servicios (NOMBRE, DESCRIPCION, ACTIVO, ID_EMPLEADO) 
VALUES ('MATRONATACIÓN', 'Clases de natación para bebés y sus madres', TRUE, 1),
('INICIACIÓN', 'Clases de iniciación a la natación', TRUE, 1),
('NATACIÓN Y NATACIÓN ADAPTADA', 'Clases grupales de natación y natación adaptada', TRUE, 2),
('NATACIÓN ADULTOS', 'Clases de natación para adultos', TRUE, 2),
('AQUAGYM', 'Ejercicios acuáticos', TRUE, 3),
('NATACIÓN INDIVIDUAL NIÑOS Y ADULTOS', 'Clases individuales de natación para niños y adultos', TRUE, 3),
('RESERVA DE CALLE LIBRE', 'Reserva de calle para natación libre', TRUE, 3);

-- Relación Servicios-Centros
INSERT INTO ServiciosCentros (ID_SERVICIO, IdCentro) VALUES 
(1, 2),
(2, 2),
(3, 2),
(4, 2),
(5, 2),
(6, 2),
(7, 2);  

-- Insertar Usuarios
INSERT INTO Usuarios (NOMBRE, DNI, CodigoFacturacion)
VALUES ('Eneko Gonzalo', '12345678Z', '101453'),
       ('Ane Miren', '87654321A', '101454'),
       ('Iker Ander', '12348765B', '101455');

-- Relación Usuarios-Centros
INSERT INTO UsuariosCentros (ID_USUARIO, ID_CENTRO)
VALUES (1, 1), 
       (1, 2);

-- Insertar Tutores
INSERT INTO Tutores (NOMBRE, DNI, EMAIL, USERNAME, PASSWORD, ACTIVO, ROL)
VALUES ('Ruth Pellicer Horna', '48572634Q', 'ruth@tutors.com', 'username', 'password', 1, 'TUTOR'),
       ('Javier Serrano', '12345678A', 'jserrano@gmail.com', 'jserrano', 'password', 1, 'TUTOR');

-- Relación Usuarios-Tutores
INSERT INTO UsuariosTutores (ID_USUARIO, ID_TUTOR)
VALUES (1, 1),
       (2, 1),
       (3, 2);

-- Relación Empleados-Centros
INSERT INTO EmpleadosCentros (ID_EMPLEADO, ID_CENTRO)
VALUES (1, 1), 
       (1, 2), 
       (2, 1), 
       (3, 2);

-- Insertar Sesiones
INSERT INTO Sesiones (FECHA, ID_USUARIO, ID_EMPLEADO, ID_SERVICIO, ID_CENTRO, FACTURAR)
VALUES ('2025-03-04 09:00:00', 1, 3, 1, 1, 1),
       ('2025-03-05 09:00:00', 1, 2, 2, 1, 1);

-- Insertar algunos anuncios de ejemplo
INSERT INTO Anuncios (TITULO, DESCRIPCION, IMAGENURL, FECHA_PUBLICACION, ACTIVO)
VALUES 
    ('Nuevo Servicio de Terapia Acuática', '¡Hemos añadido terapia acuática a nuestro centro! Consulta disponibilidad.', 'https://espacioatemtia.es/wp-content/uploads/2023/07/Piscina-Atemtia-Terapias-Acu%C3%A1ticas2-scaled-1280x852.jpg', '2024-12-17 09:00:00', 1),
    ('Cambio de Horarios en Evaluaciones', 'Desde el próximo mes, las evaluaciones se realizarán los miércoles y viernes.', 'https://espacioatemtia.es/wp-content/uploads/2023/07/Piscina-Atemtia-Terapias-Acu%C3%A1ticas2-scaled-1280x852.jpg', '2024-12-17 09:00:00', 1),
    ('Promoción en Psicología', 'Este mes, sesiones de psicología con un 10% de descuento.', 'https://espacioatemtia.es/wp-content/uploads/2023/07/Piscina-Atemtia-Terapias-Acu%C3%A1ticas2-scaled-1280x852.jpg', '2024-12-17 09:00:00', 1);

-- Insertar las opciones de servicio
INSERT INTO OpcionesServicio (IDSERVICIO, SESIONESPORSEMANA, DURACIONMINUTOS, PRECIO, DESCRIPCION) VALUES 
(1, 1, 30, 50.00, '1 sesión semanal'),
(1, 2, 30, 85.00, '2 sesiones semanales'),
(2, 1, 30, 50.00, '1 sesión semanal'),
(3, 1, 45, 65.00, '1 sesión semanal'),
(4, 1, 45, 50.00, '1 sesión semanal'),
(4, 2, 45, 85.00, '2 sesiones semanales'),
(5, 1, 45, 50.00, '1 sesión semanal'),
(6, NULL, 30, 30.00, 'Sesión individual'),
(7, NULL, 30, 10.00, 'Reserva 30 minutos'),
(7, NULL, 45, 15.00, 'Reserva 45 minutos');
