

Create Function [fnIndexation_Display]
(
 @ID [int] = Null
,@ContratID [varchar](10) = Null
,@TypeIndexation [char](1) = Null
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
	
From [dbo].[Indexation]

Where
    ((@ID Is Null) Or ([ID] = @ID))
And ((@ContratID Is Null) Or ([ContratID] = @ContratID))
And ((@TypeIndexation Is Null) Or ([TypeIndexation] = @TypeIndexation))

Order By [Display]
)


