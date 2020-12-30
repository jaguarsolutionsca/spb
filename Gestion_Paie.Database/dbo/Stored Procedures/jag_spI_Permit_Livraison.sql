CREATE PROCEDURE [dbo].[jag_spI_Permit_Livraison]
@ID INT OUTPUT, @DatePermis SMALLDATETIME=Null, @DateLivraison SMALLDATETIME=Null, @DatePaye SMALLDATETIME=Null, @Annee INT=Null, @Periode INT=Null, @ContratID VARCHAR (10)=Null, @EssenceSciage VARCHAR (25)=Null, @NumeroFactureUsine VARCHAR (25)=Null, @ProducteurID VARCHAR (15)=Null, @ProducteurEntentePaiementID VARCHAR (15)=Null, @LotID INT=null, @MunicipaliteID VARCHAR (6)=Null, @ZoneID VARCHAR (2)=Null, @UniteMesureID VARCHAR (6)=Null, @VolumeBrut FLOAT=Null
AS
Set NoCount On

declare @MaxIDPlus1 int -- for [Permit].[ID] column
set @MaxIDPlus1 = (select (max(ID)+1) from [dbo].[Permit])

if @MaxIDPlus1 is Null
Begin
	set @MaxIDPlus1 = 1
End

set @ID = @MaxIDPlus1

Insert Into [dbo].[Permit]
(
	  [ID]
	, [DatePermit]
	, [DateDebut]
	, [DateFin]
	, [Annee]
	, [Periode]
	, [ContratID]
	, [PermitSciage]
	, [ProducteurDroitCoupeID]
	, [ProducteurEntentePaiementID]
	, [PermitLivre]
	, [PermitImprime]
	, [PermitAnnule]
	, [EssenceSciage]
	, [LotID]
	, [MunicipaliteID]
	, [ZoneID]
	, [Remarques]

)

Values
(
	  @MaxIDPlus1
	, @DatePermis
	, @DatePermis	-- @DateDebut
	, @DatePermis	-- @DateFin
	, @Annee
	, @Periode
	, @ContratID
	, 1				-- @PermitSciage
	, @ProducteurID -- @ProducteurDroitCoupeID
	, @ProducteurEntentePaiementID
	, 1				-- @PermitLivre
	, 0				-- @PermitImprime
	, 0				-- @PermitAnnule
	, @EssenceSciage
	, @LotID
	, @MunicipaliteID
	, @ZoneID
	, ''			--[Remarques]

)



Insert Into [dbo].[Livraison]
(
	  [ID]
	, [DateLivraison]
	, [DatePaye]
	, [Annee]
	, [Periode]
	, [ContratID]
	, [NumeroFactureUsine]
	, [DroitCoupeID]
	, [EntentePaiementID]
	, [LotID]
	, [MunicipaliteID]
	, [ZoneID]
	, [UniteMesureID]
	, [VolumeBrut]
	, [VolumeTransporte]
	, [VolumeTare]
	, [VolumeSurcharge]
	, [VolumeAPayer]
	, [Sciage]
	, [PaieTransporteur]
	, [SurchargeManuel]
	, [NombrePermis]
	, [VolumeSurcharge_Override]
	, [Facture]
	, [ErreurCalcul]
	, [Taux_Transporteur_Override]
	, [Commentaires_Producteur]
	, [Commentaires_Transporteur]
	, [Commentaires_Chargeur]
)

Values
(
	  @MaxIDPlus1 
	 ,@DateLivraison
	 ,@DatePaye
	 ,@Annee
	 ,@Periode
	 ,@ContratID
	 ,@NumeroFactureUsine
	 ,@ProducteurID
	 ,@ProducteurEntentePaiementID
	 ,@LotID
	 ,@MunicipaliteID
	 ,@ZoneID
	 ,@UniteMesureID
	 ,@VolumeBrut
	 ,@VolumeBrut	-- [VolumeTransporte]
	 ,0				-- [VolumeTare]
	 ,0				-- [VolumeSurcharge]
	 ,0				-- [VolumeAPayer]
	 ,1				-- [Sciage]
	 ,0				-- [PaieTransporteur]
	 ,1				-- [SurchargeManuel]
	 ,1				-- [NombrePermis]
	 ,0				-- [VolumeSurcharge_Override]
	 ,0				-- [Facture]
	 ,0				-- [ErreurCalcul]
	 ,0				-- [Taux_Transporteur_Override]
	 ,''			-- [Commentaires_Producteur]
	 ,''			-- [Commentaires_Transporteur]
	 ,''			-- [Commentaires_Chargeur]

)

Set NoCount Off

Return(0)


