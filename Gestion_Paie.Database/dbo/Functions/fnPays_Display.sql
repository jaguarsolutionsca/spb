

Create Function [fnPays_Display]
(
 @ID [varchar](2) = Null
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
	
From [dbo].[Pays]

Where
    ((@ID Is Null) Or ([ID] = @ID))

Order By [Display]
)


