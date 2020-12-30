
CREATE Procedure [spD_Ajustement]

-- Delete a specific record from table [Ajustement]

(
 @ID [int] -- for [Ajustement].[ID] column
,@ContratID [varchar](10) = Null -- for [Ajustement].[ContratID] column
)

-- Returns the number of deleted records

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Delete From [dbo].[Ajustement]

Where
    ((@ID Is Null) Or ([ID] = @ID))
And ((@ContratID Is Null) Or ([ContratID] = @ContratID))

Set NoCount Off

Return(@@RowCount)

