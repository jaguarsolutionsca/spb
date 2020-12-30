CREATE PROCEDURE [dbo].[jag_FeuilletDomtar_Creer_PermitLivraison]
@ContratID VARCHAR (10), @Annee INT, @Periode INT, @DatePaye SMALLDATETIME, @PourcentSecMoyen FLOAT
AS
Set NoCount On


	-----------------------------------------------------------------------------------
	-- Definir les champs a lire des feuillets Domtar
	Declare @DateLivraison smalldatetime
	Declare @ProducteurID varchar(15)
	Declare @MunicipaliteID varchar(15) 
	Declare @Brut int
	Declare @Tare int
	Declare @Net int
	Declare @Rejets int
	Declare @KgVert_Paye int
	Declare @Pourcent_Sec float
	Declare @KgSec_Paye int
	Declare @EssenceID varchar(6)
	Declare @UniteMesureID varchar(6) 
	Declare @Code char(4)
	Declare @TransporteurID varchar(15)
	Declare @VR varchar(10)
	Declare @TMA_Producteur float
	Declare @TMA_Transporteur float
	Declare @BonCommande varchar(25)

	Declare @KgSec int


	Declare @ZoneID varchar(2)
	set  @ZoneID = '0'

	declare @PermitID int -- variable pour numéro de permit

	-----------------------------------------------------------------------------------
	-- Creer un permis pour chaque feuillet valide

	Declare @Transaction varchar(15)

	DECLARE cursDomtar CURSOR FOR
		select  
		   [Transaction]
		FROM FeuilletDomtar where Transfert=1
	
	
	OPEN cursDomtar
	
	FETCH NEXT FROM cursDomtar INTO @Transaction
	
	WHILE @@FETCH_STATUS = 0
	BEGIN
		
		select
		@DateLivraison	=DateLivraison,
		@ProducteurID	=Producteur,
		@MunicipaliteID	=Municipalite,
		@Brut			=Brut,
		@Tare			=Tare,
		@Net			=Net,
		@Rejets			=Rejets,
		@KgVert_Paye	=KgVert_Paye,
		@Pourcent_Sec	=Pourcent_Sec,
		@KgSec_Paye		=KgSec_Paye,
		@EssenceID		=EssenceID,
		@UniteMesureID	=UniteID,
		@Code			=Code,
		@TransporteurID	=TransporteurID,
		@VR				=Transporteur_Camion,
		@BonCommande	=BonCommande

		From FeuilletDomtar where [Transaction] = @Transaction


		-- Calcul Transporteur
		set @KgSec			  = @Net * @PourcentSecMoyen / 100
		set @TMA_Transporteur = round(convert(float, @KgSec) /1000 ,2)

		-- Calcul Producteur
		set @KgSec			  = @Net * @Pourcent_Sec / 100
		set @TMA_Producteur   = round(convert(float, @KgSec) /1000 ,2)

		----------------------------------------------------------------------------------
		-- Creation du permit

		set @PermitID = (select (max(ID)+1) from [dbo].[Permit])

		if @PermitID is Null
		Begin
			set @PermitID = 1
		End


		Insert Into [dbo].[Permit]
		(
			  [ID]
			, [DatePermit]
			, [DateDebut]
			, [DateFin]
			, [Annee]
			, [Periode]
			, [ContratID]
			, [EssenceID]
			, [Code]
			, [PermitSciage]
			, [TransporteurID]
			, [VR]
			, [ProducteurDroitCoupeID]
			, [PermitLivre]
			, [PermitImprime]
			, [PermitAnnule]
			, [MunicipaliteID]
			, [ZoneID]
			, [Remarques]

		)

		Values
		(
			  @PermitID
			, @DateLivraison
			, @DateLivraison	-- @DateDebut
			, @DateLivraison	-- @DateFin
			, @Annee
			, @Periode
			, @ContratID
			, @EssenceID
			, @Code
			, 0				-- @PermitSciage
			, @TransporteurID
			, @VR
			, @ProducteurID -- @ProducteurDroitCoupeID
			, 1				-- @PermitLivre
			, 0				-- @PermitImprime
			, 0				-- @PermitAnnule
			, @MunicipaliteID
			, @ZoneID
			, ''			--[Remarques]

		)



		----------------------------------------------------------------------------------
		-- Creation de Livraison Master
		Insert Into [dbo].[Livraison]
		(
			  [ID]
			, [DateLivraison]
			, [DatePaye]
			, [ContratID]
			, [UniteMesureID]
			, [EssenceID]
			, [NumeroFactureUsine]
			, [DroitCoupeID]
			, [TransporteurID]
			, [VR]
			, [MasseLimite]
			, [VolumeBrut]
			, [VolumeTare]
			, [VolumeTransporte]
			, [VolumeSurcharge]
			, [VolumeAPayer]
			, [Annee]
			, [Periode]
			, [PaieTransporteur]
			, [MunicipaliteID]
			, [ZoneID]
			, [Sciage]
			, [NombrePermis]
			, [KgVert_Brut]
			, [KgVert_Tare]
			, [KgVert_Net]
			, [KgVert_Rejets]
			, [KgVert_Paye]
			, [Pourcent_Sec_Producteur]
			, [Pourcent_Sec_Producteur_Override]
			, [TMA_Producteur]
			, [Pourcent_Sec_Transport]
			, [Pourcent_Sec_Transport_Override]
			, [TMA_Transport]
			, [isTMA]
			, [VolumeSurcharge_Override]
			, [Facture]
			, [ErreurCalcul]
			, [Taux_Transporteur_Override]
			, [BonCommande]
		)

		Values
		(
			  @PermitID
			, @DateLivraison
			, @DatePaye
			, @ContratID
			, @UniteMesureID
			, @EssenceID
			, @Transaction
			, @ProducteurID
			, @TransporteurID
			, @VR
			, 57500							--[MasseLimite]
			, round(convert(float, @Net) /1000 ,2)	--@TMA_Transporteur				--[VolumeBrut]
			, 0								--[VolumeTare]
			, round(convert(float, @Net) /1000 ,2)	--@TMA_Transporteur				--[VolumeTransporte]
			, 0								--[VolumeSurcharge]
			, round(convert(float, @Net) /1000 ,2)	--@TMA_Transporteur				--[VolumeAPayer]
			, @Annee
			, @Periode
			, 1								--[PaieTransporteur]
			, @MunicipaliteID
			, @ZoneID
			, 0								--[Sciage]
			, 1								--[NombrePermis]
			, @Brut							--[KgVert_Brut]
			, @Tare							--[KgVert_Tare]
			, @Net							--[KgVert_Net]
			, @Rejets						--[KgVert_Rejets]
			, @KgVert_Paye
			, @Pourcent_Sec					--[Pourcent_Sec_Producteur]
			, 0								--[Pourcent_Sec_Producteur_Override]
			, @TMA_Producteur				--[TMA_Producteur]
			, @PourcentSecMoyen				--[Pourcent_Sec_Transport]
			, 0								--[Pourcent_Sec_Transport_Override]
			, @TMA_Transporteur				--[TMA_Transport]
			, 1								--[isTMA]
			, 0								--[VolumeSurcharge_Override]
			, 0								--[Facture]
			, 0								--[ErreurCalcul]
			, 0								--[Taux_Transporteur_Override]
			, @BonCommande

		)


		----------------------------------------------------------------------------------
		-- Creation de Livraison Detail

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
			, [Taux_Usine_Override]
			, [Taux_Producteur_Override]
			, [Code]
		)
		Values
		(
			  @PermitID
			, @ContratID
			, @EssenceID
			, @UniteMesureID
			, @ProducteurID
			, 1						--[Droit_Coupe]
			, @TMA_Producteur		--[VolumeBrut]
			, 0						--[VolumeReduction]
			, @TMA_Producteur		--[VolumeNet]
			, @TMA_Producteur		--[VolumeContingente]
			, 0						--[Taux_Usine_Override]
			, 0						--[Taux_Producteur_Override]
			, @Code

		)
		---------------------------------------------------------------------------------
		-- Faire le calcul de la livraison
		exec jag_Calculate_Livraison @PermitID

		FETCH NEXT FROM cursDomtar INTO @Transaction
	END

	-- Deallocate resources
	CLOSE cursDomtar
	DEALLOCATE cursDomtar

	---------------------------------------------------------------------------------

	exec jag_FeuilletDomtar_Validation

Set NoCount Off

Return(0)


