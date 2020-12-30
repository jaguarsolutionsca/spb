



CREATE PROCEDURE dbo.jag_Clear_FactureEnAttente
/*	(
		
	)*/
AS

SET NOCOUNT ON

DECLARE @FactureFournisseur TABLE
(
	[ID] INT
)

DECLARE @FactureClient TABLE
(
	[ID] INT
)

INSERT INTO @FactureFournisseur
SELECT [ID] FROM FactureFournisseur WHERE Status = 'Attente'

INSERT INTO @FactureClient
SELECT [ID] FROM FactureClient WHERE Status = 'Attente'

UPDATE Livraison SET
Producteur1_FactureID = NULL
WHERE ((Producteur1_FactureID IS NOT NULL) AND (Producteur1_FactureID in (SELECT [ID] FROM @FactureFournisseur)))

UPDATE Livraison SET
Producteur2_FactureID = NULL
WHERE ((Producteur2_FactureID IS NOT NULL) AND (Producteur2_FactureID in (SELECT [ID] FROM @FactureFournisseur)))

UPDATE Livraison SET
Transporteur_FactureID = NULL
WHERE ((Transporteur_FactureID IS NOT NULL) AND (Transporteur_FactureID in (SELECT [ID] FROM @FactureFournisseur)))

UPDATE Livraison SET
Chargeur_FactureID = NULL
WHERE ((Chargeur_FactureID IS NOT NULL) AND (Chargeur_FactureID in (SELECT [ID] FROM @FactureFournisseur)))

UPDATE Livraison SET
Usine_FactureID = NULL
WHERE ((Usine_FactureID IS NOT NULL) AND (Usine_FactureID in (SELECT [ID] FROM @FactureClient)))

UPDATE AjustementCalcule_Producteur SET
Facture = 0,
FactureID = NULL
WHERE ((FactureID IS NOT NULL) AND (FactureID in (SELECT [ID] FROM @FactureFournisseur)))

UPDATE AjustementCalcule_Transporteur SET
Facture = 0,
FactureID = NULL
WHERE ((FactureID IS NOT NULL) AND (FactureID in (SELECT [ID] FROM @FactureFournisseur)))

UPDATE AjustementCalcule_Usine SET
Facture = 0,
FactureID = NULL
WHERE ((FactureID IS NOT NULL) AND (FactureID in (SELECT [ID] FROM @FactureClient)))

UPDATE IndexationCalcule_Transporteur SET
Facture = 0,
FactureID = NULL
WHERE ((FactureID IS NOT NULL) AND (FactureID in (SELECT [ID] FROM @FactureFournisseur)))

UPDATE IndexationCalcule_Producteur SET
Facture = 0,
FactureID = NULL
WHERE ((FactureID IS NOT NULL) AND (FactureID in (SELECT [ID] FROM @FactureFournisseur)))

UPDATE Livraison SET
Facture = 0
WHERE ((Producteur1_FactureID IS NULL) AND (Producteur2_FactureID IS NULL) AND (Transporteur_FactureID IS NULL) AND (Usine_FactureID IS NULL))

UPDATE Indexation SET
Facture = 0
WHERE [ID] IN (SELECT IndexationID FROM IndexationCalcule_Transporteur ICT WHERE ICT.Facture = 0)

UPDATE Indexation SET
Facture = 0
WHERE [ID] IN (SELECT IndexationID FROM IndexationCalcule_Producteur ICP WHERE ICP.Facture = 0)

UPDATE Ajustement SET
Facture = 0
WHERE [ID] IN (SELECT AjustementID FROM AjustementCalcule_Producteur ACP WHERE ACP.Facture = 0)

UPDATE Ajustement SET
Facture = 0
WHERE [ID] IN (SELECT AjustementID FROM AjustementCalcule_Transporteur ACT WHERE ACT.Facture = 0)

UPDATE Ajustement SET
Facture = 0
WHERE [ID] IN (SELECT AjustementID FROM AjustementCalcule_Usine ACU WHERE ACU.Facture = 0)

DELETE FactureFournisseur_Details WHERE FactureID in (SELECT [ID] FROM @FactureFournisseur)
DELETE FactureFournisseur_Sommaire WHERE FactureID in (SELECT [ID] FROM @FactureFournisseur)
DELETE FactureFournisseur WHERE [ID] IN (SELECT [ID] FROM @FactureFournisseur)

DELETE FactureClient_Details WHERE FactureID in (SELECT [ID] FROM @FactureClient)
DELETE FactureClient_Sommaire WHERE FactureID in (SELECT [ID] FROM @FactureClient)
DELETE FactureClient WHERE [ID] IN (SELECT [ID] FROM @FactureClient)









