USE DvdLibrary;
GO

IF EXISTS(
	SELECT *
		FROM INFORMATION_SCHEMA.ROUTINES
		WHERE ROUTINE_NAME = 'DvdSelectById')
BEGIN
   DROP PROCEDURE DvdSelectById
END
GO

CREATE PROCEDURE DvdSelectById (
	@DvdId int
)
AS
	SELECT DvdId, Title, ReleaseYear, Director, Rating, Notes
	FROM Dvd
	WHERE DvdId = @DvdId
GO

IF EXISTS(
	SELECT *
		FROM INFORMATION_SCHEMA.ROUTINES
		WHERE ROUTINE_NAME = 'DvdSelectAll')
BEGIN
   DROP PROCEDURE DvdSelectAll
END
GO

CREATE PROCEDURE DvdSelectAll
AS
	SELECT DvdId, Title, ReleaseYear, Director, Rating, Notes
	FROM Dvd
GO

IF EXISTS(
	SELECT *
		FROM INFORMATION_SCHEMA.ROUTINES
		WHERE ROUTINE_NAME = 'DvdInsert')
BEGIN
   DROP PROCEDURE DvdInsert
END
GO

CREATE PROCEDURE DvdInsert (
	@DvdId int output,
	@Title nvarchar(100),
	@Director varchar(50),
	@Rating varchar(5),
	@ReleaseYear varchar(4),
	@Notes nvarchar(500)
)AS 
BEGIN
	INSERT INTO Dvd(Title, Director, Rating, ReleaseYear, Notes)
	VALUES(
	@Title, @Director, @Rating,@ReleaseYear, @Notes);

	SET @DvdId = SCOPE_IDENTITY();
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DvdUpdate')
		DROP PROCEDURE DvdUpdate
GO

CREATE PROCEDURE DvdUpdate (
	@DvdId int,
	@Title nvarchar(100),
	@Director varchar(50),
	@Rating varchar(5),
	@ReleaseYear varchar(4),
	@Notes nvarchar(500)
)AS 
BEGIN
	UPDATE Dvd SET
		Title = @Title,
		Director = @Director,
		Rating = @Rating, 
		ReleaseYear = @ReleaseYear, 
		Notes = @Notes
	WHERE DvdId = @DvdId
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DvdDelete')
		DROP PROCEDURE DvdDelete
GO

CREATE PROCEDURE DvdDelete (
	@DvdId int
) AS	
BEGIN
	BEGIN TRANSACTION

	DELETE FROM Dvd WHERE DvdId = @DvdId;

	COMMIT TRANSACTION
END
GO

IF EXISTS(
	SELECT *
		FROM INFORMATION_SCHEMA.ROUTINES
		WHERE ROUTINE_NAME = 'DvdSelectByTitle')
BEGIN
   DROP PROCEDURE DvdSelectByTitle
END
GO

CREATE PROCEDURE DvdSelectByTitle (
	@Title nvarchar(100)
)
AS
	SELECT DvdId, Title, ReleaseYear, Director, Rating, Notes
	FROM Dvd
	WHERE Title LIKE '%'+@Title+'%'
GO

IF EXISTS(
	SELECT *
		FROM INFORMATION_SCHEMA.ROUTINES
		WHERE ROUTINE_NAME = 'DvdSelectByReleaseYear')
BEGIN
   DROP PROCEDURE DvdSelectByReleaseYear
END
GO

CREATE PROCEDURE DvdSelectByReleaseYear (
	@ReleaseYear varchar(4)
)
AS
	SELECT DvdId, Title, ReleaseYear, Director, Rating, Notes
	FROM Dvd
	WHERE ReleaseYear LIKE '%'+@ReleaseYear+'%'
GO

IF EXISTS(
	SELECT *
		FROM INFORMATION_SCHEMA.ROUTINES
		WHERE ROUTINE_NAME = 'DvdSelectByRating')
BEGIN
   DROP PROCEDURE DvdSelectByRating
END
GO

CREATE PROCEDURE DvdSelectByRating (
	@Rating varchar(5)
)
AS
	SELECT DvdId, Title, ReleaseYear, Director, Rating, Notes
	FROM Dvd
	WHERE 1 = 1 AND Rating LIKE '%'+@Rating+'%'
GO

IF EXISTS(
	SELECT *
		FROM INFORMATION_SCHEMA.ROUTINES
		WHERE ROUTINE_NAME = 'DvdSelectByDirectorName')
BEGIN
   DROP PROCEDURE DvdSelectByDirectorName
END
GO

CREATE PROCEDURE DvdSelectByDirectorName (
	@Director varchar(50)
)
AS
	SELECT DvdId, Title, ReleaseYear, Director, Rating, Notes
	FROM Dvd
	WHERE Director LIKE '%'+@Director+'%'
GO



