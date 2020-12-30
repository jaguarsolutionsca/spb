

CREATE PROCEDURE dbo.jag_Rapport_Proprietaire_LivraisonParProducteur
	(			
		@ProducteurDebut varchar(15) = Null,
		@ProducteurFin varchar(15) = Null,
		@PeriodeDebut int = Null,
		@PeriodeFin int = Null,
		@AnneeDebut int = Null,
		@AnneeFin int = Null	
	)
AS

SET NOCOUNT ON


SELECT
Fournisseur.ID,
Fournisseur.Nom,
Fournisseur.Rue,
Fournisseur.Ville,
Fournisseur.Code_postal,
Fournisseur.No_TPS,
Fournisseur.No_TVQ,
Livraison.Periode,
Livraison.Annee,
Contrat.UsineID,
Livraison_Detail.EssenceID,
Livraison.[ID] AS [Permis],
Livraison.NumeroFactureUsine As FactureUsine,
[Description] = Municipalite.[Description] +
	case when Livraison.[ZoneID] is null or Livraison.[ZoneID] = '0' then '' else ' (' + MZ.[Description] + ')' end,
Livraison_Detail.UniteMesureID,
Livraison_Detail.VolumeNet,
Livraison_Detail.Montant_Usine As Mnt_Usine,
Livraison_Detail.Montant_ProducteurNet As Mnt_Net,
NoFacture =
	case
		when Livraison_Detail.Droit_Coupe = 1 then (select top 1 NoFacture from FactureFournisseur where ID=Livraison.Producteur1_FactureID)
		when Livraison_Detail.Droit_Coupe = 0 then (select top 1 NoFacture from FactureFournisseur where ID=Livraison.Producteur2_FactureID)		
	end


FROM 
	Livraison 
		--inner join Lot L on Livraison.LotID = L.ID
		inner join Contrat on Contrat.[ID] = Livraison.ContratID
			inner join Livraison_detail on Livraison.[ID] = Livraison_detail.[LivraisonID]
				left outer join Municipalite on Municipalite.[ID] = Livraison.[MunicipaliteID] 
					left outer join Fournisseur on Fournisseur.[ID] = Livraison_detail.[ProducteurID]
						left outer join Municipalite_Zone MZ on MZ.[ID] = Livraison.ZoneID and MZ.MunicipaliteID=Livraison.MunicipaliteID

WHERE 

		((@ProducteurDebut	IS NULL) OR (Fournisseur.[ID]				>= @ProducteurDebut))
	AND	((@ProducteurFin	IS NULL) OR (Fournisseur.[ID]				<= @ProducteurFin))
	
	AND	((@PeriodeDebut is null and @AnneeDebut is null) or ( ((convert(char(4), Livraison.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,Livraison.[Periode]),2)))) >= ((convert(char(4), @AnneeDebut)) + (convert(varchar,RIGHT('00'+CONVERT(VARCHAR,@PeriodeDebut),2)))) ))
	AND	((@PeriodeFin is null and @AnneeFin is null) or ( ((convert(char(4), Livraison.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,Livraison.[Periode]),2)))) <= ((convert(char(4), @AnneeFin)) + (convert(varchar,RIGHT('00'+CONVERT(VARCHAR,@PeriodeFin),2)))) ))
	
Order by Fournisseur.Nom, Livraison.[Annee], Livraison.[Periode], Livraison.[ContratID], Municipalite.[Description], Livraison_detail.[UniteMesureID]
	

Return(@@RowCount)




