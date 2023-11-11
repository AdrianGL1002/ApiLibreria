/*Se crea la base de datos*/
CREATE DATABASE libreria;
USE libreria;
/*Se crean las tablas*/
CREATE TABLE author (id int IDENTITY (1,1), named varchar(100));
CREATE TABLE book(id int IDENTITY (1,1), title varchar(75), chapters int, pages int, price int, author_id int );
/*Llaves primarias*/
ALTER TABLE book ADD CONSTRAINT PK_book PRIMARY KEY (id);
ALTER TABLE author ADD CONSTRAINT PK_author PRIMARY KEY (id);
/*Llave foranea*/
ALTER TABLE book ADD CONSTRAINT FK_author_book FOREIGN KEY (author_id) REFERENCES author(id);

/*Insercion de datos*/
INSERT INTO author (named) VALUES ('Jack London');
INSERT INTO author (named) VALUES ('Ana Frank');

INSERT INTO book (title, chapters, pages, price, author_id) VALUES ('Colmillo Blanco', 5, 238, 200, 1);
INSERT INTO book (title, chapters, pages, price, author_id) VALUES ('Diario de Ana Frank', 15, 222, 190, 2);

SELECT * FROM author;