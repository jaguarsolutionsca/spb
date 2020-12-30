



CREATE PROCEDURE dbo.jag_Calculate_AjustementsNonFactures
	(
		@UsineID VARCHAR(6) = Null,
		@AjustementID INT = NULL
	)
AS

SET NOCOUNT ON

DECLARE @Ajustements TABLE
(
	[ID] int
)

INSERT INTO @Ajustements
SELECT [ID] FROM dbo.jag_GetAjustementsNonFactures (@UsineID, @AjustementID)

IF NOT EXISTS (SELECT * FROM @Ajustements)
BEGIN
	RETURN
END

DECLARE @thisAjustementID int
DECLARE cursAjustements CURSOR FOR
SELECT [ID]
FROM @Ajustements
ORDER BY [ID]

OPEN cursAjustements

FETCH NEXT FROM cursAjustements INTO @thisAjustementID

WHILE @@FETCH_STATUS = 0
BEGIN
	exec jag_Calculate_Ajustement @thisAjustementID

	FETCH NEXT FROM cursAjustements INTO @thisAjustementID
END

CLOSE cursAjustements
DEALLOCATE cursAjustements



