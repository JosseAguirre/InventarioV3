CREATE SCHEMA INVENTARIO;

CREATE TABLE INVENTARIO.ARTICULO(
SECUENCIAL INT NOT NULL IDENTITY PRIMARY KEY,
ARTICULO VARCHAR(50) NOT NULL,
CATEGORIAARTICULO VARCHAR(50) NOT NULL
);

CREATE TABLE INVENTARIO.INGRESOCOMPUTADORES(
SECUENCIAL INT NOT NULL IDENTITY PRIMARY KEY,
SECUENCIALRESPONSABLE INT NOT NULL,
CODIGOINTERNO VARCHAR(25) UNIQUE NOT NULL,
UBICACION INT NOT NULL,
ARTICULO VARCHAR(25) NOT NULL,
MEMORIARAM INT NOT NULL,
PROCESADOR VARCHAR(50) NOT NULL,
DISCODURO INT NOT NULL,
LICENCIADO BIT NOT NULL,
OFFICE BIT NOT NULL,
MARCA VARCHAR(50) NOT NULL,
MODELO VARCHAR(50) NOT NULL,
SERIE VARCHAR(50) NOT NULL,
PARTICULARIDAD VARCHAR(70) NOT NULL,
ESTADO BIT NOT NULL,
NODEFACTURA BIGINT,
VALORFACTURA INT,
FECHAADQUISICION DATE,
OBSERVACIONES TEXT,
FOREIGN KEY (SECUENCIALRESPONSABLE) REFERENCES TAREAS.PERSONA(SECUENCIAL),
FOREIGN KEY (UBICACION) REFERENCES TAREAS.SEDE(SECUENCIAL)
);

CREATE TABLE INVENTARIO.INGRESOVARIOS(
SECUENCIAL INT NOT NULL IDENTITY PRIMARY KEY,
SECUENCIALRESPONSABLE INT NOT NULL,
CODIGOINTERNO VARCHAR(25)UNIQUE NOT NULL,
UBICACION INT NOT NULL,
SECUENCIALARTICULO INT NOT NULL,
MARCA VARCHAR(50) NOT NULL,
MODELO VARCHAR(50) NOT NULL,
SERIE VARCHAR(50) NOT NULL,
PARTICULARIDAD VARCHAR(50) NOT NULL,
ESTADO BIT NOT NULL,
NODEFACTURA BIGINT,
VALORFACTURA INT,
FECHAADQUISICION DATE,
OBSERVACIONES TEXT,
FOREIGN KEY (SECUENCIALRESPONSABLE) REFERENCES TAREAS.PERSONA(SECUENCIAL),
FOREIGN KEY (SECUENCIALARTICULO) REFERENCES INVENTARIO.ARTICULO(SECUENCIAL),
FOREIGN KEY (UBICACION) REFERENCES TAREAS.SEDE(SECUENCIAL)
);

CREATE TABLE INVENTARIO.ASIGNACIONCOMPUTADORES(
SECUENCIAL INT NOT NULL IDENTITY PRIMARY KEY,
SECUENCIALRESPONSABLE INT NOT NULL,
SECUENCIALCOMPUTADOR INT NOT NULL,
UBICACION INT NOT NULL,
FECHAASIGNACION DATE NOT NULL,
FECHAENTREGA DATE NOT NULL,
ESTADOENTREGA BIT NOT NULL,
OBSERVACIONES TEXT,
FOREIGN KEY (SECUENCIALRESPONSABLE) REFERENCES TAREAS.PERSONA(SECUENCIAL),
FOREIGN KEY (UBICACION) REFERENCES TAREAS.SEDE(SECUENCIAL),
FOREIGN KEY (SECUENCIALCOMPUTADOR) REFERENCES INVENTARIO.INGRESOCOMPUTADORES(SECUENCIAL)
);

CREATE TABLE INVENTARIO.ASIGNACIONVARIOS(
SECUENCIAL INT NOT NULL IDENTITY PRIMARY KEY,
SECUENCIALRESPONSABLE INT NOT NULL,
SECUENCIALVARIOS INT NOT NULL,
UBICACION INT NOT NULL,
FECHAASIGNACION DATE NOT NULL,
FECHAENTREGA DATE NOT NULL,
ESTADOENTREGA BIT NOT NULL,
OBSERVACIONES TEXT,
FOREIGN KEY (SECUENCIALRESPONSABLE) REFERENCES TAREAS.PERSONA(SECUENCIAL),
FOREIGN KEY (UBICACION) REFERENCES TAREAS.SEDE(SECUENCIAL),
FOREIGN KEY (SECUENCIALVARIOS) REFERENCES INVENTARIO.INGRESOVARIOS(SECUENCIAL)
);