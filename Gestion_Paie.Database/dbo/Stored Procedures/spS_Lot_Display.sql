

Create Procedure [spS_Lot_Display]

(
 @ID [int] = Null -- for [Lot].[ID] column
,@CantonID [varchar](6) = Null -- for [Lot].[CantonID] column
,@MunicipaliteID [varchar](6) = Null -- for [Lot].[MunicipaliteID] column
,@ProprietaireID [varchar](15) = Null -- for [Lot].[ProprietaireID] column
,@ContingentID [varchar](15) = Null -- for [Lot].[ContingentID] column
,@Droit_coupeID [varchar](15) = Null -- for [Lot].[Droit_coupeID] column
,@Entente_paiementID [varchar](15) = Null -- for [Lot].[Entente_paiementID] column
,@ZoneID [varchar](2) = Null -- for [Lot].[ZoneID] column
)

-- Returns the number of records found

As


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Select
 [Lot_Records].[ID1]
,[Lot_Records].[Display]

From [fnLot_Display](@ID, @CantonID, @MunicipaliteID, @ProprietaireID, @ContingentID, @Droit_coupeID, @Entente_paiementID, @ZoneID) As [Lot_Records]

Return(@@RowCount)


