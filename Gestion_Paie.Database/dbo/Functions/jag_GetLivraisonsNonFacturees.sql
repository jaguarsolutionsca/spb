CREATE FUNCTION [dbo].[jag_GetLivraisonsNonFacturees]
(@Periode INT, @Annee INT, @UsineID VARCHAR (6)=Null, @LivraisonID INT=Null, @SuspendrePaiement BIT=Null)
RETURNS TABLE 
AS
RETURN 
    (
	SELECT TOP 100 PERCENT
	L.[ID],
	Contrat.UsineID,
	Usine.[Description] AS [Usine],
	NumeroFactureUsine AS [NoFacture],
	CONVERT(VARCHAR,DateLivraison,103) AS [Date],
	Montant_Usine,
	ROUND((Montant_Producteur1 + Montant_Producteur2),2) AS [Montant_Producteur],
	ROUND((Montant_Preleve_Plan_Conjoint + Montant_Preleve_Fond_Roulement + Montant_Preleve_Fond_Forestier + Montant_Preleve_Divers),2) AS [Montant_Preleve],
	Montant_Transporteur,
	Montant_Surcharge,
	Montant_MiseEnCommun,
	ErreurCalcul,
	ErreurDescription
	FROM Livraison L
		INNER JOIN Contrat ON Contrat.[ID] = L.ContratID
		INNER JOIN Usine ON Usine.[ID] = Contrat.UsineID
	WHERE ( ((convert(char(4), L.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,L.[Periode]),2)))) <= ((convert(char(4), @Annee)) + convert(char(2),(RIGHT('00'+CONVERT(VARCHAR,@Periode),2)))) )
	AND ((@UsineID IS NULL) OR (Usine.[ID] = @UsineID))
	--AND ((@Annee IS NULL) OR (Contrat.[Annee] = @Annee))
	--AND ((@Annee IS NULL) OR (L.[Annee] = @Annee))
	AND ((@LivraisonID IS NULL) OR (L.[ID] = @LivraisonID))
	AND ((Facture = 0) OR (Facture IS NULL))
	AND ((@SuspendrePaiement is null) or(SuspendrePaiement = @SuspendrePaiement))
	ORDER BY L.[ID]--Livraison.ContratID, DateLivraison
)



