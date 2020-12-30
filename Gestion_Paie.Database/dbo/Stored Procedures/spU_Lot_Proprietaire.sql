

Create Procedure [spU_Lot_Proprietaire]

-- Update an existing record in [Lot_Proprietaire] table

(
  @ProprietaireID [varchar](15) -- for [Lot_Proprietaire].[ProprietaireID] column
, @DateDebut [datetime] -- for [Lot_Proprietaire].[DateDebut] column
, @DateFin [datetime] = Null -- for [Lot_Proprietaire].[DateFin] column
, @ConsiderNull_DateFin bit = 0
, @LotID [int] -- for [Lot_Proprietaire].[LotID] column
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

If @ConsiderNull_DateFin Is Null
	Set @ConsiderNull_DateFin = 0


Update [dbo].[Lot_Proprietaire]

Set
	 [DateFin] = Case @ConsiderNull_DateFin When 0 Then IsNull(@DateFin, [DateFin]) When 1 Then @DateFin End

Where
	     ([ProprietaireID] = @ProprietaireID)
	And ([DateDebut] = @DateDebut)
	And ([LotID] = @LotID)

Set NoCount Off

Return(0)


