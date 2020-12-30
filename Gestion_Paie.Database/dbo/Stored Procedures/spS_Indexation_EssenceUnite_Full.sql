

CREATE Procedure [spS_Indexation_EssenceUnite_Full]

/*
Retrieve specific records from the [Indexation_EssenceUnite] table, as well as all its foreign tables, depending on the input parameters you supply:
	[Indexation] (via [IndexationID])
	[Contrat_EssenceUnite] (via [ContratID])
	[Contrat_EssenceUnite] (via [EssenceID])
	[Contrat_EssenceUnite] (via [Code])
	[Contrat_EssenceUnite] (via [UniteID])
*/

(
 @ID [int] = Null -- for [Indexation_EssenceUnite].[ID] column
,@IndexationID [int] = Null -- for [Indexation_EssenceUnite].[IndexationID] column
,@ContratID [varchar](10) = Null -- for [Indexation_EssenceUnite].[ContratID] column
,@EssenceID [varchar](6) = Null -- for [Indexation_EssenceUnite].[EssenceID] column
,@Code [char](4) = Null -- for [Indexation_EssenceUnite].[Code] column
,@UniteID [varchar](6) = Null -- for [Indexation_EssenceUnite].[UniteID] column
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

		 [Indexation_EssenceUnite_Records].[ID]
		,[Indexation_EssenceUnite_Records].[IndexationID]
		,[Indexation_EssenceUnite_Records].[ContratID]
		,[Indexation_EssenceUnite_Records].[EssenceID]
		,[Indexation_EssenceUnite_Records].[Code]
		,[Indexation_EssenceUnite_Records].[UniteID]
		,[Indexation_EssenceUnite_Records].[Taux]
		,[Indexation_EssenceUnite_Records].[IndexationID_ID]
		,[Indexation_EssenceUnite_Records].[IndexationID_DateIndexation]
		,[Indexation_EssenceUnite_Records].[IndexationID_ContratID]
		,[Indexation_EssenceUnite_Records].[IndexationID_Periode_Debut]
		,[Indexation_EssenceUnite_Records].[IndexationID_Periode_Fin]
		,[Indexation_EssenceUnite_Records].[IndexationID_TypeIndexation]
		,[Indexation_EssenceUnite_Records].[IndexationID_PourcentageDuMontant]
		,[Indexation_EssenceUnite_Records].[IndexationID_Facture]
		,[Indexation_EssenceUnite_Records].[IndexationID_IndexationTransporteur]
		,[Indexation_EssenceUnite_Records].[IndexationID_Date_Debut]
		,[Indexation_EssenceUnite_Records].[IndexationID_Date_Fin]
		,[Indexation_EssenceUnite_Records].[IndexationID_IndexationManuelle]
		,[Indexation_EssenceUnite_Records].[ContratID_ContratID]
		,[Indexation_EssenceUnite_Records].[ContratID_EssenceID]
		,[Indexation_EssenceUnite_Records].[ContratID_UniteID]
		,[Indexation_EssenceUnite_Records].[ContratID_Code]
		,[Indexation_EssenceUnite_Records].[ContratID_Quantite_prevue]
		,[Indexation_EssenceUnite_Records].[ContratID_Taux_usine]
		,[Indexation_EssenceUnite_Records].[ContratID_Taux_producteur]
		,[Indexation_EssenceUnite_Records].[ContratID_Actif]
		,[Indexation_EssenceUnite_Records].[ContratID_Description]
		,[Indexation_EssenceUnite_Records].[EssenceID_ContratID]
		,[Indexation_EssenceUnite_Records].[EssenceID_EssenceID]
		,[Indexation_EssenceUnite_Records].[EssenceID_UniteID]
		,[Indexation_EssenceUnite_Records].[EssenceID_Code]
		,[Indexation_EssenceUnite_Records].[EssenceID_Quantite_prevue]
		,[Indexation_EssenceUnite_Records].[EssenceID_Taux_usine]
		,[Indexation_EssenceUnite_Records].[EssenceID_Taux_producteur]
		,[Indexation_EssenceUnite_Records].[EssenceID_Actif]
		,[Indexation_EssenceUnite_Records].[EssenceID_Description]
		,[Indexation_EssenceUnite_Records].[Code_ContratID]
		,[Indexation_EssenceUnite_Records].[Code_EssenceID]
		,[Indexation_EssenceUnite_Records].[Code_UniteID]
		,[Indexation_EssenceUnite_Records].[Code_Code]
		,[Indexation_EssenceUnite_Records].[Code_Quantite_prevue]
		,[Indexation_EssenceUnite_Records].[Code_Taux_usine]
		,[Indexation_EssenceUnite_Records].[Code_Taux_producteur]
		,[Indexation_EssenceUnite_Records].[Code_Actif]
		,[Indexation_EssenceUnite_Records].[Code_Description]
		,[Indexation_EssenceUnite_Records].[UniteID_ContratID]
		,[Indexation_EssenceUnite_Records].[UniteID_EssenceID]
		,[Indexation_EssenceUnite_Records].[UniteID_UniteID]
		,[Indexation_EssenceUnite_Records].[UniteID_Code]
		,[Indexation_EssenceUnite_Records].[UniteID_Quantite_prevue]
		,[Indexation_EssenceUnite_Records].[UniteID_Taux_usine]
		,[Indexation_EssenceUnite_Records].[UniteID_Taux_producteur]
		,[Indexation_EssenceUnite_Records].[UniteID_Actif]
		,[Indexation_EssenceUnite_Records].[UniteID_Description]

		From [fnIndexation_EssenceUnite_Full](@ID, @IndexationID, @ContratID, @EssenceID, @Code, @UniteID) As [Indexation_EssenceUnite_Records]
	End

Else

	Begin
		Select

		 [Indexation_EssenceUnite_Records].[ID]
		,[Indexation_EssenceUnite_Records].[IndexationID]
		,[Indexation_EssenceUnite_Records].[ContratID]
		,[Indexation_EssenceUnite_Records].[EssenceID]
		,[Indexation_EssenceUnite_Records].[Code]
		,[Indexation_EssenceUnite_Records].[UniteID]
		,[Indexation_EssenceUnite_Records].[Taux]
		,[Indexation_EssenceUnite_Records].[IndexationID_ID]
		,[Indexation_EssenceUnite_Records].[IndexationID_DateIndexation]
		,[Indexation_EssenceUnite_Records].[IndexationID_ContratID]
		,[Indexation_EssenceUnite_Records].[IndexationID_Periode_Debut]
		,[Indexation_EssenceUnite_Records].[IndexationID_Periode_Fin]
		,[Indexation_EssenceUnite_Records].[IndexationID_TypeIndexation]
		,[Indexation_EssenceUnite_Records].[IndexationID_PourcentageDuMontant]
		,[Indexation_EssenceUnite_Records].[IndexationID_Facture]
		,[Indexation_EssenceUnite_Records].[IndexationID_IndexationTransporteur]
		,[Indexation_EssenceUnite_Records].[IndexationID_Date_Debut]
		,[Indexation_EssenceUnite_Records].[IndexationID_Date_Fin]
		,[Indexation_EssenceUnite_Records].[IndexationID_IndexationManuelle]
		,[Indexation_EssenceUnite_Records].[ContratID_ContratID]
		,[Indexation_EssenceUnite_Records].[ContratID_EssenceID]
		,[Indexation_EssenceUnite_Records].[ContratID_UniteID]
		,[Indexation_EssenceUnite_Records].[ContratID_Code]
		,[Indexation_EssenceUnite_Records].[ContratID_Quantite_prevue]
		,[Indexation_EssenceUnite_Records].[ContratID_Taux_usine]
		,[Indexation_EssenceUnite_Records].[ContratID_Taux_producteur]
		,[Indexation_EssenceUnite_Records].[ContratID_Actif]
		,[Indexation_EssenceUnite_Records].[ContratID_Description]
		,[Indexation_EssenceUnite_Records].[EssenceID_ContratID]
		,[Indexation_EssenceUnite_Records].[EssenceID_EssenceID]
		,[Indexation_EssenceUnite_Records].[EssenceID_UniteID]
		,[Indexation_EssenceUnite_Records].[EssenceID_Code]
		,[Indexation_EssenceUnite_Records].[EssenceID_Quantite_prevue]
		,[Indexation_EssenceUnite_Records].[EssenceID_Taux_usine]
		,[Indexation_EssenceUnite_Records].[EssenceID_Taux_producteur]
		,[Indexation_EssenceUnite_Records].[EssenceID_Actif]
		,[Indexation_EssenceUnite_Records].[EssenceID_Description]
		,[Indexation_EssenceUnite_Records].[Code_ContratID]
		,[Indexation_EssenceUnite_Records].[Code_EssenceID]
		,[Indexation_EssenceUnite_Records].[Code_UniteID]
		,[Indexation_EssenceUnite_Records].[Code_Code]
		,[Indexation_EssenceUnite_Records].[Code_Quantite_prevue]
		,[Indexation_EssenceUnite_Records].[Code_Taux_usine]
		,[Indexation_EssenceUnite_Records].[Code_Taux_producteur]
		,[Indexation_EssenceUnite_Records].[Code_Actif]
		,[Indexation_EssenceUnite_Records].[Code_Description]
		,[Indexation_EssenceUnite_Records].[UniteID_ContratID]
		,[Indexation_EssenceUnite_Records].[UniteID_EssenceID]
		,[Indexation_EssenceUnite_Records].[UniteID_UniteID]
		,[Indexation_EssenceUnite_Records].[UniteID_Code]
		,[Indexation_EssenceUnite_Records].[UniteID_Quantite_prevue]
		,[Indexation_EssenceUnite_Records].[UniteID_Taux_usine]
		,[Indexation_EssenceUnite_Records].[UniteID_Taux_producteur]
		,[Indexation_EssenceUnite_Records].[UniteID_Actif]
		,[Indexation_EssenceUnite_Records].[UniteID_Description]

		From [fnIndexation_EssenceUnite_Full](@ID, @IndexationID, @ContratID, @EssenceID, @Code, @UniteID) As [Indexation_EssenceUnite_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)


