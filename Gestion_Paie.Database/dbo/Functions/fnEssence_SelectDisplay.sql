CREATE FUNCTION [dbo].[fnEssence_SelectDisplay]
(@ID VARCHAR (6)=Null, @RegroupementID INT=Null, @ContingentID INT=Null, @RepartitionID INT=Null)
RETURNS TABLE 
AS
RETURN 
    (
Select
	 [Essence].[ID]
	,[Essence].[Description]
	,[Essence].[RegroupementID]
	,[EssenceRegroupement1].[Display] [RegroupementID_Display]
	,[Essence].[ContingentID]
	,[EssenceContingent2].[Display] [ContingentID_Display]
	,[Essence].[RepartitionID]
	,[EssenceRepartition3].[Display] [RepartitionID_Display]
	,[Essence].[Actif]

From [dbo].[Essence]
    Left Outer Join [fnEssenceRegroupement_Display](Null) [EssenceRegroupement1] On [RegroupementID] = [EssenceRegroupement1].[ID1]
        Left Outer Join [fnEssenceContingent_Display](Null) [EssenceContingent2] On [ContingentID] = [EssenceContingent2].[ID1]
            Left Outer Join [fnEssenceRepartition_Display](Null) [EssenceRepartition3] On [RepartitionID] = [EssenceRepartition3].[ID1]

Where

    ((@ID Is Null) Or ([ID] = @ID))
And ((@RegroupementID Is Null) Or ([RegroupementID] = @RegroupementID))
And ((@ContingentID Is Null) Or ([ContingentID] = @ContingentID))
And ((@RepartitionID Is Null) Or ([RepartitionID] = @RepartitionID))
)



