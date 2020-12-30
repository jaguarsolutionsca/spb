

CREATE FUNCTION dbo.jag_GetIndexationsListForTransporteur
	(
		@TransporteurID varchar(15),
		@UsineID varchar(6)	
	)
	
RETURNS varchar(90)

AS

BEGIN
	DECLARE @s VARCHAR(90)
	SET @s = 'indexations: '

	DECLARE @IndexationID int
	DECLARE @Indexations TABLE
	(
		[ID] int,
		[Date] smalldatetime
	)

	INSERT INTO @Indexations
	SELECT DISTINCT
	I.[ID],
	I.DateIndexation
	FROM IndexationCalcule IC
		INNER JOIN Indexation I ON I.[ID] = IC.[IndexationID]
		INNER JOIN Contrat C ON C.[ID] = I.ContratID
	WHERE ((@TransporteurID IS NULL) OR (IC.TransporteurID = @TransporteurID))
	AND ((@UsineID IS NULL) OR (C.UsineID = @UsineID))
	AND ((I.Facture = 0) OR (I.Facture IS NULL))
	ORDER BY I.[ID]

	DECLARE cursIndexations CURSOR FOR
	SELECT [ID]
	FROM @Indexations

	OPEN cursIndexations

	FETCH NEXT FROM cursIndexations INTO @IndexationID

	WHILE @@FETCH_STATUS = 0
	BEGIN

		SET @s = @s + CONVERT(VARCHAR,@IndexationID) + ', '
		
		FETCH NEXT FROM cursIndexations INTO @IndexationID
	END

	CLOSE cursIndexations
	DEALLOCATE cursIndexations

	SET @s = LEFT(@s, LEN(@s)-1)
	
RETURN @s
END









