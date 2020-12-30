

Create Procedure [spS_Contrat_Transporteur_Full]

/*
Retrieve specific records from the [Contrat_Transporteur] table, as well as all its foreign tables, depending on the input parameters you supply:
	[Contrat] (via [ContratID])
	[UniteMesure] (via [UniteID])
	[Municipalite_Zone] (via [MunicipaliteID])
	[Municipalite_Zone] (via [ZoneID])
*/

(
 @ContratID [varchar](10) = Null -- for [Contrat_Transporteur].[ContratID] column
,@UniteID [varchar](6) = Null -- for [Contrat_Transporteur].[UniteID] column
,@MunicipaliteID [varchar](6) = Null -- for [Contrat_Transporteur].[MunicipaliteID] column
,@ZoneID [varchar](2) = Null -- for [Contrat_Transporteur].[ZoneID] column
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

		 [Contrat_Transporteur_Records].[ContratID]
		,[Contrat_Transporteur_Records].[UniteID]
		,[Contrat_Transporteur_Records].[MunicipaliteID]
		,[Contrat_Transporteur_Records].[Taux_transporteur]
		,[Contrat_Transporteur_Records].[Taux_producteur]
		,[Contrat_Transporteur_Records].[Actif]
		,[Contrat_Transporteur_Records].[ZoneID]

		From [fnContrat_Transporteur_Full](@ContratID, @UniteID, @MunicipaliteID, @ZoneID) As [Contrat_Transporteur_Records]
	End

Else

	Begin
		Select

		 [Contrat_Transporteur_Records].[ContratID]
		,[Contrat_Transporteur_Records].[UniteID]
		,[Contrat_Transporteur_Records].[MunicipaliteID]
		,[Contrat_Transporteur_Records].[Taux_transporteur]
		,[Contrat_Transporteur_Records].[Taux_producteur]
		,[Contrat_Transporteur_Records].[Actif]
		,[Contrat_Transporteur_Records].[ZoneID]

		From [fnContrat_Transporteur_Full](@ContratID, @UniteID, @MunicipaliteID, @ZoneID) As [Contrat_Transporteur_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)


