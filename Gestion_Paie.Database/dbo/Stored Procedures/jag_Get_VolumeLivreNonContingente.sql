

CREATE PROCEDURE dbo.jag_Get_VolumeLivreNonContingente
	(
		@ContingentementID INT,
		@UniteID varchar(6) = NULL,
		@Volume float OUTPUT
	)
AS
	
INSERT INTO Contingentement_Unite (ContingentementID, UniteID, Facteur)
SELECT
ID,
UniteMesureID,
1
FROM Contingentement C
WHERE C.UniteMesureID NOT IN (SELECT UniteID FROM Contingentement_Unite CU WHERE CU.ContingentementID = C.[ID])

INSERT INTO Contingentement_Unite (ContingentementID, UniteID, Facteur)
SELECT DISTINCT
ContingentementID,
UniteMesureID,
0
FROM Livraison_Detail LD
WHERE ContingentementID IS NOT NULL
AND UniteMesureID NOT IN (SELECT UniteID FROM Contingentement_Unite CU WHERE CU.ContingentementID = LD.ContingentementID)

SELECT
@Volume = SUM(VolumeContingente * CU.Facteur)
FROM Livraison_Detail LD
	INNER JOIN Livraison L ON L.[ID] = LD.LivraisonID
	INNER JOIN Contingentement_Unite CU ON CU.ContingentementID = LD.ContingentementID AND CU.UniteID = LD.UniteMesureID
WHERE (LD.ContingentementID = @ContingentementID)
AND ((@UniteID IS NULL) OR (L.UniteMesureID = @UniteID))
AND (LD.ProducteurID not in (SELECT ProducteurID FROM Contingentement_Producteur CP WHERE CP.ContingentementID = @ContingentementID))



