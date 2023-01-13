DROP TABLE IF EXISTS Users

CREATE TABLE Users (
    idUser UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
	username VARCHAR(100) NOT NULL,
	password VARCHAR(100) NOT NULL,
	firstName VARCHAR(100) NOT NULL,
	lastName VARCHAR(100) NOT NULL,
	rol VARCHAR(100) NOT NULL,
	email VARCHAR(150) NOT NULL
)