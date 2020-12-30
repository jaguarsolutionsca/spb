

Create Function [fnCompte]
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
 [ID]
,[Description]
,[CategoryID]
,[isTaxe]
,[Actif]

From [dbo].[Compte]

Where

    ((@ID Is Null) Or ([ID] = @ID))
And ((@CategoryID Is Null) Or ([CategoryID] = @CategoryID))
)


