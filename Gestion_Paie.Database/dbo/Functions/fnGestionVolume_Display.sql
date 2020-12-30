

Create Function [fnGestionVolume_Display]
(
 @ID [int] = Null
,@UsineID [varchar](6) = Null
,@UniteMesureID [varchar](6) = Null
,@ProducteurID [varchar](15) = Null
,@LotID [int] = Null
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
	
From [dbo].[GestionVolume]

Where
    ((@ID Is Null) Or ([ID] = @ID))
And ((@UsineID Is Null) Or ([UsineID] = @UsineID))
And ((@UniteMesureID Is Null) Or ([UniteMesureID] = @UniteMesureID))
And ((@ProducteurID Is Null) Or ([ProducteurID] = @ProducteurID))
And ((@LotID Is Null) Or ([LotID] = @LotID))

Order By [Display]
)


