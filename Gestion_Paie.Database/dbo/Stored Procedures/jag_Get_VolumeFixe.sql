

CREATE PROCEDURE [dbo].[jag_Get_VolumeFixe]
(
	@ContingentementID int,
	@ProducteurID varchar(15) = null,
	@SuperficieContingentee real = null,
	@DateContingent datetime = Null,
	@LastLivraison datetime = null
)
AS

Begin
						
	Declare @Volume_Fixe real
	Declare @NombreMois int
	
	Select top 1 
	@Volume_Fixe = Volume_Fixe,
	@NombreMois = NombreMois
	From Contingentement_VolumeFixe
	Where ContingentementID = @ContingentementID
	and Superficie_Min <=@SuperficieContingentee
	order by Superficie_Min desc
	
	if(@Volume_Fixe is null)
	begin
		set @Volume_Fixe = 0
	end
	
	if(@LastLivraison is not null)
	Begin
		if(@NombreMois >= DateDiff(Month, @LastLivraison, @DateContingent ))
		begin
			set @Volume_Fixe = 0
		end
	end	
	
	Select @Volume_Fixe as VolumeFixe
	
End
