

CREATE PROCEDURE dbo.jag_Rapport_GestionVolume_Detail
	(		
		@UsineDebut varchar(6) = NULL,
		@UsineFin varchar(6) = NULL,
		@ProducteurDebut varchar(15) = NULL,
		@ProducteurFin varchar(15) = NULL,
		@PeriodeDebut int = NULL,
		@AnneeDebut int = NULL,
		@PeriodeFin int = NULL,
		@AnneeFin int = NULL,
		@DateEntreeDebut smalldatetime = NULL,
		@DateEntreeFin smalldatetime = NULL
	)
AS

select 
GV.ID,
U.[Description] AS [Usine],
GV.DateLivraison,
GV.Periode,
GV.ProducteurID AS [ProducteurID],
F.[Nom] AS [Producteur],
D.EssenceID + ' - ' + E.[Description] AS [Essence],
GV.UniteMesureID,
SUM(D.VolumeNet) AS [Volume]
from GestionVolume_Detail D
	inner join gestionvolume GV ON GV.[ID] = D.GestionVolumeID
	inner join Usine U ON U.[ID] = GV.UsineID
	inner join Fournisseur F ON F.[ID] = GV.ProducteurID
	inner join Essence E ON E.[ID] = D.EssenceID
WHERE ((@PeriodeDebut is null and @AnneeDebut is null) or ( ((convert(char(4), GV.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,GV.[Periode]),2)))) >= ((convert(char(4), @AnneeDebut)) + (convert(char(2),RIGHT('00'+CONVERT(VARCHAR,@PeriodeDebut),2)))) ))
AND	((@PeriodeFin is null and @AnneeFin is null) or ( ((convert(char(4), GV.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,GV.[Periode]),2)))) <= ((convert(char(4), @AnneeFin)) + (convert(char(2),RIGHT('00'+CONVERT(VARCHAR,@PeriodeFin),2)))) ))	
AND ((@UsineDebut is null) or (GV.UsineID <= @UsineDebut))
AND ((@UsineFin is null) or (GV.UsineID >= @UsineFin))
AND ((@ProducteurDebut is null) or (@ProducteurDebut <= GV.ProducteurID))
AND ((@ProducteurFin is null) or (@ProducteurFin >= GV.ProducteurID))
AND ((@DateEntreeDebut is null) or (DATEDIFF(day, @DateEntreeDebut, GV.DateEntree) >= 0))
AND ((@DateEntreeFin is null) or (DATEDIFF(day, @DateEntreeFin, GV.DateEntree) <= 0))

GROUP BY GV.ID, U.[Description], GV.DateLivraison, GV.Periode, GV.ProducteurID, F.[Nom], D.EssenceID, E.[Description], GV.UniteMesureID
ORDER BY GV.ID, U.[Description], GV.DateLivraison, GV.Periode, GV.ProducteurID, F.[Nom], D.EssenceID, E.[Description], GV.UniteMesureID

