﻿

CREATE FUNCTION dbo.jag_GetAjustementsListForTransporteur
	(
		@TransporteurID varchar(15),
		@UsineID varchar(6)	
	)
	
RETURNS varchar(90)

AS

BEGIN
	DECLARE @s VARCHAR(90)
	SET @s = 'ajustements: '

	DECLARE @AjustementID int
	DECLARE @Ajustements TABLE
	(
		[ID] int,
		[Date] smalldatetime
	)

	INSERT INTO @Ajustements
	SELECT DISTINCT
	A.[ID],
	A.DateAjustement
	FROM AjustementCalcule_Transporteur ACT
		INNER JOIN Ajustement A ON A.[ID] = ACT.[AjustementID]
		INNER JOIN Contrat C ON C.[ID] = A.ContratID
	WHERE ((@TransporteurID IS NULL) OR (ACT.TransporteurID = @TransporteurID))
	AND ((@UsineID IS NULL) OR (C.UsineID = @UsineID))
	AND ((A.Facture = 0) OR (A.Facture IS NULL))
	ORDER BY A.[ID]

	DECLARE cursAjustements CURSOR FOR
	SELECT [ID]
	FROM @Ajustements

	OPEN cursAjustements

	FETCH NEXT FROM cursAjustements INTO @AjustementID

	WHILE @@FETCH_STATUS = 0
	BEGIN

		SET @s = @s + CONVERT(VARCHAR,@AjustementID) + ', '
		
		FETCH NEXT FROM cursAjustements INTO @AjustementID
	END

	CLOSE cursAjustements
	DEALLOCATE cursAjustements

	SET @s = LEFT(@s, LEN(@s)-1)
	
RETURN @s
END









