CREATE PROCEDURE [dbo].[jag_Update_Contrat_Transporteur_Pourcent]
@ContratID VARCHAR (10)=Null, @Taux_augmentation_transporteur REAL=Null
AS
SET NOCOUNT ON

if @Taux_augmentation_transporteur is not Null and @ContratID is not null
Begin
	update Contrat_Transporteur set Taux_transporteur = round(Taux_transporteur + Taux_transporteur * @Taux_augmentation_transporteur /100,2)
	where 
		((@ContratID is null) 		or (ContratID 		= @ContratID)) and
		Taux_transporteur > 0 and
		Actif = 1
End


