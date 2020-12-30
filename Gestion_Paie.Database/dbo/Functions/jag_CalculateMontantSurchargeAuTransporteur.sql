

CREATE FUNCTION dbo.jag_CalculateMontantSurchargeAuTransporteur
	(
		@LivraisonID INT
	)
RETURNS float
AS

BEGIN

	DECLARE @Montant FLOAT
	SET @Montant = 0
	
	DECLARE @TransporteurPayeSurcharge BIT
	SET @TransporteurPayeSurcharge = 0
	
	SELECT @TransporteurPayeSurcharge = PaieTransporteur FROM Livraison WHERE Livraison.[ID] = @LivraisonID

	IF (@TransporteurPayeSurcharge = 1)
	BEGIN
		SELECT 
		@Montant = L.Montant_Surcharge
		FROM Livraison L
		WHERE L.[ID] = @LivraisonID	
	END
	
	SET @Montant = (CASE WHEN @Montant IS NOT NULL THEN @Montant ELSE 0 END)
	RETURN @Montant

END












