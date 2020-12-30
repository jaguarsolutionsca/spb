

Create Procedure [spS_Ajustement_Transporteur_Display]

(
 @AjustementID [int] = Null -- for [Ajustement_Transporteur].[AjustementID] column
,@UniteID [varchar](6) = Null -- for [Ajustement_Transporteur].[UniteID] column
,@MunicipaliteID [varchar](6) = Null -- for [Ajustement_Transporteur].[MunicipaliteID] column
,@ZoneID [varchar](2) = Null -- for [Ajustement_Transporteur].[ZoneID] column
,@ContratID [varchar](10) = Null -- for [Ajustement_Transporteur].[ContratID] column
)

-- Returns the number of records found

As


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Select
 [Ajustement_Transporteur_Records].[ID1]
,[Ajustement_Transporteur_Records].[ID2]
,[Ajustement_Transporteur_Records].[ID3]
,[Ajustement_Transporteur_Records].[ID4]
,[Ajustement_Transporteur_Records].[Display]

From [fnAjustement_Transporteur_Display](@AjustementID, @UniteID, @MunicipaliteID, @ZoneID, @ContratID) As [Ajustement_Transporteur_Records]

Return(@@RowCount)


