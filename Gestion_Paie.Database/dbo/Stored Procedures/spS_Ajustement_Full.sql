
CREATE Procedure [spS_Ajustement_Full]

/*
Retrieve specific records from the [Ajustement] table, as well as all its foreign tables, depending on the input parameters you supply:
	[Contrat] (via [ContratID])
*/

(
 @ID [int] = Null -- for [Ajustement].[ID] column
,@ContratID [varchar](10) = Null -- for [Ajustement].[ContratID] column
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

		 [Ajustement_Records].[ID]
		,[Ajustement_Records].[ContratID]
		,[Ajustement_Records].[DateAjustement]
		,[Ajustement_Records].[Periode_Debut]
		,[Ajustement_Records].[Periode_Fin]
		,[Ajustement_Records].[Facture]
		,[Ajustement_Records].[UsePeriodes]
		,[Ajustement_Records].[Date_Debut]
		,[Ajustement_Records].[Date_Fin]
		,[Ajustement_Records].[ProducteurID]
		,[Ajustement_Records].[TransporteurID]
		,[Ajustement_Records].[IsRistourne]
		,[Ajustement_Records].[ContratID_ID]
		,[Ajustement_Records].[ContratID_Description]
		,[Ajustement_Records].[ContratID_UsineID]
		,[Ajustement_Records].[ContratID_Annee]
		,[Ajustement_Records].[ContratID_Date_debut]
		,[Ajustement_Records].[ContratID_Date_fin]
		,[Ajustement_Records].[ContratID_Actif]
		,[Ajustement_Records].[ContratID_PaieTransporteur]
		,[Ajustement_Records].[ContratID_Taux_Surcharge]
		,[Ajustement_Records].[ContratID_SurchargeManuel]
		,[Ajustement_Records].[ContratID_TxTransSameProd]

		From [fnAjustement_Full](@ID, @ContratID) As [Ajustement_Records]
	End

Else

	Begin
		Select

		 [Ajustement_Records].[ID]
		,[Ajustement_Records].[ContratID]
		,[Ajustement_Records].[DateAjustement]
		,[Ajustement_Records].[Periode_Debut]
		,[Ajustement_Records].[Periode_Fin]
		,[Ajustement_Records].[Facture]
		,[Ajustement_Records].[UsePeriodes]
		,[Ajustement_Records].[Date_Debut]
		,[Ajustement_Records].[Date_Fin]
		,[Ajustement_Records].[ProducteurID]
		,[Ajustement_Records].[TransporteurID]
		,[Ajustement_Records].[IsRistourne]
		,[Ajustement_Records].[ContratID_ID]
		,[Ajustement_Records].[ContratID_Description]
		,[Ajustement_Records].[ContratID_UsineID]
		,[Ajustement_Records].[ContratID_Annee]
		,[Ajustement_Records].[ContratID_Date_debut]
		,[Ajustement_Records].[ContratID_Date_fin]
		,[Ajustement_Records].[ContratID_Actif]
		,[Ajustement_Records].[ContratID_PaieTransporteur]
		,[Ajustement_Records].[ContratID_Taux_Surcharge]
		,[Ajustement_Records].[ContratID_SurchargeManuel]
		,[Ajustement_Records].[ContratID_TxTransSameProd]

		From [fnAjustement_Full](@ID, @ContratID) As [Ajustement_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)

