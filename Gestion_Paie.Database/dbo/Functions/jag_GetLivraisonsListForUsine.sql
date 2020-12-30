

CREATE FUNCTION dbo.jag_GetLivraisonsListForUsine
	(
		@Periode int,
		@Annee int,
		@UsineID varchar(6)
	
	)
RETURNS varchar(90)
AS

BEGIN
	DECLARE @s VARCHAR(90)
	SET @s = 'livraisons: '
	
	DECLARE @LivraisonID int
	DECLARE @Livraisons TABLE
	(
		[ID] int,
		[Date] smalldatetime
	)

	INSERT INTO @Livraisons
	SELECT DISTINCT
	L.[ID],
	L.DateLivraison
	FROM Livraison L
		INNER JOIN Contrat C ON C.[ID] = L.ContratID
	WHERE ( ((convert(char(4), L.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,L.[Periode]),2)))) <= ((convert(char(4), @Annee)) + convert(char(2),(RIGHT('00'+CONVERT(VARCHAR,@Periode),2)))) )
	AND ((@UsineID IS NULL) OR (C.UsineID = @UsineID))
	AND ((Facture = 0) OR (Facture IS NULL))
	ORDER BY L.[ID]

	DECLARE cursLivraisons CURSOR FOR
	SELECT [ID]
	FROM @Livraisons

	OPEN cursLivraisons

	FETCH NEXT FROM cursLivraisons INTO @LivraisonID

	WHILE @@FETCH_STATUS = 0
	BEGIN

		SET @s = @s + CONVERT(VARCHAR,@LivraisonID) + ', '
		
		FETCH NEXT FROM cursLivraisons INTO @LivraisonID
	END

	CLOSE cursLivraisons
	DEALLOCATE cursLivraisons

	SET @s = LEFT(@s, LEN(@s)-1)
	
RETURN @s
END













