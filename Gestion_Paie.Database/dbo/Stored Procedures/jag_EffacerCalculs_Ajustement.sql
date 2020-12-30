

CREATE PROCEDURE [dbo].[jag_EffacerCalculs_Ajustement]
	(
		@AjustementID int
	)
AS

SET NOCOUNT ON

DELETE FROM AjustementCalcule_Producteur WHERE AjustementID = @AjustementID AND ((Facture = 0) OR (Facture IS NULL))
DELETE FROM AjustementCalcule_Transporteur WHERE AjustementID = @AjustementID AND ((Facture = 0) OR (Facture IS NULL))
DELETE FROM AjustementCalcule_TransporteurEssence WHERE AjustementID = @AjustementID AND ((Facture = 0) OR (Facture IS NULL))
DELETE FROM AjustementCalcule_Usine WHERE AjustementID = @AjustementID AND ((Facture = 0) OR (Facture IS NULL))
