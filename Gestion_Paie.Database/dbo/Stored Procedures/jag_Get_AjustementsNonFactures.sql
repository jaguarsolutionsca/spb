

CREATE PROCEDURE [dbo].[jag_Get_AjustementsNonFactures]
	(
		@UsineID VARCHAR(6) = Null,
		@AjustementID INT = Null
	)
AS

SET NOCOUNT ON

exec jag_Clear_FactureEnAttente

DECLARE @Ajustements TABLE
(
	_ID int,
	Montant_Producteur float,
	Montant_Transporteur float,
	Montant_TransporteurEssence float,
	Montant_Usine float	
)

INSERT INTO @Ajustements (_ID)
SELECT [ID] FROM dbo.jag_GetAjustementsNonFactures (@UsineID, @AjustementID)

UPDATE @Ajustements SET

Montant_Producteur = (
	SELECT
	ROUND(SUM(ACP.Montant),2)
	FROM Ajustement A
		INNER JOIN AjustementCalcule_Producteur ACP ON ACP.[AjustementID] = A.[ID]
	WHERE A.[ID] in (SELECT _ID FROM @Ajustements)
	AND AjustementID = _ID
	),

Montant_Transporteur = (
	SELECT
	ROUND(SUM(ACT.Montant),2)
	FROM Ajustement A
		INNER JOIN AjustementCalcule_Transporteur ACT ON ACT.[AjustementID] = A.[ID]
	WHERE A.[ID] in (SELECT _ID FROM @Ajustements)
	AND AjustementID = _ID
	),

Montant_TransporteurEssence = (
	SELECT
	ROUND(SUM(ACT.Montant),2)
	FROM Ajustement A
		INNER JOIN AjustementCalcule_TransporteurEssence ACT ON ACT.[AjustementID] = A.[ID]
	WHERE A.[ID] in (SELECT _ID FROM @Ajustements)
	AND AjustementID = _ID
	),

Montant_Usine = (
	SELECT
	ROUND(SUM(ACU.Montant),2)
	FROM Ajustement A
		INNER JOIN AjustementCalcule_Usine ACU ON ACU.[AjustementID] = A.[ID]
	WHERE A.[ID] in (SELECT _ID FROM @Ajustements)
	AND AjustementID = _ID
	)

UPDATE @Ajustements SET
Montant_Producteur = 0
WHERE Montant_Producteur IS NULL

UPDATE @Ajustements SET
Montant_Transporteur = 0
WHERE Montant_Transporteur IS NULL

UPDATE @Ajustements SET
Montant_TransporteurEssence = 0
WHERE Montant_TransporteurEssence IS NULL

UPDATE @Ajustements SET
Montant_Usine = 0
WHERE Montant_Usine IS NULL

SELECT
A.[_ID] AS [ID],
C.UsineID,
CONVERT(VARCHAR,A2.DateAjustement,103) AS [Date],
A.Montant_Usine,
A.Montant_Producteur,
A.Montant_Transporteur + A.Montant_TransporteurEssence [Montant_Transporteur]
FROM @Ajustements A
	INNER JOIN Ajustement A2 ON A2.[ID] = A.[_ID]
	INNER JOIN Contrat C ON C.[ID] = A2.ContratID
ORDER BY C.UsineID, A.[_ID]








