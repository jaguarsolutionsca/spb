﻿

Create Function [fnFactureFournisseur_Details_Display]
(
 @FactureID [int] = Null
,@Ligne [int] = Null
,@Compte [int] = Null
)


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Returns Table

As

Return
(
Select TOP 100 PERCENT
 [FactureID] As [ID1]
,[Ligne] As [ID2]
,[Ligne] As [Display]
	
From [dbo].[FactureFournisseur_Details]

Where
    ((@FactureID Is Null) Or ([FactureID] = @FactureID))
And ((@Ligne Is Null) Or ([Ligne] = @Ligne))
And ((@Compte Is Null) Or ([Compte] = @Compte))

Order By [Display]
)


