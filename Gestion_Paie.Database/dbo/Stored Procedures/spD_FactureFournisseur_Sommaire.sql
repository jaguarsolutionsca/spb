

Create Procedure [spD_FactureFournisseur_Sommaire]

-- Delete a specific record from table [FactureFournisseur_Sommaire]

(
 @FactureID [int] -- for [FactureFournisseur_Sommaire].[FactureID] column
,@Ligne [int] -- for [FactureFournisseur_Sommaire].[Ligne] column
,@Compte [int] = Null -- for [FactureFournisseur_Sommaire].[Compte] column
)

-- Returns the number of deleted records

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Delete From [dbo].[FactureFournisseur_Sommaire]

Where
    ((@FactureID Is Null) Or ([FactureID] = @FactureID))
And ((@Ligne Is Null) Or ([Ligne] = @Ligne))
And ((@Compte Is Null) Or ([Compte] = @Compte))

Set NoCount Off

Return(@@RowCount)


