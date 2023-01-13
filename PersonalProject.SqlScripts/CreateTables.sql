DROP TABLE IF EXISTS Users

CREATE TABLE Addresses (
    idAddress UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
	street VARCHAR (100) NOT NULL,
	apartment VARCHAR(100) NULL,
	city VARCHAR(100) NOT NULL,
	state VARCHAR(100) NOT NULL,
	zipCode VARCHAR(100) NOT NULL,
	country VARCHAR(100) NOT NULL,
)

CREATE TABLE Employees (
    idEmployee UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
	name VARCHAR(100) NOT NULL,
	lastName VARCHAR(100) NOT NULL,
	birthday date NOT NULL,
	gender CHAR(1) NOT NULL,
	scholarity CHAR(1) NOT NULL,
	idAddress UNIQUEIDENTIFIER NOT NULL,
	phoneNumber VARCHAR(10) NOT NULL
)

ALTER TABLE Employees ADD CONSTRAINT FK_Employees_Addresses FOREIGN KEY (idAddress) REFERENCES Addresses(idAddress)

DROP TABLE IF EXISTS Users
CREATE TABLE Users (
    idUser UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
	username VARCHAR(100) NOT NULL,
	password VARCHAR(100) NOT NULL,
	rol VARCHAR(100) NOT NULL,
	email VARCHAR(200) NOT NULL,
	idEmployee UNIQUEIDENTIFIER NOT NULL
)

ALTER TABLE Users ADD CONSTRAINT FK_Users_Employees FOREIGN KEY (idEmployee) REFERENCES Employees(idEmployee)

CREATE TABLE Patients (
    idPatient UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
	name VARCHAR(100) NOT NULL,
	lastName VARCHAR(100) NOT NULL,
	birthday date NOT NULL,
	gender CHAR(1) NOT NULL,
	idAddress UNIQUEIDENTIFIER NOT NULL,
)

ALTER TABLE Patients ADD CONSTRAINT FK_Patients_Addresses FOREIGN KEY (idAddress) REFERENCES Addresses(idAddress)

CREATE TABLE MedicalHistories(
	idMedicalHistories UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
	assignationHistory DATETIME NOT NULL,
	patientCondition VARCHAR(200) NOT NULL,
	patientSurgeries VARCHAR(200) NOT NULL,
	patientMedication VARCHAR(200) NOT NULL
)

CREATE TABLE PatientsHistory (
	idPatientsHistory UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
	idPatient UNIQUEIDENTIFIER NOT NULL,
	idHistory UNIQUEIDENTIFIER NOT NULL,
)

ALTER TABLE PatientsHistory ADD CONSTRAINT FK_PatientsHistory_Patients FOREIGN KEY (idPatient) REFERENCES Patients(idPatient)
ALTER TABLE PatientsHistory ADD CONSTRAINT FK_PatientsHistory_MedicalHistories FOREIGN KEY (idHistory) REFERENCES MedicalHistories(idMedicalHistories)

CREATE TABLE PatientsAppointMents (
	idAppointMent UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
	assignationDate DATETIME NOT NULL,
	appointMentStatus BIT NOT NULL DEFAULT 1,
)

CREATE TABLE PatientDiagnoses (
	idPatientDiagnose UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
	idAppointMent UNIQUEIDENTIFIER NOT NULL,
	idDoctor UNIQUEIDENTIFIER NOT NULL,
	symptoms VARCHAR(200),
	diagnose VARCHAR(200),
	prescription VARCHAR(200)
)

ALTER TABLE PatientDiagnoses ADD CONSTRAINT FK_PatientDiagnoses_Users FOREIGN KEY (idDoctor) REFERENCES Users(idUser)
ALTER TABLE PatientDiagnoses ADD CONSTRAINT FK_PatientDiagnoses_PatientsAppointMents FOREIGN KEY (idAppointMent) REFERENCES PatientsAppointMents(idAppointMent)

CREATE TABLE Schedules (
	idSchedule UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
	startTime DATETIME NOT NULL,
	endTime DATETIME NOT NULL,
	breakTime DATETIME NOT NULL,
	dayOfWeek CHAR(1) NOT NULL
)

CREATE TABLE DoctorSchedules (
	idDoctorSchedule UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
	idEmployee UNIQUEIDENTIFIER NOT NULL,
	idSchedule UNIQUEIDENTIFIER NOT NULL,
)

ALTER TABLE DoctorSchedules ADD CONSTRAINT FK_DoctorSchedules_Schedules FOREIGN KEY (idEmployee) REFERENCES Schedules(idSchedule)
ALTER TABLE DoctorSchedules ADD CONSTRAINT FK_DoctorSchedules_Employees FOREIGN KEY (idSchedule) REFERENCES Employees(idEmployee)
