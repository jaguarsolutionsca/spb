

CREATE PROCEDURE dbo.jag_Get_FournisseurEnPaiementManuel

AS

Select

F.[ID],
F.Nom,
(CASE WHEN F.IsProducteur = 1 THEN 'P' ELSE '' END) +
(CASE WHEN F.IsTransporteur = 1 THEN 'T' ELSE '' END) +
(CASE WHEN F.IsChargeur= 1 THEN 'C' ELSE '' END) +
(CASE WHEN F.IsAutre = 1 THEN 'A' ELSE '' END) AS [Type]
, F.PaiementManuel

From Fournisseur F

WHERE F.PaiementManuel = 1 
AND ((F.IsProducteur = 1) OR (F.IsTransporteur = 1) OR (F.IsChargeur= 1))
AND F.Actif = 1
ORDER BY F.[ID]

