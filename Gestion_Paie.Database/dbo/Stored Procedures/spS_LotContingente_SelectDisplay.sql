

Create Procedure [spS_LotContingente_SelectDisplay]

-- Retrieve specific records from the [LotContingente] table depending on the input parameters you supply.

(
 @LotID [int] = Null -- for [LotContingente].[LotID] column
,@Annee [int] = Null -- for [LotContingente].[Annee] column
,@FournisseurID [varchar](15) = Null -- for [LotContingente].[FournisseurID] column
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

		 [LotContingente_Records].[LotID]
		,[LotContingente_Records].[LotID_Display]
		,[LotContingente_Records].[Annee]
		,[LotContingente_Records].[SuperficieContingentee]
		,[LotContingente_Records].[Override]
		,[LotContingente_Records].[FournisseurID]
		,[LotContingente_Records].[FournisseurID_Display]

		From [fnLotContingente_SelectDisplay](@LotID, @Annee, @FournisseurID) As [LotContingente_Records]
	End

Else

	Begin
		Select

		 [LotContingente_Records].[LotID]
		,[LotContingente_Records].[LotID_Display]
		,[LotContingente_Records].[Annee]
		,[LotContingente_Records].[SuperficieContingentee]
		,[LotContingente_Records].[Override]
		,[LotContingente_Records].[FournisseurID]
		,[LotContingente_Records].[FournisseurID_Display]

		From [fnLotContingente_SelectDisplay](@LotID, @Annee, @FournisseurID) As [LotContingente_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)


