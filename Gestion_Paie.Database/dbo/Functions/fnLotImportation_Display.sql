

Create Function [fnLotImportation_Display]
(
)


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Returns Table

As

Return
(
Select TOP 100 PERCENT
 [Raison] As [Display]
	
From [dbo].[LotImportation]

Order By [Display]
)


