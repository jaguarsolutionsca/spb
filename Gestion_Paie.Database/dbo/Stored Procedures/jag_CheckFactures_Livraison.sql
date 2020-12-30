CREATE PROCEDURE [dbo].[jag_CheckFactures_Livraison]
@Periode INT, @Annee INT, @Usines VARCHAR (4000)=Null, @LivraisonID INT=Null, @Erreurs VARCHAR (5000) OUTPUT
AS
SET NOCOUNT ON

DECLARE @UsineErreur VARCHAR(1000)
SET @Erreurs = ''
SET @UsineErreur = ''
DECLARE @CompteID INT
DECLARE @FournisseurID VARCHAR(15)
DECLARE @CurrentUsineID VARCHAR(6)

Declare @SuspendrePaiement bit
set @SuspendrePaiement = 0

DECLARE @tUsines TABLE
(
	[ID] varchar(6)	
)

DECLARE @Livraisons TABLE
(
	[ID] int
)

IF (@Usines IS NOT NULL)
BEGIN
	INSERT INTO @tUsines ([ID])
	select * from Split(@Usines,';')
	
	DECLARE @CurrentUsine varchar(6)
	
	DECLARE cursUsine CURSOR FOR
		SELECT [ID] FROM @tUsines
	
	OPEN cursUsine
	
	FETCH NEXT FROM cursUsine INTO @CurrentUsine
	
	WHILE @@FETCH_STATUS = 0
	BEGIN
		INSERT INTO @Livraisons
		SELECT [ID] FROM dbo.jag_GetLivraisonsNonFacturees (@Periode, @Annee, @CurrentUsine, @LivraisonID, @SuspendrePaiement)
	
		FETCH NEXT FROM cursUsine INTO @CurrentUsine
	END
	
	-- Deallocate resources
	CLOSE cursUsine
	DEALLOCATE cursUsine
END
ELSE
BEGIN
	INSERT INTO @Livraisons
	SELECT [ID] FROM dbo.jag_GetLivraisonsNonFacturees (@Periode, @Annee, NULL, @LivraisonID, @SuspendrePaiement)
END

DELETE @tUsines

INSERT INTO @tUsines
SELECT DISTINCT C.UsineID FROM @Livraisons L INNER JOIN Livraison Li ON Li.[ID] = L.[ID] INNER JOIN Contrat C ON C.[ID] = Li.ContratID

SELECT * FROM @tUsines

SELECT
@FournisseurID = Fournisseur_PlanConjoint
FROM jag_System

IF (@FournisseurID IS NULL or ltrim(rtrim(@FournisseurID)) = '')
BEGIN
	SET @Erreurs = @Erreurs + 'le fournisseur de ''plan conjoint'' n''est pas spécifié%1'
END

SELECT
@FournisseurID = Fournisseur_Surcharge
FROM jag_System

IF (@FournisseurID IS NULL or ltrim(rtrim(@FournisseurID)) = '')
BEGIN
	SET @Erreurs = @Erreurs + 'le fournisseur de ''surcharge'' n''est pas spécifié%1'
END

SELECT
@FournisseurID = Fournisseur_Fond_Roulement
FROM jag_System

IF (@FournisseurID IS NULL or ltrim(rtrim(@FournisseurID)) = '')
BEGIN
	SET @Erreurs = @Erreurs + 'le fournisseur de ''prélevé fond de roulement'' n''est pas spécifié%1'
END

SELECT
@FournisseurID = Fournisseur_Fond_Forestier
FROM jag_System

IF (@FournisseurID IS NULL or ltrim(rtrim(@FournisseurID)) = '')
BEGIN
	SET @Erreurs = @Erreurs + 'le fournisseur de ''prélevé fond forestier'' n''est pas spécifié%1'
END

SELECT
@FournisseurID = Fournisseur_Preleve_Divers
FROM jag_System

IF (@FournisseurID IS NULL or ltrim(rtrim(@FournisseurID)) = '')
BEGIN
	SET @Erreurs = @Erreurs + 'le fournisseur de ''prélevé divers'' n''est pas spécifié%1'
END

SELECT
@CompteID = Compte_Paiements
FROM jag_System

IF (@CompteID IS NULL)
BEGIN
	SET @Erreurs = @Erreurs + 'le compte ''paiements'' n''est pas spécifié%1'
END

SELECT
@CompteID = Compte_ARecevoir
FROM jag_System

IF (@CompteID IS NULL)
BEGIN
	SET @Erreurs = @Erreurs + 'le compte ''à recevoir'' n''est pas spécifié%1'
END

SELECT
@CompteID = Compte_APayer
FROM jag_System

IF (@CompteID IS NULL)
BEGIN
	SET @Erreurs = @Erreurs + 'le compte ''à payer'' n''est pas spécifié%1'
END

SELECT
@CompteID = Compte_DuAuxProducteurs
FROM jag_System

IF (@CompteID IS NULL)
BEGIN
	SET @Erreurs = @Erreurs + 'le compte ''dû aux producteurs'' n''est pas spécifié%1'
END

SELECT
@CompteID = Compte_TPSpercues
FROM jag_System

IF (@CompteID IS NULL)
BEGIN
	SET @Erreurs = @Erreurs + 'le compte ''TPS perçues'' n''est pas spécifié%1'
END

SELECT
@CompteID = Compte_TPSpayees
FROM jag_System

IF (@CompteID IS NULL)
BEGIN
	SET @Erreurs = @Erreurs + 'le compte ''TPS payées'' n''est pas spécifié%1'
END

SELECT
@CompteID = Compte_TVQpercues
FROM jag_System

IF (@CompteID IS NULL)
BEGIN
	SET @Erreurs = @Erreurs + 'le compte ''TVQ perçues'' n''est pas spécifié%1'
END

SELECT
@CompteID = Compte_TVQpayees
FROM jag_System

IF (@CompteID IS NULL)
BEGIN
	SET @Erreurs = @Erreurs + 'le compte ''TVQ payées'' n''est pas spécifié%1'
END
SELECT
@CompteID = Compte_ARecevoir
FROM jag_System

IF (LEN(@Erreurs) > 0)
BEGIN
	SET @Erreurs = '%1[PARAMÊTRES SYSTÈME]%1' + @Erreurs
END

DECLARE cursUsines CURSOR FOR
	select TOP 100 PERCENT [ID] from @tUsines ORDER BY [ID]

OPEN cursUsines

FETCH NEXT FROM cursUsines INTO @CurrentUsineID

WHILE @@FETCH_STATUS = 0
BEGIN
	SET @UsineErreur = ''

	SELECT
	@CompteID = U.Compte_a_recevoir
	FROM Usine U
	WHERE U.[ID] = @CurrentUsineID

	IF (@CompteID IS NULL)
	BEGIN
		SET @UsineErreur = @UsineErreur + 'le compte ''à recevoir'' n''est pas spécifié%1'
	END	

	/*SELECT
	@CompteID = U.Compte_ajustement
	FROM Usine U
	WHERE U.[ID] = @CurrentUsineID

	IF (@CompteID IS NULL)
	BEGIN
		SET @UsineErreur = @UsineErreur + 'le compte ''ajustement'' n''est pas spécifié%1'
	END	*/

	SELECT
	@CompteID = U.Compte_transporteur
	FROM Usine U
	WHERE U.[ID] = @CurrentUsineID

	IF (@CompteID IS NULL)
	BEGIN
		SET @UsineErreur = @UsineErreur + 'le compte ''transporteur'' n''est pas spécifié%1'
	END	

	SELECT
	@CompteID = U.Compte_chargeur
	FROM Usine U
	WHERE U.[ID] = @CurrentUsineID

	IF (@CompteID IS NULL)
	BEGIN
		SET @UsineErreur = @UsineErreur + 'le compte ''chargeur'' n''est pas spécifié%1'
	END	

	SELECT
	@CompteID = U.Compte_producteur
	FROM Usine U
	WHERE U.[ID] = @CurrentUsineID

	IF (@CompteID IS NULL)
	BEGIN
		SET @UsineErreur = @UsineErreur + 'le compte ''producteur'' n''est pas spécifié%1'
	END	

	SELECT
	@CompteID = U.Compte_preleve_plan_conjoint
	FROM Usine U
	WHERE U.[ID] = @CurrentUsineID

	IF (@CompteID IS NULL)
	BEGIN
		SET @UsineErreur = @UsineErreur + 'le compte ''prélevé plan conjoint'' n''est pas spécifié%1'
	END	

	SELECT
	@CompteID = U.Compte_preleve_fond_roulement
	FROM Usine U
	WHERE U.[ID] = @CurrentUsineID

	IF (@CompteID IS NULL)
	BEGIN
		SET @UsineErreur = @UsineErreur + 'le compte ''prélevé fond de roulement'' n''est pas spécifié%1'
	END	

	SELECT
	@CompteID = U.Compte_preleve_fond_forestier
	FROM Usine U
	WHERE U.[ID] = @CurrentUsineID

	IF (@CompteID IS NULL)
	BEGIN
		SET @UsineErreur = @UsineErreur + 'le compte ''prélevé fond forestier'' n''est pas spécifié%1'
	END	

	SELECT
	@CompteID = U.Compte_preleve_divers
	FROM Usine U
	WHERE U.[ID] = @CurrentUsineID

	IF (@CompteID IS NULL)
	BEGIN
		SET @UsineErreur = @UsineErreur + 'le compte ''prélevé divers'' n''est pas spécifié%1'
	END	

	SELECT
	@CompteID = U.Compte_mise_en_commun
	FROM Usine U
	WHERE U.[ID] = @CurrentUsineID

	IF (@CompteID IS NULL)
	BEGIN
		SET @UsineErreur = @UsineErreur + 'le compte ''mise en commun'' n''est pas spécifié%1'
	END	

	SELECT
	@CompteID = U.Compte_surcharge
	FROM Usine U
	WHERE U.[ID] = @CurrentUsineID

	IF (@CompteID IS NULL)
	BEGIN
		SET @UsineErreur = @UsineErreur + 'le compte ''surcharge'' n''est pas spécifié%1'
	END	

	SELECT
	@CompteID = U.Compte_indexation_carburant
	FROM Usine U
	WHERE U.[ID] = @CurrentUsineID

	IF (@CompteID IS NULL)
	BEGIN
		SET @UsineErreur = @UsineErreur + 'le compte ''indexation carburant'' n''est pas spécifié%1'
	END	
	
	IF (LEN(@UsineErreur) > 0)
	BEGIN
		SET @UsineErreur = '[USINE ' + @CurrentUsineID + ']%1' + @UsineErreur
	END

	SET @Erreurs = @Erreurs + @UsineErreur

	FETCH NEXT FROM cursUsines INTO @CurrentUsineID
END

-- Deallocate resources
CLOSE cursUsines
DEALLOCATE cursUsines


