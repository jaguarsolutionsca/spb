

Create Procedure [spI_Compte]

-- Inserts a new record in [Compte] table
(
  @ID [int] -- for [Compte].[ID] column
, @Description [varchar](50) = Null  -- for [Compte].[Description] column
, @CategoryID [int] = Null  -- for [Compte].[CategoryID] column
, @isTaxe [bit] = Null  -- for [Compte].[isTaxe] column
, @Actif [bit] = Null  -- for [Compte].[Actif] column
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Insert Into [dbo].[Compte]
(
	  [ID]
	, [Description]
	, [CategoryID]
	, [isTaxe]
	, [Actif]
)

Values
(
	  @ID
	, @Description
	, @CategoryID
	, @isTaxe
	, @Actif
)

Set NoCount Off

Return(0)


