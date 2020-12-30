CREATE FUNCTION [dbo].[fnLivraison_Display]
(@ID INT=Null, @ContratID VARCHAR (10)=Null, @UniteMesureID VARCHAR (6)=Null, @EssenceID VARCHAR (6)=Null, @DroitCoupeID VARCHAR (15)=Null, @EntentePaiementID VARCHAR (15)=Null, @TransporteurID VARCHAR (15)=Null, @Annee INT=Null, @Periode INT=Null, @Producteur1_FactureID INT=Null, @Producteur2_FactureID INT=Null, @Transporteur_FactureID INT=Null, @Usine_FactureID INT=Null, @LotID INT=Null, @ZoneID VARCHAR (2)=Null, @MunicipaliteID VARCHAR (6)=Null, @ChargeurID VARCHAR (15)=Null, @Chargeur_FactureID INT=Null)
RETURNS TABLE 
AS
RETURN 
    (
Select TOP 100 PERCENT
 [ID] As [ID1]
,[ErreurDescription] As [Display]
	
From [dbo].[Livraison]

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

Order By [Display]
)



