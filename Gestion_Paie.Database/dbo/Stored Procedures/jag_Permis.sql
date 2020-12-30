


CREATE  PROCEDURE dbo.jag_Permis
	(
		@ID int
	)

AS

SET NOCOUNT ON



SELECT
Permit.[ID],
DatePermit,
Usine.[Description] AS [Usine],
Usine.Rue as [Usine_Rue],
Usine.Ville as [Usine_Ville],
Usine.Code_postal as [Usine_Code_Postal],
(CASE WHEN PermitSciage = 1 THEN Permit.EssenceSciage ELSE 
(CASE WHEN Permit.Code IS NULL THEN
Essence.[Description]
WHEN ((SELECT TOP 1 [Description] FROM Contrat_EssenceUnite CEU WHERE CEU.ContratID = Permit.ContratID AND CEU.EssenceID = Permit.EssenceID AND CEU.Code = Permit.Code) IS NOT NULL) 
THEN Essence.[Description] + ' - ' + (SELECT TOP 1 [Description] FROM Contrat_EssenceUnite CEU WHERE CEU.ContratID = Permit.ContratID AND CEU.EssenceID = Permit.EssenceID AND CEU.Code = Permit.Code ORDER BY UniteID)
ELSE Essence.[Description] + ' - ' + LTRIM(RTRIM(Code))
END)
END) AS [Essence],
DateDebut,
DateFin,
TransporteurID + ' - ' + Transporteur.[Nom] AS [Transporteur],
Transporteur.Rue AS [Transporteur_Rue],
Transporteur.Ville AS [Transporteur_Ville],
Transporteur.Code_postal AS [Transporteur_Code_postal],
Transporteur.No_TPS AS [Transporteur_No_TPS],
Transporteur.No_TVQ AS [Transporteur_No_TVQ],
VR As [Transporteur_Licence],
ProducteurDroitCoupeID AS [ProducteurDroitCoupeID],
ProducteurDroitCoupeID + ' - ' + ProducteurDroitCoupe.[Nom] AS [ProducteurDroitCoupe],
ProducteurDroitCoupe.[AuSoinsDe] AS [ProducteurDroitCoupe_AuSoinsDe],
ProducteurDroitCoupe.[Rue] AS [ProducteurDroitCoupe_Rue],
ProducteurDroitCoupe.[Ville] AS [ProducteurDroitCoupe_Ville],
ProducteurDroitCoupe.[Code_postal] AS [ProducteurDroitCoupe_Code_postal],
ProducteurDroitCoupe.[No_TVQ] AS [ProducteurDroitCoupe_No_TVQ],
ProducteurDroitCoupe.[No_TPS] AS [ProducteurDroitCoupe_No_TPS],
ProducteurEntentePaiementID + ' - ' + ProducteurEntentePaiement.[Nom] AS [ProducteurEntentePaiement],
ProducteurEntentePaiement.[AuSoinsDe] AS [ProducteurEntentePaiement_AuSoinsDe],
ProducteurEntentePaiement.[Rue] AS [ProducteurEntentePaiement_Rue],
ProducteurEntentePaiement.[Ville] AS [ProducteurEntentePaiement_Ville],
ProducteurEntentePaiement.[Code_postal] AS [ProducteurEntentePaiement_Code_postal],
ProducteurEntentePaiement.[No_TVQ] AS [ProducteurEntentePaiement_No_TVQ],
ProducteurEntentePaiement.[No_TPS] AS [ProducteurEntentePaiement_No_TPS],
L.CantonID + ' - ' + Canton.[Description] AS [Canton],
L.Rang,
--l.Lot,
--L.Sequence,
--L.Partie,
L.Lot 
	+ (CASE WHEN (L.Sequence IS NOT NULL AND L.Sequence <> '') then '-' + L.Sequence else '' END) 
	+ (CASE WHEN (L.Partie is not null and L.Partie <> 0) then '(P)' else '' END) 
as [Lot],

L.Reforme,
L.Cadastre,
L.Matricule,
   
(CASE WHEN (Permit.ZoneID IS NOT NULL AND Permit.ZoneID <> '0') 
	THEN Permit.MunicipaliteID + ' - ' + Permit.ZoneID + ' - ' + Municipalite.[Description] 
	ELSE Permit.MunicipaliteID + ' - ' + Municipalite.[Description]
end)
AS [Municipalite],  

MRC.[Description] AS [MRC],
(CASE WHEN Agence.[Description] IS NOT NULL THEN Agence.[Description] ELSE Municipalite.[AgenceID] END) AS [Agence],
Usine.Specification
FROM Permit
	INNER JOIN Contrat ON Contrat.[ID] = Permit.ContratID
	INNER JOIN Usine ON Usine.[ID] = Contrat.UsineID
	LEFT OUTER JOIN Essence ON Essence.[ID] = EssenceID
	LEFT OUTER JOIN Fournisseur AS [Transporteur] ON Transporteur.[ID] = TransporteurID
	LEFT OUTER JOIN Fournisseur AS [ProducteurDroitCoupe] ON ProducteurDroitCoupe.[ID] = ProducteurDroitCoupeID
	LEFT OUTER JOIN Fournisseur AS [ProducteurEntentePaiement] ON ProducteurEntentePaiement.[ID] = ProducteurEntentePaiementID
	LEFT OUTER join Lot L on Permit.LotID = L.ID	
	LEFT OUTER JOIN Canton ON Canton.[ID] = L.CantonID
	LEFT OUTER JOIN Municipalite ON Municipalite.[ID] = Permit.[MunicipaliteID]
	LEFT OUTER JOIN Agence ON Agence.[ID] = Municipalite.[AgenceID]
	LEFT OUTER JOIN MRC ON MRC.[ID] = Municipalite.MRCID

WHERE Permit.[ID] = @ID
ORDER BY Permit.[ID]

RETURN


