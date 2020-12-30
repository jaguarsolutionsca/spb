

Create Procedure [spI_Pays]

-- Inserts a new record in [Pays] table
(
  @ID [varchar](2) -- for [Pays].[ID] column
, @Nom [varchar](50) = Null  -- for [Pays].[Nom] column
, @CodePostal_InputMask [varchar](50) = Null  -- for [Pays].[CodePostal_InputMask] column
, @Actif [bit] = Null  -- for [Pays].[Actif] column
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Insert Into [dbo].[Pays]
(
	  [ID]
	, [Nom]
	, [CodePostal_InputMask]
	, [Actif]
)

Values
(
	  @ID
	, @Nom
	, @CodePostal_InputMask
	, @Actif
)

Set NoCount Off

Return(0)


