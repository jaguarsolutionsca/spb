

CREATE PROCEDURE [dbo].[jag_GetCalculs_Indexation]
	(
		@IndexationID int
	)
WITH RECOMPILE 
AS

DECLARE @Facture bit 
select @Facture = (select Facture from Indexation where [ID] = @IndexationID)

If (@Facture is Null) or (@Facture = 0) 
Begin
	Exec jag_Calculate_Indexation @IndexationID
END

DECLARE @IndexationTransporteur bit 
select @IndexationTransporteur = (select IndexationTransporteur from Indexation where [ID] = @IndexationID)
SET @IndexationTransporteur = (CASE WHEN @IndexationTransporteur IS NOT NULL THEN @IndexationTransporteur ELSE 1 END)

IF (@IndexationTransporteur = 1)
BEGIN
	SELECT
	ICT.LivraisonID,
	ICT.TransporteurID,
	ICT.TransporteurID + ' - ' + Fournisseur.Nom AS [Transporteur],
	L.MunicipaliteID,
	Municipalite.[Description] AS [Municipalite],
	ZoneID = case when L.[ZoneID] <> '0' and L.[ZoneID] is not null then L.[ZoneID] else '' end,
	Zone = case when L.[ZoneID] <> '0' and L.[ZoneID] is not null then L.[ZoneID] + ' - ' + mz.[Description] else '' end,
	L.VolumeTransporte AS [VolumeTransporte],
	L.VolumeAPayer AS [VolumeAPayer],
	ICT.MontantDejaPaye as [MontantDejaPaye],
	(ICT.PourcentageDuMontant * 100) AS [PourcentageDuMontant],
	ICT.Montant AS [Montant]
	FROM IndexationCalcule_Transporteur ICT
		INNER JOIN Fournisseur ON Fournisseur.[ID] = ICT.TransporteurID
		INNER JOIN Livraison L ON L.[ID] = ICT.LivraisonID
		INNER JOIN Municipalite ON Municipalite.[ID] = L.MunicipaliteID
		inner join Municipalite_Zone mz on L.MunicipaliteID = mz.MunicipaliteID and L.ZoneID = mz.[ID]
	WHERE (IndexationID = @IndexationID) OR (IndexationDetailID in (SELECT [ID] FROM Indexation_Municipalite IM WHERE IM.IndexationID = @IndexationID))
END
ELSE
BEGIN
	SELECT
	ICP.LivraisonID,
	ICP.ProducteurID,
	ICP.ProducteurID + ' - ' + Fournisseur.Nom AS [Producteur],
	ICP.EssenceID,
	ICP.Code,
	ICP.UniteID,
	(CASE WHEN MAX(ICP.Volume) IS NULL THEN SUM(LD.VolumeNet) ELSE MAX(ICP.Volume) END) AS [Volume],
	MAX(ICP.MontantDejaPaye) AS [MontantDejaPaye],
	MAX(ICP.PourcentageDuMontant * 100) AS [PourcentageDuMontant],
	MAX(ICP.Taux) AS [Taux],
	MAX(ICP.Montant) AS [Montant]
	FROM IndexationCalcule_Producteur ICP
		INNER JOIN Fournisseur ON Fournisseur.[ID] = ICP.ProducteurID
		INNER JOIN Livraison L ON L.[ID] = ICP.LivraisonID
		INNER JOIN Livraison_Detail LD ON LD.LivraisonID = L.[ID] AND LD.ProducteurID = ICP.ProducteurID
		INNER JOIN Municipalite ON Municipalite.[ID] = L.MunicipaliteID
		inner join Municipalite_Zone mz on L.MunicipaliteID = mz.MunicipaliteID and L.ZoneID = mz.[ID]
	WHERE (IndexationID = @IndexationID) OR (IndexationDetailID in (SELECT [ID] FROM Indexation_EssenceUnite IEU WHERE IEU.IndexationID = @IndexationID))
	GROUP BY ICP.LivraisonID, ICP.ProducteurID, Fournisseur.Nom, ICP.EssenceID, ICP.Code, ICP.UniteID
END

