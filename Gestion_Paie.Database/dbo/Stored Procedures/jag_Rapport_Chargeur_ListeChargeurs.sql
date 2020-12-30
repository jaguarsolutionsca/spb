

CREATE PROCEDURE dbo.jag_Rapport_Chargeur_ListeChargeurs
	(		
		@ChargeurDebut varchar(15) = Null,
		@ChargeurFin varchar(15) = Null
	)
AS

SET NOCOUNT ON



select 

Fournisseur.ID				as [ID],
Fournisseur.Nom				as [Nom],
Fournisseur.Rep_Nom			as [Rep_Nom]

from 
	Fournisseur
			
			
where 
		((@ChargeurDebut	is null) or (Fournisseur.[ID]	>= @ChargeurDebut))
	AND ((@ChargeurFin		is null) or (Fournisseur.[ID]	<= @ChargeurFin))
	AND (IsChargeur = 1)
	
order by Fournisseur.Nom

Return(@@RowCount)









