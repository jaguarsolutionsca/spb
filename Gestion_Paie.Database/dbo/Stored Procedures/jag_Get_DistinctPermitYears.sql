

CREATE PROCEDURE dbo.jag_Get_DistinctPermitYears
AS

SELECT
distinct Annee as [Year]
FROM Permit
ORDER BY Annee

