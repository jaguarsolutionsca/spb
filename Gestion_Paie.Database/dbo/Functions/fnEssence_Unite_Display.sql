CREATE FUNCTION [dbo].[fnEssence_Unite_Display]
(@EssenceID VARCHAR (6)=Null, @UniteID VARCHAR (6)=Null)
RETURNS TABLE 
AS
RETURN 
    (
Select TOP 100 PERCENT
 [EssenceID] As [ID1]
,[UniteID] As [ID2]
,[UniteID] As [Display]
	
From [dbo].[Essence_Unite]

Where
    ((@EssenceID Is Null) Or ([EssenceID] = @EssenceID))
And ((@UniteID Is Null) Or ([UniteID] = @UniteID))

Order By [Display]
)



