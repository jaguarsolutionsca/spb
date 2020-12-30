

Create Procedure [spI_Fournisseur_Camion]

-- Inserts a new record in [Fournisseur_Camion] table
(
  @FournisseurID [varchar](15) -- for [Fournisseur_Camion].[FournisseurID] column
, @VR [varchar](10) -- for [Fournisseur_Camion].[VR] column
, @MasseLimite [float] = Null  -- for [Fournisseur_Camion].[MasseLimite] column
, @Actif [bit] = Null  -- for [Fournisseur_Camion].[Actif] column
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Insert Into [dbo].[Fournisseur_Camion]
(
	  [FournisseurID]
	, [VR]
	, [MasseLimite]
	, [Actif]
)

Values
(
	  @FournisseurID
	, @VR
	, @MasseLimite
	, @Actif
)

Set NoCount Off

Return(0)


