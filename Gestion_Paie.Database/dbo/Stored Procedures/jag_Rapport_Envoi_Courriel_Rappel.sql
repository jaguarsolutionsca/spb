
CREATE PROCEDURE [dbo].[jag_Rapport_Envoi_Courriel_Rappel]
AS

SET NOCOUNT ON
Begin

	select 

    max(F.Nom) Nom,
	F.Email,
	max(F.Ville) Ville,
	max(F.Resident) Resident

	from fournisseur f
	where 
	 F.[Actif] = 1
	 and (F.Email is not null)
	 
	 group by f.Email
	
end