CREATE FUNCTION [dbo].[fnLivraison_SelectDisplay]
(@ID INT=Null, @ContratID VARCHAR (10)=Null, @UniteMesureID VARCHAR (6)=Null, @EssenceID VARCHAR (6)=Null, @DroitCoupeID VARCHAR (15)=Null, @EntentePaiementID VARCHAR (15)=Null, @TransporteurID VARCHAR (15)=Null, @Annee INT=Null, @Periode INT=Null, @Producteur1_FactureID INT=Null, @Producteur2_FactureID INT=Null, @Transporteur_FactureID INT=Null, @Usine_FactureID INT=Null, @LotID INT=Null, @ZoneID VARCHAR (2)=Null, @MunicipaliteID VARCHAR (6)=Null, @ChargeurID VARCHAR (15)=Null, @Chargeur_FactureID INT=Null)
RETURNS TABLE 
AS
RETURN 
    (
Select
	 [Livraison].[ID]
	,[Permit1].[Display] [ID_Display]
	,[Livraison].[DateLivraison]
	,[Livraison].[DatePaye]
	,[Livraison].[ContratID]
	,[Contrat2].[Display] [ContratID_Display]
	,[Livraison].[UniteMesureID]
	,[UniteMesure3].[Display] [UniteMesureID_Display]
	,[Livraison].[EssenceID]
	,[Essence4].[Display] [EssenceID_Display]
	,[Livraison].[Sciage]
	,[Livraison].[NumeroFactureUsine]
	,[Livraison].[DroitCoupeID]
	,[Fournisseur5].[Display] [DroitCoupeID_Display]
	,[Livraison].[EntentePaiementID]
	,[Fournisseur6].[Display] [EntentePaiementID_Display]
	,[Livraison].[TransporteurID]
	,[Fournisseur7].[Display] [TransporteurID_Display]
	,[Livraison].[VR]
	,[Livraison].[MasseLimite]
	,[Livraison].[VolumeBrut]
	,[Livraison].[VolumeTare]
	,[Livraison].[VolumeTransporte]
	,[Livraison].[VolumeSurcharge]
	,[Livraison].[VolumeAPayer]
	,[Livraison].[Annee]
	,[Periode8].[Display] [Annee_Display]
	,[Livraison].[Periode]
	,[Periode9].[Display] [Periode_Display]
	,[Livraison].[DateCalcul]
	,[Livraison].[Taux_Transporteur]
	,[Livraison].[Montant_Transporteur]
	,[Livraison].[Montant_Usine]
	,[Livraison].[Montant_Producteur1]
	,[Livraison].[Montant_Producteur2]
	,[Livraison].[Montant_Preleve_Plan_Conjoint]
	,[Livraison].[Montant_Preleve_Fond_Roulement]
	,[Livraison].[Montant_Preleve_Fond_Forestier]
	,[Livraison].[Montant_Preleve_Divers]
	,[Livraison].[Montant_Surcharge]
	,[Livraison].[Montant_MiseEnCommun]
	,[Livraison].[Facture]
	,[Livraison].[Producteur1_FactureID]
	,[FactureFournisseur10].[Display] [Producteur1_FactureID_Display]
	,[Livraison].[Producteur2_FactureID]
	,[FactureFournisseur11].[Display] [Producteur2_FactureID_Display]
	,[Livraison].[Transporteur_FactureID]
	,[FactureFournisseur12].[Display] [Transporteur_FactureID_Display]
	,[Livraison].[Usine_FactureID]
	,[FactureClient13].[Display] [Usine_FactureID_Display]
	,[Livraison].[ErreurCalcul]
	,[Livraison].[ErreurDescription]
	,[Livraison].[LotID]
	,[Lot14].[Display] [LotID_Display]
	,[Livraison].[Taux_Transporteur_Override]
	,[Livraison].[PaieTransporteur]
	,[Livraison].[VolumeSurcharge_Override]
	,[Livraison].[SurchargeManuel]
	,[Livraison].[Code]
	,[Livraison].[NombrePermis]
	,[Livraison].[ZoneID]
	,[Municipalite_Zone15].[Display] [ZoneID_Display]
	,[Livraison].[MunicipaliteID]
	,[Municipalite_Zone16].[Display] [MunicipaliteID_Display]
	,[Livraison].[ChargeurID]
	,[Fournisseur17].[Display] [ChargeurID_Display]
	,[Livraison].[Montant_Chargeur]
	,[Livraison].[Frais_ChargeurAuProducteur]
	,[Livraison].[Frais_ChargeurAuTransporteur]
	,[Livraison].[Frais_AutresAuProducteur]
	,[Livraison].[Frais_AutresAuProducteurDescription]
	,[Livraison].[Frais_AutresAuTransporteur]
	,[Livraison].[Frais_AutresAuTransporteurDescription]
	,[Livraison].[Frais_CompensationDeDeplacement]
	,[Livraison].[Chargeur_FactureID]
	,[FactureFournisseur18].[Display] [Chargeur_FactureID_Display]
	,[Livraison].[Commentaires_Producteur]
	,[Livraison].[Commentaires_Transporteur]
	,[Livraison].[Commentaires_Chargeur]
	,[Livraison].[TauxChargeurAuProducteur]
	,[Livraison].[TauxChargeurAuTransporteur]
	,[Livraison].[Frais_AutresRevenusTransporteur]
	,[Livraison].[Frais_AutresRevenusTransporteurDescription]
	,[Livraison].[Frais_AutresRevenusProducteur]
	,[Livraison].[Frais_AutresRevenusProducteurDescription]
	,[Livraison].[Montant_SurchargeProducteur]
	,[Livraison].[KgVert_Brut]
	,[Livraison].[KgVert_Tare]
	,[Livraison].[KgVert_Net]
	,[Livraison].[KgVert_Rejets]
	,[Livraison].[KgVert_Paye]
	,[Livraison].[Pourcent_Sec_Producteur]
	,[Livraison].[Pourcent_Sec_Producteur_Override]
	,[Livraison].[TMA_Producteur]
	,[Livraison].[Pourcent_Sec_Transport]
	,[Livraison].[Pourcent_Sec_Transport_Override]
	,[Livraison].[TMA_Transport]
	,[Livraison].[IsTMA]
	,[Livraison].[SuspendrePaiement]
	,[Livraison].[BonCommande]

From [dbo].[Livraison]
    Inner Join [fnPermit_Display](Null, Null, Null, Null, Null, Null, Null, Null, Null, Null) [Permit1] On [ID] = [Permit1].[ID1]
        Left Outer Join [fnContrat_Display](Null, Null) [Contrat2] On [ContratID] = [Contrat2].[ID1]
            Left Outer Join [fnUniteMesure_Display](Null) [UniteMesure3] On [UniteMesureID] = [UniteMesure3].[ID1]
                Left Outer Join [fnEssence_Display](Null, Null, Null, Null) [Essence4] On [EssenceID] = [Essence4].[ID1]
                    Left Outer Join [fnFournisseur_Display](Null, Null, Null) [Fournisseur5] On [DroitCoupeID] = [Fournisseur5].[ID1]
                        Left Outer Join [fnFournisseur_Display](Null, Null, Null) [Fournisseur6] On [EntentePaiementID] = [Fournisseur6].[ID1]
                            Left Outer Join [fnFournisseur_Display](Null, Null, Null) [Fournisseur7] On [TransporteurID] = [Fournisseur7].[ID1]
                                Left Outer Join [fnPeriode_Display](Null, Null) [Periode8] On [Annee] = [Periode8].[ID1]
                                    Left Outer Join [fnPeriode_Display](Null, Null) [Periode9] On [Periode] = [Periode9].[ID2]
                                        Left Outer Join [fnFactureFournisseur_Display](Null, Null, Null, Null, Null, Null) [FactureFournisseur10] On [Producteur1_FactureID] = [FactureFournisseur10].[ID1]
                                            Left Outer Join [fnFactureFournisseur_Display](Null, Null, Null, Null, Null, Null) [FactureFournisseur11] On [Producteur2_FactureID] = [FactureFournisseur11].[ID1]
                                                Left Outer Join [fnFactureFournisseur_Display](Null, Null, Null, Null, Null, Null) [FactureFournisseur12] On [Transporteur_FactureID] = [FactureFournisseur12].[ID1]
                                                    Left Outer Join [fnFactureClient_Display](Null, Null, Null, Null, Null, Null) [FactureClient13] On [Usine_FactureID] = [FactureClient13].[ID1]
                                                        Left Outer Join [fnLot_Display](Null, Null, Null, Null, Null, Null, Null, Null) [Lot14] On [LotID] = [Lot14].[ID1]
                                                            Left Outer Join [fnMunicipalite_Zone_Display](Null, Null) [Municipalite_Zone15] On [ZoneID] = [Municipalite_Zone15].[ID1]
                                                                Left Outer Join [fnMunicipalite_Zone_Display](Null, Null) [Municipalite_Zone16] On [MunicipaliteID] = [Municipalite_Zone16].[ID2]
                                                                    Left Outer Join [fnFournisseur_Display](Null, Null, Null) [Fournisseur17] On [ChargeurID] = [Fournisseur17].[ID1]
                                                                        Left Outer Join [fnFactureFournisseur_Display](Null, Null, Null, Null, Null, Null) [FactureFournisseur18] On [Chargeur_FactureID] = [FactureFournisseur18].[ID1]

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
)



