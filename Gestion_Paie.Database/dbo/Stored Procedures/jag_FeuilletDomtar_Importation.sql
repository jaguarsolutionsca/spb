CREATE PROCEDURE [dbo].[jag_FeuilletDomtar_Importation]
@filename VARCHAR (256)
AS
BEGIN


SET NOCOUNT ON


--SET @filename = 'C:\temp\Domtar.txt'

IF OBJECT_ID('tempdb..#tempFeuilletDomtar') IS NOT NULL
	DROP TABLE #tempFeuilletDomtar

create table #tempFeuilletDomtar
(
	[Transaction] [varchar] (15) NOT NULL,
	[TransactionType] [varchar] (3) NULL,
	[Fournisseur] [varchar] (15) NULL,
	[Contrat] [varchar] (55) NULL,
	[Produit] [varchar] (10) NULL,
	[DateLivraison] [varchar] (15) NULL,
	[HeureLivraison] [varchar] (15) NULL,
	[Carte] [varchar] (15) NULL,
	[License] [varchar] (15) NULL,
	[Transporteur]  [varchar] (15) NULL,
	[Producteur_1] [varchar] (15) NULL,
	[Producteur_2] [varchar] (15) NULL,
	[Producteur_3] [varchar] (15) NULL,
	[Producteur_4] [varchar] (15) NULL,
	[Producteur_5] [varchar] (15) NULL,
	[Municipalite_1] [varchar](15) NULL,
	[Municipalite_2] [varchar](15) NULL,
	[Municipalite_3] [varchar](15) NULL,
	[Municipalite_4] [varchar](15) NULL,
	[Municipalite_5] [varchar](15) NULL,
	[Brut] [int] NULL,
	[Tare] [int] NULL,
	[Net] [int] NULL,
	[Rejets] [int] NULL,
	[KgVert_Paye] [int] NULL,
	[Pourcent_Sec] [float] NULL,
	[KgSec_Paye] [float] NULL,
	[Taux] [float] NULL,
	[Paiement][float] NULL,
	[Montant_TPS] [float] NULL,
	[Montant_TVQ] [float] NULL,
	[Montant_Total] [float] NULL,
	[TMV_Echantillon] [float] NULL,
	[TMA_Echantillon] [float] NULL,
	[Pourcent_Sec_Moyen] [float] NULL,
	[Statut] [varchar] (15) NULL,
	[Essence1] [varchar] (15) NULL,
	[Pourcent_Essence1] [float] NULL,
	[Essence2] [varchar] (255) NULL,
	[Pourcent_Essence2] [float] NULL,
	[Chipper] [varchar] (50) NULL,
	[Manifeste] [varchar] (255) NULL,
	[Douane] [varchar] (25) NULL,
	[Chantier] [varchar] (15) NULL,
	[Chemin] [varchar] (15) NULL,
	[UC] [varchar] (25) NULL,
	[Pourcent_Rejets] [float] NULL,
	[Pourcent_Ecorce] [float] NULL,
	[Pourcent_Carie] [float] NULL,
	[Pourcent_0_2] [float] NULL,
	[Pourcent_2_8] [float] NULL,
	[Pourcent_8_plus] [float] NULL,
	[Pourcent_fines] [float] NULL,
	[Spacer_1_1] [float] NULL,
	[Spacer_1_2] [float] NULL,
	[Spacer_1_3] [float] NULL,
	[Spacer_1_4] [float] NULL,
	[Spacer_1_5] [float] NULL,
	[Spacer_1_6] [float] NULL,	
	[Pourcent_Rejets_Echantillon] [float] NULL,
	[Pourcent_Ecorce_Echantillon] [float] NULL,
	[Pourcent_Carie_Echantillon] [float] NULL,
	[Pourcent_0_2_Echantillon] [float] NULL,
	[Pourcent_2_8_Echantillon] [float] NULL,
	[Pourcent_8_plus_Echantillon] [float] NULL,
	[Pourcent_fines_Echantillon] [float] NULL,
	[Spacer_2_1] [float] NULL,
	[Spacer_2_2] [float] NULL,
	[Spacer_2_3] [float] NULL,
	[Spacer_2_4] [float] NULL,
	[Spacer_2_5] [float] NULL,
	[Spacer_2_6] [float] NULL,	
	[Poids_Total_Echantillon] [float] NULL,
	[Poids_Ecorce_Echantillon] [float] NULL,
	[Poids_Carie_Echantillon] [float] NULL,
	[Poids_0_2_Echantillon] [float] NULL,
	[Poids_2_8_Echantillon] [float] NULL,
	[Poids_8_plus_Echantillon] [float] NULL,
	[Poids_fines_Echantillon] [float] NULL,
    [Spacer_3_1] [float] NULL,
	[Spacer_3_2] [float] NULL,
	[Spacer_3_3] [float] NULL,
	[Spacer_3_4] [float] NULL,
	[Spacer_3_5] [float] NULL,
	[Spacer_3_6] [float] NULL,	
	[AT] [varchar] (25) NULL,
	[Unite] [varchar] (25) NULL,
	[PMT] [varchar] (25) NULL,
	[Connais_F] [varchar] (25) NULL,
	[Connais_T] [varchar] (25) NULL,
	[Billet] [varchar] (25) NULL,
	[Sous_Secteur] [varchar] (25) NULL,
	[Numero_Municipalite] [varchar] (255) NULL,
	[Nom_Municipalite] [varchar] (255) NULL,
	[Numero_Client] [varchar] (255) NULL,
	[Nom_Client] [varchar] (255) NULL,
	[Description_Produit] [varchar] (255) NULL
	
)

------------------------------------------------------------------------------------
-- Importer le fichier texte dans la table temporaire

declare @sql varchar(4096)
set @sql = '
bulk insert #tempFeuilletDomtar
	from '''+ @filename +'''
	with
	(
		Fieldterminator = '';'',
		RowTerminator = ''\n'',
		FIRSTROW = 1 
	)
'
exec(@sql)


------------------------------------------------------------------------------------
--Enlever les "" des champs texte
/*
update #tempFeuilletDomtar
set 
TransactionType = ltrim(rtrim(SUBSTRING(TransactionType,2,DATALENGTH(TransactionType)-2)))
,Fournisseur = ltrim(rtrim(SUBSTRING(Fournisseur,2,DATALENGTH(Fournisseur)-2)))
,Contrat = ltrim(rtrim(SUBSTRING(Contrat,2,DATALENGTH(Contrat)-2)))
,Produit = ltrim(rtrim(SUBSTRING(Produit,2,DATALENGTH(Produit)-2)))
,HeureLivraison = ltrim(rtrim(SUBSTRING(HeureLivraison,2,DATALENGTH(HeureLivraison)-2)))
,License = ltrim(rtrim(SUBSTRING(License,2,DATALENGTH(License)-2)))
,Transporteur = ltrim(rtrim(SUBSTRING(Transporteur,2,DATALENGTH(Transporteur)-2)))
,Producteur_1 = ltrim(rtrim(SUBSTRING(Producteur_1,2,DATALENGTH(Producteur_1)-2)))
,Producteur_2 = ltrim(rtrim(SUBSTRING(Producteur_2,2,DATALENGTH(Producteur_2)-2)))
,Producteur_3 = ltrim(rtrim(SUBSTRING(Producteur_3,2,DATALENGTH(Producteur_3)-2)))
,Producteur_4 = ltrim(rtrim(SUBSTRING(Producteur_4,2,DATALENGTH(Producteur_4)-2)))
,Producteur_5 = ltrim(rtrim(SUBSTRING(Producteur_5,2,DATALENGTH(Producteur_5)-2)))
,Municipalite_1 = ltrim(rtrim(SUBSTRING(Municipalite_1,2,DATALENGTH(Municipalite_1)-2)))
,Municipalite_2 = ltrim(rtrim(SUBSTRING(Municipalite_2,2,DATALENGTH(Municipalite_2)-2)))
,Municipalite_3 = ltrim(rtrim(SUBSTRING(Municipalite_3,2,DATALENGTH(Municipalite_3)-2)))
,Municipalite_4 = ltrim(rtrim(SUBSTRING(Municipalite_4,2,DATALENGTH(Municipalite_4)-2)))
,Municipalite_5 = ltrim(rtrim(SUBSTRING(Municipalite_5,2,DATALENGTH(Municipalite_5)-2)))
,Statut = ltrim(rtrim(SUBSTRING(Statut,2,DATALENGTH(Statut)-2)))
,Essence1 = ltrim(rtrim(SUBSTRING(Essence1,2,DATALENGTH(Essence1)-2)))
,Essence2 = ltrim(rtrim(SUBSTRING(Essence2,2,DATALENGTH(Essence2)-2)))
,Chipper = ltrim(rtrim(SUBSTRING(Chipper,2,DATALENGTH(Chipper)-2)))
,Douane = ltrim(rtrim(SUBSTRING(Douane,2,DATALENGTH(Douane)-2)))
,Manifeste = ltrim(rtrim(SUBSTRING(Manifeste,2,DATALENGTH(Manifeste)-2)))
,Unite = ltrim(rtrim(SUBSTRING(Unite,2,DATALENGTH(Unite)-2)))
,Chemin = ltrim(rtrim(SUBSTRING(Chemin,2,DATALENGTH(Chemin)-2)))
,UC = ltrim(rtrim(SUBSTRING(UC,2,DATALENGTH(UC)-2)))
,Spacer16 = ltrim(rtrim(SUBSTRING(Spacer16,2,DATALENGTH(Spacer16)-2)))
*/


------------------------------------------------------------------------------------
-- Effacer le table de Feuillet Domtar et y ajouter ceux de la table temporaire

TRUNCATE TABLE FeuilletDomtar

insert into FeuilletDomtar (
	[Transaction],
	[TransactionType],
	[Fournisseur],
	[Contrat],
	[Produit],
	[DateLivraison],
	[Carte],
	[License],
	[Transporteur_Camion],
	[Producteur],
	[Municipalite],
	[Brut],
	[Tare],
	[Net],
	[Rejets],
	[KgVert_Paye],
	[Pourcent_Sec],
	[KgSec_Paye],
	[Validation],
	[Transfert]
)


select 
	[Transaction],
	[TransactionType],
	[Fournisseur],
	[Contrat],  --'61802',
	[Produit],
	convert(datetime,datelivraison + ' ' + LEFT(heurelivraison, 2) + ':' + substring(heureLivraison, 4, 2)), 
	[Carte],
	[License],
	[Transporteur],
	[Producteur_1],
	[Municipalite_1],
	[Brut],
	[Tare],
	[Net],
	[Rejets],
	[KgVert_Paye],
	[Pourcent_Sec],
	[KgSec_Paye]* 1000,
	'' as [Validation],
	1 as [Transfert]
from #tempFeuilletDomtar
where [Taux] >= 95

drop table #tempFeuilletDomtar


exec  jag_FeuilletDomtar_Validation

end



