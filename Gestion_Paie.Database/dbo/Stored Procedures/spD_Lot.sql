
CREATE Procedure [spD_Lot]

-- Delete a specific record from table [Lot]

(
 @ID [int] -- for [Lot].[ID] column
,@CantonID [varchar](6) = Null -- for [Lot].[CantonID] column
,@MunicipaliteID [varchar](6) = Null -- for [Lot].[MunicipaliteID] column
,@ProprietaireID [varchar](15) = Null -- for [Lot].[ProprietaireID] column
,@ContingentID [varchar](15) = Null -- for [Lot].[ContingentID] column
,@Droit_coupeID [varchar](15) = Null -- for [Lot].[Droit_coupeID] column
,@Entente_paiementID [varchar](15) = Null -- for [Lot].[Entente_paiementID] column
,@ZoneID [varchar](2) = Null -- for [Lot].[ZoneID] column
)

-- Returns the number of deleted records

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Delete From [dbo].[Lot]

Where
    ((@ID Is Null) Or ([ID] = @ID))
And ((@CantonID Is Null) Or ([CantonID] = @CantonID))
And ((@MunicipaliteID Is Null) Or ([MunicipaliteID] = @MunicipaliteID))
And ((@ProprietaireID Is Null) Or ([ProprietaireID] = @ProprietaireID))
And ((@ContingentID Is Null) Or ([ContingentID] = @ContingentID))
And ((@Droit_coupeID Is Null) Or ([Droit_coupeID] = @Droit_coupeID))
And ((@Entente_paiementID Is Null) Or ([Entente_paiementID] = @Entente_paiementID))
And ((@ZoneID Is Null) Or ([ZoneID] = @ZoneID))

Set NoCount Off

Return(@@RowCount)

