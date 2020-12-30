CREATE PROCEDURE [dbo].[spS_FeuilletDomtar]
@Transaction VARCHAR (15)=Null, @ReturnXML BIT=0
AS
If @ReturnXML Is Null
	Set @ReturnXML = 0

If @ReturnXML = 0
	Begin
		Select

		 [FeuilletDomtar_Records].[Transaction]
		,[FeuilletDomtar_Records].[TransactionType]
		,[FeuilletDomtar_Records].[Fournisseur]
		,[FeuilletDomtar_Records].[Contrat]
		,[FeuilletDomtar_Records].[Produit]
		,[FeuilletDomtar_Records].[DateLivraison]
		,[FeuilletDomtar_Records].[Carte]
		,[FeuilletDomtar_Records].[License]
		,[FeuilletDomtar_Records].[Transporteur_Camion]
		,[FeuilletDomtar_Records].[Producteur]
		,[FeuilletDomtar_Records].[Municipalite]
		,[FeuilletDomtar_Records].[Brut]
		,[FeuilletDomtar_Records].[Tare]
		,[FeuilletDomtar_Records].[Net]
		,[FeuilletDomtar_Records].[Rejets]
		,[FeuilletDomtar_Records].[KgVert_Paye]
		,[FeuilletDomtar_Records].[Pourcent_Sec]
		,[FeuilletDomtar_Records].[KgSec_Paye]
		,[FeuilletDomtar_Records].[Validation]
		,[FeuilletDomtar_Records].[Transfert]
		,[FeuilletDomtar_Records].[EssenceID]
		,[FeuilletDomtar_Records].[UniteID]
		,[FeuilletDomtar_Records].[Code]
		,[FeuilletDomtar_Records].[TransporteurID]
		,[FeuilletDomtar_Records].[BonCommande]

		From [fnFeuilletDomtar](@Transaction) As [FeuilletDomtar_Records]
	End

Else

	Begin
		Select

		 [FeuilletDomtar_Records].[Transaction]
		,[FeuilletDomtar_Records].[TransactionType]
		,[FeuilletDomtar_Records].[Fournisseur]
		,[FeuilletDomtar_Records].[Contrat]
		,[FeuilletDomtar_Records].[Produit]
		,[FeuilletDomtar_Records].[DateLivraison]
		,[FeuilletDomtar_Records].[Carte]
		,[FeuilletDomtar_Records].[License]
		,[FeuilletDomtar_Records].[Transporteur_Camion]
		,[FeuilletDomtar_Records].[Producteur]
		,[FeuilletDomtar_Records].[Municipalite]
		,[FeuilletDomtar_Records].[Brut]
		,[FeuilletDomtar_Records].[Tare]
		,[FeuilletDomtar_Records].[Net]
		,[FeuilletDomtar_Records].[Rejets]
		,[FeuilletDomtar_Records].[KgVert_Paye]
		,[FeuilletDomtar_Records].[Pourcent_Sec]
		,[FeuilletDomtar_Records].[KgSec_Paye]
		,[FeuilletDomtar_Records].[Validation]
		,[FeuilletDomtar_Records].[Transfert]
		,[FeuilletDomtar_Records].[EssenceID]
		,[FeuilletDomtar_Records].[UniteID]
		,[FeuilletDomtar_Records].[Code]
		,[FeuilletDomtar_Records].[TransporteurID]
		,[FeuilletDomtar_Records].[BonCommande]

		From [fnFeuilletDomtar](@Transaction) As [FeuilletDomtar_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)


