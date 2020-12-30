

Create Function [fnFactureClient_Details_SelectDisplay]
(
 @FactureID [int] = Null
,@Ligne [int] = Null
,@Compte [int] = Null
)


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Returns Table

As

Return
(
Select
	 [FactureClient_Details].[FactureID]
	,[FactureClient1].[Display] [FactureID_Display]
	,[FactureClient_Details].[Ligne]
	,[FactureClient_Details].[Compte]
	,[Compte2].[Display] [Compte_Display]
	,[FactureClient_Details].[Montant]
	,[FactureClient_Details].[RefID]

From [dbo].[FactureClient_Details]
    Inner Join [fnFactureClient_Display](Null, Null, Null, Null, Null, Null) [FactureClient1] On [FactureID] = [FactureClient1].[ID1]
        Left Outer Join [fnCompte_Display](Null, Null) [Compte2] On [Compte] = [Compte2].[ID1]

Where

    ((@FactureID Is Null) Or ([FactureID] = @FactureID))
And ((@Ligne Is Null) Or ([Ligne] = @Ligne))
And ((@Compte Is Null) Or ([Compte] = @Compte))
)


