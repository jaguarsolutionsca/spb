

Create Function [fnMunicipalite_Zone_Display]
(
 @ID [varchar](2) = Null
,@MunicipaliteID [varchar](6) = Null
)


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Returns Table

As

Return
(
Select TOP 100 PERCENT
 [ID] As [ID1]
,[MunicipaliteID] As [ID2]
,[Description] As [Display]
	
From [dbo].[Municipalite_Zone]

Where
    ((@ID Is Null) Or ([ID] = @ID))
And ((@MunicipaliteID Is Null) Or ([MunicipaliteID] = @MunicipaliteID))

Order By [Display]
)


