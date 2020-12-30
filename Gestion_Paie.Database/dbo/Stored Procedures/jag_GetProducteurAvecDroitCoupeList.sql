

CREATE PROCEDURE dbo.jag_GetProducteurAvecDroitCoupeList
	(
		@ProducteurDebut VARCHAR(15),
		@ProducteurFin VARCHAR(15)
	)
AS

SET NOCOUNT ON

DECLARE @Date SMALLDATETIME
SET @Date = GetDate()

SELECT
[ID]
FROM Fournisseur
WHERE (([ID] >= @ProducteurDebut) AND ([ID] <= @ProducteurFin))
AND dbo.jag_GetCountDroitCoupeLot (Fournisseur.[ID], @Date) > 0
AND Fournisseur.Actif = 1








