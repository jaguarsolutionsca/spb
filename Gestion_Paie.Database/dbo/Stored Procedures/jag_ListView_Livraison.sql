

CREATE Procedure jag_ListView_Livraison
(
	@DateDebut DATETIME = NULL,
	@DateFin DATETIME = NULL,
	@Annee int = NULL,
	@Periode int = NULL,
	@ContratID varchar(10) = NULL,
	@UniteMesureID varchar(6) = NULL,
	@EssenceID varchar(6) = NULL,
	@Sciage bit = NULL,
	@CantonID varchar(6) = NULL,
	@Rang varchar(25) = NULL,
	@Lot varchar(6) = NULL,
	@MunicipaliteID varchar(6) = NULL,
	@TransporteurID varchar(15) = NULL,
	@VR varchar(10) = NULL,
	@ProducteurID varchar(15) = NULL
)

As

SELECT
Livraison.Periode,
(select top 1 (ProducteurID + ' - ' + F.nom) from Livraison_Detail inner join Fournisseur F on F.ID = ProducteurID where LivraisonID=Livraison.ID and Livraison_Detail.Droit_coupe=1) as Producteur,
NumeroFactureUsine as [Numéro de Facture],
Livraison.[ID],
CONVERT(varchar,DateLivraison,103) AS [Date],
ContratID AS [Contrat],
UniteMesureID AS [Unite de Mesure],
(CASE WHEN Sciage = 1 THEN 'Sciage' ELSE EssenceID + ' ' + LTRIM(RTRIM(Code)) END) AS [Essence],
TransporteurID + ' - ' + Fournisseur.Nom AS [Transporteur],
L.CantonID AS [Canton],
L.Rang, 
L.Lot
FROM Livraison
	LEFT OUTER JOIN Fournisseur ON Fournisseur.[ID] = TransporteurID
		left outer join Lot L on L.ID = Livraison.LotID



