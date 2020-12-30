

Create Procedure [spS_Indexation]

-- Retrieve specific records from the [Indexation] table depending on the input parameters you supply.

(
 @ID [int] = Null -- for [Indexation].[ID] column
,@ContratID [varchar](10) = Null -- for [Indexation].[ContratID] column
,@TypeIndexation [char](1) = Null -- for [Indexation].[TypeIndexation] column
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

		 [Indexation_Records].[ID]
		,[Indexation_Records].[DateIndexation]
		,[Indexation_Records].[ContratID]
		,[Indexation_Records].[Periode_Debut]
		,[Indexation_Records].[Periode_Fin]
		,[Indexation_Records].[TypeIndexation]
		,[Indexation_Records].[PourcentageDuMontant]
		,[Indexation_Records].[Facture]
		,[Indexation_Records].[IndexationTransporteur]
		,[Indexation_Records].[Date_Debut]
		,[Indexation_Records].[Date_Fin]
		,[Indexation_Records].[IndexationManuelle]

		From [fnIndexation](@ID, @ContratID, @TypeIndexation) As [Indexation_Records]
	End

Else

	Begin
		Select

		 [Indexation_Records].[ID]
		,[Indexation_Records].[DateIndexation]
		,[Indexation_Records].[ContratID]
		,[Indexation_Records].[Periode_Debut]
		,[Indexation_Records].[Periode_Fin]
		,[Indexation_Records].[TypeIndexation]
		,[Indexation_Records].[PourcentageDuMontant]
		,[Indexation_Records].[Facture]
		,[Indexation_Records].[IndexationTransporteur]
		,[Indexation_Records].[Date_Debut]
		,[Indexation_Records].[Date_Fin]
		,[Indexation_Records].[IndexationManuelle]

		From [fnIndexation](@ID, @ContratID, @TypeIndexation) As [Indexation_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)


