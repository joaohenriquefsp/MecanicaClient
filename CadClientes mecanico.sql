CREATE DATABASE cadclientes;
USE cadclientes;

CREATE TABLE cliente(
	codigo INT NOT NULL AUTO_INCREMENT,
	nome VARCHAR(100) NOT NULL,
	veiculo VARCHAR(50) NOT NULL,
	marca VARCHAR(50) NOT NULL,
	PRIMARY KEY (codigo)
	);
DESCRIBE cliente;
SELECT * FROM cliente;