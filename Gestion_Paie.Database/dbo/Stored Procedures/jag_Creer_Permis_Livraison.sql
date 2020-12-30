CREATE PROCEDURE [dbo].[jag_Creer_Permis_Livraison]
@FactureUsineID INT
AS
Set NoCount On


	-----------------------------------------------------------------------------------
	-- Lire les informations du Master de FactureUsine
	
	Declare @PermisID int
	Declare @DatePermis smalldatetime 
	Declare @DateLivraison smalldatetime 
	Declare @DatePaye smalldatetime 
	Declare @Annee int 
	Declare @Periode int 
	Declare @ContratID varchar(10) 
	Declare @EssenceSciage varchar(25)
	Declare @NumeroFactureUsine varchar(25)
	Declare @ProducteurID varchar(15)
	Declare @Livraison bit

	SELECT 
       @DatePermis =DatePermis
      ,@DateLivraison = DateLivraison
      ,@DatePaye = DatePaye
      ,@Annee = Annee
      ,@Periode = Periode
      ,@ContratID = ContratID
      ,@EssenceSciage = EssenceSciage
      ,@NumeroFactureUsine = NumeroFactureUsine
      ,@ProducteurID = ProducteurID
	  ,@Livraison = Livraison
	FROM FactureUsine where ID = @FactureUsineID

	-- si Permis et livraison déjà créés on sort
	if @Livraison = 1  
		return  

	-----------------------------------------------------------------------------------
	-- Creer un permis pour chaque Municipalite-Zone-UniteMesure de FactureUsine_Detail

	Declare @LotID int
	Declare @ProducteurEntentePaiementID varchar(15)
	Declare @MunicipaliteID varchar(6)
	Declare @ZoneID varchar(2)
	Declare @UniteMesureID varchar(6)
	Declare @VolumeBrut float

	DECLARE cursPermis CURSOR FOR
		select
		   LotID
		  ,ProducteurEntentePaiementID   
		  ,MunicipaliteID
		  ,ZoneID
		  ,UniteMesureID
		  ,sum(Volume)
		FROM FactureUsine_Detail where FactureUsineID = @FactureUsineID
		group by LotID, ProducteurEntentePaiementID,MunicipaliteID,ZoneID,UniteMesureID
		
	--- Le NumeroFactureUsine doit etre unique	
	declare @NumeroFactureUsine_Sequence varchar(25)
	declare @Sequence int
	set @Sequence = 0
	
	OPEN cursPermis
	
	FETCH NEXT FROM cursPermis INTO @LotID, @ProducteurEntentePaiementID, @MunicipaliteID, @ZoneID, @UniteMesureID, @VolumeBrut
	
	WHILE @@FETCH_STATUS = 0
	BEGIN
		
		set @Sequence = @Sequence + 1
		set @NumeroFactureUsine_Sequence = ltrim(rtrim(@NumeroFactureUsine))  + '-' + ltrim(rtrim(str(@Sequence)))
		---------------------------------------------------------------------------------
		-- Creer Permis et Livraison(master)	
		  exec jag_spI_Permit_Livraison
		  @PermisID OUT ,@DatePermis ,@DateLivraison,
		  @DatePaye ,@Annee ,@Periode,
		  @ContratID
		 ,@EssenceSciage
		 ,@NumeroFactureUsine_Sequence
		 ,@ProducteurID
		 ,@ProducteurEntentePaiementID
		 ,@LotID
		 ,@MunicipaliteID
		 ,@ZoneID
		 ,@UniteMesureID
		 ,@VolumeBrut

		---------------------------------------------------------------------------------
		-- Inscrire le numéro de permis dans FactureUsine_Detail
		update FactureUsine_Detail
		set PermisID = @PermisID,
		LivraisonID = @PermisID
		where FactureUsineID				= @FactureUsineID and
			  MunicipaliteID				= @MunicipaliteID and
			  ZoneID						= @ZoneID and
			  UniteMesureID					= @UniteMesureID
			  and((LotID is null and @LotID is null) or (LotID = @LotID))
			  and((ProducteurEntentePaiementID is null and @ProducteurEntentePaiementID is null)  or (ProducteurEntentePaiementID = @ProducteurEntentePaiementID))
			  
	   
		---------------------------------------------------------------------------------
		-- Inscrire Livraison_Detail
		exec jag_spI_Livraison_Detail @PermisID, @FactureUsineID 

		---------------------------------------------------------------------------------
		-- Faire le calcul de la livraison
		exec jag_Calculate_Livraison @PermisID

		FETCH NEXT FROM cursPermis INTO @LotID, @ProducteurEntentePaiementID, @MunicipaliteID, @ZoneID, @UniteMesureID, @VolumeBrut
	END

	-- Deallocate resources
	CLOSE cursPermis
	DEALLOCATE cursPermis

	---------------------------------------------------------------------------------
	-- Marquer la facture Usine comme Permis et Livraison Crées
	Update FactureUsine 
	set Livraison = 1 
	where ID = @FactureUsineID

Set NoCount Off

Return(0)


