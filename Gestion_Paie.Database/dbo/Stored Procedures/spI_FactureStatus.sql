

Create Procedure [spI_FactureStatus]

-- Inserts a new record in [FactureStatus] table
(
  @ID [varchar](15) -- for [FactureStatus].[ID] column
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Insert Into [dbo].[FactureStatus]
(
	  [ID]
)

Values
(
	  @ID
)

Set NoCount Off

Return(0)


