








CREATE PROCEDURE dbo.jag_UpdateStatus_FactureFournisseur
	(
		@FactureID INT,
		@Status VARCHAR(15),
		@StatusDescription VARCHAR(300) = NULL
	)
AS

SET NOCOUNT ON

UPDATE FactureFournisseur SET
Status = @Status,
StatusDescription = @StatusDescription
WHERE [ID] = @FactureID








