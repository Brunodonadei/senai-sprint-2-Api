CREATE DATABASE T_Peoples

USE T_Peoples

CREATE TABLE Funcionarios
(
	idFuncionario INT PRIMARY KEY IDENTITY
	,nome		  VARCHAR(255) NOT NULL
	,sobrenome	  VARCHAR(255) NOT NULL
)