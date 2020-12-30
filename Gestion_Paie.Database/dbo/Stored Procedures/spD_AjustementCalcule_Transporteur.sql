

Create Procedure [spD_AjustementCalcule_Transporteur]

-- Delete a specific record from table [AjustementCalcule_Transporteur]

(
 @ID [int] -- for [AjustementCalcule_Transporteur].[ID] column
,@AjustementID [int] = Null -- for [AjustementCalcule_Transporteur].[AjustementID] column
,@UniteID [varchar](6) = Null -- for [AjustementCalcule_Transporteur].[UniteID] column
,@MunicipaliteID [varchar](6) = Null -- for [AjustementCalcule_Transporteur].[MunicipaliteID] column
,@LivraisonID [int] = Null -- for [AjustementCalcule_Transporteur].[LivraisonID] column
,@TransporteurID [varchar](15) = Null -- for [AjustementCalcule_Transporteur].[TransporteurID] column
,@FactureID [int] = Null -- for [AjustementCalcule_Transporteur].[FactureID] column
,@ZoneID [varchar](2) = Null -- for [AjustementCalcule_Transporteur].[ZoneID] column
)

-- Returns the number of deleted records

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Delete From [dbo].[AjustementCalcule_Transporteur]

Where
    ((@ID Is Null) Or ([ID] = @ID))
And ((@AjustementID Is Null) Or ([AjustementID] = @AjustementID))
And ((@UniteID Is Null) Or ([UniteID] = @UniteID))
And ((@MunicipaliteID Is Null) Or ([MunicipaliteID] = @MunicipaliteID))
And ((@LivraisonID Is Null) Or ([LivraisonID] = @LivraisonID))
And ((@TransporteurID Is Null) Or ([TransporteurID] = @TransporteurID))
And ((@FactureID Is Null) Or ([FactureID] = @FactureID))
And ((@ZoneID Is Null) Or ([ZoneID] = @ZoneID))

Set NoCount Off

Return(@@RowCount)


