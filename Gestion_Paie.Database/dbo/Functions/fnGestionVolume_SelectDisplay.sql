

Create Function [fnGestionVolume_SelectDisplay]
(
 @ID [int] = Null
,@UsineID [varchar](6) = Null
,@UniteMesureID [varchar](6) = Null
,@ProducteurID [varchar](15) = Null
,@LotID [int] = Null
)


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Returns Table

As

Return
(
Select
	 [GestionVolume].[ID]
	,[GestionVolume].[DateLivraison]
	,[GestionVolume].[UsineID]
	,[Usine1].[Display] [UsineID_Display]
	,[GestionVolume].[UniteMesureID]
	,[UniteMesure2].[Display] [UniteMesureID_Display]
	,[GestionVolume].[ProducteurID]
	,[Fournisseur3].[Display] [ProducteurID_Display]
	,[GestionVolume].[Annee]
	,[GestionVolume].[Periode]
	,[GestionVolume].[LotID]
	,[Lot4].[Display] [LotID_Display]
	,[GestionVolume].[DateEntree]

From [dbo].[GestionVolume]
    Left Outer Join [fnUsine_Display](Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null) [Usine1] On [UsineID] = [Usine1].[ID1]
        Left Outer Join [fnUniteMesure_Display](Null) [UniteMesure2] On [UniteMesureID] = [UniteMesure2].[ID1]
            Left Outer Join [fnFournisseur_Display](Null, Null, Null) [Fournisseur3] On [ProducteurID] = [Fournisseur3].[ID1]
                Left Outer Join [fnLot_Display](Null, Null, Null, Null, Null, Null, Null, Null) [Lot4] On [LotID] = [Lot4].[ID1]

Where

    ((@ID Is Null) Or ([ID] = @ID))
And ((@UsineID Is Null) Or ([UsineID] = @UsineID))
And ((@UniteMesureID Is Null) Or ([UniteMesureID] = @UniteMesureID))
And ((@ProducteurID Is Null) Or ([ProducteurID] = @ProducteurID))
And ((@LotID Is Null) Or ([LotID] = @LotID))
)


