

Create Procedure [spS_LotContingente_Full]

/*
Retrieve specific records from the [LotContingente] table, as well as all its foreign tables, depending on the input parameters you supply:
	[Lot] (via [LotID])
	[Fournisseur] (via [FournisseurID])
*/

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
		,[LotContingente_Records].[Annee]
		,[LotContingente_Records].[SuperficieContingentee]
		,[LotContingente_Records].[Override]
		,[LotContingente_Records].[FournisseurID]

		From [fnLotContingente_Full](@LotID, @Annee, @FournisseurID) As [LotContingente_Records]
	End

Else

	Begin
		Select

		 [LotContingente_Records].[LotID]
		,[LotContingente_Records].[Annee]
		,[LotContingente_Records].[SuperficieContingentee]
		,[LotContingente_Records].[Override]
		,[LotContingente_Records].[FournisseurID]

		From [fnLotContingente_Full](@LotID, @Annee, @FournisseurID) As [LotContingente_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)


