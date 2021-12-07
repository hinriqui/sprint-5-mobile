CREATE DATABASE SP_MEDICAL_GROUP;
GO

USE SP_MEDICAL_GROUP;
GO

CREATE TABLE Clinica(
	idClinica INT PRIMARY KEY IDENTITY(1,1),
	nomeClinica VARCHAR(50) NOT NULL UNIQUE,
	razaoSocial VARCHAR(50) NOT NULL,
	CNPJ VARCHAR(14) NOT NULL UNIQUE,
	endereco VARCHAR(200) NOT NULL,
	horarioAber TIME,
	horarioFecha TIME
);
GO

CREATE TABLE Especialidade(
	idEspecialidade SMALLINT PRIMARY KEY IDENTITY(1,1),
	nomeEspecialidade VARCHAR(35) NOT NULL UNIQUE
);
GO

CREATE TABLE TipoUsuario(
	sigla VARCHAR(3) PRIMARY KEY NOT NULL,
	tipoUsuario VARCHAR(20) UNIQUE NOT NULL,
);

CREATE TABLE Usuario(
	email VARCHAR(256) PRIMARY KEY NOT NULL,
	tipoUsuario VARCHAR(3) FOREIGN KEY REFERENCES TipoUsuario(sigla),
	nomeUsuario VARCHAR(30) NOT NULL UNIQUE,
	senha VARCHAR(30) NOT NULL,
);
GO

CREATE TABLE Medico(
	idMedico INT PRIMARY KEY IDENTITY(1,1),
	idClinica INT FOREIGN KEY REFERENCES Clinica(idClinica),
	idEspecialidade SMALLINT FOREIGN KEY REFERENCES Especialidade(idEspecialidade),
	email VARCHAR(256) FOREIGN KEY REFERENCES Usuario(email),
	nome VARCHAR(100) NOT NULL,
	CRM VARCHAR(8)
);
GO

CREATE TABLE Paciente(
	idPaciente INT PRIMARY KEY IDENTITY(1,1),
	email VARCHAR(256) FOREIGN KEY REFERENCES Usuario(email),
	nome VARCHAR(100) NOT NULL,
	dataNasc DATE NOT NULL,
	tel VARCHAR(13),
	RG VARCHAR(10) NOT NULL UNIQUE,
	CPF VARCHAR(11) NOT NULL UNIQUE,
	endereco VARCHAR(200) NOT NULL,
);
GO

CREATE TABLE Situacao(
	situacao VARCHAR(10) PRIMARY KEY NOT NULL,
);
GO

CREATE TABLE Consulta(
	idConsulta INT PRIMARY KEY IDENTITY(1,1),
	idMedico INT FOREIGN KEY REFERENCES Medico(idMedico),
	idPaciente INT FOREIGN KEY REFERENCES Paciente(idPaciente),
	situacao VARCHAR(10) FOREIGN KEY REFERENCES Situacao(situacao),
	valor MONEY NOT NULL DEFAULT '50.00',
	dataConsulta DATETIME NOT NULL,
	descricao VARCHAR(200)
);
GO

CREATE PROCEDURE MedicoPorEspecialidade
    @idEspecialidade INT
AS

BEGIN
    SELECT COUNT(*) FROM Medico
    INNER JOIN Especialidade
    ON Medico.idEspecialidade = Especialidade.idEspecialidade
    WHERE Medico.idEspecialidade = @idEspecialidade
END

CREATE PROCEDURE CalcularIdade
    @idPaciente INT = NULL
AS

BEGIN
	DECLARE @DataNasc DATE
	SET @DataNasc = (SELECT dataNasc FROM Paciente
					 WHERE idPaciente = @idPaciente)
	DECLARE @Idade TINYINT
	SET @Idade = DATEDIFF( YEAR, @DataNasc, GETDATE() )

	PRINT @Idade
END