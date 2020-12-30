

CREATE FUNCTION dbo.jag_CalculateMontantChargeurNet
	(
		@LivraisonID INT
	)
RETURNS float
AS

BEGIN

	DECLARE @MontantNet FLOAT
	
	SELECT 
	@MontantNet = Montant_Chargeur
	FROM Livraison L
	WHERE L.[ID] = @LivraisonID	
	
	SET @MontantNet = (CASE WHEN @MontantNet IS NOT NULL THEN @MontantNet ELSE 0 END)
	RETURN @MontantNet

END












