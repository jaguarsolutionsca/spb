

CREATE Function [fnIndexation_EssenceUnite_SelectDisplay]
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
Select
	 [Indexation_EssenceUnite].[ID]
	,[Indexation_EssenceUnite].[IndexationID]
	,[Indexation1].[Display] [IndexationID_Display]
	,[Indexation_EssenceUnite].[ContratID]
	,[Contrat_EssenceUnite2].[Display] [ContratID_Display]
	,[Indexation_EssenceUnite].[EssenceID]
	,[Contrat_EssenceUnite3].[Display] [EssenceID_Display]
	,[Indexation_EssenceUnite].[Code]
	,[Contrat_EssenceUnite4].[Display] [Code_Display]
	,[Indexation_EssenceUnite].[UniteID]
	,[Contrat_EssenceUnite5].[Display] [UniteID_Display]
	,[Indexation_EssenceUnite].[Taux]

From [dbo].[Indexation_EssenceUnite]
    Left Outer Join [fnIndexation_Display](Null, Null, Null) [Indexation1] On [IndexationID] = [Indexation1].[ID1]
        Left Outer Join [fnContrat_EssenceUnite_Display](Null, Null, Null, Null) [Contrat_EssenceUnite2] On [ContratID] = [Contrat_EssenceUnite2].[ID1]
            Left Outer Join [fnContrat_EssenceUnite_Display](Null, Null, Null, Null) [Contrat_EssenceUnite3] On [EssenceID] = [Contrat_EssenceUnite3].[ID2]
                Left Outer Join [fnContrat_EssenceUnite_Display](Null, Null, Null, Null) [Contrat_EssenceUnite4] On [Code] = [Contrat_EssenceUnite4].[ID4]
                    Left Outer Join [fnContrat_EssenceUnite_Display](Null, Null, Null, Null) [Contrat_EssenceUnite5] On [UniteID] = [Contrat_EssenceUnite5].[ID3]

Where

    ((@ID Is Null) Or ([ID] = @ID))
And ((@IndexationID Is Null) Or ([IndexationID] = @IndexationID))
And ((@ContratID Is Null) Or ([ContratID] = @ContratID))
And ((@EssenceID Is Null) Or ([EssenceID] = @EssenceID))
And ((@Code Is Null) Or ([Code] = @Code))
And ((@UniteID Is Null) Or ([UniteID] = @UniteID))
)


