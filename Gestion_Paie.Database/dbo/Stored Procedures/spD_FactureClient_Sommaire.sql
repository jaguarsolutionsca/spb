

Create Procedure [spD_FactureClient_Sommaire]

-- Delete a specific record from table [FactureClient_Sommaire]

(
 @FactureID [int] -- for [FactureClient_Sommaire].[FactureID] column
,@Ligne [int] -- for [FactureClient_Sommaire].[Ligne] column
,@Compte [int] = Null -- for [FactureClient_Sommaire].[Compte] column
)

-- Returns the number of deleted records

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Delete From [dbo].[FactureClient_Sommaire]

Where
    ((@FactureID Is Null) Or ([FactureID] = @FactureID))
And ((@Ligne Is Null) Or ([Ligne] = @Ligne))
And ((@Compte Is Null) Or ([Compte] = @Compte))

Set NoCount Off

Return(@@RowCount)


