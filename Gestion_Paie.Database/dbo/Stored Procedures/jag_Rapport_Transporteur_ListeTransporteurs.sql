

CREATE PROCEDURE dbo.jag_Rapport_Transporteur_ListeTransporteurs
	(		
		@TransporteurDebut varchar(15) = Null,
		@TransporteurFin varchar(15) = Null
	)
AS

SET NOCOUNT ON



select 

Fournisseur.ID				as [TransporteurID],
Fournisseur.Nom				as [TransporteurNom],
Fournisseur.Rep_Nom			as [Rep_Nom]

from 
	Fournisseur
			
			
where 
		((@TransporteurDebut	is null) or (Fournisseur.[ID]	>= @TransporteurDebut))
	AND ((@TransporteurFin		is null) or (Fournisseur.[ID]	<= @TransporteurFin))
	AND (IsTransporteur = 1)
	
order by Fournisseur.Nom

Return(@@RowCount)









