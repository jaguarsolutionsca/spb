

CREATE PROCEDURE dbo.jag_Get_Permis
	(
		@Date DATETIME = NULL,
		@ProducteurID varchar(15) = NULL,
		@Sciage BIT = NULL,
		@EssenceID VARCHAR(6) = NULL,
		@Code CHAR(4) = NULL
	)
AS


SELECT
Permit.[ID],
DatePermit,
Contrat.UsineID AS [Usine],
(CASE WHEN PermitSciage = 1 THEN 'Sciage' ELSE EssenceID + ' ' + LTRIM(RTRIM(Code)) END) AS [Essence],
ProducteurDroitCoupeID + ' - ' + Fournisseur.[Nom] AS [DroitCoupe],
L.CantonID AS [Canton],
L.Rang, 
L.Lot,
L.[Sequence],
L.[Partie],
Permit.MunicipaliteID,
Permit.ZoneID,
L.Secteur
FROM 
	Permit
	left outer join Lot L on Permit.LotID = L.ID
	INNER JOIN Fournisseur ON Fournisseur.[ID] = ProducteurDroitCoupeID
	INNER JOIN Contrat ON Contrat.ID = ContratID


WHERE 
	((@Date IS NULL) OR ((DateDebut >= @Date) AND (DateFin <= @Date)))
AND 	((PermitLivre = 0)OR(PermitLivre IS NULL)) AND ((PermitAnnule = 0)OR(PermitAnnule IS NULL))
AND 	((@ProducteurID IS NULL) OR (ProducteurDroitCoupeID = @ProducteurID))
AND 	((@EssenceID IS NULL) OR (EssenceID = @EssenceID))
AND 	((@Code IS NULL) OR (Code = @Code))
AND 	((@Sciage IS NULL) OR (PermitSciage = @Sciage))


