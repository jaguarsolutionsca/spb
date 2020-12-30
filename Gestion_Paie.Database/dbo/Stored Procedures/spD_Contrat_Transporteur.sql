

Create Procedure [spD_Contrat_Transporteur]

-- Delete a specific record from table [Contrat_Transporteur]

(
 @ContratID [varchar](10) -- for [Contrat_Transporteur].[ContratID] column
,@UniteID [varchar](6) -- for [Contrat_Transporteur].[UniteID] column
,@MunicipaliteID [varchar](6) -- for [Contrat_Transporteur].[MunicipaliteID] column
,@ZoneID [varchar](2) -- for [Contrat_Transporteur].[ZoneID] column
)

-- Returns the number of deleted records

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Delete From [dbo].[Contrat_Transporteur]

Where
    ((@ContratID Is Null) Or ([ContratID] = @ContratID))
And ((@UniteID Is Null) Or ([UniteID] = @UniteID))
And ((@MunicipaliteID Is Null) Or ([MunicipaliteID] = @MunicipaliteID))
And ((@ZoneID Is Null) Or ([ZoneID] = @ZoneID))

Set NoCount Off

Return(@@RowCount)


