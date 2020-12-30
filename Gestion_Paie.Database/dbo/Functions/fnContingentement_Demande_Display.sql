
Create Function [fnContingentement_Demande_Display]
(
 @ID [int] = Null
,@ProducteurID [varchar](15) = Null
,@TransporteurID [varchar](15) = Null
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
	
From [dbo].[Contingentement_Demande]

Where
    ((@ID Is Null) Or ([ID] = @ID))
And ((@ProducteurID Is Null) Or ([ProducteurID] = @ProducteurID))
And ((@TransporteurID Is Null) Or ([TransporteurID] = @TransporteurID))

Order By [Display]
)

