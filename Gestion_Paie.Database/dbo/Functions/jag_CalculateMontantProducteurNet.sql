CREATE FUNCTION [dbo].[jag_CalculateMontantProducteurNet]
(@LivraisonID INT, @ProducteurID VARCHAR (15))
RETURNS FLOAT
AS
BEGIN

	DECLARE @MontantNet FLOAT
	
	DECLARE @IsFirstProd BIT

	SET @IsFirstProd = 0
	
	IF EXISTS (SELECT * FROM Livraison WHERE Livraison.[ID] = @LivraisonID AND Livraison.DroitCoupeID = @ProducteurID)
	BEGIN
		SET @IsFirstProd = 1	
	END
	
	IF (@IsFirstProd = 1)
	BEGIN
		SELECT 
		@MontantNet = ROUND((L.Montant_Producteur1 - dbo.jag_CalculateMontantSurchargeAuProducteur(L.[ID], @ProducteurID) - L.Frais_ChargeurAuProducteur - L.Frais_AutresAuProducteur - L.Frais_AutresAuProducteurTransportSciage - L.Frais_CompensationDeDeplacement + L.Frais_AutresRevenusProducteur),2)
		FROM Livraison L
		WHERE L.[ID] = @LivraisonID
	END
	ELSE
	BEGIN
		SELECT 
		@MontantNet = L.Montant_Producteur2
		FROM Livraison L
		WHERE L.[ID] = @LivraisonID	
	END
	
	SET @MontantNet = (CASE WHEN @MontantNet IS NOT NULL THEN @MontantNet ELSE 0 END)
	RETURN @MontantNet

END


