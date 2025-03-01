-- Active: 1740842915843@@127.0.0.1@3307@servicios_atemtia
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
    DESCRIPCION VARCHAR(1500) NOT NULL,
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


-- Tabla: Anuncios
CREATE TABLE Anuncios (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    TITULO VARCHAR(255) NOT NULL,
    DESCRIPCION TEXT NOT NULL,
    IMAGENURL TEXT,
    FECHA_PUBLICACION DATETIME NOT NULL,
    ACTIVO TINYINT(1) NOT NULL
);

-- Insertar Centros
INSERT INTO Centros (NOMBRE, DIRECCION)
VALUES ('Espacio Atemtia', 'C/ Castilla, 2, 50009 Zaragoza'),
       ('San Martin de Porres', 'C/ Octavio de Toledo, 2, 50007 Zaragoza');

-- Insertar Servicios
INSERT INTO Servicios (NOMBRE, DESCRIPCION, PRECIO)
VALUES 
    ('Evaluacion (Pruebas E Informe)', 'Evaluación completa que incluye pruebas diagnósticas y elaboración de informe detallado.', 140.00),
    ('Evaluacion', 'Evaluación inicial para determinar necesidades específicas del usuario.', 75.00),
    ('Informes', 'Elaboración de informes detallados sobre el progreso y estado del usuario.', 65.00),
    ('Comunicación Y Lenguaje', 'Terapia especializada en mejorar habilidades de comunicación y desarrollo del lenguaje.', 25.00),
    ('Fisioterapia', 'Sesiones de fisioterapia para mejorar la movilidad y funcionalidad física.', 45.00),
    ('Psicomotricidad', 'Sesiones para desarrollar la coordinación motora y habilidades psicomotrices.', 35.00),
    ('Psicología', 'Apoyo psicológico y terapia para mejorar el bienestar emocional.', 40.00),
    ('Estimulación Temprana', 'Programa de actividades para potenciar el desarrollo cognitivo y sensorial en edades tempranas.', 30.00),
    ('Terapia Acuática', 'Terapia en medio acuático para mejorar la movilidad y reducir el impacto en articulaciones.', 50.00),
    ('Natación Adaptada', 'Clases de natación adaptadas a personas con necesidades especiales.', 35.00);

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




-- Insertar algunos anuncios de ejemplo

INSERT INTO Anuncios (TITULO, DESCRIPCION, IMAGENURL, FECHA_PUBLICACION, ACTIVO)
VALUES 
    ('Nuevo Servicio de Terapia Acuática', '¡Hemos añadido terapia acuática a nuestro centro! Consulta disponibilidad.', 'https://espacioatemtia.es/wp-content/uploads/2023/07/Piscina-Atemtia-Terapias-Acu%C3%A1ticas2-scaled-1280x852.jpg', '2024-12-17 09:00:00', 1),
    
    ('Cambio de Horarios en Evaluaciones', 'Desde el próximo mes, las evaluaciones se realizarán los miércoles y viernes.', 'https://espacioatemtia.es/wp-content/uploads/2023/07/Piscina-Atemtia-Terapias-Acu%C3%A1ticas2-scaled-1280x852.jpg', '2024-12-17 09:00:00', 1),
    
    ('Promoción en Psicología', 'Este mes, sesiones de psicología con un 10% de descuento.', 'https://espacioatemtia.es/wp-content/uploads/2023/07/Piscina-Atemtia-Terapias-Acu%C3%A1ticas2-scaled-1280x852.jpg', '2024-12-17 09:00:00', 1);
