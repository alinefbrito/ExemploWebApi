DROP DATABASE if EXISTS dblivros;
CREATE DATABASE if NOT exists dblivros;
USE dblivros;
CREATE TABLE if not exists livro (id_livro smallint AUTO_INCREMENT, 
					titulo varchar(100) NOT NULL, 
					genero VARCHAR(50) NOT NULL,  
					preco double, 
					primary key(id_livro) );
					
					
INSERT INTO livro (titulo, genero, preco) VALUES ("Orgulho e Preconceito", "romance", 25.75);
INSERT INTO livro (titulo, genero, preco) VALUES ("A sociedade do Anel", "fantasia", 35.75);
INSERT INTO livro (titulo, genero, preco) VALUES ("Algoritmos para viver", "tecnologia", 22.75);
INSERT INTO livro (titulo, genero, preco) VALUES ("Iracema", "romance", 26.32);
INSERT INTO livro (titulo, genero, preco) VALUES ("O gato preto", "terror", 13.13);
INSERT INTO livro (titulo, genero, preco) VALUES ("Os sete maridos de Evelyn hugo", "romance", 34.43);
					
SELECT * FROM livro;