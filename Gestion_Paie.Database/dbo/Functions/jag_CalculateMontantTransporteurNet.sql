

CREATE FUNCTION dbo.jag_CalculateMontantTransporteurNet
	(
		@LivraisonID INT
	)
RETURNS float
AS

BEGIN

	DECLARE @MontantNet FLOAT
	
	SELECT 
	@MontantNet = ROUND((L.Montant_Transporteur - L.Frais_ChargeurAuTransporteur - L.Frais_AutresAuTransporteur + L.Frais_AutresRevenusTransporteur + L.Frais_CompensationDeDeplacement),2)
	FROM Livraison L
	WHERE L.[ID] = @LivraisonID	
	
	SET @MontantNet = (CASE WHEN @MontantNet IS NOT NULL THEN @MontantNet ELSE 0 END)
	RETURN @MontantNet

END













