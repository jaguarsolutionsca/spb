
CREATE Function [fnLot_SelectDisplay]
(
 @ID [int] = Null
,@CantonID [varchar](6) = Null
,@MunicipaliteID [varchar](6) = Null
,@ProprietaireID [varchar](15) = Null
,@ContingentID [varchar](15) = Null
,@Droit_coupeID [varchar](15) = Null
,@Entente_paiementID [varchar](15) = Null
,@ZoneID [varchar](2) = Null
)


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Returns Table

As

Return
(
Select
	 [Lot].[CantonID]
	,[Canton1].[Display] [CantonID_Display]
	,[Lot].[Rang]
	,[Lot].[Lot]
	,[Lot].[MunicipaliteID]
	,[Municipalite_Zone2].[Display] [MunicipaliteID_Display]
	,[Lot].[Superficie_total]
	,[Lot].[Superficie_boisee]
	,[Lot].[ProprietaireID]
	,[Fournisseur3].[Display] [ProprietaireID_Display]
	,[Lot].[ContingentID]
	,[Fournisseur4].[Display] [ContingentID_Display]
	,[Lot].[Contingent_Date]
	,[Lot].[Droit_coupeID]
	,[Fournisseur5].[Display] [Droit_coupeID_Display]
	,[Lot].[Droit_coupe_Date]
	,[Lot].[Entente_paiementID]
	,[Fournisseur6].[Display] [Entente_paiementID_Display]
	,[Lot].[Entente_paiement_Date]
	,[Lot].[Actif]
	,[Lot].[ID]
	,[Lot].[Sequence]
	,[Lot].[Partie]
	,[Lot].[Matricule]
	,[Lot].[ZoneID]
	,[Municipalite_Zone7].[Display] [ZoneID_Display]
	,[Lot].[Secteur]
	,[Lot].[Cadastre]
	,[Lot].[Reforme]
	,[Lot].[LotsComplementaires]
	,[Lot].[Certifie]
	,[Lot].[NumeroCertification]
	,[Lot].[OGC]

From [dbo].[Lot]
    Left Outer Join [fnCanton_Display](Null) [Canton1] On [CantonID] = [Canton1].[ID1]
        Left Outer Join [fnMunicipalite_Zone_Display](Null, Null) [Municipalite_Zone2] On [MunicipaliteID] = [Municipalite_Zone2].[ID2]
            Left Outer Join [fnFournisseur_Display](Null, Null, Null) [Fournisseur3] On [ProprietaireID] = [Fournisseur3].[ID1]
                Left Outer Join [fnFournisseur_Display](Null, Null, Null) [Fournisseur4] On [ContingentID] = [Fournisseur4].[ID1]
                    Left Outer Join [fnFournisseur_Display](Null, Null, Null) [Fournisseur5] On [Droit_coupeID] = [Fournisseur5].[ID1]
                        Left Outer Join [fnFournisseur_Display](Null, Null, Null) [Fournisseur6] On [Entente_paiementID] = [Fournisseur6].[ID1]
                            Left Outer Join [fnMunicipalite_Zone_Display](Null, Null) [Municipalite_Zone7] On [ZoneID] = [Municipalite_Zone7].[ID1]

Where

    ((@ID Is Null) Or ([ID] = @ID))
And ((@CantonID Is Null) Or ([CantonID] = @CantonID))
And ((@MunicipaliteID Is Null) Or ([MunicipaliteID] = @MunicipaliteID))
And ((@ProprietaireID Is Null) Or ([ProprietaireID] = @ProprietaireID))
And ((@ContingentID Is Null) Or ([ContingentID] = @ContingentID))
And ((@Droit_coupeID Is Null) Or ([Droit_coupeID] = @Droit_coupeID))
And ((@Entente_paiementID Is Null) Or ([Entente_paiementID] = @Entente_paiementID))
And ((@ZoneID Is Null) Or ([ZoneID] = @ZoneID))
)

