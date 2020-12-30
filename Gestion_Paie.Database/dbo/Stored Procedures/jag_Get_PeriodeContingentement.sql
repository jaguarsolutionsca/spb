

CREATE PROCEDURE dbo.jag_Get_PeriodeContingentement
(
	 @Annee INT
)
AS

SET NOCOUNT ON

SELECT DISTINCT
P.PeriodeContingentement
FROM Periode P
WHERE P.Annee = @Annee
ORDER BY P.PeriodeContingentement








