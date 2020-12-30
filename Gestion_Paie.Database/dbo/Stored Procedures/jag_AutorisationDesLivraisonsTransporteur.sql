CREATE PROCEDURE [dbo].[jag_AutorisationDesLivraisonsTransporteur]
@Annee INT, @PeriodeContingentement INT, @ContingentUsine BIT, @TransporteurID VARCHAR (15)
AS
SET NOCOUNT ON

IF NOT EXISTS (SELECT *
		FROM Contingentement_Producteur CP
			INNER JOIN Contingentement C ON C.[ID] = CP.[ContingentementID]
			INNER JOIN Contingentement_Demande CD ON CD.[ProducteurID] = CP.[ProducteurID] AND CD.[Annee] = C.[Annee]
		WHERE ((C.Annee = @Annee) AND (C.PeriodeContingentement = @PeriodeContingentement))
		AND (CD.TransporteurID = @TransporteurID)
		AND (C.ContingentUsine = @ContingentUsine)
		AND (CP.Volume_Accorde >0)
		AND (C.CalculAccepte = 1))
BEGIN
	RETURN
END


SELECT
F.[ID],
F.Nom,
F.AuSoinsDe,
F.Rue,
F.Ville,
UPPER(F.Code_Postal) AS [Code_Postal],
dbo.jag_Convert_Phone(F.Telephone) AS [Telephone],
dbo.jag_Convert_Phone(F.Telecopieur) AS [Telecopieur]
FROM Fournisseur F
WHERE F.[ID] = @TransporteurID

IF (@ContingentUsine = 1)
BEGIN
	SELECT
	E.[Description] AS [Essence],
	UM.[ID] AS [Unite],
	U.[Description] AS [Usine],
	CP.ProducteurID AS [ProducteurID],
	case when F.AuSoinsDe is null then F.Nom else F.Nom + ' ' + ltrim(rtrim(f.AuSoinsDe)) end AS[Nom],
	F.Rue AS[Rue],
	F.Ville AS[Ville],
	UPPER(F.Code_Postal) AS [Code_Postal],
	dbo.jag_Convert_Phone(F.Telephone) AS [Telephone],
	dbo.jag_Convert_Phone(F.Telecopieur) AS [Telecopieur],	
	CP.Volume_Accorde AS [Volume_Alloue]
	FROM Contingentement C
		INNER JOIN Contingentement_Producteur CP ON CP.[ContingentementID] = C.[ID]
		INNER JOIN Contingentement_Demande CD ON CD.[ProducteurID] = CP.[ProducteurID] AND CD.[Annee] = C.[Annee]
		INNER JOIN Fournisseur F ON F.[ID] = CP.[ProducteurID]
		INNER JOIN Essence E ON E.[ID] = C.EssenceID
		INNER JOIN UniteMesure UM ON UM.[ID] = C.UniteMesureID
		INNER JOIN Usine U ON U.[ID] = C.UsineID
	WHERE ((C.Annee = @Annee) AND (C.PeriodeContingentement = @PeriodeContingentement))
	AND (CD.TransporteurID = @TransporteurID)
	AND (C.ContingentUsine = @ContingentUsine)
	AND (CP.Volume_Accorde >0)
	AND (C.CalculAccepte = 1)
	order by F.Nom, E.[Description]
END
ELSE IF (@ContingentUsine = 0)
BEGIN
SELECT
	ER.[Description] AS [Regroupement],
	UM.[ID] AS [Unite],
	CP.ProducteurID AS [ProducteurID],
	case when F.AuSoinsDe is null then F.Nom else F.Nom + ' ' + ltrim(rtrim(f.AuSoinsDe)) end AS[Nom],
	F.Rue AS[Rue],
	F.Ville AS[Ville],
	UPPER(F.Code_Postal) AS [Code_Postal],
	dbo.jag_Convert_Phone(F.Telephone) AS [Telephone],
	dbo.jag_Convert_Phone(F.Telecopieur) AS [Telecopieur],	
	CP.Volume_Accorde AS [Volume_Alloue]
	FROM Contingentement C
		INNER JOIN Contingentement_Producteur CP ON CP.[ContingentementID] = C.[ID]
		INNER JOIN Contingentement_Demande CD ON CD.[ProducteurID] = CP.[ProducteurID] AND CD.[Annee] = C.[Annee]
		INNER JOIN Fournisseur F ON F.[ID] = CP.[ProducteurID]
		INNER JOIN EssenceRegroupement ER ON ER.[ID] = C.RegroupementID
		INNER JOIN UniteMesure UM ON UM.[ID] = C.UniteMesureID
	WHERE ((C.Annee = @Annee) AND (C.PeriodeContingentement = @PeriodeContingentement))
	AND (CD.TransporteurID = @TransporteurID)
	AND (C.ContingentUsine = @ContingentUsine)
	AND (CP.Volume_Accorde >0)
	AND (C.CalculAccepte = 1)
	order by F.Nom, ER.[Description]
END

SELECT [Value] AS [Message] FROM jag_SystemEx WHERE [Name] = 'Message_AutorisationDesLivraisons'



