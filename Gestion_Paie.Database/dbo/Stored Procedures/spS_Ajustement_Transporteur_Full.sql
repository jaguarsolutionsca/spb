

Create Procedure [spS_Ajustement_Transporteur_Full]

/*
Retrieve specific records from the [Ajustement_Transporteur] table, as well as all its foreign tables, depending on the input parameters you supply:
	[Ajustement] (via [AjustementID])
	[Contrat_Transporteur] (via [UniteID])
	[Contrat_Transporteur] (via [MunicipaliteID])
	[Contrat_Transporteur] (via [ContratID])
	[Contrat_Transporteur] (via [ZoneID])
*/

(
 @AjustementID [int] = Null -- for [Ajustement_Transporteur].[AjustementID] column
,@UniteID [varchar](6) = Null -- for [Ajustement_Transporteur].[UniteID] column
,@MunicipaliteID [varchar](6) = Null -- for [Ajustement_Transporteur].[MunicipaliteID] column
,@ZoneID [varchar](2) = Null -- for [Ajustement_Transporteur].[ZoneID] column
,@ContratID [varchar](10) = Null -- for [Ajustement_Transporteur].[ContratID] column
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

		 [Ajustement_Transporteur_Records].[AjustementID]
		,[Ajustement_Transporteur_Records].[UniteID]
		,[Ajustement_Transporteur_Records].[MunicipaliteID]
		,[Ajustement_Transporteur_Records].[ContratID]
		,[Ajustement_Transporteur_Records].[Taux_transporteur]
		,[Ajustement_Transporteur_Records].[Date_Modification]
		,[Ajustement_Transporteur_Records].[ZoneID]
		,[Ajustement_Transporteur_Records].[ContratID_ContratID]
		,[Ajustement_Transporteur_Records].[ContratID_UniteID]
		,[Ajustement_Transporteur_Records].[ContratID_MunicipaliteID]
		,[Ajustement_Transporteur_Records].[ContratID_Taux_transporteur]
		,[Ajustement_Transporteur_Records].[ContratID_Taux_producteur]
		,[Ajustement_Transporteur_Records].[ContratID_Actif]
		,[Ajustement_Transporteur_Records].[ContratID_ZoneID]

		From [fnAjustement_Transporteur_Full](@AjustementID, @UniteID, @MunicipaliteID, @ZoneID, @ContratID) As [Ajustement_Transporteur_Records]
	End

Else

	Begin
		Select

		 [Ajustement_Transporteur_Records].[AjustementID]
		,[Ajustement_Transporteur_Records].[UniteID]
		,[Ajustement_Transporteur_Records].[MunicipaliteID]
		,[Ajustement_Transporteur_Records].[ContratID]
		,[Ajustement_Transporteur_Records].[Taux_transporteur]
		,[Ajustement_Transporteur_Records].[Date_Modification]
		,[Ajustement_Transporteur_Records].[ZoneID]
		,[Ajustement_Transporteur_Records].[ContratID_ContratID]
		,[Ajustement_Transporteur_Records].[ContratID_UniteID]
		,[Ajustement_Transporteur_Records].[ContratID_MunicipaliteID]
		,[Ajustement_Transporteur_Records].[ContratID_Taux_transporteur]
		,[Ajustement_Transporteur_Records].[ContratID_Taux_producteur]
		,[Ajustement_Transporteur_Records].[ContratID_Actif]
		,[Ajustement_Transporteur_Records].[ContratID_ZoneID]

		From [fnAjustement_Transporteur_Full](@AjustementID, @UniteID, @MunicipaliteID, @ZoneID, @ContratID) As [Ajustement_Transporteur_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)


