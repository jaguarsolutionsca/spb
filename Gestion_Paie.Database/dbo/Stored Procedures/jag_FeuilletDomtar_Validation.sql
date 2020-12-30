CREATE PROCEDURE [dbo].[jag_FeuilletDomtar_Validation]

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


	-------------------------------------------------------------------------------------------------
	-- Trouver le transporteur selon le numéro du camion
	--
    update FeuilletDomtar
	set TransporteurID = (Select top 1 FournisseurID from Fournisseur_Camion where VR = Transporteur_Camion)

	-------------------------------------------------------------------------------------------------
	-- Trouver Essence et Unité de mesure selon le numéro du produit
	--
	update FeuilletDomtar
	set EssenceID = '12.100'
	, UniteID = (case when contrat = '61809-1' then 'TMACFE' else 'TMA FE' end)
	, Code=''
	where Produit='M244'

	update FeuilletDomtar
	set EssenceID = '14.200'
	, UniteID = (case when contrat = '61809-2' then 'TMACTR' else 'TMA TR' end )
	, Code=''
	where Produit='T244M'

	update FeuilletDomtar
	set EssenceID = '11.020'
	, UniteID = (case when contrat = '61809-4' then 'TMACRE' else 'TMA RE' end )
	, Code=''
	where Produit='R244M'


	update FeuilletDomtar
	set EssenceID = '12.100'
	, UniteID = (case when contrat = '61809-10' then 'TMACFL' else 'TMA FL' end )
	, Code=''
	where Produit='M-LONGV'

	update FeuilletDomtar
	set EssenceID = '14.200'
	, UniteID = (case when contrat = '61809-20' then 'TMACTL' else 'TMA TL' end )
	, Code=''
	where Produit='T-LONGV'

	update FeuilletDomtar
	set EssenceID = '11.200'
	, UniteID = (case when contrat = '61809-40' then 'TMACRL' else 'TMAREL' end )
	, Code=''
	where Produit='R-LONGV'

	-------------------------------------------------------------------------------------------------
	-- Reset champs VALIDATION
	--
	update FeuilletDomtar
	set Validation = '',
	Transfert=0

	-------------------------------------------------------------------------------------------------
	-- Validation des transporteur
	--
	update FeuilletDomtar
	set Validation = Validation + 'Transporteur,'
	where TransporteurID is null

	-------------------------------------------------------------------------------------------------
	-- Validation des Producteur
	--
	update FeuilletDomtar
	set Validation = Validation + 'Producteur,'
	where not exists (Select ID from Fournisseur where 
	ID=Producteur and IsProducteur =1 and actif=1)

	-------------------------------------------------------------------------------------------------
	-- Validation des Municipalite
	--
	update FeuilletDomtar
	set Validation = Validation + 'Municipalite,'
	where not exists (Select ID from Municipalite where 
	ID=Municipalite and actif=1)
	
	-------------------------------------------------------------------------------------------------
	-- Validation des Produits
	--
	update FeuilletDomtar
	set Validation = Validation + 'Essence-UniteMesure,'
	where Produit <> 'M244' and Produit <> 'T244M' and Produit<>'R244M' and Produit<>'M-LONGV' and  Produit<>'T-LONGV'

	-------------------------------------------------------------------------------------------------
	-- Validation du Type 'seulement D est supporté'
	--
	update FeuilletDomtar
	set Validation = 'Type '
	where TransactionType <> 'D'

	-------------------------------------------------------------------------------------------------
	-- Validation si livraison 
	--
	update FeuilletDomtar
	set Validation = 'Livraison=' + (select top 1 convert(char(10), ID) from Livraison where [Transaction]= NumeroFactureUsine )
	where exists (select 1 from Livraison where [Transaction]= NumeroFactureUsine)

	-------------------------------------------------------------------------------------------------
	-- Set le bit pour les feuillets qui sont transférable
	--
	update FeuilletDomtar
	set transfert=1
	where Validation=''




	
END


