




CREATE Procedure [jag_IsUsed_Secteur]
(
 @ID [varchar](2) = Null
,@MuniID [varchar](6) = Null
,@isUsed [bit] out
)

As

declare @NumUsed int
select @NumUsed = 0
select @NumUsed = (select (@NumUsed + count(*)) from Lot where MunicipaliteID=@MuniID and Secteur=@ID)

if @NumUsed > 0
Begin
	select @isUsed = 1
End
else
Begin
	select @isUsed = 0
End

Return




