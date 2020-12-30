CREATE PROCEDURE [dbo].[spS_EssenceRegroupement]
@ID INT=Null, @ReturnXML BIT=0
AS
If @ReturnXML Is Null
	Set @ReturnXML = 0

If @ReturnXML = 0
	Begin
		Select

		 [EssenceRegroupement_Records].[ID]
		,[EssenceRegroupement_Records].[Description]
		,[EssenceRegroupement_Records].[Actif]
		,[EssenceRegroupement_Records].[Ordre]

		From [fnEssenceRegroupement](@ID) As [EssenceRegroupement_Records]
	End

Else

	Begin
		Select

		 [EssenceRegroupement_Records].[ID]
		,[EssenceRegroupement_Records].[Description]
		,[EssenceRegroupement_Records].[Actif]
		,[EssenceRegroupement_Records].[Ordre]

		From [fnEssenceRegroupement](@ID) As [EssenceRegroupement_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)


