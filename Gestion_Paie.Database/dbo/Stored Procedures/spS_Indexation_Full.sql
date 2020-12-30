

Create Procedure [spS_Indexation_Full]

/*
Retrieve specific records from the [Indexation] table, as well as all its foreign tables, depending on the input parameters you supply:
	[Contrat] (via [ContratID])
	[TypeIndexation] (via [TypeIndexation])
*/

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
		,[Indexation_Records].[ContratID_ID]
		,[Indexation_Records].[ContratID_Description]
		,[Indexation_Records].[ContratID_UsineID]
		,[Indexation_Records].[ContratID_Annee]
		,[Indexation_Records].[ContratID_Date_debut]
		,[Indexation_Records].[ContratID_Date_fin]
		,[Indexation_Records].[ContratID_Actif]
		,[Indexation_Records].[ContratID_PaieTransporteur]
		,[Indexation_Records].[ContratID_Taux_Surcharge]
		,[Indexation_Records].[ContratID_SurchargeManuel]
		,[Indexation_Records].[ContratID_TxTransSameProd]
		,[Indexation_Records].[TypeIndexation_ID]
		,[Indexation_Records].[TypeIndexation_Description]

		From [fnIndexation_Full](@ID, @ContratID, @TypeIndexation) As [Indexation_Records]
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
		,[Indexation_Records].[ContratID_ID]
		,[Indexation_Records].[ContratID_Description]
		,[Indexation_Records].[ContratID_UsineID]
		,[Indexation_Records].[ContratID_Annee]
		,[Indexation_Records].[ContratID_Date_debut]
		,[Indexation_Records].[ContratID_Date_fin]
		,[Indexation_Records].[ContratID_Actif]
		,[Indexation_Records].[ContratID_PaieTransporteur]
		,[Indexation_Records].[ContratID_Taux_Surcharge]
		,[Indexation_Records].[ContratID_SurchargeManuel]
		,[Indexation_Records].[ContratID_TxTransSameProd]
		,[Indexation_Records].[TypeIndexation_ID]
		,[Indexation_Records].[TypeIndexation_Description]

		From [fnIndexation_Full](@ID, @ContratID, @TypeIndexation) As [Indexation_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)


