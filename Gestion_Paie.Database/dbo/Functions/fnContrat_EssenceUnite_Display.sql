﻿

Create Function [fnContrat_EssenceUnite_Display]
(
 @ContratID [varchar](10) = Null
,@EssenceID [varchar](6) = Null
,@UniteID [varchar](6) = Null
,@Code [char](4) = Null
)


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Returns Table

As

Return
(
Select TOP 100 PERCENT
 [ContratID] As [ID1]
,[EssenceID] As [ID2]
,[UniteID] As [ID3]
,[Code] As [ID4]
,[Description] As [Display]
	
From [dbo].[Contrat_EssenceUnite]

Where
    ((@ContratID Is Null) Or ([ContratID] = @ContratID))
And ((@EssenceID Is Null) Or ([EssenceID] = @EssenceID))
And ((@UniteID Is Null) Or ([UniteID] = @UniteID))
And ((@Code Is Null) Or ([Code] = @Code))

Order By [Display]
)


