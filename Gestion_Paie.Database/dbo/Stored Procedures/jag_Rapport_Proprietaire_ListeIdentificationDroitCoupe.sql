

CREATE PROCEDURE dbo.jag_Rapport_Proprietaire_ListeIdentificationDroitCoupe
	(		
		@DroitCoupeDebut varchar(15) = Null,
		@DroitCoupeFin varchar(15) = Null,
		@DateValide datetime = Null,
		@DateExpire datetime = Null
	)
AS

SET NOCOUNT ON

select 

Fou1.ID									as [DroitCoupeID],
Fou1.Nom								as [DroitCoupeNom],
Fou1.Rue								as [Rue],
Fou1.Ville								as [Ville],
Fou1.Code_postal						as [C.P.],
dbo.jag_Convert_Phone(Fou1.[Telephone]) As [Telephone],					
Fou2.ID									as [ProprietaireID],
Lot.[Droit_coupe_Date]					as [Date]

from Lot 
	inner join Fournisseur as Fou1 on Fou1.[ID] = Lot.[Droit_CoupeID]
	inner join Fournisseur as Fou2 on Fou2.[ID] = Lot.[ProprietaireID]
			
WHERE ((@DroitCoupeDebut is null) or (Lot.[Droit_CoupeID] >= @DroitCoupeDebut))
AND ((@DroitCoupeFin is null) or (Lot.[Droit_CoupeID] <= @DroitCoupeFin))
AND ((@DateValide is null) or (Lot.[Droit_coupe_Date] >= @DateValide))
AND ((@DateExpire is null) or (Lot.[Droit_coupe_Date] <= @DateExpire))

order by [DroitCoupeNom], Lot.[Droit_coupe_Date]

Return(@@RowCount)









