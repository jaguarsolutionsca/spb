

Create Procedure [spD_Ajustement_Transporteur]

-- Delete a specific record from table [Ajustement_Transporteur]

(
 @AjustementID [int] -- for [Ajustement_Transporteur].[AjustementID] column
,@UniteID [varchar](6) -- for [Ajustement_Transporteur].[UniteID] column
,@MunicipaliteID [varchar](6) -- for [Ajustement_Transporteur].[MunicipaliteID] column
,@ZoneID [varchar](2) -- for [Ajustement_Transporteur].[ZoneID] column
,@ContratID [varchar](10) = Null -- for [Ajustement_Transporteur].[ContratID] column
)

-- Returns the number of deleted records

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Delete From [dbo].[Ajustement_Transporteur]

Where
    ((@AjustementID Is Null) Or ([AjustementID] = @AjustementID))
And ((@UniteID Is Null) Or ([UniteID] = @UniteID))
And ((@MunicipaliteID Is Null) Or ([MunicipaliteID] = @MunicipaliteID))
And ((@ZoneID Is Null) Or ([ZoneID] = @ZoneID))
And ((@ContratID Is Null) Or ([ContratID] = @ContratID))

Set NoCount Off

Return(@@RowCount)


