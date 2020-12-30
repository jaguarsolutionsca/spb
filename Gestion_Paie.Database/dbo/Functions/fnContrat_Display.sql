

Create Function [fnContrat_Display]
(
 @ID [varchar](10) = Null
,@UsineID [varchar](6) = Null
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
	
From [dbo].[Contrat]

Where
    ((@ID Is Null) Or ([ID] = @ID))
And ((@UsineID Is Null) Or ([UsineID] = @UsineID))

Order By [Display]
)


