

CREATE PROCEDURE dbo.jag_Rapport_Transporteur_DetailLivraisonsTransporteurs
	(		
		@PeriodeDebut int = Null,
		@PeriodeFin int = Null,
		@AnneeDebut int = Null,
		@AnneeFin int = Null,
		@MuniDebut varchar(6) = Null,
		@MuniFin varchar(6) = Null,
		@TransporteurDebut varchar(15) = Null,
		@TransporteurFin varchar(15) = Null,
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
	TransporteurID VARCHAR(15),
	Periode INT,
	[Date] smalldatetime,
	UsineID VARCHAR(6),
	Essence VARCHAR(20),
	FactureUsine VARCHAR(25),
	MunicipaliteID VARCHAR(6),
	ZoneID VARCHAR(2),
	UniteMesureID VARCHAR(6),
	VolumeNet FLOAT,
	Montant_Transporteur FLOAT,
	Montant_Surcharge FLOAT,
	MntFraisChargement float,
	MntAutresFrais float,
	MntCompensationDeplacement float,
	MntAutresRevenus float,
	FactureID INT,	
	isAjustement bit
)

INSERT INTO @Livraisons
SELECT
L.LotID,
L.[ID],
L.TransporteurID,
L.Periode,
L.DateLivraison,
C.UsineID,
(CASE WHEN Sciage = 0 THEN L.EssenceID + ' ' + LTRIM(RTRIM(L.Code)) ELSE 'Sciage' END),
L.NumeroFactureUsine as FactureUsine,
L.MunicipaliteID,
L.ZoneID,
L.UniteMesureID,
L.VolumeAPayer AS [VolumeNet],
L.Montant_Transporteur as MontantNet,
L.Montant_Surcharge as Surcharge,
null,
null,
null,
null,
L.Transporteur_FactureID AS FactureID, 
0
FROM Livraison L
	--inner join Lot Lo on L.LotID = Lo.ID
		INNER JOIN Contrat C ON C.[ID] = L.ContratID
			--left outer join FactureFournisseur FF ON FF.[ID] = L.Transporteur_FactureID
WHERE 

		((@MuniDebut 	is null) or (L.[MunicipaliteID] >= @MuniDebut))
	AND 	((@MuniFin 	is null) or (L.[MunicipaliteID] <= @MuniFin))
	AND		((@TransporteurDebut 	is null) or (L.[TransporteurID] >= @TransporteurDebut))
	AND 	((@TransporteurFin 	is null) or (L.[TransporteurID] <= @TransporteurFin))
	AND		((@UsineDebut 	is null) or (C.[UsineID] >= @UsineDebut))
	AND 	((@UsineFin 	is null) or (C.[UsineID] <= @UsineFin))
	AND 	((@AnneeDebut 	is null and @PeriodeDebut is null) or ( ((convert(char(4), L.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,L.[Periode]),2)))) >= ((convert(char(4), @AnneeDebut)) + (convert(char(2),RIGHT('00'+CONVERT(VARCHAR,@PeriodeDebut),2)))) ))
	AND 	((@AnneeFin 	is null and @PeriodeFin is null) or ( ((convert(char(4), L.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,L.[Periode]),2)))) <= ((convert(char(4), @AnneeFin)) + (convert(char(2),RIGHT('00'+CONVERT(VARCHAR,@PeriodeFin),2)))) ))



	AND 	(L.Facture = 1)
	AND 	(L.TransporteurID IS NOT NULL)
ORDER BY L.[ID]




INSERT INTO @Livraisons
SELECT
L.LotID,
L.[ID],
L.TransporteurID,
L.Periode,
L.DateLivraison,
C.UsineID,
(CASE WHEN Sciage = 0 THEN L.EssenceID + ' ' + LTRIM(RTRIM(L.Code)) ELSE 'Sciage' END),
L.NumeroFactureUsine as FactureUsine,
L.MunicipaliteID,
L.ZoneID,
L.UniteMesureID,
null,
null,
null,
(-1 * L.Frais_ChargeurAuTransporteur),
(-1 * L.Frais_AutresAuTransporteur),
L.Frais_CompensationDeDeplacement,
Frais_AutresRevenusTransporteur,
L.Transporteur_FactureID AS FactureID, 
0
FROM Livraison L
	INNER JOIN Contrat C ON C.[ID] = L.ContratID
WHERE 

		((@MuniDebut 	is null) or (L.[MunicipaliteID] >= @MuniDebut))
	AND 	((@MuniFin 	is null) or (L.[MunicipaliteID] <= @MuniFin))
	AND	((@TransporteurDebut 	is null) or (L.[TransporteurID] >= @TransporteurDebut))
	AND 	((@TransporteurFin 	is null) or (L.[TransporteurID] <= @TransporteurFin))
	AND	((@UsineDebut 	is null) or (C.[UsineID] >= @UsineDebut))
	AND 	((@UsineFin 	is null) or (C.[UsineID] <= @UsineFin))
	AND 	((@AnneeDebut 	is null and @PeriodeDebut is null) or ( ((convert(char(4), L.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,L.[Periode]),2)))) >= ((convert(char(4), @AnneeDebut)) + (convert(char(2),RIGHT('00'+CONVERT(VARCHAR,@PeriodeDebut),2)))) ))
	AND 	((@AnneeFin 	is null and @PeriodeFin is null) or ( ((convert(char(4), L.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,L.[Periode]),2)))) <= ((convert(char(4), @AnneeFin)) + (convert(char(2),RIGHT('00'+CONVERT(VARCHAR,@PeriodeFin),2)))) ))
	AND 	(L.Facture = 1)
	AND 	(L.TransporteurID IS NOT NULL)
	and (	(L.Frais_ChargeurAuTransporteur <> 0) or (L.Frais_AutresAuTransporteur <> 0) or 
		(L.Frais_CompensationDeDeplacement <> 0) or (L.Frais_AutresRevenusTransporteur <> 0))
ORDER BY L.[ID]





INSERT INTO @Livraisons
SELECT
MAX(L.LotID),
ACT.LivraisonID,
MAX(L.TransporteurID),
MAX(L.Periode),
MAX(L.DateLivraison),
NULL,
NULL,
NULL,
NULL,
NULL,
NULL,
NULL,
SUM(ACT.Montant),
NULL,
null,
null,
null,
null,
MAX(ACT.FactureID),
1
FROM AjustementCalcule_Transporteur ACT
	inner join Livraison L on L.[ID] = ACT.LivraisonID
	INNER JOIN Contrat C ON C.[ID] = L.ContratID
WHERE 
		((@MuniDebut 	is null) or (L.[MunicipaliteID] >= @MuniDebut))
	AND 	((@MuniFin 	is null) or (L.[MunicipaliteID] <= @MuniFin))
	AND		((@TransporteurDebut 	is null) or (L.[TransporteurID] >= @TransporteurDebut))
	AND 	((@TransporteurFin 	is null) or (L.[TransporteurID] <= @TransporteurFin))
	AND		((@UsineDebut 	is null) or (C.[UsineID] >= @UsineDebut))
	AND 	((@UsineFin 	is null) or (C.[UsineID] <= @UsineFin))
	AND 	((@AnneeDebut 	is null and @PeriodeDebut is null) or ( ((convert(char(4), L.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,L.[Periode]),2)))) >= ((convert(char(4), @AnneeDebut)) + (convert(char(2),RIGHT('00'+CONVERT(VARCHAR,@PeriodeDebut),2)))) ))
	AND 	((@AnneeFin 	is null and @PeriodeFin is null) or ( ((convert(char(4), L.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,L.[Periode]),2)))) <= ((convert(char(4), @AnneeFin)) + (convert(char(2),RIGHT('00'+CONVERT(VARCHAR,@PeriodeFin),2)))) ))



	AND 	(L.Facture = 1)
GROUP BY ACT.LivraisonID
ORDER BY ACT.LivraisonID


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
F.Nom AS [Transporteur],
L.Periode,
CONVERT(VARCHAR, L.[Date], 103) AS [Date],
(CASE WHEN isAjustement = 0 THEN L.UsineID ELSE 'Ajustements' END) AS [Usine],
(CASE WHEN isAjustement = 0 THEN L.Essence ELSE '' END) AS [Essence],
(CASE WHEN isAjustement = 0 THEN L.FactureUsine ELSE '' END) AS [FactureUsine],
(CASE WHEN isAjustement = 0 THEN 
	M.[Description] + case when L.[ZoneID] is null or L.[ZoneID] = '0' then '' else ' (' + MZ.[Description] + ')' end
ELSE '' END) AS [Municipalite],
(CASE WHEN isAjustement = 0 THEN L.UniteMesureID ELSE '' END) AS [Unite],
(CASE WHEN isAjustement = 0 THEN L.VolumeNet ELSE '' END) AS VolumeNet,
Montant_Transporteur AS Montant_Transporteur,
Montant_Surcharge AS Montant_Surcharge,
MntFraisChargement,
MntAutresFrais,
MntCompensationDeplacement,
MntAutresRevenus,
FF.NoFacture AS [NoFacture]
FROM @Livraisons L
	left outer JOIN FactureFournisseur FF ON FF.[ID] = L.FactureID
	INNER JOIN Fournisseur F ON F.[ID] = L.TransporteurID
	LEFT OUTER JOIN Municipalite M ON M.[ID] = L.MunicipaliteID
	--left outer join Lot on Lot.[ID] = L.LotID
	left outer join Municipalite_Zone MZ on L.ZoneID = MZ.[ID] and L.MunicipaliteID = MZ.MunicipaliteID
ORDER BY F.Nom, L.Periode, L.LivraisonID, L.isAjustement

