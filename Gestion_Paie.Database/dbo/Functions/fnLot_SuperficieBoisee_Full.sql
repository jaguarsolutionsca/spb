

Create Function [fnLot_SuperficieBoisee_Full]

(
 @Annee [datetime] = Null
,@LotID [int] = Null
)


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Returns Table

As

Return
(
Select TOP 100 PERCENT
 [Lot_SuperficieBoisee].[Annee]
,[Lot_SuperficieBoisee].[Superficie_boisee]
,[Lot_SuperficieBoisee].[LotID]
,[Lot1].[CantonID] [LotID_CantonID]
,[Lot1].[Rang] [LotID_Rang]
,[Lot1].[Lot] [LotID_Lot]
,[Lot1].[MunicipaliteID] [LotID_MunicipaliteID]
,[Lot1].[Superficie_total] [LotID_Superficie_total]
,[Lot1].[Superficie_boisee] [LotID_Superficie_boisee]
,[Lot1].[ProprietaireID] [LotID_ProprietaireID]
,[Lot1].[ContingentID] [LotID_ContingentID]
,[Lot1].[Contingent_Date] [LotID_Contingent_Date]
,[Lot1].[Droit_coupeID] [LotID_Droit_coupeID]
,[Lot1].[Droit_coupe_Date] [LotID_Droit_coupe_Date]
,[Lot1].[Entente_paiementID] [LotID_Entente_paiementID]
,[Lot1].[Entente_paiement_Date] [LotID_Entente_paiement_Date]
,[Lot1].[Actif] [LotID_Actif]
,[Lot1].[ID] [LotID_ID]
,[Lot1].[Sequence] [LotID_Sequence]
,[Lot1].[Partie] [LotID_Partie]
,[Lot1].[Matricule] [LotID_Matricule]
,[Lot1].[ZoneID] [LotID_ZoneID]
,[Lot1].[Secteur] [LotID_Secteur]
,[Lot1].[Cadastre] [LotID_Cadastre]

From [dbo].[Lot_SuperficieBoisee] [Lot_SuperficieBoisee]
    Inner Join [dbo].[Lot] [Lot1] On [Lot_SuperficieBoisee].[LotID] = [Lot1].[ID]

Where

    ((@Annee Is Null) Or ([Lot_SuperficieBoisee].[Annee] = @Annee))
And ((@LotID Is Null) Or ([Lot_SuperficieBoisee].[LotID] = @LotID))
)



