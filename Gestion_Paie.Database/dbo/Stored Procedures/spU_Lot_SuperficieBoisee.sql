

Create Procedure [spU_Lot_SuperficieBoisee]

-- Update an existing record in [Lot_SuperficieBoisee] table

(
  @Annee [datetime] -- for [Lot_SuperficieBoisee].[Annee] column
, @Superficie_boisee [real] = Null -- for [Lot_SuperficieBoisee].[Superficie_boisee] column
, @ConsiderNull_Superficie_boisee bit = 0
, @LotID [int] -- for [Lot_SuperficieBoisee].[LotID] column
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

If @ConsiderNull_Superficie_boisee Is Null
	Set @ConsiderNull_Superficie_boisee = 0


Update [dbo].[Lot_SuperficieBoisee]

Set
	 [Superficie_boisee] = Case @ConsiderNull_Superficie_boisee When 0 Then IsNull(@Superficie_boisee, [Superficie_boisee]) When 1 Then @Superficie_boisee End

Where
	     ([Annee] = @Annee)
	And ([LotID] = @LotID)

Set NoCount Off

Return(0)


