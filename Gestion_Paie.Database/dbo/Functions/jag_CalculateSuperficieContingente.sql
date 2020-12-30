

CREATE FUNCTION dbo.jag_CalculateSuperficieContingente
	(
		@Superficie FLOAT
	)
RETURNS float
AS

BEGIN

	IF (@Superficie IS NULL)
	BEGIN
		RETURN 0
	END

	declare @Alloue FLOAT
	declare @Pourcentage FLOAT
	
	SELECT @Alloue = CONVERT(FLOAT, [Value]) FROM jag_SystemEx WHERE [Name] = 'SuperficieContingenteeSansDeduction'
	SELECT @Pourcentage = CONVERT(FLOAT, [Value]) FROM jag_SystemEx WHERE [Name] = 'SuperficieContingenteePourcentageDeduction'

	IF (@Alloue IS NULL)
	BEGIN
		SET @Alloue = 0
	END
		
	IF (@Pourcentage IS NULL)
	BEGIN
		SET @Pourcentage = 0
	END
	
	SET @Pourcentage = @Pourcentage / 100.0

	IF (@Superficie < @Alloue) RETURN @Superficie
	
	RETURN @Alloue + ((@Superficie-@Alloue)*(1-@Pourcentage))

END












