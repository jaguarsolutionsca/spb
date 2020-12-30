

Create Procedure [spI_Essence]

-- Inserts a new record in [Essence] table
(
  @ID [varchar](6) -- for [Essence].[ID] column
, @Description [varchar](25) = Null  -- for [Essence].[Description] column
, @RegroupementID [int] = Null  -- for [Essence].[RegroupementID] column
, @ContingentID [int] = Null  -- for [Essence].[ContingentID] column
, @RepartitionID [int] = Null  -- for [Essence].[RepartitionID] column
, @Actif [bit] = Null  -- for [Essence].[Actif] column
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Insert Into [dbo].[Essence]
(
	  [ID]
	, [Description]
	, [RegroupementID]
	, [ContingentID]
	, [RepartitionID]
	, [Actif]
)

Values
(
	  @ID
	, @Description
	, @RegroupementID
	, @ContingentID
	, @RepartitionID
	, @Actif
)

Set NoCount Off

Return(0)


