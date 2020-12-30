

CREATE PROCEDURE dbo.jag_IsLivraisonDetailInContingentement
	(
		@ContingentementID INT,
		@ProducteurID VARCHAR(10),
		@IsReallyInContingentement BIT = NULL OUTPUT
	)
AS

SET @IsReallyInContingentement = 0

IF (@ContingentementID IS NULL) 
BEGIN
	SET @IsReallyInContingentement = 0
	RETURN
END

IF ((SELECT COUNT(*) FROM Contingentement_Producteur 
			WHERE ContingentementID = @ContingentementID 
			AND ProducteurID = @ProducteurID) = 1)
BEGIN
	SET @IsReallyInContingentement = 1
END
ELSE 
BEGIN
	SET @IsReallyInContingentement = 0
END



