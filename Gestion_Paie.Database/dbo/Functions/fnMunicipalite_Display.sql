

Create Function [fnMunicipalite_Display]
(
 @ID [varchar](6) = Null
,@MrcID [varchar](6) = Null
,@AgenceID [varchar](4) = Null
)


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Returns Table

As

Return
(
Select TOP 100 PERCENT
 [ID] As [ID1]
,[Description] As [Display]
	
From [dbo].[Municipalite]

Where
    ((@ID Is Null) Or ([ID] = @ID))
And ((@MrcID Is Null) Or ([MrcID] = @MrcID))
And ((@AgenceID Is Null) Or ([AgenceID] = @AgenceID))

Order By [Display]
)


