USE SP_MEDICAL_GROUP
GO

INSERT INTO Clinica(nomeClinica, razaoSocial, CNPJ, endereco, horarioAber, horarioFecha)
VALUES('Clinica Possarle', 'SP Medical Group', '84400902000130', 'Av. Bar�o Limeira, 532, S�o Paulo, SP', '05:00', '23:00')
GO

INSERT INTO Especialidade(nomeEspecialidade)
VALUES('Acupuntura'),
	  ('Anestesiologia'),
      ('Angiologia'), 
      ('Cardiologia'), 
      ('Cirurgia Cardiovascular'), 
      ('Cirurgia da M�o'), 
      ('Cirurgia do Aparelho Digestivo'), 
      ('Cirurgia Geral'), 
      ('Cirurgia Pedi�trica'), 
      ('Cirurgia Pl�stica'), 
      ('Cirurgia Tor�cica'), 
      ('Cirurgia Vascular'), 
      ('Dermatologia'), 
      ('Radioterapia'), 
      ('Urologia'), 
      ('Pediatria'), 
      ('Psiquiatria')
GO

INSERT INTO TipoUsuario(sigla, tipoUsuario)
VALUES('ADM', 'Administrador'), 
	  ('MED', 'M�dico'),
	  ('PAC', 'Paciente')
GO

INSERT INTO Usuario(email, nomeUsuario, senha, tipoUsuario)
VALUES('roberto.possarle@spmedicalgroup.com.br', 'opossarle', '1234', 'ADM'),
	  ('saulo.santos@spmedicalgroup.com.br', 'saulo123', '123', 'MED'),
	  ('thiago.nascimento@spmedicalgroup.com.br', 'paodeqjo', '123', 'MED'),
	  ('odirlei.sabella@spmedicalgroup.com.br', 'odeuslei', '123', 'MED'),
	  ('henrique@gmail.com', 'hinriqui', '123', 'PAC'),
	  ('yuri@gmail.com', 'ychibs', '123', 'PAC'),
	  ('grande.mateus@gmail.com', 'teteu', '123', 'PAC'),
	  ('bueno@gmail.com', 'bueno', '123', 'PAC'),
	  ('teles@hotmail.com', 'tel�o', '123', 'PAC'),
	  ('gigi@gmail.com', 'gigi', '123', 'PAC')
GO

INSERT INTO Medico(idClinica, idEspecialidade, email, nome, crm)
VALUES(1, 17, 'saulo.santos@spmedicalgroup.com.br', 'Saulo Santos', '54356-SP'),
	  (1, 6, 'thiago.nascimento@spmedicalgroup.com.br', 'Thiago Nascimento', '53452-SP'),
	  (1, 10, 'odirlei.sabella@spmedicalgroup.com.br', 'Odirlei Sabella', '65463-SP')
GO

INSERT INTO Paciente(email, nome, dataNasc, tel, RG, CPF, endereco)
VALUES('henrique@gmail.com', 'Henrique', '10/03/2005', '1134567654', '43522543-5', '94839859000', 'Rua Estado de Israel 240,�S�o Paulo, Estado de S�o Paulo, 04022-000'),
	  ('yuri@gmail.com', 'Yuri', '24/12/2004', '11987656543', '32654345-7', '73556944057', 'Av. Paulista, 1578 - Bela Vista, S�o Paulo - SP, 01310-200'),
	  ('grande.mateus@gmail.com', 'Mateus', '18/03/2005', '11972084453', '54636525-3', '16839338002', 'Av. Ibirapuera - Indian�polis, 2927,  S�o Paulo - SP, 04029-200'),
	  ('bueno@gmail.com', 'Pedro Bueno', '24/03/2004', '1134566543', '54366362-5', '14332654765', 'R. Vit�ria, 120 - Vila Sao Jorge, Barueri - SP, 06402-030'),
	  ('teles@hotmail.com', 'Leonardo Teles', '05/05/2005', '1176566377', '53254444-1', '91305348010', 'R. Ver. Geraldo de Camargo, 66 - Santa Luzia, Ribeir�o Pires - SP, 09405-380'),
	  ('gigi@gmail.com', 'Giovanna', '23/06/2005', '11954368769', '54566266-7', '79799299004', 'Alameda dos Arapan�s, 945 - Indian�polis, S�o Paulo - SP, 04524-001')
GO

INSERT INTO Situacao(situacao)
VALUES ('Realizada'),
       ('Cancelada'),
       ('Agendada')
GO

INSERT INTO Consulta(idMedico, idPaciente, dataConsulta, situacao)
VALUES(1, 1, '10/03/2021 16:00', 'Realizada'),
	  (2, 2, '06/01/2020 10:00', 'Cancelada'),
	  (2, 3, '07/02/2020 11:00', 'Realizada'),
	  (3, 5, '06/06/2021 12:00', 'Agendada')