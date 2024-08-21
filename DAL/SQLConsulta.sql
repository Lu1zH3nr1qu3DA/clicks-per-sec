CREATE TABLE Pontuacao
	(
	UserId int primary key identity(1,1), 
	Nome varchar(255), 
	Cps varchar(4), 
	Tempo DateTime
	 )

SELECT * FROM Pontuacao
--!!DELETA TABELA!!--> DROP TABLE Pontuacao