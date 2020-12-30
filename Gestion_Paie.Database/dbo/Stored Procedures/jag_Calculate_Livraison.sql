CREATE PROCEDURE [dbo].[jag_Calculate_Livraison]
@LivraisonID INT
AS
SET NOCOUNT ON

DECLARE @Facture bit 
select @Facture = (select Facture from Livraison where ID = @LivraisonID)

IF (@Facture = 1)
BEGIN
	return
END

exec jag_Update_Preleves

DECLARE @LivraisonDetailID INT
DECLARE @EssenceID VARCHAR(6)
DECLARE @Code CHAR(4)
DECLARE @ProducteurID VARCHAR(15)
DECLARE @Taux_Usine FLOAT
DECLARE @Taux_Producteur FLOAT
DECLARE @Taux_TransporteurMoyen FLOAT

--DECLARE @VolumeTransporte FLOAT
DECLARE @PaieTransporteur BIT
DECLARE @SurchargeManuel BIT
DECLARE @Surcharge_Override BIT




SELECT 
@PaieTransporteur = C.PaieTransporteur,
@SurchargeManuel = C.SurchargeManuel,
@Surcharge_Override = L.VolumeSurcharge_Override
FROM Livraison L
	INNER JOIN Contrat C ON C.[ID] = L.ContratID
WHERE L.[ID] = @LivraisonID

SET @Surcharge_Override = (CASE WHEN @Surcharge_Override = 1 THEN 1 ELSE 0 END)


update Livraison SET
PaieTransporteur = @PaieTransporteur,
SurchargeManuel = @SurchargeManuel
WHERE [ID] = @LivraisonID


UPDATE Livraison SET
ErreurCalcul = 0,
ErreurDescription = NULL
WHERE Livraison.[ID] = @LivraisonID



update Livraison set 
Livraison.Taux_Transporteur_Override =
(CASE WHEN Livraison.Taux_Transporteur_Override IS NOT NULL THEN Livraison.Taux_Transporteur_Override ELSE 0 END),

Livraison.Taux_Transporteur = 
(CASE WHEN Livraison.Taux_Transporteur_Override = 1 THEN Livraison.Taux_transporteur ELSE
	(select Contrat_Transporteur.Taux_transporteur 
	from Contrat_Transporteur 
			inner join Livraison on Livraison.[ID] = @LivraisonID
--				inner join Lot on Livraison.[LotID] = Lot.[ID]
	where (Contrat_Transporteur.ContratID = Livraison.ContratID) 
		AND (Contrat_Transporteur.UniteID = Livraison.UniteMesureID) 
		AND (Contrat_Transporteur.MunicipaliteID = Livraison.MunicipaliteID)
		AND (Contrat_Transporteur.ZoneID = Livraison.ZoneID)
		AND (Contrat_Transporteur.Actif = 1)) END)
where (Livraison.[ID] = @LivraisonID)



update Livraison set
Taux_Transporteur = 0
where [ID] = @LivraisonID AND Taux_Transporteur IS NULL



update Livraison_Detail set 
Livraison_Detail.Taux_Usine_Override =
(CASE WHEN Livraison_Detail.Taux_Usine_Override IS NOT NULL THEN Livraison_Detail.Taux_Usine_Override ELSE 0 END),

Livraison_Detail.Taux_Usine = 
(CASE WHEN Livraison_Detail.Taux_Usine_Override = 1 THEN Livraison_Detail.Taux_Usine ELSE
(select Taux_usine 
from Contrat_EssenceUnite
where (Contrat_EssenceUnite.ContratID = Livraison_Detail.ContratID)
AND (Contrat_EssenceUnite.EssenceID	= Livraison_Detail.EssenceID)
AND (Contrat_EssenceUnite.Code	= Livraison_Detail.Code)
AND (Contrat_EssenceUnite.UniteID = Livraison_Detail.UniteMesureID)
AND (Contrat_EssenceUnite.Actif = 1)) END),

Livraison_Detail.Taux_Producteur_Override =
(CASE WHEN Livraison_Detail.Taux_Producteur_Override IS NOT NULL THEN Livraison_Detail.Taux_Producteur_Override ELSE 0 END),

Livraison_Detail.Taux_Producteur = 
(CASE WHEN Livraison_Detail.Taux_Producteur_Override = 1 THEN Livraison_Detail.Taux_Producteur ELSE
(select Taux_producteur 
from Contrat_EssenceUnite
where (Contrat_EssenceUnite.ContratID = Livraison_Detail.ContratID)
AND (Contrat_EssenceUnite.EssenceID			= Livraison_Detail.EssenceID)
AND (Contrat_EssenceUnite.Code			= Livraison_Detail.Code)
AND (Contrat_EssenceUnite.UniteID			= Livraison_Detail.UniteMesureID)
AND (Contrat_EssenceUnite.Actif = 1)) END),
	
Livraison_Detail.Taux_TransporteurMoyen_Override =
(CASE WHEN Livraison_Detail.Taux_TransporteurMoyen_Override IS NOT NULL THEN Livraison_Detail.Taux_TransporteurMoyen_Override ELSE 0 END),

Livraison_Detail.Taux_TransporteurMoyen	= 
(CASE WHEN Livraison_Detail.Taux_TransporteurMoyen_Override = 1 THEN Livraison_Detail.Taux_TransporteurMoyen ELSE
(select Taux_producteur 
from Contrat_Transporteur
	inner join Livraison on Livraison.[ID] = @LivraisonID
--		inner join Lot L on Livraison.LotID = L.ID
where (Contrat_Transporteur.ContratID = Livraison_Detail.ContratID)
AND (Contrat_Transporteur.UniteID = Livraison_Detail.UniteMesureID)
AND (Contrat_Transporteur.MunicipaliteID = Livraison.MunicipaliteID)
AND (Contrat_Transporteur.ZoneID = Livraison.ZoneID)
AND (Contrat_Transporteur.Actif = 1)) END),

Livraison_Detail.UsePreleveMontant =
(select UseMontant 
from Essence_Unite EU
where (EU.UniteID = Livraison_Detail.UniteMesureID)
AND (EU.EssenceID = Livraison_Detail.EssenceID)),

Livraison_Detail.Taux_Preleve_Plan_Conjoint	= 
(select Preleve_plan_conjoint 
from Essence_Unite EU
where (EU.UniteID = Livraison_Detail.UniteMesureID)
AND (EU.EssenceID = Livraison_Detail.EssenceID)),
	
Livraison_Detail.Taux_Preleve_Fond_Roulement =
(select Preleve_fond_roulement 
from Essence_Unite EU
where (EU.UniteID = Livraison_Detail.UniteMesureID)
AND (EU.EssenceID = Livraison_Detail.EssenceID)),																

Livraison_Detail.Taux_Preleve_Fond_Forestier = 
(select Preleve_fond_forestier 
from Essence_Unite EU
where (EU.UniteID = Livraison_Detail.UniteMesureID)
AND (EU.EssenceID = Livraison_Detail.EssenceID)),

Livraison_Detail.Taux_Preleve_Divers = 
(select Preleve_divers
from Essence_Unite EU
where (EU.UniteID = Livraison_Detail.UniteMesureID)
AND (EU.EssenceID = Livraison_Detail.EssenceID))

where (Livraison_Detail.LivraisonID = @LivraisonID)


UPDATE Livraison_Detail SET Taux_TransporteurMoyen = 0
WHERE LivraisonID = @LivraisonID AND Taux_TransporteurMoyen IS NULL

UPDATE Livraison_Detail SET Taux_Usine = 0
WHERE LivraisonID = @LivraisonID AND Taux_Usine IS NULL

UPDATE Livraison_Detail SET Taux_Producteur = 0
WHERE LivraisonID = @LivraisonID AND Taux_Producteur IS NULL

UPDATE Livraison_Detail SET Taux_Preleve_Plan_Conjoint = 0
WHERE LivraisonID = @LivraisonID AND Taux_Preleve_Plan_Conjoint IS NULL

UPDATE Livraison_Detail SET Taux_Preleve_Fond_Roulement = 0
WHERE LivraisonID = @LivraisonID AND Taux_Preleve_Fond_Roulement IS NULL

UPDATE Livraison_Detail SET Taux_Preleve_Fond_Forestier = 0
WHERE LivraisonID = @LivraisonID AND Taux_Preleve_Fond_Forestier IS NULL

UPDATE Livraison_Detail SET Taux_Preleve_Divers = 0
WHERE LivraisonID = @LivraisonID AND Taux_Preleve_Divers IS NULL

update Livraison set Frais_ChargeurAuProducteur = 0 where Frais_ChargeurAuProducteur is Null and [ID] = @LivraisonID
update Livraison set Frais_ChargeurAuTransporteur = 0 where Frais_ChargeurAuTransporteur is Null and [ID] = @LivraisonID

update Livraison set Frais_AutresAuProducteur = 0 where Frais_AutresAuProducteur is Null and [ID] = @LivraisonID
update Livraison set Frais_AutresAuProducteurTransportSciage = 0 where Frais_AutresAuProducteurTransportSciage is Null and [ID] = @LivraisonID
update Livraison set Frais_AutresAuTransporteur = 0 where Frais_AutresAuTransporteur is Null and [ID] = @LivraisonID
update Livraison set Frais_CompensationDeDeplacement = 0 where Frais_CompensationDeDeplacement is Null and [ID] = @LivraisonID
update Livraison set Frais_AutresRevenusTransporteur = 0 where Frais_AutresRevenusTransporteur is Null and [ID] = @LivraisonID
update Livraison set Frais_AutresRevenusProducteur = 0 where Frais_AutresRevenusProducteur is Null and [ID] = @LivraisonID

update Livraison set Frais_AutresAuProducteurDescription = '' where Frais_AutresAuProducteurDescription is Null and [ID] = @LivraisonID
update Livraison set Frais_AutresAuTransporteurDescription = '' where Frais_AutresAuTransporteurDescription is Null and [ID] = @LivraisonID
update Livraison set Frais_AutresRevenusTransporteurDescription = '' where Frais_AutresRevenusTransporteurDescription is Null and [ID] = @LivraisonID
update Livraison set Frais_AutresRevenusProducteurDescription = '' where Frais_AutresRevenusProducteurDescription is Null and [ID] = @LivraisonID

DECLARE @MSG VARCHAR(1000)
SET @MSG = ''
DECLARE @ERREURS VARCHAR(4000)
SET @ERREURS = ''
DECLARE @ContratID VARCHAR(10)
DECLARE @Taux_Transporteur FLOAT
DECLARE @MunicipaliteID VARCHAR(6)
DECLARE @UniteMesureID VARCHAR(6)
DECLARE @TauxTransporteurOverride bit
DECLARE @TauxUsineOverride bit
DECLARE @TauxTransporteurMoyenOverride bit


SELECT 
@UniteMesureID = UniteMesureID,
@ContratID = ContratID,
@Taux_Transporteur = Taux_Transporteur,
@MunicipaliteID = Livraison.MunicipaliteID,
@TauxTransporteurOverride = Livraison.Taux_Transporteur_Override
FROM Livraison 
--	inner join Lot L on l.ID = Livraison.LotID
WHERE Livraison.[ID] = @LivraisonID


declare @CountCheck1 int
select @CountCheck1 = 0
select @CountCheck1 = (select count(*) from Livraison WHERE ID = @LivraisonID and ZoneID IS NULL)
IF (@CountCheck1 > 0)
BEGIN
	SET @ERREURS = @ERREURS + 'Le LOT est invalide puisqu''il n''a pas de ZONE de sélectionnée;'
END

select @CountCheck1 = 0
select @CountCheck1 = (select count(*) from Contrat where ID = @ContratID and PaieTransporteur=1)

IF ((@CountCheck1 > 0) and ((@Taux_Transporteur IS NULL) OR (@Taux_Transporteur = 0)))
BEGIN
	if (@TauxTransporteurOverride <> 1)
	BEGIN
		SET @ERREURS = @ERREURS + 'Le TAUX TRANSPORTEUR pour l''unité de mesure ''' + @UniteMesureID + ''' et la municipalié ''' + @MunicipaliteID + ''' dans le contrat ''' + @ContratID + ''' est 0 ou inactif;'
	END
END

SET @LivraisonDetailID = NULL
SET @EssenceID = NULL
SET @Code = NULL
SET @ProducteurID = NULL
SET @Taux_Usine = NULL
SET @Taux_Producteur = NULL
SET @Taux_TransporteurMoyen = NULL
set @TauxUsineOverride = Null
set @TauxTransporteurMoyenOverride = NULL

DECLARE cursDetails CURSOR FOR
SELECT [ID], EssenceID, Code, ProducteurID, Taux_Usine, Taux_Producteur, Taux_TransporteurMoyen, Taux_Usine_Override, Taux_TransporteurMoyen_Override
FROM Livraison_Detail LD
WHERE LD.LivraisonID = @LivraisonID

OPEN cursDetails

FETCH NEXT FROM cursDetails INTO @LivraisonDetailID, @EssenceID, @Code, @ProducteurID, @Taux_Usine, @Taux_Producteur, @Taux_TransporteurMoyen, @TauxUsineOverride, @TauxTransporteurMoyenOverride

WHILE @@FETCH_STATUS = 0
BEGIN
	IF ((@Taux_Usine IS NULL) OR (@Taux_Usine = 0))
	BEGIN
		if @TauxUsineOverride <> 1
		BEGIN
			SET @MSG = 'Le TAUX USINE pour l''essence '''+ @EssenceID + ' ' + LTRIM(RTRIM(@Code)) + ''' et l''unité de mesure ''' + @UniteMesureID + ''' dans le contrat ''' + @ContratID + ''' est 0 ou inactif;'
			IF ((CHARINDEX(@MSG, @ERREURS))=0) --existe pas
			BEGIN
				SET @ERREURS = @ERREURS + @MSG	
			END
		END
	END

	IF ((@Taux_Producteur IS NULL) OR (@Taux_Producteur = 0))
	BEGIN
		IF ((SELECT Taux_Producteur_Override FROM Livraison_Detail WHERE [ID] = @LivraisonDetailID) <> 1) 
		BEGIN
			SET @MSG = 'Le TAUX PRODUCTEUR pour l''essence '''+ @EssenceID + ' ' + LTRIM(RTRIM(@Code)) + ''' et l''unité de mesure ''' + @UniteMesureID + ''' dans le contrat ''' + @ContratID + ''' est 0 ou inactif;'
			IF ((CHARINDEX(@MSG, @ERREURS))=0) --existe pas
			BEGIN
				SET @ERREURS = @ERREURS + @MSG	
			END
		END
	END


	declare @CountCheck2 int
	select @CountCheck2 = 0
	select @CountCheck2 = (select count(*) from Contrat where ID = @ContratID and PaieTransporteur=1)

	IF ((@CountCheck2 > 0) and ((@Taux_TransporteurMoyen IS NULL) OR (@Taux_TransporteurMoyen = 0)))
	BEGIN
		IF ((SELECT Taux_TransporteurMoyen_Override FROM Livraison_Detail WHERE [ID] = @LivraisonDetailID) <> 1) 
		BEGIN
			SET @MSG = 'Le TAUX TRANSPORTEUR MOYEN pour l''unité de mesure ''' + @UniteMesureID + ''' et la municipalité ''' + @MunicipaliteID + ''' dans le contrat ''' + @ContratID + ''' est 0 ou inactif;'
			IF ((CHARINDEX(@MSG, @ERREURS))=0) --existe pas
			BEGIN
				SET @ERREURS = @ERREURS + @MSG	
			END
		END
	END
	
	FETCH NEXT FROM cursDetails INTO @LivraisonDetailID, @EssenceID, @Code, @ProducteurID, @Taux_Usine, @Taux_Producteur, @Taux_TransporteurMoyen, @TauxUsineOverride, @TauxTransporteurMoyenOverride
END

CLOSE cursDetails
DEALLOCATE cursDetails

Update Livraison_Detail set 

Montant_Usine = (VolumeNet * Taux_Usine),
Montant_ProducteurBrut = (VolumeNet * Taux_Producteur),
Montant_TransporteurMoyen = (VolumeNet * Taux_TransporteurMoyen)

where (Livraison_Detail.LivraisonID = @LivraisonID)	

update Livraison_Detail set Montant_Usine = 0 where Montant_Usine is Null and [LivraisonID] = @LivraisonID
update Livraison_Detail set Montant_ProducteurBrut = 0 where Montant_ProducteurBrut is Null and [LivraisonID] = @LivraisonID
update Livraison_Detail set Montant_TransporteurMoyen = 0 where Montant_TransporteurMoyen is Null and [LivraisonID] = @LivraisonID

Update Livraison_Detail set 

Montant_Preleve_Plan_Conjoint = (VolumeNet * Taux_Preleve_Plan_Conjoint),
Montant_Preleve_Fond_Roulement = (VolumeNet * Taux_Preleve_Fond_Roulement),
Montant_Preleve_Fond_Forestier = (VolumeNet * Taux_Preleve_Fond_Forestier),
Montant_Preleve_Divers = (VolumeNet * Taux_Preleve_Divers)

where (Livraison_Detail.LivraisonID = @LivraisonID)
AND (Livraison_Detail.UsePreleveMontant = 1)	

Update Livraison_Detail set 

Montant_Preleve_Plan_Conjoint = (Montant_Usine * Taux_Preleve_Plan_Conjoint),
Montant_Preleve_Fond_Roulement = (Montant_Usine * Taux_Preleve_Fond_Roulement),
Montant_Preleve_Fond_Forestier = (Montant_Usine * Taux_Preleve_Fond_Forestier),
Montant_Preleve_Divers = (Montant_Usine * Taux_Preleve_Divers)

where (Livraison_Detail.LivraisonID = @LivraisonID)
AND (Livraison_Detail.UsePreleveMontant = 0)				

update Livraison_Detail set Montant_Preleve_Plan_Conjoint = 0 where Montant_Preleve_Plan_Conjoint is Null and [LivraisonID] = @LivraisonID
update Livraison_Detail set Montant_Preleve_Fond_Roulement = 0 where Montant_Preleve_Fond_Roulement is Null and [LivraisonID] = @LivraisonID
update Livraison_Detail set Montant_Preleve_Fond_Forestier = 0 where Montant_Preleve_Fond_Forestier is Null and [LivraisonID] = @LivraisonID
update Livraison_Detail set Montant_Preleve_Divers = 0 where Montant_Preleve_Divers is Null  and [LivraisonID] = @LivraisonID

update Livraison_Detail SET Montant_Usine = ROUND(Montant_Usine,2) where [LivraisonID] = @LivraisonID
update Livraison_Detail SET Montant_ProducteurBrut = ROUND(Montant_ProducteurBrut,2) where [LivraisonID] = @LivraisonID
update Livraison_Detail SET Montant_TransporteurMoyen = ROUND(Montant_TransporteurMoyen,2) where [LivraisonID] = @LivraisonID
update Livraison_Detail SET Montant_Preleve_Plan_Conjoint = ROUND(Montant_Preleve_Plan_Conjoint,2) where [LivraisonID] = @LivraisonID
update Livraison_Detail SET Montant_Preleve_Fond_Roulement = ROUND(Montant_Preleve_Fond_Roulement,2) where [LivraisonID] = @LivraisonID
update Livraison_Detail SET Montant_Preleve_Fond_Forestier = ROUND(Montant_Preleve_Fond_Forestier,2) where [LivraisonID] = @LivraisonID
update Livraison_Detail SET Montant_Preleve_Divers = ROUND(Montant_Preleve_Divers,2) where [LivraisonID] = @LivraisonID

Update Livraison_Detail set 
Montant_ProducteurNet = ROUND((Montant_ProducteurBrut - Montant_TransporteurMoyen - Montant_Preleve_Plan_Conjoint - Montant_Preleve_Fond_Roulement - Montant_Preleve_Fond_Forestier - Montant_Preleve_Divers),2)
where (Livraison_Detail.LivraisonID = @LivraisonID)	

update Livraison_Detail SET Montant_ProducteurNet = ROUND(Montant_ProducteurNet,2) where [LivraisonID] = @LivraisonID

-- update a la table Livraison

update Livraison set

Montant_Transporteur = (VolumeAPayer * Livraison.Taux_Transporteur),
Montant_Usine = (select sum(Livraison_Detail.Montant_Usine) from Livraison_Detail where Livraison_Detail.LivraisonID = @LivraisonID),
Montant_Chargeur = (Frais_ChargeurAuProducteur + Frais_ChargeurAuTransporteur),
Montant_Preleve_Plan_Conjoint = (select sum(Livraison_Detail.Montant_Preleve_Plan_Conjoint) from Livraison_Detail where Livraison_Detail.LivraisonID = @LivraisonID),
Montant_Preleve_Fond_Roulement = (select sum(Livraison_Detail.Montant_Preleve_Fond_Roulement) from Livraison_Detail where Livraison_Detail.LivraisonID = @LivraisonID),
Montant_Preleve_Fond_Forestier = (select sum(Livraison_Detail.Montant_Preleve_Fond_Forestier) from Livraison_Detail where Livraison_Detail.LivraisonID = @LivraisonID),
Montant_Preleve_Divers = (select sum(Livraison_Detail.Montant_Preleve_Divers) from Livraison_Detail where Livraison_Detail.LivraisonID = @LivraisonID)
	
where (Livraison.[ID] = @LivraisonID)


--Si le syndicat paye le transporteur, le transporteur paie la surchage
IF (@PaieTransporteur = 1)
BEGIN
	update Livraison set
	Montant_Surcharge = ROUND((VolumeSurcharge * Livraison.Taux_Transporteur),2)
	where (Livraison.[ID] = @LivraisonID)

	update Livraison set
	Montant_SurchargeProducteur = 0
	where (Livraison.[ID] = @LivraisonID)
END
--Si le syndicat ne paye pas le tranporteur
ELSE 
BEGIN
	update Livraison set
	Montant_Surcharge = 0
	where (Livraison.[ID] = @LivraisonID)


	declare @ProducteurSurchargeID VARCHAR(15)
	declare @SurchargeProd float
	select @ProducteurSurchargeID = DroitCoupeID from Livraison where (Livraison.[ID] = @LivraisonID)
	select @SurchargeProd = dbo.jag_CalculateMontantSurchargeAuProducteur(@LivraisonID, @ProducteurSurchargeID)

	update Livraison set
	Montant_SurchargeProducteur = @SurchargeProd
	where (Livraison.[ID] = @LivraisonID)
END

update Livraison set
Montant_Producteur1 = ROUND((select sum(Livraison_Detail.Montant_ProducteurNet) from Livraison_Detail where Livraison_Detail.LivraisonID = @LivraisonID AND Droit_Coupe = 1 GROUP BY ProducteurID),2)
where (Livraison.[ID] = @LivraisonID)

update Livraison set
Montant_Producteur2 = ROUND((select sum(Livraison_Detail.Montant_ProducteurNet) from Livraison_Detail where Livraison_Detail.LivraisonID = @LivraisonID AND Droit_Coupe = 0 GROUP BY ProducteurID),2)
where (Livraison.[ID] = @LivraisonID)

/* --CES CALCULS SONT FAIT DANS CreerFactures
UPDATE Livraison SET 
Montant_Transporteur = Montant_Transporteur - Frais_ChargeurAuTransporteur - Frais_AutresAuTransporteur + Frais_AutreChargePourTransport + Frais_CompensationDeDeplacement,
Montant_Usine = Montant_Usine - Frais_ChargeurAuProducteur - Frais_ChargeurAuTransporteur - Frais_AutresAuProducteur - Frais_AutresAuTransporteur + Frais_AutreChargePourTransport,
Montant_Producteur1 = Montant_Producteur1 - Frais_ChargeurAuProducteur - Frais_AutresAuProducteur - Frais_CompensationDeDeplacement
where (Livraison.[ID] = @LivraisonID)
*/

update Livraison set Montant_Transporteur = 0 where Montant_Transporteur is Null and [ID] = @LivraisonID
update Livraison set Montant_Surcharge = 0 where Montant_Surcharge is Null and [ID] = @LivraisonID
update Livraison set Montant_Usine = 0 where Montant_Usine is Null and [ID] = @LivraisonID
update Livraison set Montant_Chargeur = 0 where Montant_Chargeur is Null and [ID] = @LivraisonID
update Livraison set Montant_Producteur1 = 0 where Montant_Producteur1 is Null and [ID] = @LivraisonID
update Livraison set Montant_Producteur2 = 0 where Montant_Producteur2 is Null and [ID] = @LivraisonID
update Livraison set Montant_Preleve_Plan_Conjoint = 0 where Montant_Preleve_Plan_Conjoint is Null and [ID] = @LivraisonID
update Livraison set Montant_Preleve_Fond_Roulement = 0 where Montant_Preleve_Fond_Roulement is Null and [ID] = @LivraisonID
update Livraison set Montant_Preleve_Fond_Forestier = 0 where Montant_Preleve_Fond_Forestier is Null and [ID] = @LivraisonID
update Livraison set Montant_Preleve_Divers = 0 where Montant_Preleve_Divers is Null and [ID] = @LivraisonID


UPDATE Livraison SET Montant_Transporteur = ROUND(Montant_Transporteur,2) where [ID] = @LivraisonID
UPDATE Livraison SET Montant_Surcharge = ROUND(Montant_Surcharge,2) where [ID] = @LivraisonID
UPDATE Livraison SET Montant_Usine = ROUND(Montant_Usine,2) where [ID] = @LivraisonID
UPDATE Livraison SET Montant_Chargeur = ROUND(Montant_Chargeur,2) where [ID] = @LivraisonID
UPDATE Livraison SET Montant_Producteur1 = ROUND(Montant_Producteur1,2) where [ID] = @LivraisonID
UPDATE Livraison SET Montant_Producteur2 = ROUND(Montant_Producteur2,2) where [ID] = @LivraisonID
UPDATE Livraison SET Montant_Preleve_Plan_Conjoint = ROUND(Montant_Preleve_Plan_Conjoint,2) where [ID] = @LivraisonID
UPDATE Livraison SET Montant_Preleve_Fond_Roulement = ROUND(Montant_Preleve_Fond_Roulement,2) where [ID] = @LivraisonID
UPDATE Livraison SET Montant_Preleve_Fond_Forestier = ROUND(Montant_Preleve_Fond_Forestier,2) where [ID] = @LivraisonID
UPDATE Livraison SET Montant_Preleve_Divers = ROUND(Montant_Preleve_Divers,2) where [ID] = @LivraisonID
	

		
update 	Livraison set
--Montant_MiseEnCommun = (Montant_Usine - Frais_ChargeurAuProducteur - Montant_Transporteur - Montant_Producteur1 - Montant_Producteur2 - Montant_Preleve_Plan_Conjoint - Montant_Surcharge - Montant_Preleve_Fond_Roulement - Montant_Preleve_Fond_Forestier - Montant_Preleve_Divers)		
Montant_MiseEnCommun = ROUND((Montant_Usine - Montant_Transporteur - Montant_Producteur1 - Montant_Producteur2 - Montant_Preleve_Plan_Conjoint - Montant_Surcharge - Montant_Preleve_Fond_Roulement - Montant_Preleve_Fond_Forestier - Montant_Preleve_Divers),
2)
where (Livraison.[ID] = @LivraisonID)



UPDATE Livraison SET
Montant_MiseEnCommun = 0
WHERE Montant_MiseEnCommun IS NULL and [ID] = @LivraisonID



UPDATE Livraison SET
Montant_MiseEnCommun = ROUND(Montant_MiseEnCommun,2) where [ID] = @LivraisonID



IF (LEN(@ERREURS) > 300) SET @ERREURS = LEFT(@ERREURS, 300)
IF (LEN(@ERREURS) > 0)
BEGIN
	UPDATE Livraison SET
	ErreurCalcul = 1,
	ErreurDescription = LEFT(@ERREURS, LEN(@ERREURS)-1)
	WHERE Livraison.[ID] = @LivraisonID
END
ELSE
BEGIN
	UPDATE Livraison SET
	ErreurCalcul = 0,
	ErreurDescription = NULL,
	DateCalcul = GetDate()
	WHERE Livraison.[ID] = @LivraisonID
END


