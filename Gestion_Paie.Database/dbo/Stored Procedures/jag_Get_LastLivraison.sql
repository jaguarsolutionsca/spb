

Create PROCEDURE [dbo].[jag_Get_LastLivraison]
(
	@RegroupementID int,
	@ProducteurID varchar(15) = null,
	@DateDebutContingent datetime = Null
)
AS

Begin

	select top 1 
	LD.ID,
	LD.LivraisonID,
	LD.ContratID,
	LD.ProducteurID,
	C.UsineID, 
	E.RegroupementID, 
	L.Annee, 
	L.DateLivraison,
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
		E.RegroupementID = @RegroupementID
		and LD.ProducteurID = @ProducteurID
		and L.DateLivraison < @DateDebutContingent
		
	order by L.DateLivraison desc

	
End



