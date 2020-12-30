

Create Function [fnPermit_SelectDisplay]
(
 @ID [int] = Null
,@ContratID [varchar](10) = Null
,@EssenceID [varchar](6) = Null
,@TransporteurID [varchar](15) = Null
,@ProducteurDroitCoupeID [varchar](15) = Null
,@ProducteurEntentePaiementID [varchar](15) = Null
,@LotID [int] = Null
,@ChargeurID [varchar](15) = Null
,@ZoneID [varchar](2) = Null
,@MunicipaliteID [varchar](6) = Null
)


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Returns Table

As

Return
(
Select
	 [Permit].[ID]
	,[Permit].[DatePermit]
	,[Permit].[DateDebut]
	,[Permit].[DateFin]
	,[Permit].[Annee]
	,[Permit].[Periode]
	,[Permit].[ContratID]
	,[Contrat1].[Display] [ContratID_Display]
	,[Permit].[EssenceID]
	,[Essence2].[Display] [EssenceID_Display]
	,[Permit].[PermitSciage]
	,[Permit].[TransporteurID]
	,[Fournisseur3].[Display] [TransporteurID_Display]
	,[Permit].[VR]
	,[Permit].[ProducteurDroitCoupeID]
	,[Fournisseur4].[Display] [ProducteurDroitCoupeID_Display]
	,[Permit].[ProducteurEntentePaiementID]
	,[Fournisseur5].[Display] [ProducteurEntentePaiementID_Display]
	,[Permit].[PermitLivre]
	,[Permit].[PermitImprime]
	,[Permit].[PermitAnnule]
	,[Permit].[LotID]
	,[Lot6].[Display] [LotID_Display]
	,[Permit].[EssenceSciage]
	,[Permit].[Code]
	,[Permit].[Remarques]
	,[Permit].[ChargeurID]
	,[Fournisseur7].[Display] [ChargeurID_Display]
	,[Permit].[ZoneID]
	,[Municipalite_Zone8].[Display] [ZoneID_Display]
	,[Permit].[MunicipaliteID]
	,[Municipalite_Zone9].[Display] [MunicipaliteID_Display]

From [dbo].[Permit]
    Left Outer Join [fnContrat_Display](Null, Null) [Contrat1] On [ContratID] = [Contrat1].[ID1]
        Left Outer Join [fnEssence_Display](Null, Null, Null, Null) [Essence2] On [EssenceID] = [Essence2].[ID1]
            Left Outer Join [fnFournisseur_Display](Null, Null, Null) [Fournisseur3] On [TransporteurID] = [Fournisseur3].[ID1]
                Left Outer Join [fnFournisseur_Display](Null, Null, Null) [Fournisseur4] On [ProducteurDroitCoupeID] = [Fournisseur4].[ID1]
                    Left Outer Join [fnFournisseur_Display](Null, Null, Null) [Fournisseur5] On [ProducteurEntentePaiementID] = [Fournisseur5].[ID1]
                        Left Outer Join [fnLot_Display](Null, Null, Null, Null, Null, Null, Null, Null) [Lot6] On [LotID] = [Lot6].[ID1]
                            Left Outer Join [fnFournisseur_Display](Null, Null, Null) [Fournisseur7] On [ChargeurID] = [Fournisseur7].[ID1]
                                Left Outer Join [fnMunicipalite_Zone_Display](Null, Null) [Municipalite_Zone8] On [ZoneID] = [Municipalite_Zone8].[ID1]
                                    Left Outer Join [fnMunicipalite_Zone_Display](Null, Null) [Municipalite_Zone9] On [MunicipaliteID] = [Municipalite_Zone9].[ID2]

Where

    ((@ID Is Null) Or ([ID] = @ID))
And ((@ContratID Is Null) Or ([ContratID] = @ContratID))
And ((@EssenceID Is Null) Or ([EssenceID] = @EssenceID))
And ((@TransporteurID Is Null) Or ([TransporteurID] = @TransporteurID))
And ((@ProducteurDroitCoupeID Is Null) Or ([ProducteurDroitCoupeID] = @ProducteurDroitCoupeID))
And ((@ProducteurEntentePaiementID Is Null) Or ([ProducteurEntentePaiementID] = @ProducteurEntentePaiementID))
And ((@LotID Is Null) Or ([LotID] = @LotID))
And ((@ChargeurID Is Null) Or ([ChargeurID] = @ChargeurID))
And ((@ZoneID Is Null) Or ([ZoneID] = @ZoneID))
And ((@MunicipaliteID Is Null) Or ([MunicipaliteID] = @MunicipaliteID))
)


