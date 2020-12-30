




CREATE Procedure [jag_Municipalite_Zone_Exists]
(
 @ID [varchar](2) = Null
,@MuniID [varchar](6) = Null
,@Exists [bit] out
)

As

declare @NumUsed int
select @NumUsed = 0
select @NumUsed = (select (@NumUsed + count(*)) from Municipalite_Zone	where MunicipaliteID=@MuniID and [ID] = @ID)

if @NumUsed > 0
Begin
	select @Exists = 1
End
else
Begin
	select @Exists = 0
End

Return




