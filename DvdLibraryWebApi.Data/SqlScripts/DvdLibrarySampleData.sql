USE DvdLibrary;
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DbReset')
		DROP PROCEDURE DbReset
GO

CREATE PROCEDURE DbReset AS
BEGIN
	DELETE FROM Dvd;

	DBCC CHECKIDENT ('dvd', RESEED, 1)

	SET IDENTITY_INSERT Dvd ON

	INSERT INTO Dvd(DvdId, Title, ReleaseYear, Director, Rating,  Notes)
	VALUES(1, 'Avatar', '2019', 'James Cameron', 'PG-13', 'Not a very good movie'),
	(2, 'Titanic', '1997', 'James Cameron', 'PG-13', 'There was room'),
	(3, 'Star Wars Episode VII - The Force Awakens', '2015', 'J.J. Abrams', 'PG-13', 'Another death star?'),
	(4, 'Jurassic World', '2015', 'Colin Trevorrow','PG-13', 'Have we not learned?'),
	(5, 'The Lion King', '2019', 'John Favreau', 'PG', 'Not as good as the animated film'),
	(6, 'The Avengers', '2012', 'Joss Whedon', 'PG-13', 'We have a hulk'),
	(7, 'Avengers: Age of Ultron', '2015', 'Joss Whedon', 'PG-13', 'There are no strings on me'),
	(8, 'Deadpool 2', '2018', 'David Leitch', 'R', 'A love story!'),
	(9, 'Cars 3', '2017', 'Brian Fee', 'G', 'Now reach for your lunch..')

	SET IDENTITY_INSERT Dvd OFF
END
GO
