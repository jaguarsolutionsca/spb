

CREATE PROCEDURE dbo.jag_Get_Essence_From_Contrat_EssenceUnite
	(
		@Annee int = NULL,
		@Usine varchar(6) = NULL,
		@UniteMesureID VARCHAR(6) = NULL
	)
AS

SELECT

distinct

Essence.ID AS [ID],
LTRIM(RTRIM(Code)) AS [Code],
Essence.[Description] AS [Description],
(CASE WHEN Contrat_EssenceUnite.Actif = 0 OR Essence.Actif = 0 THEN CONVERT(BIT, 0) ELSE CONVERT(BIT, 1) END) AS [Actif]
FROM Contrat
	INNER JOIN Contrat_EssenceUnite ON Contrat.ID = Contrat_EssenceUnite.ContratID
		inner join Essence on Contrat_EssenceUnite.[EssenceID] = Essence.ID
	
WHERE 
		((@Annee IS NULL) OR (Contrat.Annee = @Annee))
	AND ((@Usine IS NULL) OR (Contrat.UsineID = @Usine))		
	AND ((@UniteMesureID IS NULL) OR (Contrat_EssenceUnite.UniteID = @UniteMesureID))









