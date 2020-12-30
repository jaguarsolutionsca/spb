

CREATE FUNCTION dbo.jag_GetCompteIndexation
	(
	
		@UsineID VARCHAR(6)
	
	)
RETURNS INT
AS

BEGIN
	DECLARE @Compte INT
	
	SELECT
	@Compte = Compte_indexation_carburant
	FROM Usine
	WHERE Usine.[ID] = @UsineID

RETURN @Compte
END









