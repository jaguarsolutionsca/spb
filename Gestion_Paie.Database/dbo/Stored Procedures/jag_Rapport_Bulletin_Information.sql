CREATE PROCEDURE [dbo].[jag_Rapport_Bulletin_Information]
@Journal BIT=Null, @Actif BIT=Null
AS
SET NOCOUNT ON
Begin


	select 
	F.ID,
	F.Nom,
	case when F.AuSoinsDe is null then '' else F.AuSoinsDe end AuSoinsDe,
	case when F.Rep_Nom is null then '' else F.Rep_Nom end Representant,
	case when F.Rep2_Nom is null then '' else F.Rep2_Nom end Representant2,
	F.Rue,
	F.Ville,
	case when F.Code_Postal is null then '' else F.Code_Postal end,
	F.PaysID,
	case when F.[Telephone] is null then '' else dbo.jag_Convert_Phone(F.[Telephone]) end As Telephone,
	case when F.No_TPS is null then '' else F.No_TPS end No_TPS,
	case when F.No_TVQ is null then '' else F.No_TVQ end No_TVQ,
	case when F.No_membre is null then '' else F.No_membre end No_Membre,
	case when F.Resident is null then '' else F.Resident end Resident,
	case when F.No_membre is null then 'Non-Membre' else 'Membre' end Membre
	

	from fournisseur f
	where 
	    ((@Actif	IS NULL) OR (F.[Actif] = @Actif))
	And ((@Journal	IS NULL) OR (F.Journal = @Journal))
	
	
end
