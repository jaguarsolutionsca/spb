

CREATE PROCEDURE dbo.jag_Get_ClientsFromFacturesEnAttente

AS

SET NOCOUNT ON

SELECT DISTINCT
FC.ClientID AS [ID]
FROM FactureClient FC
WHERE FC.ClientID IS NOT NULL
AND FC.Status = 'Attente'
ORDER BY FC.ClientID



