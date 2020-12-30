

CREATE PROCEDURE dbo.jag_Update_FournisseurEnPaiementManuel
	(
		@FournisseurID VARCHAR(15),
		@IsManuel BIT
	)
AS

SET NOCOUNT ON

if (@FournisseurID IS NULL) RETURN
if (@IsManuel IS NULL) RETURN

UPDATE Fournisseur SET PaiementManuel = @IsManuel WHERE [ID] = @FournisseurID

