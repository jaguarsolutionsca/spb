
CREATE Procedure [spD_Contingentement_Producteur]

-- Delete a specific record from table [Contingentement_Producteur]

(
 @ContingentementID [int] -- for [Contingentement_Producteur].[ContingentementID] column
,@ProducteurID [varchar](15) -- for [Contingentement_Producteur].[ProducteurID] column
)

-- Returns the number of deleted records

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Delete From [dbo].[Contingentement_Producteur]

Where
    ((@ContingentementID Is Null) Or ([ContingentementID] = @ContingentementID))
And ((@ProducteurID Is Null) Or ([ProducteurID] = @ProducteurID))

Set NoCount Off

Return(@@RowCount)

