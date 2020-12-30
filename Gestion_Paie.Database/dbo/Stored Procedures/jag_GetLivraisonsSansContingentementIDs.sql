


CREATE PROCEDURE dbo.jag_GetLivraisonsSansContingentementIDs
AS

SET NOCOUNT ON

select 
LD.ID,
LD.LivraisonID,
LD.ContratID,
C.UsineID, 
E.RegroupementID, 
L.Annee, 
LD.EssenceID, 
LD.UniteMesureID, 
L.DatePaye, 
LD.ProducteurID

from 
	Livraison_detail LD inner join
	Livraison L on L.ID = LD.LivraisonID inner join
	Contrat C on C.ID = LD.ContratID inner join
	Essence E on E.ID = LD.EssenceID

where
	LD.ContingentementID is null



