

CREATE FUNCTION dbo.jag_GetCompteMEC
	(
	
		@UsineID VARCHAR(6)
	
	)
RETURNS INT
AS

BEGIN
	DECLARE @Compte INT
	
	SELECT
	@Compte = Compte_mise_en_commun
	FROM Usine
	WHERE Usine.[ID] = @UsineID

RETURN @Compte
END









