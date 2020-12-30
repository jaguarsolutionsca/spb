

CREATE FUNCTION dbo.jag_CalculateMontantSurchargeAuProducteur
	(
		@LivraisonID INT,
		@ProducteurID VARCHAR(15)
	)
RETURNS float
AS

BEGIN

	DECLARE @Montant FLOAT
	SET @Montant = 0
	
	DECLARE @IsFirstProd BIT
	DECLARE @TransporteurPayeSurcharge BIT

	SET @IsFirstProd = 0
	SET @TransporteurPayeSurcharge = 0
	
	IF EXISTS (SELECT * FROM Livraison WHERE Livraison.[ID] = @LivraisonID AND Livraison.DroitCoupeID = @ProducteurID)
	BEGIN
		SET @IsFirstProd = 1	
	END
	
	SELECT @TransporteurPayeSurcharge = PaieTransporteur FROM Livraison WHERE Livraison.[ID] = @LivraisonID

	IF ((@IsFirstProd = 1) AND (@TransporteurPayeSurcharge = 0))
	BEGIN
		SELECT 
		@Montant = round(L.VolumeSurcharge * C.Taux_Surcharge, 2)
		FROM Livraison L
			INNER JOIN Contrat C ON C.[ID] = L.ContratID
		WHERE L.[ID] = @LivraisonID	
	END
	
	SET @Montant = (CASE WHEN @Montant IS NOT NULL THEN @Montant ELSE 0 END)
	RETURN @Montant

END













