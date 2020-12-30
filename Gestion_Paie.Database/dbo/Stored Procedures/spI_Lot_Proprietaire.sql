

Create Procedure [spI_Lot_Proprietaire]

-- Inserts a new record in [Lot_Proprietaire] table
(
  @ProprietaireID [varchar](15) -- for [Lot_Proprietaire].[ProprietaireID] column
, @DateDebut [datetime] -- for [Lot_Proprietaire].[DateDebut] column
, @DateFin [datetime] = Null  -- for [Lot_Proprietaire].[DateFin] column
, @LotID [int] -- for [Lot_Proprietaire].[LotID] column
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Insert Into [dbo].[Lot_Proprietaire]
(
	  [ProprietaireID]
	, [DateDebut]
	, [DateFin]
	, [LotID]
)

Values
(
	  @ProprietaireID
	, @DateDebut
	, @DateFin
	, @LotID
)

Set NoCount Off

Return(0)


