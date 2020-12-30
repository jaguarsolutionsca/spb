

Create Procedure [spI_InstitutionBanquaire]

-- Inserts a new record in [InstitutionBanquaire] table
(
  @ID [varchar](3) -- for [InstitutionBanquaire].[ID] column
, @Description [varchar](50) = Null  -- for [InstitutionBanquaire].[Description] column
, @Actif [bit] = Null  -- for [InstitutionBanquaire].[Actif] column
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Insert Into [dbo].[InstitutionBanquaire]
(
	  [ID]
	, [Description]
	, [Actif]
)

Values
(
	  @ID
	, @Description
	, @Actif
)

Set NoCount Off

Return(0)


