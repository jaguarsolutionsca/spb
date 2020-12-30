

CREATE PROCEDURE dbo.jag_Rapport_LivraisonNonConforme
	(
		@PeriodeDebut int,
		@PeriodeFin int,
		@AnneeDebut int,
		@AnneeFin int,
		@FournisseurID varchar(15)
	)
AS

SET NOCOUNT ON


SELECT
ID,
F.Nom,
F.Rue,
F.Ville,
UPPER(F.Code_Postal) AS [Code_Postal]
FROM Fournisseur F 
WHERE F.ID = @FournisseurID

SELECT
L.DateLivraison AS [DateLivraison],
L.NumeroFactureUsine AS [FactureUsine],
L.[ID] AS [Permis],
P.DateDebut AS [DateDebutPermis],
P.DateFin AS [DateFinPermis],
C.UsineID AS [Usine],
L.UniteMesureID AS [Unite],
LD.EssenceID + ' ' + LTRIM(RTRIM(LD.Code)) AS [Essence],
LD.VolumeNet AS [Volume],
LD.Montant_Usine,
LD.Montant_TransporteurMoyen AS [Montant_Transporteur],
Round((LD.Montant_Preleve_Plan_Conjoint + LD.Montant_Preleve_Fond_Roulement + LD.Montant_Preleve_Fond_Forestier + LD.Montant_Preleve_Divers),2) AS [Montant_Preleve],
LD.Montant_ProducteurNet AS [Montant_Producteur]

FROM Livraison L 
	INNER JOIN Livraison_Detail LD ON LD.[LivraisonID] = L.[ID]
	INNER JOIN Contrat C ON C.[ID] = L.ContratID
	INNER JOIN Permit P ON P.ID = L.ID
where 
	-- Condition pour filtrer
	((L.DateLivraison < P.DateDebut) or (L.DateLivraison > P.DateFin))and
	-- Conditions pour l'intervale
	((@PeriodeDebut is null and @AnneeDebut is null) or ( ((convert(char(4), L.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,L.[Periode]),2)))) >= ((convert(char(4), @AnneeDebut)) + (convert(varchar,RIGHT('00'+CONVERT(VARCHAR,@PeriodeDebut),2)))) )) AND
	((@PeriodeFin is null and @AnneeFin is null) or ( ((convert(char(4), L.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,L.[Periode]),2)))) <= ((convert(char(4), @AnneeFin)) + (convert(varchar,RIGHT('00'+CONVERT(VARCHAR,@PeriodeFin),2)))) )) AND
	--(@AnneeDebut + @PeriodeDebut/100	<= (L.Annee + L.Periode/100)) and 
	--(@AnneeFin	 + @PeriodeFin/100	>= (L.Annee + L.Periode/100)) and
	(@FournisseurID = L.DroitCoupeID) and
	(L.Facture = 1)

ORDER BY L.DateLivraison DESC

