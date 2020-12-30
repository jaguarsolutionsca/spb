

CREATE PROCEDURE dbo.jag_EffacerCalculs_Indexation
	(
		@IndexationID int
	)
AS

DELETE FROM IndexationCalcule_Transporteur WHERE IndexationID = @IndexationID AND ((Facture = 0) OR (Facture IS NULL))
DELETE FROM IndexationCalcule_Producteur WHERE IndexationID = @IndexationID AND ((Facture = 0) OR (Facture IS NULL))

DELETE FROM IndexationCalcule_Transporteur 
WHERE IndexationDetailID IN (SELECT [ID] FROM Indexation_Municipalite WHERE IndexationID = @IndexationID)
AND ((Facture = 0) OR (Facture IS NULL))

DELETE FROM IndexationCalcule_Producteur
WHERE IndexationDetailID IN (SELECT [ID] FROM Indexation_EssenceUnite WHERE IndexationID = @IndexationID)
AND ((Facture = 0) OR (Facture IS NULL))



