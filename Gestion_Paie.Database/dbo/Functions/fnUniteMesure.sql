

Create Function [fnUniteMesure]
(
 @ID [varchar](6) = Null
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
,[Nb_decimale]
,[Actif]
,[UseMontant]
,[Montant_Preleve_plan_conjoint]
,[Montant_Preleve_fond_roulement]
,[Montant_Preleve_fond_forestier]
,[Montant_Preleve_divers]
,[Pourc_Preleve_plan_conjoint]
,[Pourc_Preleve_fond_roulement]
,[Pourc_Preleve_fond_forestier]
,[Pourc_Preleve_divers]

From [dbo].[UniteMesure]

Where

    ((@ID Is Null) Or ([ID] = @ID))
)


