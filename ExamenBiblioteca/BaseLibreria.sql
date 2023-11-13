-- Crear la tabla "autor"
CREATE TABLE autor (
    Id INT IDENTITY(1, 1) PRIMARY KEY,
    nombre NVARCHAR(255) NOT NULL
);

-- Crear la tabla "libro" con la relación a la tabla "autor"
CREATE TABLE libro (
    Id INT IDENTITY(1, 1) PRIMARY KEY,
    titulo NVARCHAR(255) NOT NULL,
    capitulos INT,
    paginas INT,
    precio REAL,
    autorId INT,
    FOREIGN KEY (autorId) REFERENCES autor(Id)
);



INSERT INTO autor (nombre)
VALUES
    ('Grabriel Garcia Marquez'),
    ('Octavio Paz'),
    ('Jane Austen'),
    ('George Orwell'),
    ('Charles Dickens');

	-- Insertar datos de libros para los autores
-- Autor 1
INSERT INTO libro (titulo, capitulos, paginas, precio, autorId)
VALUES
    ('Cien años desoledad', 10, 200, 25.99, 1),
    ('El otoño del patriarca', 15, 300, 35.99, 1);

-- Autor 2
INSERT INTO libro (titulo, capitulos, paginas, precio, autorId)
VALUES
    ('El laberinto de la soledad', 12, 250, 29.99, 2),
    ('Piedra de sol', 18, 350, 39.99, 2);

-- Autor 3
INSERT INTO libro (titulo, capitulos, paginas, precio, autorId)
VALUES
    ('Orgullo y prejuicio', 14, 280, 27.99, 3),
    ('Sentido y sensibilidad', 20, 400, 44.99, 3);

-- Autor 4
INSERT INTO libro (titulo, capitulos, paginas, precio, autorId)
VALUES
    ('1984', 16, 320, 31.99, 4),
    ('Homenaje a Cataluña', 22, 450, 49.99, 4);

-- Autor 5
INSERT INTO libro (titulo, capitulos, paginas, precio, autorId)
VALUES
    ('Cuento de navidad', 13, 270, 26.99, 5),
    ('Grandes esperanzas', 19, 380, 41.99, 5);

	delete from autor
