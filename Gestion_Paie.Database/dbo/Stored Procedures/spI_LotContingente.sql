

Create Procedure [spI_LotContingente]

-- Inserts a new record in [LotContingente] table
(
  @LotID [int] -- for [LotContingente].[LotID] column
, @Annee [int] -- for [LotContingente].[Annee] column
, @SuperficieContingentee [real] = Null  -- for [LotContingente].[SuperficieContingentee] column
, @Override [bit] = Null  -- for [LotContingente].[Override] column
, @FournisseurID [varchar](15) -- for [LotContingente].[FournisseurID] column
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Insert Into [dbo].[LotContingente]
(
	  [LotID]
	, [Annee]
	, [SuperficieContingentee]
	, [Override]
	, [FournisseurID]
)

Values
(
	  @LotID
	, @Annee
	, @SuperficieContingentee
	, @Override
	, @FournisseurID
)

Set NoCount Off

Return(0)


