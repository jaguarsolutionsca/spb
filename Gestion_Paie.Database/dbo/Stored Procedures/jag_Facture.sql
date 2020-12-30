CREATE PROCEDURE [dbo].[jag_Facture]
@FactureID INT, @AjustementResume BIT=0
AS
SET NOCOUNT ON

DECLARE @NoLigneTPSPreleve INT
DECLARE @NoLigneTVQPreleve INT
DECLARE @NoLigneTPSProducteur INT
DECLARE @NoLigneTVQProducteur INT
DECLARE @NoLigneTPSTransporteur INT
DECLARE @NoLigneTVQTransporteur INT
DECLARE @NoLigneTPSSurcharge INT
DECLARE @NoLigneTVQSurcharge INT
DECLARE @NoLigneTPSChargeur INT
DECLARE @NoLigneTVQChargeur INT
DECLARE @NoLigneTPSCompensation INT
DECLARE @NoLigneTVQCompensation INT
DECLARE @NoLigneTPSAutresFrais INT
DECLARE @NoLigneTVQAutresFrais INT
DECLARE @NoLigneTPSAutresRevenus INT
DECLARE @NoLigneTVQAutresRevenus INT
DECLARE @NoLigneTPS INT
DECLARE @NoLigneTVQ INT
DECLARE @NoLigneMEC INT
DECLARE @NoLigneMEC2 INT

SET @NoLigneTPSPreleve = 1000
SET @NoLigneTVQPreleve = 1001
SET @NoLigneTPSProducteur = 1002
SET @NoLigneTVQProducteur = 1003
SET @NoLigneTPSTransporteur = 1004
SET @NoLigneTVQTransporteur = 1005
SET @NoLigneTPSSurcharge = 1006
SET @NoLigneTVQSurcharge = 1007
SET @NoLigneTPSChargeur = 1008
SET @NoLigneTVQChargeur = 1009
SET @NoLigneTPSCompensation = 1010
SET @NoLigneTVQCompensation = 1011
SET @NoLigneTPSAutresFrais = 1012
SET @NoLigneTVQAutresFrais = 1013
SET @NoLigneTPSAutresRevenus = 1014
SET @NoLigneTVQAutresRevenus = 1015
SET @NoLigneTPS = 500
SET @NoLigneTVQ = 501
SET @NoLigneMEC = 450
SET @NoLigneMEC2 = 451

DECLARE @Montant_Surcharge FLOAT
DECLARE @Frais_Chargeur FLOAT
DECLARE @Frais_Autres FLOAT
DECLARE @Frais_CompensationDeDeplacement FLOAT
DECLARE @Frais_AutresRevenus FLOAT

DECLARE @Surcharges table
(
	ContratID VARCHAR(10),
	Volume float,
	Taux float,
	Montant float
)

DECLARE @TypeFactureFournisseur CHAR(1)
SELECT @TypeFactureFournisseur = TypeFactureFournisseur FROM FactureFournisseur WHERE [ID] = @FactureID

IF (@TypeFactureFournisseur IS NULL)
BEGIN
	RETURN
END

DECLARE @TypeFacture CHAR(1)
SELECT @TypeFacture = TypeFacture FROM FactureFournisseur WHERE [ID] = @FactureID

DECLARE @Compte_DuAuxProducteurs int
SELECT @Compte_DuAuxProducteurs = Compte_DuAuxProducteurs FROM jag_System


DECLARE @Syndicat_NoTPS VARCHAR(20)
SELECT @Syndicat_NoTPS = [Value] FROM jag_SystemEx WHERE [Name] = 'Syndicat_NoTPS'

DECLARE @Syndicat_NoTVQ VARCHAR(20)
SELECT @Syndicat_NoTVQ = [Value] FROM jag_SystemEx WHERE [Name] = 'Syndicat_NoTVQ'

--------------------------------------------
-- AJSUTEMENT
--------------------------------------------
IF (@TypeFacture = 'A')
BEGIN
	IF (@TypeFactureFournisseur = 'T')
	BEGIN
		declare @nb int
		SELECT @nb = count(*) FROM AjustementCalcule_Transporteur WHERE factureID = 58100;
		if @nb > 0 

		-- Ajustement Transporteur
		Begin
			SELECT
			MAX(FF.TypeFactureFournisseur) AS [TypeFactureFournisseur],
			(FF.NoFacture) AS [Facture],
			MAX(FF.DateFactureAcomba) AS [DateFacture],
			MAX(FF.DatePaiementAcomba) AS [DatePaiement],
			MAX(C.Annee) AS [Annee],
			MIN(A.Periode_Debut) AS [Periode_Debut],
			MAX(A.Periode_Fin) AS [Periode_Fin],
			MIN(A.Date_Debut) AS [Date_Debut],
			MAX(A.Date_Fin) AS [Date_Fin],
			MAX(TF.[Description] + 's') AS [TypeFacture],
			MAX(FF.FournisseurID) AS [FournisseurID],
			MAX(F.Nom) AS [Nom],
			MAX(F.AuSoinsDe) AS [AS],
			MAX(F.Rue) AS [Rue],
			MAX(F.Ville) AS [Ville],
			MAX(UPPER(F.Code_Postal)) AS [Code_Postal],
			MAX(FF.Montant_Total) AS [Montant],
			MAX(FF.NumeroCheque) AS [NumeroCheque],
			max(F.No_TPS) as [No_TPS],
			max(F.No_TVQ) as [No_TVQ],
			@Syndicat_NoTPS AS [Syndicat_No_TPS],
			@Syndicat_NoTVQ AS [Syndicat_No_TVQ]
			FROM FactureFournisseur FF
				INNER JOIN Fournisseur F ON F.[ID] = FF.FournisseurID
				INNER JOIN TypeFacture TF ON TF.[ID] = FF.TypeFacture
				INNER JOIN FactureFournisseur_Details FFD ON FFD.FactureID = FF.[ID]
				INNER JOIN AjustementCalcule_Transporteur ACT ON ACT.[ID] = FFD.RefID
				INNER JOIN Ajustement A ON A.[ID] = ACT.AjustementID
				INNER JOIN Contrat C ON C.[ID] = A.ContratID
			WHERE FF.[ID] = @FactureID
			GROUP BY FF.NoFacture
		End
		
		Else

		-- Ajustement Transporteur Essence
		Begin
			SELECT
			MAX(FF.TypeFactureFournisseur) AS [TypeFactureFournisseur],
			(FF.NoFacture) AS [Facture],
			MAX(FF.DateFactureAcomba) AS [DateFacture],
			MAX(FF.DatePaiementAcomba) AS [DatePaiement],
			MAX(C.Annee) AS [Annee],
			MIN(A.Periode_Debut) AS [Periode_Debut],
			MAX(A.Periode_Fin) AS [Periode_Fin],
			MIN(A.Date_Debut) AS [Date_Debut],
			MAX(A.Date_Fin) AS [Date_Fin],
			MAX(TF.[Description] + 's') AS [TypeFacture],
			MAX(FF.FournisseurID) AS [FournisseurID],
			MAX(F.Nom) AS [Nom],
			MAX(F.AuSoinsDe) AS [AS],
			MAX(F.Rue) AS [Rue],
			MAX(F.Ville) AS [Ville],
			MAX(UPPER(F.Code_Postal)) AS [Code_Postal],
			MAX(FF.Montant_Total) AS [Montant],
			MAX(FF.NumeroCheque) AS [NumeroCheque],
			max(F.No_TPS) as [No_TPS],
			max(F.No_TVQ) as [No_TVQ],
			@Syndicat_NoTPS AS [Syndicat_No_TPS],
			@Syndicat_NoTVQ AS [Syndicat_No_TVQ]
			FROM FactureFournisseur FF
				INNER JOIN Fournisseur F ON F.[ID] = FF.FournisseurID
				INNER JOIN TypeFacture TF ON TF.[ID] = FF.TypeFacture
				INNER JOIN FactureFournisseur_Details FFD ON FFD.FactureID = FF.[ID]
				INNER JOIN AjustementCalcule_TransporteurEssence ACT ON ACT.[ID] = FFD.RefID
				INNER JOIN Ajustement A ON A.[ID] = ACT.AjustementID
				INNER JOIN Contrat C ON C.[ID] = A.ContratID
			WHERE FF.[ID] = @FactureID
			GROUP BY FF.NoFacture
		End

	END	
	ELSE IF (@TypeFactureFournisseur = 'P')
	BEGIN
		SELECT
		MAX(FF.TypeFactureFournisseur) AS [TypeFactureFournisseur],
		FF.NoFacture AS [Facture],
		MAX(FF.DateFactureAcomba) AS [DateFacture],
		MAX(FF.DatePaiementAcomba) AS [DatePaiement],
		MAX(C.Annee) AS [Annee],
		MIN(A.Periode_Debut) AS [Periode_Debut],
		MAX(A.Periode_Fin) AS [Periode_Fin],
		MIN(A.Date_Debut) AS [Date_Debut],
		MAX(A.Date_Fin) AS [Date_Fin],
		MAX(TF.[Description] + 's') AS [TypeFacture],
		MAX(FF.FournisseurID) AS [FournisseurID],
		MAX(F.Nom) AS [Nom],
		MAX(F.AuSoinsDe) AS [AS],
		MAX(F.Rue) AS [Rue],
		MAX(F.Ville) AS [Ville],

		MAX(UPPER(F.Code_Postal)) AS [Code_Postal],
		MAX(FF.Montant_Total) AS [Montant],
		MAX(FF.NumeroCheque) AS [NumeroCheque],
		max(F.No_TPS) as [No_TPS],
		max(F.No_TVQ) as [No_TVQ],
		@Syndicat_NoTPS AS [Syndicat_No_TPS],
		@Syndicat_NoTVQ AS [Syndicat_No_TVQ]
		
		FROM FactureFournisseur FF
			INNER JOIN Fournisseur F ON F.[ID] = FF.FournisseurID
			INNER JOIN TypeFacture TF ON TF.[ID] = FF.TypeFacture
			INNER JOIN FactureFournisseur_Details FFD ON FFD.FactureID = FF.[ID]
			INNER JOIN AjustementCalcule_Producteur ACP ON ACP.[ID] = FFD.RefID
			INNER JOIN Ajustement A ON A.[ID] = ACP.AjustementID
			INNER JOIN Contrat C ON C.[ID] = A.ContratID
		WHERE FF.[ID] = @FactureID
		GROUP BY FF.NoFacture
	END
END

--------------------------------------------
-- INDEXATION
--------------------------------------------
ELSE IF (@TypeFacture = 'I')
BEGIN
	IF (@TypeFactureFournisseur = 'T')
	BEGIN
		SELECT
		MAX(FF.TypeFactureFournisseur) AS [TypeFactureFournisseur],
		(FF.NoFacture) AS [Facture],
		MAX(FF.DateFactureAcomba) AS [DateFacture],
		MAX(FF.DatePaiementAcomba) AS [DatePaiement],
		MAX(C.Annee) AS [Annee],
		MIN(I.Periode_Debut) AS [Periode_Debut],
		MAX(I.Periode_Fin) AS [Periode_Fin],
		MAX(TF.[Description] + 's') AS [TypeFacture],
		MAX(FF.FournisseurID) AS [FournisseurID],
		MAX(F.Nom) AS [Nom],
		MAX(F.AuSoinsDe) AS [AS],
		MAX(F.Rue) AS [Rue],
		MAX(F.Ville) AS [Ville],
		MAX(UPPER(F.Code_Postal)) AS [Code_Postal],
		MAX(FF.Montant_Total) AS [Montant],
		MAX(FF.NumeroCheque) AS [NumeroCheque]
		FROM FactureFournisseur FF
			LEFT OUTER JOIN Fournisseur F ON F.[ID] = FF.FournisseurID
			LEFT OUTER JOIN TypeFacture TF ON TF.[ID] = FF.TypeFacture
			LEFT OUTER JOIN FactureFournisseur_Details FFD ON FFD.FactureID = FF.[ID]
			LEFT OUTER JOIN IndexationCalcule_Transporteur ICT ON ICT.[ID] = FFD.RefID
			LEFT OUTER JOIN Indexation_Municipalite [IM] ON [IM].[ID] = ICT.IndexationDetailID
			LEFT OUTER JOIN Indexation I ON ((I.[ID] = ICT.IndexationID) OR (I.[ID] = [IM].IndexationID))
			LEFT OUTER JOIN Contrat C ON C.[ID] = I.ContratID
		WHERE FF.[ID] = @FactureID
		GROUP BY FF.NoFacture
	END
	ELSE
	BEGIN
		SELECT
		MAX(FF.TypeFactureFournisseur) AS [TypeFactureFournisseur],
		FF.NoFacture AS [Facture],
		MAX(FF.DateFactureAcomba) AS [DateFacture],
		MAX(FF.DatePaiementAcomba) AS [DatePaiement],
		MAX(C.Annee) AS [Annee],
		MIN(I.Periode_Debut) AS [Periode_Debut],
		MAX(I.Periode_Fin) AS [Periode_Fin],
		MAX(TF.[Description] + 's') AS [TypeFacture],
		MAX(FF.FournisseurID) AS [FournisseurID],
		MAX(F.Nom) AS [Nom],
		MAX(F.AuSoinsDe) AS [AS],
		MAX(F.Rue) AS [Rue],
		MAX(F.Ville) AS [Ville],
		MAX(UPPER(F.Code_Postal)) AS [Code_Postal],
		MAX(FF.Montant_Total) AS [Montant],
		MAX(FF.NumeroCheque) AS [NumeroCheque]
		FROM FactureFournisseur FF
			INNER JOIN Fournisseur F ON F.[ID] = FF.FournisseurID
			INNER JOIN TypeFacture TF ON TF.[ID] = FF.TypeFacture
			INNER JOIN FactureFournisseur_Details FFD ON FFD.FactureID = FF.[ID]
			INNER JOIN IndexationCalcule_Producteur ICP ON ICP.[ID] = FFD.RefID
			LEFT OUTER JOIN Indexation_Municipalite [IM] ON [IM].[ID] = ICP.IndexationDetailID
			INNER JOIN Indexation I ON ((I.[ID] = ICP.IndexationID) OR (I.[ID] = [IM].IndexationID))
			INNER JOIN Contrat C ON C.[ID] = I.ContratID
		WHERE FF.[ID] = @FactureID
		GROUP BY FF.NoFacture
	END
END

--------------------------------------------
-- LIVRAISON
--------------------------------------------
ELSE
BEGIN
SELECT
	TypeFactureFournisseur,
	NoFacture AS [Facture],
	DateFactureAcomba AS [DateFacture],
	DatePaiementAcomba AS [DatePaiement],
	TF.[Description] + 's' AS [TypeFacture],
	FournisseurID,
	F.Nom,
	(F.AuSoinsDe) AS [AS],
	F.Rue,
	F.Ville,
	UPPER(F.Code_Postal) AS [Code_Postal],
	Montant_Total AS [Montant],
	NumeroCheque
	FROM FactureFournisseur FF
		INNER JOIN Fournisseur F ON F.[ID] = FF.FournisseurID
		INNER JOIN TypeFacture TF ON TF.[ID] = FF.TypeFacture
	WHERE FF.[ID] = @FactureID
END


--------------------------------------------
-- PRODUCTEUR
--------------------------------------------

IF (@TypeFactureFournisseur = 'P') -- Producteur
BEGIN
	IF (@TypeFacture = 'L')
	BEGIN
		SELECT
		L.DateLivraison AS [Date],
		L.NumeroFactureUsine AS [FactureUsine],
		L.[ID] AS [Permis],
		C.UsineID AS [UsineID],
		U.[Description] AS [Usine],
		L.UniteMesureID AS [Unite],
		E.[Description] + ' ' + LTRIM(RTRIM(LD.Code)) AS [Essence],
		LD.VolumeNet AS [Volume],
		LD.Montant_ProducteurNet as SubTotal, 
		LD.Taux_Usine,
		LD.Montant_Usine,
		LD.Taux_TransporteurMoyen,
		LD.Montant_TransporteurMoyen,
		LD.Taux_Preleve_Plan_Conjoint AS [Taux_Preleve_Plan_Conjoint],
		LD.Montant_Preleve_Plan_Conjoint,
		LD.Taux_Preleve_Fond_Roulement AS [Taux_Preleve_Fond_Roulement],
		LD.Montant_Preleve_Fond_Roulement,
		LD.Taux_Preleve_Fond_Forestier AS [Taux_Preleve_Fond_Forestier],
		LD.Montant_Preleve_Fond_Forestier,
		LD.Taux_Preleve_Divers AS [Taux_Preleve_Divers],
		LD.Montant_Preleve_Divers,
		ROUND((LD.Taux_Preleve_Plan_Conjoint + LD.Taux_Preleve_Fond_Roulement + LD.Taux_Preleve_Fond_Forestier + LD.Taux_Preleve_Divers),2) AS [Taux_Preleve],
		ROUND((LD.Montant_Preleve_Plan_Conjoint + LD.Montant_Preleve_Fond_Roulement + LD.Montant_Preleve_Fond_Forestier + LD.Montant_Preleve_Divers),2) AS [Montant_Preleve],
		ROUND((LD.Taux_Usine - LD.Taux_TransporteurMoyen - (CASE WHEN LD.UsePreleveMontant = 1 THEN LD.Taux_Preleve_Plan_Conjoint ELSE 0 END) - (CASE WHEN LD.UsePreleveMontant = 1 THEN LD.Taux_Preleve_Fond_Roulement ELSE 0 END) - (CASE WHEN LD.UsePreleveMontant = 1 THEN LD.Taux_Preleve_Fond_Forestier ELSE 0 END) - (CASE WHEN LD.UsePreleveMontant = 1 THEN LD.Taux_Preleve_Divers ELSE 0 END)),2) AS [Taux_ProducteurNet],
		LD.UsePreleveMontant,
		LD.Montant_ProducteurNet
		FROM FactureFournisseur_Details FFD
			INNER JOIN FactureFournisseur FF ON FF.[ID] = FFD.FactureID
			INNER JOIN Livraison L ON L.[ID] = FFD.RefID
			INNER JOIN Livraison_Detail LD ON LD.[LivraisonID] = L.[ID] AND LD.ProducteurID = FF.FournisseurID
			INNER JOIN Contrat C ON C.[ID] = L.ContratID
			INNER JOIN Usine U ON U.[ID] = C.UsineID
			LEFT OUTER JOIN Essence E ON E.[ID] = LD.EssenceID
		WHERE FFD.FactureID = @FactureID
		ORDER BY L.DateLivraison DESC

		SELECT
		FFS.Ligne,
		FFS.Montant,
		FFS.[Description],
		(CASE WHEN (Ligne = @NoLigneTPSProducteur) THEN (SELECT No_TPS FROM Fournisseur F WHERE F.[ID] = FF.[FournisseurID]) WHEN ((Ligne = @NoLigneTPSTransporteur)OR(Ligne = @NoLigneTPSChargeur)OR(Ligne = @NoLigneTPSAutresFrais)OR(Ligne = @NoLigneTPSCompensation)OR(Ligne = @NoLigneTPSAutresRevenus)) THEN (SELECT [Value] FROM jag_SystemEx WHERE [Name] = 'Syndicat_NoTPS') WHEN (Ligne = @NoLigneTVQProducteur) THEN (SELECT No_TVQ FROM Fournisseur F WHERE F.[ID] = FF.[FournisseurID]) WHEN ((Ligne = @NoLigneTVQTransporteur)OR(Ligne = @NoLigneTVQAutresFrais)OR(Ligne = @NoLigneTVQAutresRevenus)OR(Ligne = @NoLigneTVQCompensation)OR(Ligne = @NoLigneTVQChargeur)) THEN (SELECT [Value] FROM jag_SystemEx WHERE [Name] = 'Syndicat_NoTVQ') WHEN ((Ligne = @NoLigneTPSPreleve)OR(Ligne = @NoLigneTPSSurcharge)) THEN (SELECT [Value] FROM jag_SystemEx WHERE [Name] = 'Preleves_NoTPS') WHEN ((Ligne = @NoLigneTVQPreleve)OR(Ligne = @NoLigneTVQSurcharge)) THEN (SELECT [Value] FROM jag_SystemEx WHERE [Name] = 'Preleves_NoTVQ') END) AS [No_Taxe]
		FROM FactureFournisseur_Sommaire FFS
			INNER JOIN FactureFournisseur FF ON FF.[ID] = FFS.FactureID
		WHERE FFS.FactureID = @FactureID
		AND Ligne >= 500
		
		SET @Montant_Surcharge = 0
		SET @Frais_Chargeur = 0
		SET @Frais_Autres = 0
		SET @Frais_CompensationDeDeplacement = 0
		SET @Frais_AutresRevenus = 0

		/*delete @Surcharges
		
		insert into @Surcharges (ContratID, Montant)
		SELECT
		C.[ID],
		SUM(dbo.jag_CalculateMontantSurchargeAuProducteur(L.[ID], LD.ProducteurID))
		FROM FactureFournisseur_Details FFD
			INNER JOIN Livraison L ON L.[ID] = FFD.RefID
			INNER JOIN Contrat C ON C.[ID] = L.ContratID
			INNER JOIN FactureFournisseur FF ON FF.[ID] = FFD.FactureID
			INNER JOIN Livraison_Detail LD ON LD.[LivraisonID] = L.[ID] AND LD.ProducteurID = FF.FournisseurID
		WHERE FFD.FactureID = @FactureID
		GROUP BY C.[ID]*/
		
		SELECT 
		@Montant_Surcharge = SUM(dbo.jag_CalculateMontantSurchargeAuProducteur(L.[ID], LD.ProducteurID))
		FROM FactureFournisseur_Details FFD
			INNER JOIN Livraison L ON L.[ID] = FFD.RefID
			INNER JOIN FactureFournisseur FF ON FF.[ID] = FFD.FactureID
			INNER JOIN Livraison_Detail LD ON LD.[LivraisonID] = L.[ID] AND LD.ProducteurID = FF.FournisseurID
		WHERE FFD.FactureID = @FactureID
		
		SET @Montant_Surcharge = (CASE WHEN @Montant_Surcharge IS NOT NULL THEN @Montant_Surcharge ELSE 0 END)

		--update @Surcharges set Volume = 0 WHERE Volume IS NULL
		--update @Surcharges set Taux = 0 WHERE Taux IS NULL
		--update @Surcharges set Montant = ROUND((Volume*Taux),2)
		
		--update @Surcharges SET Montant=0 WHERE Montant IS NULL
		--delete @Surcharges where Montant <= 0
		
		--SET @Montant_Surcharge = (SELECT (-1*SUM(Montant)) FROM @Surcharges)
		--SET @Montant_Surcharge = (CASE WHEN @Montant_Surcharge IS NOT NULL THEN @Montant_Surcharge ELSE 0 END)

		SELECT
		@Frais_Chargeur = ROUND((-1*SUM(Frais_ChargeurAuProducteur)),2),
		@Frais_Autres = ROUND((-1*SUM(Frais_AutresAuProducteur)),2),
		@Frais_CompensationDeDeplacement = ROUND((-1*SUM(Frais_CompensationDeDeplacement)),2),
		@Frais_AutresRevenus = ROUND(SUM(Frais_AutresRevenusProducteur),2)	
		FROM FactureFournisseur_Details FFD
			INNER JOIN Livraison L ON L.[ID] = FFD.RefID
		WHERE FFD.FactureID = @FactureID
		
		if @Montant_Surcharge is null
		BEGIN
			set @Montant_Surcharge = 0
		END
		if @Frais_Chargeur is null
		BEGIN
			set @Frais_Chargeur = 0
		END
		if @Frais_CompensationDeDeplacement is null
		BEGIN
			set @Frais_CompensationDeDeplacement = 0
		END
		if @Frais_Autres is null
		BEGIN
			set @Frais_Autres = 0
		END
		if @Frais_AutresRevenus is null
		BEGIN
			set @Frais_AutresRevenus = 0
		END

		SELECT 
		@Montant_Surcharge AS [MontantSurcharge],
		@Frais_Chargeur AS [MontantChargeur],
		@Frais_CompensationDeDeplacement AS [MontantCompensationDeDeplacement],
		@Frais_Autres AS [MontantAutres],
		@Frais_AutresRevenus AS [MontantAutresRevenus]
		
		DECLARE @FournisseurID VARCHAR(15)
		DECLARE @Periode INT
		DECLARE @PeriodeContingentement INT
		DECLARE @AnneeContingentement INT

		select TOP 1
		@AnneeContingentement = L.Annee, 
		@Periode = L.Periode
		from Livraison L
		WHERE [ID] in (select RefID from facturefournisseur_details where FactureID = @FactureID)
		ORDER BY (convert(char(4), L.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,L.[Periode]),2))) DESC

		SELECT
		@PeriodeContingentement = PeriodeContingentement
		FROM Periode
		WHERE Annee = @AnneeContingentement
		AND SemaineNo = @Periode

		SELECT
		@FournisseurID = FournisseurID
		FROM FactureFournisseur FF
		WHERE FF.[ID] = @FactureID
		
		SELECT
		(CASE WHEN C.ContingentUsine = 1 THEN C.UsineID + ' - ' + U.[Description] ELSE 'Regroupement' END) AS [Contingentement],
		(CASE WHEN C.ContingentUsine = 1 THEN C.EssenceID + ' - ' + E.[Description] ELSE R.[Description] END) AS [EssenceRegroupement],
		(CP.Volume_Accorde - dbo.jag_GetVolumeLivrePourContingentementParProducteur (CP.ContingentementID, CP.ProducteurID)) AS [VolumeRestant],
		C.UniteMesureID AS [Unite]
		FROM Contingentement C
			INNER JOIN Contingentement_Producteur CP ON CP.ContingentementID = C.[ID] AND CP.ProducteurID = @FournisseurID
			LEFT OUTER JOIN Usine U ON U.[ID] = C.UsineID
			LEFT OUTER JOIN Essence E ON E.[ID] = C.EssenceID
			LEFT OUTER JOIN EssenceRegroupement R ON R.[ID] = C.RegroupementID
		WHERE C.PeriodeContingentement = @PeriodeContingentement
		AND C.Annee = @AnneeContingentement
	END
	ELSE IF (@TypeFacture = 'A')
	BEGIN
		if (@AjustementResume = 0)
		Begin	
			SELECT Distinct
			(L.DateLivraison) AS [Date],
			(L.NumeroFactureUsine) AS [FactureUsine],
			L.[ID] AS [Permis],
			C.UsineID AS [UsineID],
			U.[Description] AS [Usine],
			L.UniteMesureID AS [Unite],
			E.[Description] + ' ' + LTRIM(RTRIM(LD.Code)) AS [Essence],
			A.[ID] AS [Ajustement],
			ACP.Volume,
			ACP.Taux,
			ACP.Montant
			FROM FactureFournisseur_Details FFD
				INNER JOIN FactureFournisseur FF ON FF.[ID] = FFD.FactureID
				INNER JOIN AjustementCalcule_Producteur ACP ON ACP.[ID] = FFD.RefID AND ACP.ProducteurID = FF.FournisseurID
				INNER JOIN Ajustement A ON A.[ID] = ACP.AjustementID
				INNER JOIN Livraison_Detail LD ON LD.[ID] = ACP.LivraisonDetailID
				INNER JOIN Livraison L ON L.[ID] = LD.[LivraisonID]
				INNER JOIN Contrat C ON C.[ID] = A.ContratID
				INNER JOIN Usine U ON U.[ID] = C.UsineID
				LEFT OUTER JOIN Essence E ON E.[ID] = L.EssenceID
			WHERE FFD.FactureID = @FactureID
			AND FFD.Compte <> @Compte_DuAuxProducteurs
			AND FFD.Compte <> dbo.jag_GetCompteMEC (C.UsineID)
			ORDER BY L.DateLivraison DESC

			SELECT
			FFS.Ligne,
			FFS.Montant,
			FFS.[Description],
			(CASE WHEN (Ligne = @NoLigneTPS) THEN F.No_TPS WHEN (Ligne = @NoLigneTVQ) THEN F.No_TVQ END) AS [No_Taxe]
			FROM FactureFournisseur_Sommaire FFS
				INNER JOIN FactureFournisseur FF ON FF.[ID] = FFS.FactureID
				INNER JOIN Fournisseur F ON F.[ID] = FF.FournisseurID
			WHERE FFS.FactureID = @FactureID

			AND Ligne >= 500
		end
		else
		Begin
			SELECT
			C.UsineID AS [UsineID],
			U.[Description] AS [Usine],
			L.UniteMesureID AS [Unite],
			sum(ACP.Volume) AS [Volume],
			ACP.Taux,
			sum(ACP.Montant) as [Montant]
			FROM FactureFournisseur_Details FFD
				INNER JOIN FactureFournisseur FF ON FF.[ID] = FFD.FactureID
				INNER JOIN AjustementCalcule_Producteur ACP ON ACP.[ID] = FFD.RefID AND ACP.ProducteurID = FF.FournisseurID
				INNER JOIN Ajustement A ON A.[ID] = ACP.AjustementID
				INNER JOIN Livraison_Detail LD ON LD.[ID] = ACP.LivraisonDetailID
				INNER JOIN Livraison L ON L.[ID] = LD.[LivraisonID]
				INNER JOIN Contrat C ON C.[ID] = A.ContratID
				INNER JOIN Usine U ON U.[ID] = C.UsineID
				LEFT OUTER JOIN Essence E ON E.[ID] = L.EssenceID
			WHERE FFD.FactureID = @FactureID
			AND FFD.Compte <> @Compte_DuAuxProducteurs
			AND FFD.Compte <> dbo.jag_GetCompteMEC (C.UsineID)
			Group by C.UsineID,	U.[Description], L.UniteMesureID , ACP.Taux				
			ORDER BY C.UsineID 

			SELECT
			FFS.Ligne,
			FFS.Montant,
			FFS.[Description],
			(CASE WHEN (Ligne = @NoLigneTPS) THEN F.No_TPS WHEN (Ligne = @NoLigneTVQ) THEN F.No_TVQ END) AS [No_Taxe]
			FROM FactureFournisseur_Sommaire FFS
				INNER JOIN FactureFournisseur FF ON FF.[ID] = FFS.FactureID
				INNER JOIN Fournisseur F ON F.[ID] = FF.FournisseurID
			where FFS.FactureID = @FactureID				
			AND Ligne >= 500				
		end
	END
	ELSE IF (@TypeFacture = 'I')
	BEGIN
		
		SELECT
		(L.DateLivraison) AS [Date],
		(L.NumeroFactureUsine) AS [FactureUsine],
		L.[ID] AS [Permis],
		C.UsineID AS [UsineID],
		U.[Description] AS [Usine],
		L.UniteMesureID AS [Unite],
		(CASE WHEN L.Sciage = 1 THEN 'Sciage' ELSE E.[Description] + ' ' + LTRIM(RTRIM(L.Code)) END) AS [Essence],
		I.[ID] AS [Indexation],
		(CASE WHEN ICP.TypeIndexation = 'M' THEN ICP.Volume ELSE 0 END) AS [Volume],
		(CASE WHEN ICP.TypeIndexation = 'P' THEN (ICP.MontantDejaPaye) ELSE 0 END) AS [MontantDejaPaye],
		(CASE WHEN ICP.TypeIndexation = 'P' THEN (ICP.PourcentageDuMontant * 100) ELSE 0 END) AS [PourcentageDuMontant],
		(CASE WHEN ICP.TypeIndexation = 'M' THEN ICP.Taux ELSE 0 END) AS [Taux],
		ICP.Montant
		FROM FactureFournisseur_Details FFD
			INNER JOIN FactureFournisseur FF ON FF.[ID] = FFD.FactureID
			INNER JOIN IndexationCalcule_Producteur ICP ON ICP.[ID] = FFD.RefID
			LEFT OUTER JOIN Indexation_EssenceUnite [IEU] ON [IEU].[ID] = ICP.IndexationDetailID
			INNER JOIN Indexation I ON ((I.[ID] = ICP.IndexationID) OR (I.[ID] = [IEU].IndexationID))
			INNER JOIN Livraison L ON L.[ID] = ICP.LivraisonID
			INNER JOIN Contrat C ON C.[ID] = I.ContratID
			INNER JOIN Usine U ON U.[ID] = C.UsineID
			LEFT OUTER JOIN Essence E ON E.[ID] = L.EssenceID
		WHERE FFD.FactureID = @FactureID
		ORDER BY L.DateLivraison DESC
		
		SELECT
		FFS.Ligne,
		FFS.Montant,
		FFS.[Description],
		(CASE WHEN (Ligne = @NoLigneTPS) THEN F.No_TPS WHEN (Ligne = @NoLigneTVQ) THEN F.No_TVQ END) AS [No_Taxe]
		FROM FactureFournisseur_Sommaire FFS
			INNER JOIN FactureFournisseur FF ON FF.[ID] = FFS.FactureID
			INNER JOIN Fournisseur F ON F.[ID] = FF.FournisseurID
		WHERE FFS.FactureID = @FactureID
		AND Ligne >= 500
	
	END
END

--------------------------------------------
-- TRANSPORTEUR
--------------------------------------------
ELSE IF (@TypeFactureFournisseur = 'T')--TRANSPORTEUR
BEGIN
	
	IF (@TypeFacture = 'L')
	BEGIN
	
		SELECT
		(L.DateLivraison) AS [Date],
		(L.NumeroFactureUsine) AS [FactureUsine],
		L.[ID] AS [Permis],
		C.UsineID AS [UsineID],
		U.[Description] AS [Usine],
		L.UniteMesureID AS [Unite],
		(CASE WHEN L.Sciage = 1 THEN 'Sciage' ELSE E.[Description] + ' ' + LTRIM(RTRIM(L.Code)) END) AS [Essence],
		L.VolumeTransporte AS [VolumeBrut],
		(CASE WHEN (L.PaieTransporteur = 1) THEN L.VolumeSurcharge ELSE 0 END) AS [VolumeSurcharge],
		L.VolumeAPayer AS [VolumeNet],
		L.Taux_Transporteur AS [Taux_Transporteur],
		L.Montant_Transporteur AS [Montant_Transporteur],
		L.Montant_Transporteur as SubTotal 
		FROM FactureFournisseur_Details FFD
			INNER JOIN FactureFournisseur FF ON FF.[ID] = FFD.FactureID
			INNER JOIN Livraison L ON L.[ID] = FFD.RefID AND L.TransporteurID = FF.FournisseurID
			INNER JOIN Contrat C ON C.[ID] = L.ContratID
			INNER JOIN Usine U ON U.[ID] = C.UsineID
			LEFT OUTER JOIN Essence E ON E.[ID] = L.EssenceID
		WHERE FFD.FactureID = @FactureID
		ORDER BY L.DateLivraison DESC

		SELECT
		FFS.Ligne,
		FFS.Montant,

		FFS.[Description],
		(CASE WHEN ((Ligne = @NoLigneTPSTransporteur)OR(Ligne = @NoLigneTPSAutresRevenus)OR(Ligne = @NoLigneTPSCompensation)) THEN F.No_TPS WHEN ((Ligne = @NoLigneTVQTransporteur)OR(Ligne = @NoLigneTVQAutresRevenus)OR(Ligne = @NoLigneTVQCompensation)) THEN F.No_TVQ WHEN ((Ligne = @NoLigneTPSChargeur)OR(Ligne = @NoLigneTPSAutresFrais)) THEN (SELECT [Value] FROM jag_SystemEx WHERE [Name] = 'Syndicat_NoTPS') WHEN ((Ligne = @NoLigneTVQChargeur)OR(Ligne = @NoLigneTVQAutresFrais)) THEN (SELECT [Value] FROM jag_SystemEx WHERE [Name] = 'Syndicat_NoTVQ') END) AS [No_Taxe]
		FROM FactureFournisseur_Sommaire FFS
			INNER JOIN FactureFournisseur FF ON FF.[ID] = FFS.FactureID
			INNER JOIN Fournisseur F ON F.[ID] = FF.FournisseurID
		WHERE FFS.FactureID = @FactureID
		AND Ligne >= 500
		
		SET @Frais_Chargeur = 0
		SET @Frais_Autres = 0
		SET @Frais_CompensationDeDeplacement = 0
		SET @Frais_AutresRevenus = 0

		SELECT
		@Frais_Chargeur = ROUND((-1*SUM(Frais_ChargeurAuTransporteur)),2),
		@Frais_Autres = ROUND((-1*SUM(Frais_AutresAuTransporteur)),2),
		@Frais_CompensationDeDeplacement = ROUND(SUM(Frais_CompensationDeDeplacement),2),
		@Frais_AutresRevenus = ROUND(SUM(Frais_AutresRevenusTransporteur),2)
		FROM FactureFournisseur_Details FFD
			INNER JOIN Livraison L ON L.[ID] = FFD.RefID
		WHERE FFD.FactureID = @FactureID

		if @Frais_Chargeur is null
		BEGIN
			set @Frais_Chargeur = 0
		END
		if @Frais_Autres is null
		BEGIN
			set @Frais_Autres = 0
		END
		if @Frais_CompensationDeDeplacement is null
		BEGIN
			set @Frais_CompensationDeDeplacement = 0
		END
		if @Frais_AutresRevenus is null
		BEGIN
			set @Frais_AutresRevenus = 0
		END

		SELECT 
		@Frais_Chargeur AS [MontantChargeur],
		@Frais_Autres AS [MontantAutres],
		@Frais_CompensationDeDeplacement AS [MontantCompensationDeDeplacement],
		@Frais_AutresRevenus AS [MontantAutresRevenus]
		
	END
	ELSE IF (@TypeFacture = 'A')
	BEGIN

		SELECT @nb = count(*) FROM AjustementCalcule_Transporteur WHERE factureID = 58100;
		if @nb > 0 

		-- Ajustement Transporteur
		Begin		
			SELECT
			(L.DateLivraison) AS [Date],
			(L.NumeroFactureUsine) AS [FactureUsine],
			L.[ID] AS [Permis],
			C.UsineID AS [UsineID],
			U.[Description] AS [Usine],
			L.UniteMesureID AS [Unite],
			(CASE WHEN L.Sciage = 1 THEN 'Sciage' ELSE E.[Description] + ' ' + LTRIM(RTRIM(L.Code)) END) AS [Essence],
			A.[ID] AS [Ajustement],
			ACT.Volume,
			ACT.Taux,
			ACT.Montant
			FROM FactureFournisseur_Details FFD
				INNER JOIN FactureFournisseur FF ON FF.[ID] = FFD.FactureID
				INNER JOIN AjustementCalcule_Transporteur ACT ON ACT.[ID] = FFD.RefID AND ACT.TransporteurID = FF.FournisseurID
				INNER JOIN Ajustement A ON A.[ID] = ACT.AjustementID
				INNER JOIN Livraison L ON L.[ID] = ACT.LivraisonID
				INNER JOIN Contrat C ON C.[ID] = A.ContratID
				INNER JOIN Usine U ON U.[ID] = C.UsineID
				LEFT OUTER JOIN Essence E ON E.[ID] = L.EssenceID
			WHERE FFD.FactureID = @FactureID
			AND FFD.Compte <> @Compte_DuAuxProducteurs
			AND FFD.Compte <> dbo.jag_GetCompteMEC (C.UsineID)
			ORDER BY L.DateLivraison DESC

			SELECT
			FFS.Ligne,
			FFS.Montant,
			FFS.[Description],
			(CASE WHEN (Ligne = @NoLigneTPS) THEN F.No_TPS WHEN (Ligne = @NoLigneTVQ) THEN F.No_TVQ END) AS [No_Taxe]
			FROM FactureFournisseur_Sommaire FFS
				INNER JOIN FactureFournisseur FF ON FF.[ID] = FFS.FactureID
				INNER JOIN Fournisseur F ON F.[ID] = FF.FournisseurID

			WHERE FFS.FactureID = @FactureID
			AND Ligne >= 500
		End
		Else

		-- Ajustement Transporteur Essece
		Begin
			SELECT Distinct
			(L.DateLivraison) AS [Date],
			(L.NumeroFactureUsine) AS [FactureUsine],
			L.[ID] AS [Permis],
			C.UsineID AS [UsineID],
			U.[Description] AS [Usine],
			L.UniteMesureID AS [Unite],
			(CASE WHEN L.Sciage = 1 THEN 'Sciage' ELSE E.[Description] + ' ' + LTRIM(RTRIM(L.Code)) END) AS [Essence],
			A.[ID] AS [Ajustement],
			ACT.Volume,
			ACT.Taux,
			ACT.Montant
			FROM FactureFournisseur_Details FFD
				INNER JOIN FactureFournisseur FF ON FF.[ID] = FFD.FactureID
				INNER JOIN AjustementCalcule_TransporteurEssence ACT ON ACT.[ID] = FFD.RefID AND ACT.TransporteurID = FF.FournisseurID
				INNER JOIN Ajustement A ON A.[ID] = ACT.AjustementID
				INNER JOIN Livraison_Detail LD ON LD.[ID] = ACT.LivraisonDetailID
				INNER JOIN Livraison L ON L.[ID] = LD.[LivraisonID]
				INNER JOIN Contrat C ON C.[ID] = A.ContratID
				INNER JOIN Usine U ON U.[ID] = C.UsineID
				LEFT OUTER JOIN Essence E ON E.[ID] = L.EssenceID
			WHERE FFD.FactureID = @FactureID
			AND FFD.Compte <> @Compte_DuAuxProducteurs
			AND FFD.Compte <> dbo.jag_GetCompteMEC (C.UsineID)
			ORDER BY L.DateLivraison DESC

			SELECT
			FFS.Ligne,
			FFS.Montant,
			FFS.[Description],
			(CASE WHEN (Ligne = @NoLigneTPS) THEN F.No_TPS WHEN (Ligne = @NoLigneTVQ) THEN F.No_TVQ END) AS [No_Taxe]
			FROM FactureFournisseur_Sommaire FFS
				INNER JOIN FactureFournisseur FF ON FF.[ID] = FFS.FactureID
				INNER JOIN Fournisseur F ON F.[ID] = FF.FournisseurID

			WHERE FFS.FactureID = @FactureID
			AND Ligne >= 500
		End
	
	END
	ELSE IF (@TypeFacture = 'I')
	BEGIN
		
		SELECT
		(L.DateLivraison) AS [Date],
		(L.NumeroFactureUsine) AS [FactureUsine],
		L.[ID] AS [Permis],
		C.UsineID AS [UsineID],
		U.[Description] AS [Usine],
		L.UniteMesureID AS [Unite],
		(CASE WHEN L.Sciage = 1 THEN 'Sciage' ELSE E.[Description] + ' ' + LTRIM(RTRIM(L.Code)) END) AS [Essence],
		I.[ID] AS [Indexation],
		(CASE WHEN ICT.TypeIndexation = 'P' THEN (ICT.MontantDejaPaye) ELSE 0 END) AS [MontantDejaPaye],
		(CASE WHEN ICT.TypeIndexation = 'P' THEN (ICT.PourcentageDuMontant * 100) ELSE 0 END) AS [PourcentageDuMontant],
		ICT.Montant
		FROM FactureFournisseur_Details FFD

			INNER JOIN FactureFournisseur FF ON FF.[ID] = FFD.FactureID
			INNER JOIN IndexationCalcule_Transporteur ICT ON ICT.[ID] = FFD.RefID
			LEFT OUTER JOIN Indexation_Municipalite [IM] ON [IM].[ID] = ICT.IndexationDetailID
			INNER JOIN Indexation I ON ((I.[ID] = ICT.IndexationID) OR (I.[ID] = [IM].IndexationID))
			INNER JOIN Livraison L ON L.[ID] = ICT.LivraisonID
			INNER JOIN Contrat C ON C.[ID] = I.ContratID
			INNER JOIN Usine U ON U.[ID] = C.UsineID
			LEFT OUTER JOIN Essence E ON E.[ID] = L.EssenceID
		WHERE FFD.FactureID = @FactureID
		ORDER BY L.DateLivraison DESC
		
		SELECT
		FFS.Ligne,
		FFS.Montant,
		FFS.[Description],
		(CASE WHEN (Ligne = @NoLigneTPS) THEN F.No_TPS WHEN (Ligne = @NoLigneTVQ) THEN F.No_TVQ END) AS [No_Taxe]
		FROM FactureFournisseur_Sommaire FFS
			INNER JOIN FactureFournisseur FF ON FF.[ID] = FFS.FactureID
			INNER JOIN Fournisseur F ON F.[ID] = FF.FournisseurID
		WHERE FFS.FactureID = @FactureID
		AND Ligne >= 500
		
		SELECT
		C.UsineID AS [UsineID],
		U.[Description] AS [Usine],
		L.UniteMesureID AS [Unite],
		sum(L.VolumeTransporte) AS [VolumePaye],
		sum((CASE WHEN ICT.TypeIndexation = 'P' THEN (ICT.MontantDejaPaye) ELSE 0 END)) AS [MontantDejaPaye],
		MAX((CASE WHEN ICT.TypeIndexation = 'P' THEN (ICT.PourcentageDuMontant * 100) ELSE 0 END)) AS [PourcentageDuMontant],
		sum(ICT.Montant) [Montant]
		FROM FactureFournisseur_Details FFD
			INNER JOIN FactureFournisseur FF ON FF.[ID] = FFD.FactureID
			INNER JOIN IndexationCalcule_Transporteur ICT ON ICT.[ID] = FFD.RefID
			LEFT OUTER JOIN Indexation_Municipalite [IM] ON [IM].[ID] = ICT.IndexationDetailID
			INNER JOIN Indexation I ON ((I.[ID] = ICT.IndexationID) OR (I.[ID] = [IM].IndexationID))
			INNER JOIN Livraison L ON L.[ID] = ICT.LivraisonID
			INNER JOIN Contrat C ON C.[ID] = I.ContratID
			INNER JOIN Usine U ON U.[ID] = C.UsineID
		WHERE FFD.FactureID = @FactureID
		GROUP BY C.UsineID, U.[Description], L.UniteMesureID
		ORDER BY U.[Description]
	
	END
END

--------------------------------------------
-- CHARGEUR
--------------------------------------------
ELSE IF (@TypeFactureFournisseur = 'C')--CHARGEUR
BEGIN
	
	IF (@TypeFacture = 'L')
	BEGIN
		SELECT
		(L.DateLivraison) AS [Date],
		(L.NumeroFactureUsine) AS [FactureUsine],
		L.[ID] AS [Permis],
		C.UsineID AS [UsineID],
		U.[Description] AS [Usine],
		L.UniteMesureID AS [Unite],
		(CASE WHEN L.Sciage = 1 THEN 'Sciage' ELSE E.[Description] + ' ' + LTRIM(RTRIM(L.Code)) END) AS [Essence],
		L.Frais_ChargeurAuProducteur AS [MontantPayeParProducteur],
		L.Frais_ChargeurAuTransporteur AS [MontantPayeParTransporteur],
		L.Montant_Chargeur AS [Montant_Chargeur],
		L.Montant_Chargeur as SubTotal 
		FROM FactureFournisseur_Details FFD
			INNER JOIN FactureFournisseur FF ON FF.[ID] = FFD.FactureID
			INNER JOIN Livraison L ON L.[ID] = FFD.RefID AND L.ChargeurID = FF.FournisseurID
			INNER JOIN Contrat C ON C.[ID] = L.ContratID
			INNER JOIN Usine U ON U.[ID] = C.UsineID
			LEFT OUTER JOIN Essence E ON E.[ID] = L.EssenceID
		WHERE FFD.FactureID = @FactureID
		ORDER BY L.DateLivraison DESC

		SELECT
		FFS.Ligne,
		FFS.Montant,
		FFS.[Description],
		(CASE WHEN (Ligne = @NoLigneTPS) THEN F.No_TPS WHEN (Ligne = @NoLigneTVQ) THEN F.No_TVQ END) AS [No_Taxe]
		FROM FactureFournisseur_Sommaire FFS
			INNER JOIN FactureFournisseur FF ON FF.[ID] = FFS.FactureID
			INNER JOIN Fournisseur F ON F.[ID] = FF.FournisseurID
		WHERE FFS.FactureID = @FactureID
		AND Ligne >= 500
	END
END

--------------------------------------------
-- AUTRES
--------------------------------------------
ELSE IF (@TypeFactureFournisseur = 'R') or (@TypeFactureFournisseur = 'S') --PRELEVE ou - SURCHARGE
BEGIN
	SELECT
	FFS.Compte,
	C.[Description] AS [CompteDesc],
	FFS.Montant,
	FFS.[Description]
	FROM FactureFournisseur_Sommaire FFS
		INNER JOIN FactureFournisseur FF ON FF.[ID] = FFS.FactureID
		INNER JOIN Compte C ON C.[ID] = FFS.Compte
	WHERE FFS.FactureID = @FactureID
	ORDER BY FFS.Ligne
END
