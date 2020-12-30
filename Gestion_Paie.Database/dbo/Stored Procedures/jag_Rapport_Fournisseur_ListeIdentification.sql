

CREATE PROCEDURE dbo.jag_Rapport_Fournisseur_ListeIdentification
	(		
		@FouDebut varchar(15) = Null,
		@FouFin varchar(15) = Null,
		@TypeFou char(1) = 'C'
	)
AS

SET NOCOUNT ON



select 
Fournisseur.ID										as [Code],
Fournisseur.Nom										as [Nom],
Fournisseur.Rep_Nom									as [Rep_Nom],
Fournisseur.Rue										as [Rue],
Fournisseur.Ville									as [Ville],
Fournisseur.Code_postal								as [CodePostal],
dbo.jag_Convert_Phone([Fournisseur].[Telephone])	as [Telephone],
Fournisseur.No_TPS									as [NoTPS],
Fournisseur.No_TVQ									as [NoTVQ]

from Fournisseur
			
where ((@FouDebut	is null) or (Fournisseur.[ID]	>= @FouDebut))
AND ((@FouFin		is null) or (Fournisseur.[ID]	<= @FouFin))
AND (((@TypeFou = 'C') AND (IsChargeur = 1)) OR
	 ((@TypeFou = 'A') AND (IsAutre = 1)) OR
	 ((@TypeFou = 'P') AND (IsProducteur = 1)) OR
	 ((@TypeFou = 'T') AND (IsTransporteur = 1)))
	
order by Fournisseur.Nom

Return(@@RowCount)









