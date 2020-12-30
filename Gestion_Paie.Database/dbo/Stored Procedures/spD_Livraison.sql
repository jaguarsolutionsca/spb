
CREATE Procedure [spD_Livraison]

-- Delete a specific record from table [Livraison]

(
 @ID [int] -- for [Livraison].[ID] column
,@ContratID [varchar](10) = Null -- for [Livraison].[ContratID] column
,@UniteMesureID [varchar](6) = Null -- for [Livraison].[UniteMesureID] column
,@EssenceID [varchar](6) = Null -- for [Livraison].[EssenceID] column
,@DroitCoupeID [varchar](15) = Null -- for [Livraison].[DroitCoupeID] column
,@EntentePaiementID [varchar](15) = Null -- for [Livraison].[EntentePaiementID] column
,@TransporteurID [varchar](15) = Null -- for [Livraison].[TransporteurID] column
,@Annee [int] = Null -- for [Livraison].[Annee] column
,@Periode [int] = Null -- for [Livraison].[Periode] column
,@Producteur1_FactureID [int] = Null -- for [Livraison].[Producteur1_FactureID] column
,@Producteur2_FactureID [int] = Null -- for [Livraison].[Producteur2_FactureID] column
,@Transporteur_FactureID [int] = Null -- for [Livraison].[Transporteur_FactureID] column
,@Usine_FactureID [int] = Null -- for [Livraison].[Usine_FactureID] column
,@LotID [int] = Null -- for [Livraison].[LotID] column
,@ZoneID [varchar](2) = Null -- for [Livraison].[ZoneID] column
,@MunicipaliteID [varchar](6) = Null -- for [Livraison].[MunicipaliteID] column
,@ChargeurID [varchar](15) = Null -- for [Livraison].[ChargeurID] column
,@Chargeur_FactureID [int] = Null -- for [Livraison].[Chargeur_FactureID] column
)

-- Returns the number of deleted records

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Delete From [dbo].[Livraison]

Where
    ((@ID Is Null) Or ([ID] = @ID))
And ((@ContratID Is Null) Or ([ContratID] = @ContratID))
And ((@UniteMesureID Is Null) Or ([UniteMesureID] = @UniteMesureID))
And ((@EssenceID Is Null) Or ([EssenceID] = @EssenceID))
And ((@DroitCoupeID Is Null) Or ([DroitCoupeID] = @DroitCoupeID))
And ((@EntentePaiementID Is Null) Or ([EntentePaiementID] = @EntentePaiementID))
And ((@TransporteurID Is Null) Or ([TransporteurID] = @TransporteurID))
And ((@Annee Is Null) Or ([Annee] = @Annee))
And ((@Periode Is Null) Or ([Periode] = @Periode))
And ((@Producteur1_FactureID Is Null) Or ([Producteur1_FactureID] = @Producteur1_FactureID))
And ((@Producteur2_FactureID Is Null) Or ([Producteur2_FactureID] = @Producteur2_FactureID))
And ((@Transporteur_FactureID Is Null) Or ([Transporteur_FactureID] = @Transporteur_FactureID))
And ((@Usine_FactureID Is Null) Or ([Usine_FactureID] = @Usine_FactureID))
And ((@LotID Is Null) Or ([LotID] = @LotID))
And ((@ZoneID Is Null) Or ([ZoneID] = @ZoneID))
And ((@MunicipaliteID Is Null) Or ([MunicipaliteID] = @MunicipaliteID))
And ((@ChargeurID Is Null) Or ([ChargeurID] = @ChargeurID))
And ((@Chargeur_FactureID Is Null) Or ([Chargeur_FactureID] = @Chargeur_FactureID))

Set NoCount Off

Return(@@RowCount)

