USE master
GO

IF EXISTS (SELECT * FROM sys.databases WHERE name='DvdLibrary')
DROP DATABASE DvdLibrary
GO

CREATE DATABASE DvdLibrary
GO

USE DvdLibrary
GO

--Table
IF EXISTS(SELECT * FROM sys.tables WHERE name='Dvd')
	DROP TABLE Dvd
GO

CREATE TABLE Dvd (
	DvdId int identity(1,1) not null primary key,
	Title nvarchar(100) not null, 
	Director varchar(50) not null,
	Rating varchar(5) null,
	ReleaseYear varchar(4) not null,
	Notes nvarchar(500)
)
GO


