

CREATE Procedure jag_ListView_Contingentement
(
	@ContingentUsine [bit] = NULL,
	@CalculAccepte [bit] = NULL
)

As

IF @ContingentUsine = 0
BEGIN
	SELECT
	Contingentement.[ID],
	EssenceRegroupement.[Description] AS [Regroupement],
	Contingentement.Annee,
	--CONVERT(VARCHAR,UniteMesureID) + ' - ' + UniteMesure.[Description] AS [UniteMesure],
	UniteMesureID,
	Contingentement.[PeriodeContingentement],
	CalculAccepte
	FROM Contingentement
		INNER JOIN EssenceRegroupement ON EssenceRegroupement.[ID] = RegroupementID
		INNER JOIN UniteMesure ON UniteMesure.[ID] = UniteMesureID
	WHERE (ContingentUsine = @ContingentUsine)
	AND ((@CalculAccepte IS NULL) OR (CalculAccepte = @CalculAccepte))
END
ELSE IF (@ContingentUsine = 1)
BEGIN
	SELECT
	Contingentement.[ID],
	CONVERT(VARCHAR,Contingentement.UsineID) + ' - ' + Usine.[Description] AS [Usine],
	Contingentement.Annee,
	--CONVERT(VARCHAR,EssenceID) + ' - ' + Essence.[Description] AS [Essence],
	EssenceID + ' ' + LTRIM(RTRIM(Code)) AS [Essence],
	--CONVERT(VARCHAR,UniteMesureID) + ' - ' + UniteMesure.[Description] AS [UniteMesure],
	UniteMesureID,
	Contingentement.[PeriodeContingentement],
	CalculAccepte
	FROM Contingentement
		INNER JOIN Usine ON Usine.[ID] = Contingentement.UsineID
		INNER JOIN Essence ON Essence.[ID] = EssenceID
		INNER JOIN UniteMesure ON UniteMesure.[ID] = UniteMesureID
	WHERE (ContingentUsine = @ContingentUsine)
	AND ((@CalculAccepte IS NULL) OR (CalculAccepte = @CalculAccepte))
END
ELSE IF (@ContingentUsine IS NULL)
BEGIN
	SELECT
	Contingentement.[ID],
	CONVERT(VARCHAR,Contingentement.UsineID) + ' - ' + Usine.[Description] AS [Usine],
	EssenceRegroupement.[Description] AS [Regroupement],
	Contingentement.Annee,
	--CONVERT(VARCHAR,EssenceID) + ' - ' + Essence.[Description] AS [Essence],
	EssenceID + ' ' + LTRIM(RTRIM(Code)) AS [Essence],
	--CONVERT(VARCHAR,UniteMesureID) + ' - ' + UniteMesure.[Description] AS [UniteMesure],
	UniteMesureID,
	Contingentement.[PeriodeContingentement],
	CalculAccepte
	FROM Contingentement
		LEFT OUTER JOIN Usine ON Usine.[ID] = Contingentement.UsineID
		LEFT OUTER JOIN EssenceRegroupement ON EssenceRegroupement.[ID] = RegroupementID
		LEFT OUTER JOIN Essence ON Essence.[ID] = EssenceID
		INNER JOIN UniteMesure ON UniteMesure.[ID] = UniteMesureID
	WHERE ((@CalculAccepte IS NULL) OR (CalculAccepte = @CalculAccepte))
END

RETURN








