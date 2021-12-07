USE SP_MEDICAL_GROUP_MANHA
GO

SELECT * FROM Usuario

SELECT * FROM Paciente

SELECT * FROM Clinica

SELECT * FROM Medico

SELECT * FROM Especialidade

SELECT * FROM Consulta
WHERE Consulta.idMedico = 1

SELECT * FROM Consulta
WHERE Consulta.idPaciente = 1

SELECT COUNT(email) FROM Usuario

SELECT *, CONVERT(VARCHAR, CONVERT(DATE, dataNasc, 103), 110) FROM Paciente

EXEC MedicoPorEspecialidade @idEspecialidade = 17

EXEC CalcularIdade @idPaciente = 1