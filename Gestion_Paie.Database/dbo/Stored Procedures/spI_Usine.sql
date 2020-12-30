

Create Procedure [spI_Usine]

-- Inserts a new record in [Usine] table
(
  @ID [varchar](6) -- for [Usine].[ID] column
, @Description [varchar](50) = Null  -- for [Usine].[Description] column
, @UtilisationID [int] = Null  -- for [Usine].[UtilisationID] column
, @Paye_producteur [bit] = Null  -- for [Usine].[Paye_producteur] column
, @Paye_transporteur [bit] = Null  -- for [Usine].[Paye_transporteur] column
, @Specification [text] = Null  -- for [Usine].[Specification] column
, @Compte_a_recevoir [int] = Null  -- for [Usine].[Compte_a_recevoir] column
, @Compte_ajustement [int] = Null  -- for [Usine].[Compte_ajustement] column
, @Compte_transporteur [int] = Null  -- for [Usine].[Compte_transporteur] column
, @Compte_producteur [int] = Null  -- for [Usine].[Compte_producteur] column
, @Compte_preleve_plan_conjoint [int] = Null  -- for [Usine].[Compte_preleve_plan_conjoint] column
, @Compte_preleve_fond_roulement [int] = Null  -- for [Usine].[Compte_preleve_fond_roulement] column
, @Compte_preleve_fond_forestier [int] = Null  -- for [Usine].[Compte_preleve_fond_forestier] column
, @Compte_preleve_divers [int] = Null  -- for [Usine].[Compte_preleve_divers] column
, @Compte_mise_en_commun [int] = Null  -- for [Usine].[Compte_mise_en_commun] column
, @Compte_surcharge [int] = Null  -- for [Usine].[Compte_surcharge] column
, @Compte_indexation_carburant [int] = Null  -- for [Usine].[Compte_indexation_carburant] column
, @Actif [bit] = Null  -- for [Usine].[Actif] column
, @NePaiePasTPS [bit] = Null  -- for [Usine].[NePaiePasTPS] column
, @NePaiePasTVQ [bit] = Null  -- for [Usine].[NePaiePasTVQ] column
, @NoTPS [varchar](25) = Null  -- for [Usine].[NoTPS] column
, @NoTVQ [varchar](25) = Null  -- for [Usine].[NoTVQ] column
, @Compte_chargeur [int] = Null  -- for [Usine].[Compte_chargeur] column
, @UsineGestionVolume [bit] = Null  -- for [Usine].[UsineGestionVolume] column
, @AuSoinsDe [varchar](30) = Null  -- for [Usine].[AuSoinsDe] column
, @Rue [varchar](30) = Null  -- for [Usine].[Rue] column
, @Ville [varchar](30) = Null  -- for [Usine].[Ville] column
, @PaysID [varchar](2) = Null  -- for [Usine].[PaysID] column
, @Code_postal [varchar](7) = Null  -- for [Usine].[Code_postal] column
, @Telephone [varchar](12) = Null  -- for [Usine].[Telephone] column
, @Telephone_Poste [varchar](4) = Null  -- for [Usine].[Telephone_Poste] column
, @Telecopieur [varchar](12) = Null  -- for [Usine].[Telecopieur] column
, @Telephone2 [varchar](12) = Null  -- for [Usine].[Telephone2] column
, @Telephone2_Desc [varchar](20) = Null  -- for [Usine].[Telephone2_Desc] column
, @Telephone2_Poste [varchar](4) = Null  -- for [Usine].[Telephone2_Poste] column
, @Telephone3 [varchar](12) = Null  -- for [Usine].[Telephone3] column
, @Telephone3_Desc [varchar](20) = Null  -- for [Usine].[Telephone3_Desc] column
, @Telephone3_Poste [varchar](4) = Null  -- for [Usine].[Telephone3_Poste] column
, @Email [varchar](80) = Null  -- for [Usine].[Email] column
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Insert Into [dbo].[Usine]
(
	  [ID]
	, [Description]
	, [UtilisationID]
	, [Paye_producteur]
	, [Paye_transporteur]
	, [Specification]
	, [Compte_a_recevoir]
	, [Compte_ajustement]
	, [Compte_transporteur]
	, [Compte_producteur]
	, [Compte_preleve_plan_conjoint]
	, [Compte_preleve_fond_roulement]
	, [Compte_preleve_fond_forestier]
	, [Compte_preleve_divers]
	, [Compte_mise_en_commun]
	, [Compte_surcharge]
	, [Compte_indexation_carburant]
	, [Actif]
	, [NePaiePasTPS]
	, [NePaiePasTVQ]
	, [NoTPS]
	, [NoTVQ]
	, [Compte_chargeur]
	, [UsineGestionVolume]
	, [AuSoinsDe]
	, [Rue]
	, [Ville]
	, [PaysID]
	, [Code_postal]
	, [Telephone]
	, [Telephone_Poste]
	, [Telecopieur]
	, [Telephone2]
	, [Telephone2_Desc]
	, [Telephone2_Poste]
	, [Telephone3]
	, [Telephone3_Desc]
	, [Telephone3_Poste]

	, [Email]
)

Values
(
	  @ID
	, @Description
	, @UtilisationID
	, @Paye_producteur
	, @Paye_transporteur
	, @Specification
	, @Compte_a_recevoir
	, @Compte_ajustement
	, @Compte_transporteur
	, @Compte_producteur
	, @Compte_preleve_plan_conjoint
	, @Compte_preleve_fond_roulement
	, @Compte_preleve_fond_forestier
	, @Compte_preleve_divers
	, @Compte_mise_en_commun
	, @Compte_surcharge
	, @Compte_indexation_carburant
	, @Actif
	, @NePaiePasTPS
	, @NePaiePasTVQ
	, @NoTPS
	, @NoTVQ
	, @Compte_chargeur
	, @UsineGestionVolume
	, @AuSoinsDe
	, @Rue
	, @Ville
	, @PaysID
	, @Code_postal
	, @Telephone
	, @Telephone_Poste
	, @Telecopieur
	, @Telephone2
	, @Telephone2_Desc
	, @Telephone2_Poste
	, @Telephone3
	, @Telephone3_Desc
	, @Telephone3_Poste
	, @Email
)

Set NoCount Off

Return(0)


