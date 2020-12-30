

CREATE PROCEDURE dbo.jag_Rapport_Transporteur_ListeIdentificationTransporteurs
	(		
		@TransporteurDebut varchar(15) = Null,
		@TransporteurFin varchar(15) = Null
	)
AS

SET NOCOUNT ON



select 
Fournisseur.ID										as [TransporteurCode],
Fournisseur.Nom										as [TransporteurNom],
Fournisseur.Rep_Nom									as [Rep_Nom],
Fournisseur.Rue										as [TransporteurRue],
Fournisseur.Ville									as [Ville],
Fournisseur.Code_postal								as [CodePostal],
dbo.jag_Convert_Phone([Fournisseur].[Telephone])	as [Telephone],
Fournisseur.No_TPS									as [NoTPS],
Fournisseur.No_TVQ									as [NoTVQ],
Fournisseur_Camion.VR								as [VR]

from 
	Fournisseur
		left outer join Fournisseur_Camion on Fournisseur_Camion.FournisseurID = Fournisseur.[ID]
			
where 
		((@TransporteurDebut	is null) or (Fournisseur.[ID]	>= @TransporteurDebut))
	AND ((@TransporteurFin		is null) or (Fournisseur.[ID]	<= @TransporteurFin))
	AND (IsTransporteur = 1)
	
order by Fournisseur.Nom

Return(@@RowCount)









