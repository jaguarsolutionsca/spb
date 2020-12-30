

Create Function [fnIndexation_EssenceUnite_Display]
(
 @ID [int] = Null
,@IndexationID [int] = Null
,@ContratID [varchar](10) = Null
,@EssenceID [varchar](6) = Null
,@Code [char](4) = Null
,@UniteID [varchar](6) = Null
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
	
From [dbo].[Indexation_EssenceUnite]

Where
    ((@ID Is Null) Or ([ID] = @ID))
And ((@IndexationID Is Null) Or ([IndexationID] = @IndexationID))
And ((@ContratID Is Null) Or ([ContratID] = @ContratID))
And ((@EssenceID Is Null) Or ([EssenceID] = @EssenceID))
And ((@Code Is Null) Or ([Code] = @Code))
And ((@UniteID Is Null) Or ([UniteID] = @UniteID))

Order By [Display]
)


