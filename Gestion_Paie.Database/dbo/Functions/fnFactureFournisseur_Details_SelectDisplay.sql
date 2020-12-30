

Create Function [fnFactureFournisseur_Details_SelectDisplay]
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
	 [FactureFournisseur_Details].[FactureID]
	,[FactureFournisseur1].[Display] [FactureID_Display]
	,[FactureFournisseur_Details].[Ligne]
	,[FactureFournisseur_Details].[Compte]
	,[Compte2].[Display] [Compte_Display]
	,[FactureFournisseur_Details].[Montant]
	,[FactureFournisseur_Details].[RefID]

From [dbo].[FactureFournisseur_Details]
    Inner Join [fnFactureFournisseur_Display](Null, Null, Null, Null, Null, Null) [FactureFournisseur1] On [FactureID] = [FactureFournisseur1].[ID1]
        Left Outer Join [fnCompte_Display](Null, Null) [Compte2] On [Compte] = [Compte2].[ID1]

Where

    ((@FactureID Is Null) Or ([FactureID] = @FactureID))
And ((@Ligne Is Null) Or ([Ligne] = @Ligne))
And ((@Compte Is Null) Or ([Compte] = @Compte))
)


