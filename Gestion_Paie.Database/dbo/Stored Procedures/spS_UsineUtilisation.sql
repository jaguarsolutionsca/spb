CREATE PROCEDURE [dbo].[spS_UsineUtilisation]
@ID INT=Null, @ReturnXML BIT=0
AS
If @ReturnXML Is Null
	Set @ReturnXML = 0

If @ReturnXML = 0
	Begin
		Select

		 [UsineUtilisation_Records].[ID]
		,[UsineUtilisation_Records].[Description]
		,[UsineUtilisation_Records].[isPate]
		,[UsineUtilisation_Records].[Actif]

		From [fnUsineUtilisation](@ID) As [UsineUtilisation_Records]
	End

Else

	Begin
		Select

		 [UsineUtilisation_Records].[ID]
		,[UsineUtilisation_Records].[Description]
		,[UsineUtilisation_Records].[isPate]
		,[UsineUtilisation_Records].[Actif]

		From [fnUsineUtilisation](@ID) As [UsineUtilisation_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)
