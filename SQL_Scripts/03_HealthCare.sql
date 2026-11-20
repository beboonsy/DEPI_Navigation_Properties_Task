CREATE DATABASE DEPI_HealthCareDB;
GO
USE DEPI_HealthCareDB;
GO

CREATE TABLE Patients (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    DateOfBirth DATE NOT NULL
);
GO

CREATE TABLE Doctors (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Specialization NVARCHAR(100) NOT NULL
);
GO

CREATE TABLE Appointments (
    PatientId INT NOT NULL,
    DoctorId INT NOT NULL,
    AppointmentDate DATETIME2 NOT NULL,
    CONSTRAINT PK_Appointments PRIMARY KEY (PatientId, DoctorId, AppointmentDate),
    CONSTRAINT FK_Appointments_Patients
        FOREIGN KEY (PatientId) REFERENCES Patients(Id),
    CONSTRAINT FK_Appointments_Doctors
        FOREIGN KEY (DoctorId) REFERENCES Doctors(Id)
);
GO
