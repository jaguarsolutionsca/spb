

CREATE PROCEDURE dbo.jag_Get_NoMembreProducteur
	(
		@Actif bit = Null
	)
AS

Select
distinct 

Fournisseur.No_membre as ID,
Fournisseur.No_membre as Display

From Fournisseur

WHERE 
		((@Actif is Null) or(Fournisseur.[Actif] = @Actif))
	AND (Fournisseur.IsProducteur = 1)
	AND Fournisseur.[No_membre] IS NOT NULL

ORDER BY Fournisseur.No_membre









