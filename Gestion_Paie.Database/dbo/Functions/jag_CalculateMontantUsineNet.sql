

CREATE FUNCTION dbo.jag_CalculateMontantUsineNet
	(
		@LivraisonID INT
	)
RETURNS float
AS

BEGIN

	DECLARE @MontantNet FLOAT
	
	SELECT 
	@MontantNet = ROUND((L.Montant_Usine - L.Frais_AutresAuTransporteur - L.Frais_AutresAuProducteur + L.Frais_AutresRevenusProducteur + L.Frais_AutresRevenusTransporteur),2)
	FROM Livraison L
	WHERE L.[ID] = @LivraisonID	
	
	SET @MontantNet = (CASE WHEN @MontantNet IS NOT NULL THEN @MontantNet ELSE 0 END)
	RETURN @MontantNet

END













