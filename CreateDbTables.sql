USE MovieCatalog;
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Movie')
	DROP TABLE Movie
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Rating')
	DROP TABLE Rating
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Genre')
	DROP TABLE Genre
GO

CREATE TABLE Genre (
	GenreId int identity(1,1) primary key not null,
	GenreType varchar(50) not null
)

CREATE TABLE Rating (
	RatingId int identity(1,1) primary key not null,
	RatingName varchar(50) not null
)

CREATE TABLE Movie (
	MovieId int identity(1,1) primary key not null,
	RatingId int foreign key references Rating(RatingId) null,
	GenreId int foreign key references Genre(GenreId) not null,
	Title varchar(50) not null
)