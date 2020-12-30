



CREATE PROCEDURE dbo.jag_Calculate_IndexationsNonFactures
	(
		@UsineID VARCHAR(6) = Null,
		@IndexationID INT = Null
	)
AS

SET NOCOUNT ON

DECLARE @Indexations TABLE
(
	[ID] int
)

INSERT INTO @Indexations
SELECT [ID] FROM dbo.jag_GetIndexationsNonFactures (@UsineID, @IndexationID)

IF NOT EXISTS (SELECT * FROM @Indexations)
BEGIN
	RETURN
END

DECLARE @thisIndexationID int
DECLARE cursIndexations CURSOR FOR
SELECT [ID]
FROM @Indexations
ORDER BY [ID]

OPEN cursIndexations

FETCH NEXT FROM cursIndexations INTO @thisIndexationID

WHILE @@FETCH_STATUS = 0
BEGIN
	exec jag_Calculate_Indexation @thisIndexationID

	FETCH NEXT FROM cursIndexations INTO @thisIndexationID
END

CLOSE cursIndexations
DEALLOCATE cursIndexations








