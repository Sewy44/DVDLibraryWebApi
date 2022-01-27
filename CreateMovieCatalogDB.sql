USE master
GO

IF EXISTS(SELECT * FROM sys.databases WHERE name='MovieCatalog')
DROP DATABASE MovieCatalog
GO

CREATE DATABASE MovieCatalog
GO


