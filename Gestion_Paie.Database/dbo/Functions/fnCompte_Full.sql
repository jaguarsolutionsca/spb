

Create Function [fnCompte_Full]

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
Select TOP 100 PERCENT
 [Compte].[ID]
,[Compte].[Description]
,[Compte].[CategoryID]
,[Compte].[isTaxe]
,[Compte].[Actif]
,[CompteCategory1].[ID] [CategoryID_ID]
,[CompteCategory1].[Description] [CategoryID_Description]

From [dbo].[Compte] [Compte]
    Left Outer Join [dbo].[CompteCategory] [CompteCategory1] On [Compte].[CategoryID] = [CompteCategory1].[ID]

Where

    ((@ID Is Null) Or ([Compte].[ID] = @ID))
And ((@CategoryID Is Null) Or ([Compte].[CategoryID] = @CategoryID))
)



