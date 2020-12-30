﻿

Create Function [fnjag_Profile_Display]
(
 @ID [int] = Null
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
	
From [dbo].[jag_Profile]

Where
    ((@ID Is Null) Or ([ID] = @ID))

Order By [Display]
)


