

Create Procedure [spD_GestionVolume]

-- Delete a specific record from table [GestionVolume]

(
 @ID [int] -- for [GestionVolume].[ID] column
,@UsineID [varchar](6) = Null -- for [GestionVolume].[UsineID] column
,@UniteMesureID [varchar](6) = Null -- for [GestionVolume].[UniteMesureID] column
,@ProducteurID [varchar](15) = Null -- for [GestionVolume].[ProducteurID] column
,@LotID [int] = Null -- for [GestionVolume].[LotID] column
)

-- Returns the number of deleted records

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Delete From [dbo].[GestionVolume]

Where
    ((@ID Is Null) Or ([ID] = @ID))
And ((@UsineID Is Null) Or ([UsineID] = @UsineID))
And ((@UniteMesureID Is Null) Or ([UniteMesureID] = @UniteMesureID))
And ((@ProducteurID Is Null) Or ([ProducteurID] = @ProducteurID))
And ((@LotID Is Null) Or ([LotID] = @LotID))

Set NoCount Off

Return(@@RowCount)


