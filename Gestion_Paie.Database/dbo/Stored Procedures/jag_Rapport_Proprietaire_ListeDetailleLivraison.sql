


CREATE PROCEDURE dbo.jag_Rapport_Proprietaire_ListeDetailleLivraison
	(			
		@ProducteurDebut varchar(15) = Null,
		@ProducteurFin varchar(15) = Null,
		@PeriodeDebut int = Null,
		@PeriodeFin int = Null,
		@AnneeDebut int = Null,
		@AnneeFin int = Null,
		@UsineDebut varchar(6) = Null,
		@UsineFin varchar(6) = Null,
		@AgenceDebut varchar(4) = null,
		@AgenceFin varchar(4) = null,
		@MuniDebut varchar(6) = null,
		@MuniFin varchar(6) = null
	)
AS

SET NOCOUNT ON

DECLARE @Livraisons TABLE
(
	LotID INT,
	LivraisonDetailID INT,
	FournisseurID VARCHAR(15),
	Periode INT,
	[Date] smalldatetime,
	UsineID VARCHAR(6),
	Essence VARCHAR(20),
	FactureUsine VARCHAR(25),
	MunicipaliteID VARCHAR(6),
	ZoneID VARCHAR(2),
	AgenceID VARCHAR(4),
	UniteMesureID VARCHAR(6),
	VolumeNet FLOAT,
	Montant_Usine FLOAT,
	Montant FLOAT,
	MntFraisChargement float,
	MntAutresFrais float,
	MntCompensationDeplacement float,
	MntAutresRevenus float,
	FactureID INT,	
	isAjustement bit
)

INSERT INTO @Livraisons
SELECT
L.[LotID],
LD.[ID],
LD.ProducteurID,
L.Periode,
L.DateLivraison,
C.UsineID,
LD.EssenceID + ' ' + LTRIM(RTRIM(LD.Code)),
L.NumeroFactureUsine as FactureUsine,
L.MunicipaliteID,
L.ZoneID,
M.AgenceID,
L.UniteMesureID,
LD.VolumeNet,
LD.Montant_Usine,
LD.Montant_ProducteurNet,
null,
null,
null,
null,
case
	when LD.Droit_Coupe = 1 then L.Producteur1_FactureID
	when LD.Droit_Coupe = 0 then L.Producteur2_FactureID
end,
0
FROM Livraison_Detail LD
	inner join Livraison L on L.[ID] = LD.LivraisonID
--	left outer join Lot Lo on L.LotID = Lo.ID
	INNER JOIN Contrat C ON C.[ID] = L.ContratID
	INNER JOIN Municipalite M ON M.[ID] = L.MunicipaliteID
--	left outer join FactureFournisseur F1 on L.Producteur1_FactureID = F1.ID
--	left outer join FactureFournisseur F2 on L.Producteur2_FactureID = F2.ID
WHERE 
((@ProducteurDebut		IS NULL) OR (LD.ProducteurID >= @ProducteurDebut))
AND ((@ProducteurFin	IS NULL) OR (LD.ProducteurID <= @ProducteurFin))
AND ((@PeriodeDebut		is null and @AnneeDebut is null) or ( ((convert(char(4), L.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,L.[Periode]),2)))) >= ((convert(char(4), @AnneeDebut)) + (convert(char(2),RIGHT('00'+CONVERT(VARCHAR,@PeriodeDebut),2)
))) ))
AND ((@PeriodeFin		is null and @AnneeFin is null) or ( ((convert(char(4), L.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,L.[Periode]),2)))) <= ((convert(char(4), @AnneeFin)) + (convert(char(2),RIGHT('00'+CONVERT(VARCHAR,@PeriodeFin),2)))) ))
AND ((@UsineDebut		IS NULL) OR (C.UsineID >= @UsineDebut))
AND ((@UsineFin			IS NULL) OR (C.UsineID <= @UsineFin))
AND ((@MuniDebut		IS NULL) OR (L.MunicipaliteID >= @MuniDebut))
AND ((@MuniFin			IS NULL) OR (L.MunicipaliteID <= @MuniFin))
AND ((@AgenceDebut		IS NULL) OR (M.AgenceID >= @AgenceDebut))
AND ((@AgenceFin			IS NULL) OR (M.AgenceID <= @AgenceFin))
AND (L.Facture = 1)
ORDER BY LD.[ID]



INSERT INTO @Livraisons
SELECT
null,
null,
max(LD.ProducteurID),
max(L.Periode),
max(L.DateLivraison),
max(C.UsineID),
null,
max(L.NumeroFactureUsine) as FactureUsine,
max(L.MunicipaliteID),
max(L.ZoneID),
max(M.AgenceID),
max(L.UniteMesureID),
null,
null,
null,
(-1 * max(L.Frais_ChargeurAuProducteur)),
(-1 * max(L.Frais_AutresAuProducteur)),
(-1 * max(L.Frais_CompensationDeDeplacement)),
max(L.Frais_AutresRevenusProducteur),
case
	when LD.Droit_Coupe = 1 then max(L.Producteur1_FactureID)
	when LD.Droit_Coupe = 0 then max(L.Producteur2_FactureID)
end,
0
FROM Livraison_Detail LD
	inner join Livraison L on L.[ID] = LD.LivraisonID
	INNER JOIN Contrat C ON C.[ID] = L.ContratID
	INNER JOIN Municipalite M ON M.[ID] = L.MunicipaliteID
WHERE 
((@ProducteurDebut		IS NULL) OR (LD.ProducteurID >= @ProducteurDebut))
AND ((@ProducteurFin	IS NULL) OR (LD.ProducteurID <= @ProducteurFin))
AND ((@PeriodeDebut		is null and @AnneeDebut is null) or ( ((convert(char(4), L.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,L.[Periode]),2)))) >= ((convert(char(4), @AnneeDebut)) + (convert(char(2),RIGHT('00'+CONVERT(VARCHAR,@PeriodeDebut),2)
))) ))
AND ((@PeriodeFin		is null and @AnneeFin is null) or ( ((convert(char(4), L.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,L.[Periode]),2)))) <= ((convert(char(4), @AnneeFin)) + (convert(char(2),RIGHT('00'+CONVERT(VARCHAR,@PeriodeFin),2)))) ))
AND ((@UsineDebut		IS NULL) OR (C.UsineID >= @UsineDebut))
AND ((@UsineFin			IS NULL) OR (C.UsineID <= @UsineFin))
AND ((@MuniDebut		IS NULL) OR (L.MunicipaliteID >= @MuniDebut))
AND ((@MuniFin			IS NULL) OR (L.MunicipaliteID <= @MuniFin))
AND ((@AgenceDebut		IS NULL) OR (M.AgenceID >= @AgenceDebut))
AND ((@AgenceFin			IS NULL) OR (M.AgenceID <= @AgenceFin))
AND (L.Facture = 1)
and (	(L.Frais_ChargeurAuProducteur <> 0) or (L.Frais_AutresAuProducteur <> 0) or 
	(L.Frais_CompensationDeDeplacement <> 0) or (L.Frais_AutresRevenusProducteur <> 0))
group BY L.[ID], LD.Droit_Coupe



INSERT INTO @Livraisons
SELECT
max(L.[LotID]),
ACP.LivraisonDetailID,
MAX(LD.ProducteurID),
MAX(L.Periode),
MAX(L.DateLivraison),
NULL,
NULL,
NULL,
NULL,
NULL,
NULL,
NULL,
NULL,
SUM(ACU.Montant),
SUM(ACP.Montant),
NULL,
NULL,
NULL,
NULL,
NULL,
1
FROM AjustementCalcule_Producteur ACP
	INNER JOIN Livraison_Detail LD ON LD.[ID] = ACP.LivraisonDetailID
	inner join Livraison L on L.[ID] = LD.LivraisonID
	INNER JOIN Municipalite M ON M.[ID] = L.MunicipaliteID
	INNER JOIN Contrat C ON C.[ID] = L.ContratID
	INNER JOIN AjustementCalcule_Usine ACU ON ACU.AjustementID = ACP.AjustementID AND ACU.LivraisonDetailID = ACP.LivraisonDetailID
WHERE 
((@ProducteurDebut IS NULL) OR (LD.ProducteurID >= @ProducteurDebut))
AND ((@ProducteurFin IS NULL) OR (LD.ProducteurID <= @ProducteurFin))
AND ((@PeriodeDebut is null and @AnneeDebut is null) or ( ((convert(char(4), L.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,L.[Periode]),2)))) >= ((convert(char(4), @AnneeDebut)) + (convert(char(2),RIGHT('00'+CONVERT(VARCHAR,@PeriodeDebut),2))
)) ))
AND ((@PeriodeFin is null and @AnneeFin is null) or ( ((convert(char(4), L.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,L.[Periode]),2)))) <= ((convert(char(4), @AnneeFin)) + (convert(char(2),RIGHT('00'+CONVERT(VARCHAR,@PeriodeFin),2)))) ))
AND ((@UsineDebut		IS NULL) OR (C.UsineID >= @UsineDebut))
AND ((@UsineFin			IS NULL) OR (C.UsineID <= @UsineFin))
AND ((@MuniDebut		IS NULL) OR (L.MunicipaliteID >= @MuniDebut))
AND ((@MuniFin			IS NULL) OR (L.MunicipaliteID <= @MuniFin))
AND ((@AgenceDebut		IS NULL) OR (M.AgenceID >= @AgenceDebut))
AND ((@AgenceFin			IS NULL) OR (M.AgenceID <= @AgenceFin))
AND (L.Facture = 1)
GROUP BY ACP.LivraisonDetailID
ORDER BY ACP.LivraisonDetailID


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


-- liste des usines qui paient des taxes
--declare @UsinePaieTPS table
--(
--	ID varchar(16)
--)
--insert into @UsinePaieTPS 
--select ID from Usine where NePaiePasTPS <> 1

--declare @UsinePaieTVQ table
--(
--	ID varchar(16)
--)
--insert into @UsinePaieTVQ 
--select ID from Usine where NePaiePasTVQ <> 1
		 
SELECT 
--LivraisonDetailID,
F.Nom AS [Producteur],    
L.Periode,
CONVERT(VARCHAR, L.Date, 103) AS [Date],
(CASE WHEN isAjustement = 0 THEN L.UsineID ELSE 'Ajustements' END) AS [Usine],
(CASE WHEN isAjustement = 0 THEN L.Essence ELSE '' END) AS [Essence],   
(CASE WHEN isAjustement = 0 THEN L.FactureUsine ELSE '' END) AS [FactureUsine],
(CASE WHEN isAjustement = 0 THEN 
	M.[Description] + case when L.[ZoneID] is null or L.[ZoneID] = '0' then '' else ' (' + MZ.[Description] + ')' end
ELSE '' END) AS [Municipalite],
L.AgenceID, 
(CASE WHEN isAjustement = 0 THEN L.UniteMesureID ELSE '' END) AS [Unite],
(CASE WHEN isAjustement = 0 THEN L.VolumeNet ELSE '' END) AS VolumeNet,  
Montant_Usine AS Montant_Usine,
Montant AS Montant,
MntFraisChargement,
MntAutresFrais,
MntCompensationDeplacement,
MntAutresRevenus,
(case when isAjustement = 1 THEN '' else FF.NoFacture end) AS [NoFacture]
FROM @Livraisons L
	INNER JOIN FactureFournisseur FF ON FF.[ID] = L.FactureID
	INNER JOIN Fournisseur F ON F.[ID] = L.FournisseurID
		LEFT OUTER JOIN Municipalite M ON M.[ID] = L.MunicipaliteID
			left outer join Lot on Lot.[ID] = L.LotID
				left outer join Municipalite_Zone MZ on MZ.MunicipaliteID = Lot.MunicipaliteID and MZ.[ID] = Lot.ZoneID
ORDER BY F.Nom, L.Periode, L.LivraisonDetailID, isAjustement

