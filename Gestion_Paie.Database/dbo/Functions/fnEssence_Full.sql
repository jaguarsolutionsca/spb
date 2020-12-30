CREATE FUNCTION [dbo].[fnEssence_Full]
(@ID VARCHAR (6)=Null, @RegroupementID INT=Null, @ContingentID INT=Null, @RepartitionID INT=Null)
RETURNS TABLE 
AS
RETURN 
    (
Select TOP 100 PERCENT
 [Essence].[ID]
,[Essence].[Description]
,[Essence].[RegroupementID]
,[Essence].[ContingentID]
,[Essence].[RepartitionID]
,[Essence].[Actif]
,[EssenceRegroupement1].[ID] [RegroupementID_ID]
,[EssenceRegroupement1].[Description] [RegroupementID_Description]
,[EssenceRegroupement1].[Actif] [RegroupementID_Actif]
,[EssenceContingent2].[ID] [ContingentID_ID]
,[EssenceContingent2].[Description] [ContingentID_Description]
,[EssenceContingent2].[Actif] [ContingentID_Actif]
,[EssenceRepartition3].[ID] [RepartitionID_ID]
,[EssenceRepartition3].[Description] [RepartitionID_Description]
,[EssenceRepartition3].[Actif] [RepartitionID_Actif]

From [dbo].[Essence] [Essence]
    Left Outer Join [dbo].[EssenceRegroupement] [EssenceRegroupement1] On [Essence].[RegroupementID] = [EssenceRegroupement1].[ID]
        Left Outer Join [dbo].[EssenceContingent] [EssenceContingent2] On [Essence].[ContingentID] = [EssenceContingent2].[ID]
            Left Outer Join [dbo].[EssenceRepartition] [EssenceRepartition3] On [Essence].[RepartitionID] = [EssenceRepartition3].[ID]

Where

    ((@ID Is Null) Or ([Essence].[ID] = @ID))
And ((@RegroupementID Is Null) Or ([Essence].[RegroupementID] = @RegroupementID))
And ((@ContingentID Is Null) Or ([Essence].[ContingentID] = @ContingentID))
And ((@RepartitionID Is Null) Or ([Essence].[RepartitionID] = @RepartitionID))
)



