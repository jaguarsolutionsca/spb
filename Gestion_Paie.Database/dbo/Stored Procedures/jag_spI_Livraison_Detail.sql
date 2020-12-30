
CREATE Procedure [dbo].[jag_spI_Livraison_Detail]

-- Insert a new record in [Livraison_Detail] table
-- cette procedure est appelée par [jag_Creer_Permis_Livraison]
(
  @LivraisonID int
, @FactureUsineID int 
)

As

Set NoCount On


	Insert Into [dbo].[Livraison_Detail]
	(
		  [LivraisonID]
		, [ContratID]
		, [EssenceID]
		, [UniteMesureID]
		, [ProducteurID]
		, [Droit_Coupe]
		, [VolumeBrut]
		, [VolumeReduction]
		, [VolumeNet]
		, [VolumeContingente]
		, [Taux_Usine]
		, [Montant_Usine]
		, [Taux_Producteur]
		, [Montant_ProducteurBrut]
		, [Taux_Usine_Override]
		, [Taux_Producteur_Override]
		, [Code]
	)

	Select 
		  @LivraisonID
		, ContratID
		, EssenceID
		, UniteMesureID
		, ProducteurID	
		, 1				-- Droit_Coupe
		, Volume		-- VolumeBrut
		, 0				-- VolumreReduction
		, Volume		-- VolumeNet
		, Volume		-- VolumeContingente
		, Taux			-- Taux_Usine
		, Montant		-- Montant_Usine
		, Taux			-- Taux_Producteur
		, Montant		-- Montant_ProducteurBrut
		, Taux_Usine_Override
		, Taux_Usine_Override    -- Taux_Producteur_Override
		, Code
	From FactureUsine_Detail where
		FactureUsineID = @FactureUsineID and
		LivraisonID	   = @LivraisonID
	


Set NoCount Off

Return(0)
