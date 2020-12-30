

Create Function [fnAjustementCalcule_Transporteur_Display]
(
 @ID [int] = Null
,@AjustementID [int] = Null
,@UniteID [varchar](6) = Null
,@MunicipaliteID [varchar](6) = Null
,@LivraisonID [int] = Null
,@TransporteurID [varchar](15) = Null
,@FactureID [int] = Null
,@ZoneID [varchar](2) = Null
)


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Returns Table

As

Return
(
Select TOP 100 PERCENT
 [ID] As [ID1]
,[ErreurDescription] As [Display]
	
From [dbo].[AjustementCalcule_Transporteur]

Where
    ((@ID Is Null) Or ([ID] = @ID))
And ((@AjustementID Is Null) Or ([AjustementID] = @AjustementID))
And ((@UniteID Is Null) Or ([UniteID] = @UniteID))
And ((@MunicipaliteID Is Null) Or ([MunicipaliteID] = @MunicipaliteID))
And ((@LivraisonID Is Null) Or ([LivraisonID] = @LivraisonID))
And ((@TransporteurID Is Null) Or ([TransporteurID] = @TransporteurID))
And ((@FactureID Is Null) Or ([FactureID] = @FactureID))
And ((@ZoneID Is Null) Or ([ZoneID] = @ZoneID))

Order By [Display]
)


