

CREATE PROCEDURE dbo.jag_Rapport_Chargeur_DetailLivraisonsChargeurs
	(		
		@PeriodeDebut int = Null,
		@PeriodeFin int = Null,
		@AnneeDebut int = Null,
		@AnneeFin int = Null,
		@MuniDebut varchar(6) = Null,
		@MuniFin varchar(6) = Null,
		@ChargeurDebut varchar(15) = Null,
		@ChargeurFin varchar(15) = Null,
		@UsineDebut varchar(6) = Null,
		@UsineFin varchar(6) = Null
	)
AS

SET NOCOUNT ON


SET NOCOUNT ON

DECLARE @Livraisons TABLE
(
	LotID int,
	LivraisonID INT,
	ChargeurID VARCHAR(15),
	Periode INT,
	[Date] smalldatetime,
	UsineID VARCHAR(6),
	Essence VARCHAR(20),
	FactureUsine VARCHAR(25),
	MunicipaliteID VARCHAR(6),
	ZoneID VARCHAR(2),
	UniteMesureID VARCHAR(6),
	VolumeNet FLOAT,
	Montant_Chargeur FLOAT,
	FactureID INT
)

INSERT INTO @Livraisons
SELECT
L.LotID,
L.[ID],
L.ChargeurID,
L.Periode,
L.DateLivraison,
C.UsineID,
(CASE WHEN Sciage = 0 THEN L.EssenceID + ' ' + LTRIM(RTRIM(L.Code)) ELSE 'Sciage' END),
L.NumeroFactureUsine as FactureUsine,
L.MunicipaliteID,
L.ZoneID,
L.UniteMesureID,
L.VolumeAPayer AS [VolumeNet],
L.Montant_Chargeur as MontantNet,
L.Chargeur_FactureID AS FactureID
FROM Livraison L
	--inner join Lot Lo on L.LotID = Lo.ID
		INNER JOIN Contrat C ON C.[ID] = L.ContratID
			--left outer join FactureFournisseur FF ON FF.[ID] = L.Transporteur_FactureID
WHERE 

		((@MuniDebut 	is null) or (L.[MunicipaliteID] >= @MuniDebut))
	AND 	((@MuniFin 	is null) or (L.[MunicipaliteID] <= @MuniFin))
	AND		((@ChargeurDebut 	is null) or (L.[ChargeurID] >= @ChargeurDebut))
	AND 	((@ChargeurFin 	is null) or (L.[ChargeurID] <= @ChargeurFin))
	AND		((@UsineDebut 	is null) or (C.[UsineID] >= @UsineDebut))
	AND 	((@UsineFin 	is null) or (C.[UsineID] <= @UsineFin))
	AND 	((@AnneeDebut 	is null and @PeriodeDebut is null) or ( ((convert(char(4), L.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,L.[Periode]),2)))) >= ((convert(char(4), @AnneeDebut)) + (convert(char(2),RIGHT('00'+CONVERT(VARCHAR,@PeriodeDebut),2)))) ))
	AND 	((@AnneeFin 	is null and @PeriodeFin is null) or ( ((convert(char(4), L.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,L.[Periode]),2)))) <= ((convert(char(4), @AnneeFin)) + (convert(char(2),RIGHT('00'+CONVERT(VARCHAR,@PeriodeFin),2)))) ))

	AND 	(L.Facture = 1)
	AND 	(L.ChargeurID IS NOT NULL)
ORDER BY L.[ID]

-- liste des fournisseurs qui recoivent des taxes
declare @ProducteurRecoitTPS table
(
	ID varchar(16)
)
insert into @ProducteurRecoitTPS 
select ID from Fournisseur where RecoitTPS = 1
   
declare @ProducteurRecoitTVQ table
(
	ID varchar(16)
)
insert into @ProducteurRecoitTVQ 
select ID from Fournisseur where RecoitTVQ = 1


SELECT 
--LivraisonID6,
F.[ID] AS [Code],
F.Nom AS [Chargeur],
L.Periode,
CONVERT(VARCHAR, L.[Date], 103) AS [Date],
L.UsineID AS [Usine],
L.Essence AS [Essence],
L.FactureUsine AS [FactureUsine],
M.[Description] + (case when L.[ZoneID] is null or L.[ZoneID] = '0' then '' else ' (' + MZ.[Description] + ')' end) AS [Municipalite],
L.UniteMesureID AS [Unite],
L.VolumeNet AS VolumeNet,
Montant_Chargeur AS Montant_Chargeur,
FF.NoFacture AS [NoFacture]
FROM @Livraisons L
	INNER JOIN FactureFournisseur FF ON FF.[ID] = L.FactureID
	INNER JOIN Fournisseur F ON F.[ID] = L.ChargeurID
	LEFT OUTER JOIN Municipalite M ON M.[ID] = L.MunicipaliteID
	--left outer join Lot on Lot.[ID] = L.LotID
	left outer join Municipalite_Zone MZ on L.ZoneID = MZ.[ID] and L.MunicipaliteID = MZ.MunicipaliteID
ORDER BY F.Nom, L.Periode, L.LivraisonID

