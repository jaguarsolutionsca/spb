

CREATE PROCEDURE dbo.jag_Update_Contrat_Transporteur
	(
		@ContratID varchar(10) = Null,
		@UniteID varchar(6) = Null,
		@MunicipaliteID varchar(6) = Null,		
		@ZoneID VARCHAR(15) = Null,
		@Taux_transporteur real = Null,
		@Taux_producteur real = Null,
		@Actif bit = Null
	)

AS

SET NOCOUNT ON

if @Taux_transporteur is not Null
Begin
	update Contrat_Transporteur set Taux_transporteur = @Taux_transporteur
	where 
		((@ContratID is null) 		or (ContratID 		= @ContratID)) and
		((@UniteID is null) 		or (UniteID 		= @UniteID)) and
		((@MunicipaliteID is null) 	or (MunicipaliteID 	= @MunicipaliteID)) and
		((@ZoneID is null) 		or (ZoneID 		= @ZoneID))
End


if @Taux_producteur is not Null
Begin
	update Contrat_Transporteur set Taux_producteur = @Taux_producteur
	where 
		((@ContratID is null) 		or (ContratID 		= @ContratID)) and
		((@UniteID is null) 		or (UniteID 		= @UniteID)) and
		((@MunicipaliteID is null) 	or (MunicipaliteID 	= @MunicipaliteID)) and
		((@ZoneID is null) 		or (ZoneID 		= @ZoneID))
End


if @Actif is not Null
Begin
	update Contrat_Transporteur set Actif = @Actif
	where 
		((@ContratID is null) 		or (ContratID 		= @ContratID)) and
		((@UniteID is null) 		or (UniteID 		= @UniteID)) and
		((@MunicipaliteID is null) 	or (MunicipaliteID 	= @MunicipaliteID)) and
		((@ZoneID is null) 		or (ZoneID 		= @ZoneID))
End



