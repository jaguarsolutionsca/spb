CREATE PROCEDURE [dbo].[jag_Get_Unite_From_Contrat_EssenceUnite]
@Annee INT=NULL, @Usine VARCHAR (6)=NULL, @Essence VARCHAR (6)=NULL, @Code CHAR (4)=NULL
AS
SELECT

distinct

UniteMesure.ID AS [ID],
UniteMesure.[Description] AS [Description],
(CASE WHEN Contrat_EssenceUnite.Actif = 0 OR UniteMesure.Actif = 0 THEN CONVERT(BIT, 0) ELSE CONVERT(BIT, 1) END) AS [Actif]
FROM Contrat
	INNER JOIN Contrat_EssenceUnite ON Contrat.ID = Contrat_EssenceUnite.ContratID
		inner join UniteMesure on Contrat_EssenceUnite.[UniteID] = UniteMesure.ID
	
WHERE 
		((@Annee IS NULL) OR (Contrat.Annee = @Annee))
	AND ((@Usine IS NULL) OR (Contrat.UsineID = @Usine))		
	AND ((@Essence IS NULL) OR (Contrat_EssenceUnite.EssenceID = @Essence))		
	AND ((@Code IS NULL) OR (Contrat_EssenceUnite.Code = @Code))		

Order by UniteMesure.ID


