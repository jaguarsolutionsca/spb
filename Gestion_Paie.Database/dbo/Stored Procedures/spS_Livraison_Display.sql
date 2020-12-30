

Create Procedure [spS_Livraison_Display]

(
 @ID [int] = Null -- for [Livraison].[ID] column
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

-- Returns the number of records found

As


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Select
 [Livraison_Records].[ID1]
,[Livraison_Records].[Display]

From [fnLivraison_Display](@ID, @ContratID, @UniteMesureID, @EssenceID, @DroitCoupeID, @EntentePaiementID, @TransporteurID, @Annee, @Periode, @Producteur1_FactureID, @Producteur2_FactureID, @Transporteur_FactureID, @Usine_FactureID, @LotID, @ZoneID, @MunicipaliteID, @ChargeurID, @Chargeur_FactureID) As [Livraison_Records]

Return(@@RowCount)


