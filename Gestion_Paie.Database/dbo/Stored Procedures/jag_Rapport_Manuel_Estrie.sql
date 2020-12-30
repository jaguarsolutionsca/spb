

CREATE PROCEDURE [dbo].[jag_Rapport_Manuel_Estrie]

AS
Begin
SET NOCOUNT ON



declare @DateDebut SMALLDATETIME
declare @DateFin SMALLDATETIME

set @DateDebut = '2009-01-01'
set @DateFin = '2009-12-31'


select 
	C.UsineID Usine,
	C.[Description] Nom,
	SUM(Frais_AutresAuTransporteur)[Transporteur AutresFrais],
	SUM(Frais_AutresRevenusTransporteur) [Transporteur AutresRevenus],
	SUM(Frais_AutresAuProducteur) [Producteur AutresFrais],
	SUM(Frais_AutresRevenusProducteur) [Producteur AutresRevenus]
	--,SUM(L.Montant_MiseEnCommun)
FROM Livraison L
	INNER JOIN Contrat C ON C.[ID] = L.ContratID
WHERE L.Facture = 1
AND ( DATEDIFF(day, @DateDebut, L.DatePaye) >= 0 AND DATEDIFF(day, @DateFin, L.DatePaye) <= 0)
group by C.USineID,C.[Description]



select 
	C.UsineID Usine,
	C.[Description] Nom,
	Frais_AutresAuTransporteur[Transporteur AutresFrais],
	Frais_AutresRevenusTransporteur [Transporteur AutresRevenus],
	Frais_AutresAuProducteur [Producteur AutresFrais],
	Frais_AutresRevenusProducteur [Producteur AutresRevenus],
	replace(REPLACE(Frais_AutresRevenusTransporteurDescription, CHAR(13),' '), CHAR(10), ' ') Frais_AutresRevenusTransporteurDescription,
	replace(REPLACE(Frais_AutresRevenusProducteurDescription, CHAR(13),' '), CHAR(10), ' ') Frais_AutresRevenusProducteurDescription,
	replace(REPLACE(Frais_AutresAuProducteurDescription, CHAR(13),' '), CHAR(10), ' ') Frais_AutresAuProducteurDescription,
	replace(REPLACE(Frais_AutresAuTransporteurDescription, CHAR(13),' '), CHAR(10), ' ') Frais_AutresAuTransporteurDescription,
	replace(REPLACE(Commentaires_Producteur, CHAR(13),' '), CHAR(10), ' ') Commentaires_Producteur,
	replace(REPLACE(Commentaires_Transporteur, CHAR(13),' '), CHAR(10), ' ') Commentaires_Transporteur
	
	
FROM Livraison L
	INNER JOIN Contrat C ON C.[ID] = L.ContratID
WHERE L.Facture = 1
AND ( DATEDIFF(day, @DateDebut, L.DatePaye) >= 0 AND DATEDIFF(day, @DateFin, L.DatePaye) <= 0)
and (
Frais_AutresAuTransporteur<>0 or
Frais_AutresRevenusTransporteur <>0 or
Frais_AutresAuProducteur <>0 or
Frais_AutresRevenusProducteur <>0
)





end

