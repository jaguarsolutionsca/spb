﻿

Create Function [fnCanton_Display]
(
 @ID [varchar](6) = Null
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
	
From [dbo].[Canton]

Where
    ((@ID Is Null) Or ([ID] = @ID))

Order By [Display]
)


