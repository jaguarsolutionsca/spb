

Create Procedure [spI_Lot_SuperficieBoisee]

-- Inserts a new record in [Lot_SuperficieBoisee] table
(
  @Annee [datetime] -- for [Lot_SuperficieBoisee].[Annee] column
, @Superficie_boisee [real] = Null  -- for [Lot_SuperficieBoisee].[Superficie_boisee] column
, @LotID [int] -- for [Lot_SuperficieBoisee].[LotID] column
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Insert Into [dbo].[Lot_SuperficieBoisee]
(
	  [Annee]
	, [Superficie_boisee]
	, [LotID]
)

Values
(
	  @Annee
	, @Superficie_boisee
	, @LotID
)

Set NoCount Off

Return(0)


