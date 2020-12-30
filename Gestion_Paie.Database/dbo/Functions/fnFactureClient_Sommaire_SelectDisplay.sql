

Create Function [fnFactureClient_Sommaire_SelectDisplay]
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
	 [FactureClient_Sommaire].[FactureID]
	,[FactureClient1].[Display] [FactureID_Display]
	,[FactureClient_Sommaire].[Ligne]
	,[FactureClient_Sommaire].[Compte]
	,[Compte2].[Display] [Compte_Display]
	,[FactureClient_Sommaire].[Montant]
	,[FactureClient_Sommaire].[Description]
	,[FactureClient_Sommaire].[isTaxe]

From [dbo].[FactureClient_Sommaire]
    Inner Join [fnFactureClient_Display](Null, Null, Null, Null, Null, Null) [FactureClient1] On [FactureID] = [FactureClient1].[ID1]
        Left Outer Join [fnCompte_Display](Null, Null) [Compte2] On [Compte] = [Compte2].[ID1]

Where

    ((@FactureID Is Null) Or ([FactureID] = @FactureID))
And ((@Ligne Is Null) Or ([Ligne] = @Ligne))
And ((@Compte Is Null) Or ([Compte] = @Compte))
)


