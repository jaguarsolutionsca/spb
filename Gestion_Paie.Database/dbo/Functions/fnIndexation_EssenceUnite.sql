

CREATE Function [fnIndexation_EssenceUnite]
(
 @ID [int] = Null
,@IndexationID [int] = Null
,@ContratID [varchar](10) = Null
,@EssenceID [varchar](6) = Null
,@Code [char](4) = Null
,@UniteID [varchar](6) = Null
)


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Returns Table

As

Return
(
Select TOP 100 PERCENT
 [ID]
,[IndexationID]
,[ContratID]
,[EssenceID]
,[Code]
,[UniteID]
,[Taux]

From [dbo].[Indexation_EssenceUnite]

Where

    ((@ID Is Null) Or ([ID] = @ID))
And ((@IndexationID Is Null) Or ([IndexationID] = @IndexationID))
And ((@ContratID Is Null) Or ([ContratID] = @ContratID))
And ((@EssenceID Is Null) Or ([EssenceID] = @EssenceID))
And ((@Code Is Null) Or ([Code] = @Code))
And ((@UniteID Is Null) Or ([UniteID] = @UniteID))
)


