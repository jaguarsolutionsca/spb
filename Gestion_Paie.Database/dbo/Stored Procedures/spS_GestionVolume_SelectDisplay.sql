

Create Procedure [spS_GestionVolume_SelectDisplay]

-- Retrieve specific records from the [GestionVolume] table depending on the input parameters you supply.

(
 @ID [int] = Null -- for [GestionVolume].[ID] column
,@UsineID [varchar](6) = Null -- for [GestionVolume].[UsineID] column
,@UniteMesureID [varchar](6) = Null -- for [GestionVolume].[UniteMesureID] column
,@ProducteurID [varchar](15) = Null -- for [GestionVolume].[ProducteurID] column
,@LotID [int] = Null -- for [GestionVolume].[LotID] column
,@ReturnXML [bit] = 0 -- Indicates if we want to get back XML content instead of normal resultset (@ReturnXML = 1 to get XML back)
)

-- Returns the number of records found

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


If @ReturnXML Is Null
	Set @ReturnXML = 0

If @ReturnXML = 0
	Begin
		Select

		 [GestionVolume_Records].[ID]
		,[GestionVolume_Records].[DateLivraison]
		,[GestionVolume_Records].[UsineID]
		,[GestionVolume_Records].[UsineID_Display]
		,[GestionVolume_Records].[UniteMesureID]
		,[GestionVolume_Records].[UniteMesureID_Display]
		,[GestionVolume_Records].[ProducteurID]
		,[GestionVolume_Records].[ProducteurID_Display]
		,[GestionVolume_Records].[Annee]
		,[GestionVolume_Records].[Periode]
		,[GestionVolume_Records].[LotID]
		,[GestionVolume_Records].[LotID_Display]
		,[GestionVolume_Records].[DateEntree]

		From [fnGestionVolume_SelectDisplay](@ID, @UsineID, @UniteMesureID, @ProducteurID, @LotID) As [GestionVolume_Records]
	End

Else

	Begin
		Select

		 [GestionVolume_Records].[ID]
		,[GestionVolume_Records].[DateLivraison]
		,[GestionVolume_Records].[UsineID]
		,[GestionVolume_Records].[UsineID_Display]
		,[GestionVolume_Records].[UniteMesureID]
		,[GestionVolume_Records].[UniteMesureID_Display]
		,[GestionVolume_Records].[ProducteurID]
		,[GestionVolume_Records].[ProducteurID_Display]
		,[GestionVolume_Records].[Annee]
		,[GestionVolume_Records].[Periode]
		,[GestionVolume_Records].[LotID]
		,[GestionVolume_Records].[LotID_Display]
		,[GestionVolume_Records].[DateEntree]

		From [fnGestionVolume_SelectDisplay](@ID, @UsineID, @UniteMesureID, @ProducteurID, @LotID) As [GestionVolume_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)


