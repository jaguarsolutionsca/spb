

Create Function [fnMunicipalite_Secteur_Display]
(
 @MunicipaliteID [varchar](6) = Null
,@Secteur [varchar](2) = Null
)


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Returns Table

As

Return
(
Select TOP 100 PERCENT
 [MunicipaliteID] As [ID1]
,[Secteur] As [ID2]
,[Secteur] As [Display]
	
From [dbo].[Municipalite_Secteur]

Where
    ((@MunicipaliteID Is Null) Or ([MunicipaliteID] = @MunicipaliteID))
And ((@Secteur Is Null) Or ([Secteur] = @Secteur))

Order By [Display]
)


