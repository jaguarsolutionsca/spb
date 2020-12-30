

Create Function [fnMRCCorrection_Display]
(
)


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Returns Table

As

Return
(
Select TOP 100 PERCENT
 [CodeCIEL] As [Display]
	
From [dbo].[MRCCorrection]

Order By [Display]
)


