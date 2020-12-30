﻿Create Function [dbo].[fnAjustementCalcule_TransporteurEssence_Display]
(
 @ID [int] = Null
,@AjustementID [int] = Null
,@EssenceID [varchar](6) = Null
,@UniteID [varchar](6) = Null
,@LivraisonDetailID [int] = Null
,@TransporteurID [varchar](15) = Null
,@FactureID [int] = Null
,@Code [char](4) = Null
)


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Returns Table

As

Return
(
Select TOP 100 PERCENT
 [ID] As [ID1]
,[ErreurDescription] As [Display]
	
From [dbo].[AjustementCalcule_TransporteurEssence]

Where
    ((@ID Is Null) Or ([ID] = @ID))
And ((@AjustementID Is Null) Or ([AjustementID] = @AjustementID))
And ((@EssenceID Is Null) Or ([EssenceID] = @EssenceID))
And ((@UniteID Is Null) Or ([UniteID] = @UniteID))
And ((@LivraisonDetailID Is Null) Or ([LivraisonDetailID] = @LivraisonDetailID))
And ((@TransporteurID Is Null) Or ([TransporteurID] = @TransporteurID))
And ((@FactureID Is Null) Or ([FactureID] = @FactureID))
And ((@Code Is Null) Or ([Code] = @Code))

Order By [Display]
)
