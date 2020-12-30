

Create Function [fnContingentement_Display]
(
 @ID [int] = Null
,@UsineID [varchar](6) = Null
,@RegroupementID [int] = Null
,@EssenceID [varchar](6) = Null
,@UniteMesureID [varchar](6) = Null
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
	
From [dbo].[Contingentement]

Where
    ((@ID Is Null) Or ([ID] = @ID))
And ((@UsineID Is Null) Or ([UsineID] = @UsineID))
And ((@RegroupementID Is Null) Or ([RegroupementID] = @RegroupementID))
And ((@EssenceID Is Null) Or ([EssenceID] = @EssenceID))
And ((@UniteMesureID Is Null) Or ([UniteMesureID] = @UniteMesureID))

Order By [Display]
)


