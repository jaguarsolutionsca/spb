

Create Function [fnCompte_Display]
(
 @ID [int] = Null
,@CategoryID [int] = Null
)


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Returns Table

As

Return
(
Select TOP 100 PERCENT
 [ID] As [ID1]
,[Description] As [Display]
	
From [dbo].[Compte]

Where
    ((@ID Is Null) Or ([ID] = @ID))
And ((@CategoryID Is Null) Or ([CategoryID] = @CategoryID))

Order By [Display]
)


