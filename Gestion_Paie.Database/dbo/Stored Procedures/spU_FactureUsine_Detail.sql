CREATE PROCEDURE [dbo].[spU_FactureUsine_Detail]
@ID INT, @FactureUsineID INT=Null, @ConsiderNull_FactureUsineID BIT=0, @ContratID VARCHAR (10)=Null, @ConsiderNull_ContratID BIT=0, @ProducteurID VARCHAR (15)=Null, @ConsiderNull_ProducteurID BIT=0, @ProducteurEntentePaiementID VARCHAR (15)=Null, @ConsiderNull_ProducteurEntentePaiementID BIT=0, @ZoneID VARCHAR (2)=Null, @ConsiderNull_ZoneID BIT=0, @MunicipaliteID VARCHAR (6)=Null, @ConsiderNull_MunicipaliteID BIT=0, @LotID INT=Null, @ConsiderNull_LotID BIT=0, @UniteMesureID VARCHAR (6), @ConsiderNull_UniteMesureID BIT=0, @LivraisonID INT=Null, @ConsiderNull_LivraisonID BIT=0, @EssenceID VARCHAR (6)=Null, @ConsiderNull_EssenceID BIT=0, @Code CHAR (4)=Null, @ConsiderNull_Code BIT=0, @Volume FLOAT=Null, @ConsiderNull_Volume BIT=0, @Taux FLOAT=Null, @ConsiderNull_Taux BIT=0, @Montant FLOAT=Null, @ConsiderNull_Montant BIT=0, @Taux_Usine_Override BIT=Null, @ConsiderNull_Taux_Usine_Override BIT=0, @PermisID INT=Null, @ConsiderNull_PermisID BIT=0
AS
Set NoCount On

If @ConsiderNull_FactureUsineID Is Null
	Set @ConsiderNull_FactureUsineID = 0

If @ConsiderNull_ContratID Is Null
	Set @ConsiderNull_ContratID = 0

If @ConsiderNull_ProducteurID Is Null
	Set @ConsiderNull_ProducteurID = 0

If @ConsiderNull_ProducteurEntentePaiementID Is Null
	Set @ConsiderNull_ProducteurEntentePaiementID = 0

If @ConsiderNull_ZoneID Is Null
	Set @ConsiderNull_ZoneID = 0

If @ConsiderNull_MunicipaliteID Is Null
	Set @ConsiderNull_MunicipaliteID = 0

If @ConsiderNull_LotID Is Null
	Set @ConsiderNull_LotID = 0

If @ConsiderNull_UniteMesureID Is Null
	Set @ConsiderNull_UniteMesureID = 0

If @ConsiderNull_LivraisonID Is Null
	Set @ConsiderNull_LivraisonID = 0

If @ConsiderNull_EssenceID Is Null
	Set @ConsiderNull_EssenceID = 0

If @ConsiderNull_Code Is Null
	Set @ConsiderNull_Code = 0

If @ConsiderNull_Volume Is Null
	Set @ConsiderNull_Volume = 0

If @ConsiderNull_Taux Is Null
	Set @ConsiderNull_Taux = 0

If @ConsiderNull_Montant Is Null
	Set @ConsiderNull_Montant = 0

If @ConsiderNull_Taux_Usine_Override Is Null
	Set @ConsiderNull_Taux_Usine_Override = 0

If @ConsiderNull_PermisID Is Null
	Set @ConsiderNull_PermisID = 0


Update [dbo].[FactureUsine_Detail]

Set
	 [FactureUsineID] = Case @ConsiderNull_FactureUsineID When 0 Then IsNull(@FactureUsineID, [FactureUsineID]) When 1 Then @FactureUsineID End
	,[ContratID] = Case @ConsiderNull_ContratID When 0 Then IsNull(@ContratID, [ContratID]) When 1 Then @ContratID End
	,[ProducteurID] = Case @ConsiderNull_ProducteurID When 0 Then IsNull(@ProducteurID, [ProducteurID]) When 1 Then @ProducteurID End
	,[ProducteurEntentePaiementID] = Case @ConsiderNull_ProducteurEntentePaiementID When 0 Then IsNull(@ProducteurEntentePaiementID, [ProducteurEntentePaiementID]) When 1 Then @ProducteurEntentePaiementID End
	,[ZoneID] = Case @ConsiderNull_ZoneID When 0 Then IsNull(@ZoneID, [ZoneID]) When 1 Then @ZoneID End
	,[MunicipaliteID] = Case @ConsiderNull_MunicipaliteID When 0 Then IsNull(@MunicipaliteID, [MunicipaliteID]) When 1 Then @MunicipaliteID End
	,[LotID] = Case @ConsiderNull_LotID When 0 Then IsNull(@LotID, [LotID]) When 1 Then @LotID End
	,[UniteMesureID] = Case @ConsiderNull_UniteMesureID When 0 Then IsNull(@UniteMesureID, [UniteMesureID]) When 1 Then @UniteMesureID End
	,[LivraisonID] = Case @ConsiderNull_LivraisonID When 0 Then IsNull(@LivraisonID, [LivraisonID]) When 1 Then @LivraisonID End
	,[EssenceID] = Case @ConsiderNull_EssenceID When 0 Then IsNull(@EssenceID, [EssenceID]) When 1 Then @EssenceID End
	,[Code] = Case @ConsiderNull_Code When 0 Then IsNull(@Code, [Code]) When 1 Then @Code End
	,[Volume] = Case @ConsiderNull_Volume When 0 Then IsNull(@Volume, [Volume]) When 1 Then @Volume End
	,[Taux] = Case @ConsiderNull_Taux When 0 Then IsNull(@Taux, [Taux]) When 1 Then @Taux End
	,[Montant] = Case @ConsiderNull_Montant When 0 Then IsNull(@Montant, [Montant]) When 1 Then @Montant End
	,[Taux_Usine_Override] = Case @ConsiderNull_Taux_Usine_Override When 0 Then IsNull(@Taux_Usine_Override, [Taux_Usine_Override]) When 1 Then @Taux_Usine_Override End
	,[PermisID] = Case @ConsiderNull_PermisID When 0 Then IsNull(@PermisID, [PermisID]) When 1 Then @PermisID End

Where
	     ([ID] = @ID)

Set NoCount Off

Return(0)


