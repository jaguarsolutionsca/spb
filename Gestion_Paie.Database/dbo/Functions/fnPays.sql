

Create Function [fnPays]
(
 @ID [varchar](2) = Null
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
,[Nom]
,[CodePostal_InputMask]
,[Actif]

From [dbo].[Pays]

Where

    ((@ID Is Null) Or ([ID] = @ID))
)


