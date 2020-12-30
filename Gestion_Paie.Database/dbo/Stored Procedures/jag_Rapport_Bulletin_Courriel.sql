

CREATE PROCEDURE [dbo].[jag_Rapport_Bulletin_Courriel]
AS

SET NOCOUNT ON
Begin

	select 

	F.Email,
    max(F.Nom) Nom	

	from fournisseur f
	where 
	  --   (F.[Actif] = 1)
	 (F.Journal = 0)
	 and (F.Email is not null)
	 
	 group by f.Email
	
end
