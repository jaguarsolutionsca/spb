

Create Function [fnCompte_SelectDisplay]
(
 @ID [int] = Null
,@CategoryID [int] = Null
)


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Returns Table

As

Return
(
Select
	 [Compte].[ID]
	,[Compte].[Description]
	,[Compte].[CategoryID]
	,[CompteCategory1].[Display] [CategoryID_Display]
	,[Compte].[isTaxe]
	,[Compte].[Actif]

From [dbo].[Compte]
    Left Outer Join [fnCompteCategory_Display](Null) [CompteCategory1] On [CategoryID] = [CompteCategory1].[ID1]

Where

    ((@ID Is Null) Or ([ID] = @ID))
And ((@CategoryID Is Null) Or ([CategoryID] = @CategoryID))
)


