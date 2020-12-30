

Create Procedure [spS_Contrat]

-- Retrieve specific records from the [Contrat] table depending on the input parameters you supply.

(
 @ID [varchar](10) = Null -- for [Contrat].[ID] column
,@UsineID [varchar](6) = Null -- for [Contrat].[UsineID] column
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

		 [Contrat_Records].[ID]
		,[Contrat_Records].[Description]
		,[Contrat_Records].[UsineID]
		,[Contrat_Records].[Annee]
		,[Contrat_Records].[Date_debut]
		,[Contrat_Records].[Date_fin]
		,[Contrat_Records].[Actif]
		,[Contrat_Records].[PaieTransporteur]
		,[Contrat_Records].[Taux_Surcharge]
		,[Contrat_Records].[SurchargeManuel]
		,[Contrat_Records].[TxTransSameProd]

		From [fnContrat](@ID, @UsineID) As [Contrat_Records]
	End

Else

	Begin
		Select

		 [Contrat_Records].[ID]
		,[Contrat_Records].[Description]
		,[Contrat_Records].[UsineID]
		,[Contrat_Records].[Annee]
		,[Contrat_Records].[Date_debut]
		,[Contrat_Records].[Date_fin]
		,[Contrat_Records].[Actif]
		,[Contrat_Records].[PaieTransporteur]
		,[Contrat_Records].[Taux_Surcharge]
		,[Contrat_Records].[SurchargeManuel]
		,[Contrat_Records].[TxTransSameProd]

		From [fnContrat](@ID, @UsineID) As [Contrat_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)


