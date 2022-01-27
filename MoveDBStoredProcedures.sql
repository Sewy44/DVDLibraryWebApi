USE MovieCatalog;
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'MovieSelectAll')
      DROP PROCEDURE MovieSelectAll
GO

CREATE PROCEDURE MovieSelectAll
AS
	SELECT MovieId, Title, GenreType, RatingName
	FROM Movie m 
		INNER JOIN Genre g ON m.GenreId = g.GenreId
		LEFT JOIN Rating r ON m.RatingId = r.RatingId
	ORDER BY Title
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'MovieSelectById')
      DROP PROCEDURE MovieSelectById
GO

CREATE PROCEDURE MovieSelectById (
	@MovieId int
)
AS
	SELECT MovieId, Title, GenreId, RatingId
	FROM Movie
	WHERE MovieId = @MovieId
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'MovieInsert')
      DROP PROCEDURE MovieInsert
GO

CREATE PROCEDURE MovieInsert (
	@MovieId int output,
	@GenreId int,
	@RatingId int,
	@Title Varchar(50)
)
AS
	INSERT INTO Movie (GenreId, RatingId, Title)
	VALUES (@GenreId, @RatingId, @Title)

	SET @MovieId = SCOPE_IDENTITY()
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'MovieUpdate')
      DROP PROCEDURE MovieUpdate
GO

CREATE PROCEDURE MovieUpdate (
	@MovieId int,
	@GenreId int,
	@RatingId int,
	@Title Varchar(50)
)
AS
	UPDATE Movie
		SET GenreId = @GenreId,
		RatingID = @RatingId,
		Title = @Title
	WHERE MovieId = @MovieId
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'MovieDelete')
      DROP PROCEDURE MovieDelete
GO

CREATE PROCEDURE MovieDelete (
	@MovieId int
)
AS
	DELETE FROM Movie
	WHERE MovieId = @MovieId
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'RatingSelectAll')
      DROP PROCEDURE RatingSelectAll
GO

CREATE PROCEDURE RatingSelectAll
AS
	SELECT RatingId, RatingName
	FROM Rating
	ORDER BY RatingName
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GenreSelectAll')
      DROP PROCEDURE GenreSelectAll
GO

CREATE PROCEDURE GenreSelectAll
AS
	SELECT GenreId, GenreType
	FROM Genre
	ORDER BY GenreType
GO
