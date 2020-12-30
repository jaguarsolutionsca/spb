CREATE PROCEDURE [dbo].[jag_AutorisationDesLivraisons]
@Annee INT, @PeriodeContingentement INT, @ContingentUsine BIT, @ProducteurID VARCHAR (15), @UpdateImprime BIT=0
AS
SET NOCOUNT ON


-----------------------------------------------------------
-- Liste des Autorisations
-----------------------------------------------------------
Declare @Autorisation table
(
	ContingentementID  int,
	ProducteurID  varchar(15)
)


	insert into @Autorisation(ContingentementID, ProducteurID)
	select  CP.[ContingentementID],CP.ProducteurID  
	
	FROM Contingentement_Producteur CP
		INNER JOIN Contingentement C ON C.[ID] = CP.[ContingentementID]
	WHERE ((C.Annee = @Annee) AND (C.PeriodeContingentement = @PeriodeContingentement))
		AND (CP.ProducteurID = @ProducteurID)
		AND (C.ContingentUsine = @ContingentUsine)
		AND (C.CalculAccepte = 1)


IF NOT EXISTS (SELECT * from @Autorisation)
BEGIN
	RETURN
END

-----------------------------------------------------------
-- Mettre a jour le bit Imprime
-----------------------------------------------------------
if (@UpdateImprime = 1)
Begin
	update Contingentement_Producteur
	set imprime = 1 
	where exists (select 1 from @Autorisation as a where a.ContingentementID = Contingentement_Producteur.ContingentementID
															and a.ProducteurID = Contingentement_Producteur.ProducteurID)
End


SELECT
F.[ID],
F.Nom,
F.Rue,
F.Ville,
UPPER(F.Code_Postal) AS [Code_Postal],
dbo.jag_Convert_Phone(F.Telephone) AS [Telephone],
dbo.jag_Convert_Phone(F.Telecopieur) AS [Telecopieur],
F.No_TPS,
F.No_TVQ,
dbo.jag_GetSuperficieContingente (@Annee, @PeriodeContingentement, @ContingentUsine, @ProducteurID) AS [Superficie_Contingente]
FROM Fournisseur F
WHERE F.[ID] = @ProducteurID

IF (@ContingentUsine = 1)
BEGIN
	SELECT
	E.[Description] AS [Essence],
	UM.[ID] AS [Unite],
	U.[Description] AS [Usine],
	(CASE WHEN (CP.Volume_Demande IS NOT NULL) THEN CP.Volume_Demande ELSE 0 END) AS [Volume_Demande],
	CP.Volume_Accorde AS [Volume_Alloue],
	(CASE WHEN dbo.jag_GetVolumeLivrePourContingentementParProducteur (C.[ID], CP.ProducteurID) IS NOT NULL THEN dbo.jag_GetVolumeLivrePourContingentementParProducteur (C.[ID], CP.ProducteurID) ELSE 0 END) AS [Volume_Livre],
	(CASE WHEN (CP.Volume_Accorde - dbo.jag_GetVolumeLivrePourContingentementParProducteur (C.[ID], CP.ProducteurID)) IS NOT NULL THEN (CP.Volume_Accorde - dbo.jag_GetVolumeLivrePourContingentementParProducteur (C.[ID], CP.ProducteurID)) ELSE 0 END) AS [Volume_A_Livre],
	C.Facteur
	FROM Contingentement C
		INNER JOIN Contingentement_Producteur CP ON CP.[ContingentementID] = C.[ID]
		INNER JOIN Essence E ON E.[ID] = C.EssenceID
		INNER JOIN UniteMesure UM ON UM.[ID] = C.UniteMesureID
		INNER JOIN Usine U ON U.[ID] = C.UsineID
	WHERE ((C.Annee = @Annee) AND (C.PeriodeContingentement = @PeriodeContingentement))
	AND (CP.ProducteurID = @ProducteurID)
	AND (C.ContingentUsine = @ContingentUsine)
	AND (C.CalculAccepte = 1)
END
ELSE IF (@ContingentUsine = 0)
BEGIN
SELECT
	ER.[Description] AS [Regroupement],
	UM.[ID] AS [Unite],
	(CASE WHEN (CP.Volume_Demande IS NOT NULL) THEN CP.Volume_Demande ELSE 0 END) AS [Volume_Demande],
	CP.Volume_Accorde AS [Volume_Alloue],
	(CASE WHEN dbo.jag_GetVolumeLivrePourContingentementParProducteur (C.[ID], CP.ProducteurID) IS NOT NULL THEN dbo.jag_GetVolumeLivrePourContingentementParProducteur (C.[ID], CP.ProducteurID) ELSE 0 END) AS [Volume_Livre],
	(CASE WHEN (CP.Volume_Accorde - dbo.jag_GetVolumeLivrePourContingentementParProducteur (C.[ID], CP.ProducteurID)) IS NOT NULL THEN (CP.Volume_Accorde - dbo.jag_GetVolumeLivrePourContingentementParProducteur (C.[ID], CP.ProducteurID)) ELSE 0 END) AS [Volume_A_Livre],
	C.Facteur
	FROM Contingentement C
		INNER JOIN Contingentement_Producteur CP ON CP.[ContingentementID] = C.[ID]
		INNER JOIN EssenceRegroupement ER ON ER.[ID] = C.RegroupementID
		INNER JOIN UniteMesure UM ON UM.[ID] = C.UniteMesureID
	WHERE ((C.Annee = @Annee) AND (C.PeriodeContingentement = @PeriodeContingentement))
	AND (CP.ProducteurID = @ProducteurID)
	AND (C.ContingentUsine = @ContingentUsine)
	AND (C.CalculAccepte = 1)
END

SELECT [Value] AS [Message] FROM jag_SystemEx WHERE [Name] = 'Message_AutorisationDesLivraisons'


