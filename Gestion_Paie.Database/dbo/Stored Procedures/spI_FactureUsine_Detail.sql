CREATE PROCEDURE [dbo].[spI_FactureUsine_Detail]
@ID INT=Null OUTPUT, @FactureUsineID INT=Null, @ContratID VARCHAR (10)=Null, @ProducteurID VARCHAR (15)=Null, @ProducteurEntentePaiementID VARCHAR (15)=Null, @ZoneID VARCHAR (2)=Null, @MunicipaliteID VARCHAR (6)=Null, @LotID INT=Null, @UniteMesureID VARCHAR (6)=Null, @LivraisonID INT=Null, @EssenceID VARCHAR (6)=Null, @Code CHAR (4)=Null, @Volume FLOAT=Null, @Taux FLOAT=Null, @Montant FLOAT=Null, @Taux_Usine_Override BIT=Null, @PermisID INT=Null
AS
Set NoCount On

If @ID Is Null
	Begin

		Insert Into [dbo].[FactureUsine_Detail]
		(
			  [FactureUsineID]
			, [ContratID]
			, [ProducteurID]
			, [ProducteurEntentePaiementID]
			, [ZoneID]
			, [MunicipaliteID]
			, [LotID]
			, [UniteMesureID]
			, [LivraisonID]
			, [EssenceID]
			, [Code]
			, [Volume]
			, [Taux]
			, [Montant]
			, [Taux_Usine_Override]
			, [PermisID]
		)

		Values
		(
			  @FactureUsineID
			, @ContratID
			, @ProducteurID
			, @ProducteurEntentePaiementID
			, @ZoneID
			, @MunicipaliteID
			, @LotID
			, @UniteMesureID
			, @LivraisonID
			, @EssenceID
			, @Code
			, @Volume
			, @Taux
			, @Montant
			, @Taux_Usine_Override
			, @PermisID
		)

		Set @ID = Cast(SCOPE_IDENTITY() As [int])

	End

Else
	Begin
		Set Identity_Insert [dbo].[FactureUsine_Detail] On

		Insert Into [dbo].[FactureUsine_Detail]
		(
			  [ID]
			, [FactureUsineID]
			, [ContratID]
			, [ProducteurID]
			, [ProducteurEntentePaiementID]
			, [ZoneID]
			, [MunicipaliteID]
			, [LotID]
			, [UniteMesureID]
			, [LivraisonID]
			, [EssenceID]
			, [Code]
			, [Volume]
			, [Taux]
			, [Montant]
			, [Taux_Usine_Override]
			, [PermisID]
		)

		Values
		(
			  @ID
			, @FactureUsineID
			, @ContratID
			, @ProducteurID
			, @ProducteurEntentePaiementID
			, @ZoneID
			, @MunicipaliteID
			, @LotID
			, @UniteMesureID
			, @LivraisonID
			, @EssenceID
			, @Code
			, @Volume
			, @Taux
			, @Montant
			, @Taux_Usine_Override
			, @PermisID
		)

		Set Identity_Insert [dbo].[FactureUsine_Detail] Off

	End

Set NoCount Off

Return(0)


