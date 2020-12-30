

Create Procedure [spU_LotContingente]

-- Update an existing record in [LotContingente] table

(
  @LotID [int] -- for [LotContingente].[LotID] column
, @Annee [int] -- for [LotContingente].[Annee] column
, @SuperficieContingentee [real] -- for [LotContingente].[SuperficieContingentee] column
, @ConsiderNull_SuperficieContingentee bit = 0
, @Override [bit] -- for [LotContingente].[Override] column
, @ConsiderNull_Override bit = 0
, @FournisseurID [varchar](15) -- for [LotContingente].[FournisseurID] column
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

If @ConsiderNull_SuperficieContingentee Is Null
	Set @ConsiderNull_SuperficieContingentee = 0

If @ConsiderNull_Override Is Null
	Set @ConsiderNull_Override = 0


Update [dbo].[LotContingente]

Set
	 [SuperficieContingentee] = Case @ConsiderNull_SuperficieContingentee When 0 Then IsNull(@SuperficieContingentee, [SuperficieContingentee]) When 1 Then @SuperficieContingentee End
	,[Override] = Case @ConsiderNull_Override When 0 Then IsNull(@Override, [Override]) When 1 Then @Override End

Where
	     ([LotID] = @LotID)
	And ([Annee] = @Annee)
	And ([FournisseurID] = @FournisseurID)

Set NoCount Off

Return(0)


