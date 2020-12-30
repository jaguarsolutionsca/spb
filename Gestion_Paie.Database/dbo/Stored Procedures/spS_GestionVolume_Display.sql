

Create Procedure [spS_GestionVolume_Display]

(
 @ID [int] = Null -- for [GestionVolume].[ID] column
,@UsineID [varchar](6) = Null -- for [GestionVolume].[UsineID] column
,@UniteMesureID [varchar](6) = Null -- for [GestionVolume].[UniteMesureID] column
,@ProducteurID [varchar](15) = Null -- for [GestionVolume].[ProducteurID] column
,@LotID [int] = Null -- for [GestionVolume].[LotID] column
)

-- Returns the number of records found

As


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Select
 [GestionVolume_Records].[ID1]
,[GestionVolume_Records].[Display]

From [fnGestionVolume_Display](@ID, @UsineID, @UniteMesureID, @ProducteurID, @LotID) As [GestionVolume_Records]

Return(@@RowCount)


