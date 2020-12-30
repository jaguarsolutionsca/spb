

CREATE PROCEDURE dbo.jag_Rapport_Contingentement_ParUsine
	(		
		@ProducteurDebut VARCHAR(15),
		@ProducteurFin VARCHAR(15),
		@Annee INT,
		@PeriodeContingentement INT
	)
AS

SET NOCOUNT ON

declare @Producteurs table
(
	_ProducteurID varchar(15),
	_ContingentementID int,
	UsineID varchar(6),
	EssenceID varchar(6),
	Code char(4),
	Volume_Demande float,
	Volume_Accorde float,
	Volume_Livre float,
	Volume_Restant float,
	Date_Modification smalldatetime
)

INSERT INTO @Producteurs (_ProducteurID, _ContingentementID)
SELECT DISTINCT 
ProducteurID,
LD.[ContingentementID]
FROM Livraison_Detail LD
	INNER JOIN Livraison L ON L.[ID] = LD.LivraisonID AND L.Facture=1
	INNER JOIN Contingentement C ON C.[ID] = LD.ContingentementID
WHERE LD.ContingentementID IS NOT NULL
AND C.ContingentUsine = 1
AND ((@PeriodeContingentement	IS NULL) OR (@PeriodeContingentement = C.PeriodeContingentement))
AND ((@Annee IS NULL) OR (@Annee = C.Annee))

INSERT INTO @Producteurs (_ProducteurID, _ContingentementID)
SELECT
CP.ProducteurID,
C.[ID]
FROM Contingentement C
	INNER JOIN Contingentement_Producteur CP ON CP.ContingentementID = C.[ID]
WHERE C.ContingentUsine = 1
AND CP.ProducteurID not in (SELECT _ProducteurID FROM @Producteurs WHERE _ContingentementID = C.[ID])
AND C.[ID] not in (SELECT _ContingentementID FROM @Producteurs WHERE _ProducteurID = CP.ProducteurID)
AND ((@PeriodeContingentement	IS NULL) OR (@PeriodeContingentement = C.PeriodeContingentement))
AND ((@Annee IS NULL) OR (@Annee = C.Annee))

UPDATE @Producteurs SET UsineID = (SELECT UsineID FROM Contingentement C WHERE C.[ID] = _ContingentementID)
UPDATE @Producteurs SET EssenceID = (SELECT EssenceID FROM Contingentement C WHERE C.[ID] = _ContingentementID)
UPDATE @Producteurs SET Code = (SELECT Code FROM Contingentement C WHERE C.[ID] = _ContingentementID)

UPDATE @Producteurs SET 
Volume_Demande = (
SELECT CP.Volume_Demande FROM Contingentement_Producteur CP WHERE CP.ContingentementID = _ContingentementID AND CP.ProducteurID = _ProducteurID
),
Volume_Accorde = (
SELECT CP.Volume_Accorde FROM Contingentement_Producteur CP WHERE CP.ContingentementID = _ContingentementID AND CP.ProducteurID = _ProducteurID
),
Volume_Livre = (
SELECT dbo.jag_GetVolumeLivrePourContingentementParProducteur(_ContingentementID, _ProducteurID)
),
Date_Modification = (
SELECT CP.Date_Modification FROM Contingentement_Producteur CP WHERE CP.ContingentementID = _ContingentementID AND CP.ProducteurID = _ProducteurID
)

UPDATE @Producteurs SET Volume_Demande = 0 WHERE Volume_Demande IS NULL
UPDATE @Producteurs SET Volume_Accorde = 0 WHERE Volume_Accorde IS NULL
UPDATE @Producteurs SET Volume_Livre = 0 WHERE Volume_Livre IS NULL

UPDATE @Producteurs SET Volume_Restant = Volume_Accorde - Volume_Livre
UPDATE @Producteurs SET Volume_Restant = 0 WHERE Volume_Restant IS NULL


SELECT
_ProducteurID AS [ProducteurID],
F.[Nom] AS [Producteur],
U.[Description] AS [Usine],
E.[Description] + ' ' + LTRIM(RTRIM(Code)) AS [Essence],
Volume_Demande,
Volume_Accorde,
Volume_Livre,
Volume_Restant,
Date_Modification,
F.[Rep_Nom] AS Representant
FROM @Producteurs
	INNER JOIN Fournisseur F ON F.[ID] = _ProducteurID
	INNER JOIN Usine U ON U.[ID] = UsineID
	INNER JOIN Essence E ON E.[ID] = EssenceID

where 
		(@ProducteurDebut <= _ProducteurID) and (@ProducteurFin >= _ProducteurID)

ORDER BY F.[Nom]



