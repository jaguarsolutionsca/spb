

Create Procedure [spS_Contrat_Transporteur_Display]

(
 @ContratID [varchar](10) = Null -- for [Contrat_Transporteur].[ContratID] column
,@UniteID [varchar](6) = Null -- for [Contrat_Transporteur].[UniteID] column
,@MunicipaliteID [varchar](6) = Null -- for [Contrat_Transporteur].[MunicipaliteID] column
,@ZoneID [varchar](2) = Null -- for [Contrat_Transporteur].[ZoneID] column
)

-- Returns the number of records found

As


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Select
 [Contrat_Transporteur_Records].[ID1]
,[Contrat_Transporteur_Records].[ID2]
,[Contrat_Transporteur_Records].[ID3]
,[Contrat_Transporteur_Records].[ID4]
,[Contrat_Transporteur_Records].[Display]

From [fnContrat_Transporteur_Display](@ContratID, @UniteID, @MunicipaliteID, @ZoneID) As [Contrat_Transporteur_Records]

Return(@@RowCount)


