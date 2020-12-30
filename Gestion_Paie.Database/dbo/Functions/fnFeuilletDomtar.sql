CREATE FUNCTION [dbo].[fnFeuilletDomtar]
(@Transaction VARCHAR (15)=Null)
RETURNS TABLE 
AS
RETURN 
    (
Select TOP 100 PERCENT
 [Transaction]
,[TransactionType]
,[Fournisseur]
,[Contrat]
,[Produit]
,[DateLivraison]
,[Carte]
,[License]
,[Transporteur_Camion]
,[Producteur]
,[Municipalite]
,[Brut]
,[Tare]
,[Net]
,[Rejets]
,[KgVert_Paye]
,[Pourcent_Sec]
,[KgSec_Paye]
,[Validation]
,[Transfert]
,[EssenceID]
,[UniteID]
,[Code]
,[TransporteurID]
,[BonCommande]

From [dbo].[FeuilletDomtar]

Where

    ((@Transaction Is Null) Or ([Transaction] = @Transaction))
)



