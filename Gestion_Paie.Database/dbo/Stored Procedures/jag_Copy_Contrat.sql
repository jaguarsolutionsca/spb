

CREATE PROCEDURE dbo.jag_Copy_Contrat
	(
		@ID varchar(10),
		@Annee int,
		@NewID varchar(10) output
	)
AS

SET NOCOUNT ON

declare @UsineID varchar(6)
SELECT @UsineID = UsineID FROM Contrat WHERE [ID] = @ID
SET @NewID = @UsineID + CONVERT(VARCHAR, @Annee)

IF (EXISTS (SELECT * FROM Contrat WHERE [ID] = @NewID))
BEGIN
	SET @NewID = NULL
	RETURN
END

INSERT INTO Contrat ([ID], [Description], UsineID, Annee, Date_debut, Date_fin, Actif, PaieTransporteur, Taux_Surcharge, SurchargeManuel, TxTransSameProd)
SELECT
@NewID,
[Description],
UsineID,
@Annee,
CONVERT(DATETIME, CONVERT(VARCHAR,@Annee) + '/' + CONVERT(VARCHAR,DATEPART(mm, Date_debut)) + '/' + CONVERT(VARCHAR,DATEPART(dd, Date_debut))),
CONVERT(DATETIME, CONVERT(VARCHAR,@Annee) + '/' + CONVERT(VARCHAR,DATEPART(mm, Date_fin)) + '/' + CONVERT(VARCHAR,DATEPART(dd, Date_fin))),
Actif,
PaieTransporteur,
Taux_Surcharge,
SurchargeManuel,
TxTransSameProd
FROM Contrat WHERE [ID] = @ID

INSERT INTO Contrat_EssenceUnite (ContratID, EssenceID, UniteID, Code, Quantite_prevue, Taux_usine, Taux_producteur, Actif, [Description])
SELECT
@NewID,
EssenceID,
UniteID,
Code,
Quantite_prevue,
Taux_usine,
Taux_producteur,
Actif,
[Description]
FROM Contrat_EssenceUnite WHERE ContratID = @ID

INSERT INTO Contrat_Transporteur (ContratID, UniteID, MunicipaliteID, Taux_transporteur, Taux_producteur, Actif, ZoneID)
SELECT
@NewID,
UniteID,
MunicipaliteID,
Taux_transporteur,
Taux_producteur,
Actif,
ZoneID
FROM Contrat_Transporteur WHERE ContratID = @ID


