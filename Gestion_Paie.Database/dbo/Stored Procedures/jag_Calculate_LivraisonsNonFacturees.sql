CREATE PROCEDURE [dbo].[jag_Calculate_LivraisonsNonFacturees]
@Periode INT, @Annee INT, @Usines VARCHAR (4000)=Null, @LivraisonID INT=NULL, @SuspendrePaiement BIT=Null
AS
SET NOCOUNT ON

DECLARE @tUsines TABLE
(
	[ID] varchar(6)	
)

DECLARE @Livraisons TABLE
(
	[ID] int
)

IF (@Usines IS NOT NULL)
BEGIN
	INSERT INTO @tUsines ([ID])
	select * from Split(@Usines,';')

	DECLARE @CurrentUsine varchar(6)
	
	DECLARE cursUsine CURSOR FOR
		SELECT [ID] FROM @tUsines
	
	OPEN cursUsine
	
	FETCH NEXT FROM cursUsine INTO @CurrentUsine
	
	WHILE @@FETCH_STATUS = 0
	BEGIN
		INSERT INTO @Livraisons
		SELECT [ID] FROM dbo.jag_GetLivraisonsNonFacturees (@Periode, @Annee, @CurrentUsine, @LivraisonID, @SuspendrePaiement)
	
		FETCH NEXT FROM cursUsine INTO @CurrentUsine
	END
	
	-- Deallocate resources
	CLOSE cursUsine
	DEALLOCATE cursUsine
END
ELSE
BEGIN
	INSERT INTO @Livraisons
	SELECT [ID] FROM dbo.jag_GetLivraisonsNonFacturees (@Periode, @Annee, NULL, @LivraisonID,@SuspendrePaiement)
END

IF NOT EXISTS (SELECT * FROM @Livraisons)
BEGIN
	RETURN
END

DECLARE @thisLivraisonID int
DECLARE cursLivraisons CURSOR FOR
SELECT [ID]
FROM @Livraisons
ORDER BY [ID]

OPEN cursLivraisons

FETCH NEXT FROM cursLivraisons INTO @thisLivraisonID

WHILE @@FETCH_STATUS = 0
BEGIN
	exec jag_Calculate_Livraison @thisLivraisonID

	FETCH NEXT FROM cursLivraisons INTO @thisLivraisonID
END

CLOSE cursLivraisons
DEALLOCATE cursLivraisons


