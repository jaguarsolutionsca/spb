

CREATE PROCEDURE dbo.jag_Get_ContingentementIDForLivraisonDetail
	(
		@UsineID VARCHAR(6) = NULL,
		@RegroupementID INT = NULL,
		@Annee INT,
		@EssenceID VARCHAR(6),
		@UniteMesureID VARCHAR(6),
		@Date DATETIME,
		@ProducteurID VARCHAR(10),
		@ID int = NULL OUTPUT
	)
AS
	
SET @ID = NULL

DECLARE @PeriodeContin int

SELECT @PeriodeContin = PeriodeContingentement FROM Periode WHERE Periode.Annee = @Annee AND Periode.DateDebut <= @Date AND Periode.DateFin >= @Date

--On essaye de trouver un contingentement usine qui match les paramètres
if (@UsineID IS NOT NULL)
BEGIN
	SELECT
	@ID = [ID]
	FROM Contingentement
		INNER JOIN Contingentement_Producteur ON Contingentement_Producteur.ContingentementID = Contingentement.[ID] AND Contingentement_Producteur.ProducteurID = @ProducteurID
	WHERE Contingentement.ContingentUsine = 1
	AND (Contingentement.UsineID = @UsineID)
	AND (Contingentement.Annee = @Annee)
	AND (Contingentement.EssenceID = @EssenceID)
	--AND (Contingentement.UniteMesureID = @UniteMesureID)
	AND (PeriodeContingentement = @PeriodeContin)
	AND (CalculAccepte = 1)
END

--On essaye de trouver un contintentement regroupement qui match les paramètres
IF (@ID IS NULL)
BEGIN
	SELECT
	@ID = [ID]
	FROM Contingentement
		INNER JOIN Contingentement_Producteur ON Contingentement_Producteur.ContingentementID = Contingentement.[ID] AND Contingentement_Producteur.ProducteurID = @ProducteurID
	WHERE Contingentement.ContingentUsine = 0
	AND (Contingentement.RegroupementID = @RegroupementID)
	AND (Contingentement.Annee = @Annee)
	--AND (Contingentement.UniteMesureID = @UniteMesureID)
	AND (PeriodeContingentement = @PeriodeContin)
	AND (CalculAccepte = 1)
END

--si on a rien trouvé, on essaie de l'assigner dans un contingentement usine même si le producteur n'existe pas dedans
IF ((@ID IS NULL) AND (@UsineID IS NOT NULL))
BEGIN
	SELECT
	@ID = [ID]
	FROM Contingentement
	WHERE Contingentement.ContingentUsine = 1
	AND (Contingentement.UsineID = @UsineID)
	AND (Contingentement.Annee = @Annee)
	AND (Contingentement.EssenceID = @EssenceID)
	--AND (Contingentement.UniteMesureID = @UniteMesureID)
	AND (PeriodeContingentement = @PeriodeContin)
	AND (CalculAccepte = 1)
END

--si on a encore rien trouvé, on essaie de l'assigner dans un contingentement regroupement même si le producteur n'existe pas dedans
IF (@ID IS NULL)
BEGIN
	SELECT
	@ID = [ID]
	FROM Contingentement
	WHERE Contingentement.ContingentUsine = 0
	AND (Contingentement.RegroupementID = @RegroupementID)
	AND (Contingentement.Annee = @Annee)
	--AND (Contingentement.UniteMesureID = @UniteMesureID)
	AND (PeriodeContingentement = @PeriodeContin)
	AND (CalculAccepte = 1)
END

INSERT INTO Contingentement_Unite (ContingentementID, UniteID, Facteur)
SELECT
ID,
UniteMesureID,
1
FROM Contingentement C
WHERE C.UniteMesureID NOT IN (SELECT UniteID FROM Contingentement_Unite CU WHERE CU.ContingentementID = C.[ID])

IF (@ID IS NOT NULL)
BEGIN
	IF NOT EXISTS (SELECT * FROM Contingentement_Unite CP WHERE CP.ContingentementID = @ID AND CP.UniteID = @UniteMesureID)
	BEGIN
		INSERT INTO Contingentement_Unite (ContingentementID, UniteID, Facteur)
		SELECT @ID, @UniteMesureID, 0
	END
END


