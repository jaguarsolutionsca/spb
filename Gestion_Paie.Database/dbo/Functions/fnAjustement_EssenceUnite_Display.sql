CREATE Function [dbo].[fnAjustement_EssenceUnite_Display]
(
 @AjustementID [int] = Null
,@EssenceID [varchar](6) = Null
,@UniteID [varchar](6) = Null
,@Code [char](4) = Null
,@ContratID [varchar](10) = Null
)


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Returns Table

As

Return
(
Select TOP 100 PERCENT
 [AjustementID] As [ID1]
,[EssenceID] As [ID2]
,[UniteID] As [ID3]
,[Code] As [ID4]
,[Code] As [Display]
	
From [dbo].[Ajustement_EssenceUnite]

Where
    ((@AjustementID Is Null) Or ([AjustementID] = @AjustementID))
And ((@EssenceID Is Null) Or ([EssenceID] = @EssenceID))
And ((@UniteID Is Null) Or ([UniteID] = @UniteID))
And ((@Code Is Null) Or ([Code] = @Code))
And ((@ContratID Is Null) Or ([ContratID] = @ContratID))

Order By [Display]
)
