Create PROCEDURE [dbo].[jag_Get_FactureFournisseur_for_NumeroCheque]
(
	@CategoryID int = NULL,
	@Actif bit = 1
)
AS
select ID, NoFacture, Annee, FournisseurID, DateFactureAcomba, DatePaiementAcomba,NumeroCheque, NumeroPaiement, NumeroPaiementUnique 
from FactureFournisseur 
where 
isNull(NumeroCheque,'') =''
and isNull(NumeroPaiement,'') =''
and isNull(NumeroPaiementUnique,'') <> ''
