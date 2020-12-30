

Create Procedure [spD_FactureClient_Details]

-- Delete a specific record from table [FactureClient_Details]

(
 @FactureID [int] -- for [FactureClient_Details].[FactureID] column
,@Ligne [int] -- for [FactureClient_Details].[Ligne] column
,@Compte [int] = Null -- for [FactureClient_Details].[Compte] column
)

-- Returns the number of deleted records

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Delete From [dbo].[FactureClient_Details]

Where
    ((@FactureID Is Null) Or ([FactureID] = @FactureID))
And ((@Ligne Is Null) Or ([Ligne] = @Ligne))
And ((@Compte Is Null) Or ([Compte] = @Compte))

Set NoCount Off

Return(@@RowCount)


