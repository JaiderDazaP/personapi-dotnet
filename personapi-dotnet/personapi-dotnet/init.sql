-- Crear base de datos
CREATE DATABASE persona_db;
GO

-- Usar la base de datos recién creada
USE persona_db;

-- Crear tabla de profesión
CREATE TABLE profesion (
  id INT PRIMARY KEY,
  nom VARCHAR(90),
  des TEXT
);

-- Crear tabla de persona
CREATE TABLE persona (
  cc INT PRIMARY KEY,
  nombre VARCHAR(45),
  apellido VARCHAR(45),
  genero CHAR(1),
  edad INT
);

-- Crear tabla de estudios
CREATE TABLE estudios (
  id_prof INT,
  cc_per INT,
  fecha DATE,
  univer VARCHAR(50),
  PRIMARY KEY (id_prof, cc_per),
  FOREIGN KEY (id_prof) REFERENCES profesion(id),
  FOREIGN KEY (cc_per) REFERENCES persona(cc)
);

-- Crear tabla de teléfono
CREATE TABLE telefono (
  num VARCHAR(15) PRIMARY KEY,
  oper VARCHAR(45),
  duenio INT,
  FOREIGN KEY (duenio) REFERENCES persona(cc)
);

-- Insertar datos en la tabla profesion
INSERT INTO profesion (id, nom, des) 
VALUES (1, 'Ingeniero', 'Encargado de proyectos de ingeniería'),
       (2, 'Médico', 'Profesional de la salud');

-- Insertar datos en la tabla persona
INSERT INTO persona (cc, nombre, apellido, genero, edad) 
VALUES (1010101, 'Juan', 'Pérez', 'M', 30),
       (2020202, 'Ana', 'Gómez', 'F', 25);

-- Insertar datos en la tabla estudios
INSERT INTO estudios (id_prof, cc_per, fecha, univer)
VALUES (1, 1010101, '2010-06-15', 'Universidad Nacional'),
       (2, 2020202, '2012-09-23', 'Universidad de los Andes');

-- Insertar datos en la tabla telefono
INSERT INTO telefono (num, oper, duenio) 
VALUES ('3001234567', 'Claro', 1010101),
       ('3109876543', 'Movistar', 2020202);
