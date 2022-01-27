USE MovieCatalog;
GO

SET IDENTITY_INSERT Genre ON

INSERT INTO Genre (GenreId, GenreType)
VALUES (1, 'Action'),
	(2, 'Horror'),
	(3, 'Kids'),
	(4, 'Mystery'),
	(5, 'Romance'),
	(6, 'Sci-Fi')

SET IDENTITY_INSERT Genre OFF

SET IDENTITY_INSERT Rating ON

INSERT INTO Rating (RatingId, RatingName)
VALUES (1, 'G'),
	(2, 'PG'),
	(3, 'PG-13'),
	(4, 'R')

SET IDENTITY_INSERT Rating OFF

SET IDENTITY_INSERT Movie ON

INSERT INTO Movie (MovieId, RatingId, GenreId, Title)
VALUES (1, 1, 3, 'The Lion King'),
	(2, 4, 6, 'Terminator'),
	(3, 4, 2, 'Friday the 13th'),
	(4, null, 6, 'This movie has no rating')

SET IDENTITY_INSERT Movie OFF