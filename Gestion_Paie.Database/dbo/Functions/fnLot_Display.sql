

Create Function [fnLot_Display]
(
 @ID [int] = Null
,@CantonID [varchar](6) = Null
,@MunicipaliteID [varchar](6) = Null
,@ProprietaireID [varchar](15) = Null
,@ContingentID [varchar](15) = Null
,@Droit_coupeID [varchar](15) = Null
,@Entente_paiementID [varchar](15) = Null
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
,[ID] As [Display]
	
From [dbo].[Lot]

Where
    ((@ID Is Null) Or ([ID] = @ID))
And ((@CantonID Is Null) Or ([CantonID] = @CantonID))
And ((@MunicipaliteID Is Null) Or ([MunicipaliteID] = @MunicipaliteID))
And ((@ProprietaireID Is Null) Or ([ProprietaireID] = @ProprietaireID))
And ((@ContingentID Is Null) Or ([ContingentID] = @ContingentID))
And ((@Droit_coupeID Is Null) Or ([Droit_coupeID] = @Droit_coupeID))
And ((@Entente_paiementID Is Null) Or ([Entente_paiementID] = @Entente_paiementID))
And ((@ZoneID Is Null) Or ([ZoneID] = @ZoneID))

Order By [Display]
)


