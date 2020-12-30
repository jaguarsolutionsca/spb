CREATE PROCEDURE [dbo].[jag_Get_LivraisonsNonFacturees]
@Periode INT, @Annee INT, @Usines VARCHAR (4000)=Null, @LivraisonID INT=NULL
AS
declare @SuspendrePaiement bit
set @SuspendrePaiement = 0

exec jag_Clear_FactureEnAttente

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
	SELECT [ID] FROM dbo.jag_GetLivraisonsNonFacturees (@Periode, @Annee, NULL, @LivraisonID, @SuspendrePaiement)
END

SELECT 
L.[ID],
Contrat.UsineID,
Usine.[Description] AS [Usine],
L.NumeroFactureUsine AS [NoFacture],
CONVERT(VARCHAR,L.DateLivraison,103) AS [Date],
L.Montant_Usine,
ROUND((L.Montant_Producteur1 + L.Montant_Producteur2),2) AS [Montant_Producteur],
ROUND((L.Montant_Preleve_Plan_Conjoint + L.Montant_Preleve_Fond_Roulement + L.Montant_Preleve_Fond_Forestier + L.Montant_Preleve_Divers),2) AS [Montant_Preleve],
L.Montant_Transporteur,
L.Montant_Surcharge,
L.Montant_MiseEnCommun,
L.ErreurCalcul,
L.ErreurDescription
FROM @Livraisons L2
	INNER JOIN Livraison L ON L.ID = L2.ID
	INNER JOIN Contrat ON Contrat.[ID] = L.ContratID
	INNER JOIN Usine ON Usine.[ID] = Contrat.UsineID
ORDER BY L.[ID]


