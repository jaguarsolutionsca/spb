

CREATE PROCEDURE [dbo].[jag_Rapport_GestionVolume_ParUsine]
	(		
		@Usine varchar(6) = NULL,
		@ProducteurDebut varchar(15) = NULL,
		@ProducteurFin varchar(15) = NULL,
		@PeriodeDebut int = NULL,
		@AnneeDebut int = NULL,
		@PeriodeFin int = NULL,
		@AnneeFin int = NULL
	)
AS

select 
U.[Description] AS [Usine],
GV.Periode,
GV.ProducteurID AS [ProducteurID],
MAX(F.[Nom]) AS [Producteur],
--D.EssenceID,
MAX(E.[Description]) AS [Essence],
GV.UniteMesureID,
SUM(D.VolumeNet) AS [Volume],
SUM(D.VolumeNet) * max(EU.Facteur_M3sol) as [M3Sol]
from GestionVolume_Detail D
	inner join gestionvolume GV ON GV.[ID] = D.GestionVolumeID
	inner join Usine U ON U.[ID] = GV.UsineID
	inner join Fournisseur F ON F.[ID] = GV.ProducteurID
	inner join Essence E ON E.[ID] = D.EssenceID
	inner join Essence_Unite EU ON EU.EssenceID = D.EssenceID AND EU.UniteID = GV.UniteMesureID
WHERE ((@PeriodeDebut is null and @AnneeDebut is null) or ( ((convert(char(4), GV.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,GV.[Periode]),2)))) >= ((convert(char(4), @AnneeDebut)) + (convert(char(2),RIGHT('00'+CONVERT(VARCHAR,@PeriodeDebut),2)))) ))
AND	((@PeriodeFin is null and @AnneeFin is null) or ( ((convert(char(4), GV.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,GV.[Periode]),2)))) <= ((convert(char(4), @AnneeFin)) + (convert(char(2),RIGHT('00'+CONVERT(VARCHAR,@PeriodeFin),2)))) ))	
AND ((@Usine is null) or (GV.UsineID = @Usine))
AND ((@ProducteurDebut is null) or (@ProducteurDebut <= GV.ProducteurID))
AND ((@ProducteurFin is null) or (@ProducteurFin >= GV.ProducteurID))

GROUP BY U.[Description], GV.Periode, GV.ProducteurID, F.[Nom], D.EssenceID, GV.UniteMesureID
ORDER BY U.[Description], GV.Periode, F.[Nom], D.EssenceID, GV.UniteMesureID

