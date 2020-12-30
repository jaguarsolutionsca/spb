

CREATE PROCEDURE dbo.jag_Get_IndexationsNonFactures
	(
		@UsineID VARCHAR(6) = Null,
		@IndexationID INT = NULL	
	)
AS

SET NOCOUNT ON

exec jag_Clear_FactureEnAttente

DECLARE @Indexations TABLE
(
	[_ID] int,
	IndexationTransporteur bit,
	TypeIndexation CHAR(1),
	[Date] SMALLDATETIME,
	UsineID VARCHAR(6),
	Montant FLOAT
)

INSERT INTO @Indexations ([_ID])
SELECT [ID] FROM dbo.jag_GetIndexationsNonFactures (@UsineID, @IndexationID)

UPDATE @Indexations SET
IndexationTransporteur = (SELECT IndexationTransporteur FROM Indexation I WHERE I.[ID] = [_ID]),
TypeIndexation = (SELECT TypeIndexation FROM Indexation I WHERE I.[ID] = [_ID]),
[Date] = (SELECT [DateIndexation] FROM Indexation I WHERE I.[ID] = [_ID]),
UsineID = (SELECT C.UsineID FROM Indexation I INNER JOIN Contrat C ON C.[ID] = ContratID WHERE I.[ID] = [_ID])

UPDATE @Indexations SET
Montant = (
	SELECT 
	SUM(ICT.Montant)
	FROM Indexation I
		LEFT OUTER JOIN Indexation_Municipalite IM ON IM.[IndexationID] = I.[ID]
		LEFT OUTER JOIN IndexationCalcule_Transporteur ICT ON ICT.[IndexationDetailID] = IM.[ID]
	WHERE I.[ID] = [_ID]
	)
WHERE TypeIndexation = 'M'
AND IndexationTransporteur = 1

UPDATE @Indexations SET
Montant = (
	SELECT 
	SUM(ICP.Montant)
	FROM Indexation I
		LEFT OUTER JOIN Indexation_EssenceUnite IM ON IM.[IndexationID] = I.[ID]
		LEFT OUTER JOIN IndexationCalcule_Producteur ICP ON ICP.[IndexationDetailID] = IM.[ID]
	WHERE I.[ID] = [_ID]
	)
WHERE TypeIndexation = 'M'
AND IndexationTransporteur = 0

UPDATE @Indexations SET
Montant = (
	SELECT 
	SUM(ICT.Montant)
	FROM Indexation I
		LEFT OUTER JOIN IndexationCalcule_Transporteur ICT ON ICT.[IndexationID] = I.[ID]
	WHERE I.[ID] = [_ID]
	)
WHERE TypeIndexation = 'P'
AND IndexationTransporteur = 1

UPDATE @Indexations SET
Montant = (
	SELECT 
	SUM(ICP.Montant)
	FROM Indexation I
		LEFT OUTER JOIN IndexationCalcule_Producteur ICP ON ICP.[IndexationID] = I.[ID]
	WHERE I.[ID] = [_ID]
	)
WHERE TypeIndexation = 'P'
AND IndexationTransporteur = 0

UPDATE @Indexations SET Montant = 0 WHERE Montant IS NULL

/*SELECT
I.[ID] AS [ID],
MAX(C.UsineID) AS [UsineID],
MAX(CONVERT(VARCHAR,I.DateIndexation,103)) AS [Date],
(CASE WHEN I.TypeIndexation = 'P' THEN SUM(IC.Montant) WHEN I.TypeIndexation = 'M' THEN SUM(ICD.Montant) END) AS [Montant]
FROM Indexation I
	LEFT OUTER JOIN Indexation_Detail ON Indexation_Detail.[IndexationID] = I.[ID]
	INNER JOIN Contrat C ON C.[ID] = I.ContratID
	LEFT OUTER JOIN IndexationCalcule IC ON IC.[IndexationID] = I.[ID]
	LEFT OUTER JOIN IndexationCalcule ICD ON ICD.[IndexationDetailID] = Indexation_Detail.[ID]
WHERE I.[ID] IN (SELECT [_ID] FROM @Indexations)
GROUP BY I.[ID], I.TypeIndexation
ORDER BY I.[ID]*/

SELECT
I.[_ID] AS [ID],
(I.UsineID) AS [UsineID],
(CONVERT(VARCHAR,I.Date,103)) AS [Date],
(CASE WHEN IndexationTransporteur = 1 THEN 'Transporteurs' ELSE 'Producteurs' END) AS [IndexationTransporteur],
Montant AS [Montant]
FROM @Indexations I
ORDER BY I.[_ID]








