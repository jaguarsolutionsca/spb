CREATE PROCEDURE [dbo].[jag_Rapport_Livraison_ListeDesCalculsNonFactures]
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
	SELECT [ID] FROM dbo.jag_GetLivraisonsNonFacturees (@Periode, @Annee, NULL, @LivraisonID, @SuspendrePaiement)
END

SELECT
Contrat.UsineID,
NumeroFactureUsine,
CONVERT(VARCHAR,Livraison.DateLivraison,103) AS [Date],
Montant_Usine,
ROUND((Montant_Producteur1 + Montant_Producteur2),2) AS [Montant_Producteur],
Taux_Transporteur,
Montant_Transporteur,
Montant_Preleve_Plan_Conjoint,
Montant_Preleve_Fond_Roulement,
Montant_Preleve_Fond_Forestier,
Montant_Preleve_Divers,
Montant_Surcharge,
Montant_MiseEnCommun,
Frais_ChargeurAuProducteur,
Frais_ChargeurAuTransporteur,
Frais_AutresAuProducteur + Frais_AutresAuProducteurTransportSciage,
Frais_AutresAuTransporteur,
Frais_CompensationDeDeplacement,
Frais_AutresRevenusProducteur,
Frais_AutresRevenusTransporteur
FROM Livraison
	INNER JOIN Contrat ON Contrat.[ID] = Livraison.ContratID
WHERE Livraison.[ID] in (SELECT [ID] FROM @Livraisons)
ORDER BY Livraison.ContratID, RIGHT('000000000000000000000000'+NumeroFactureUsine,25)


