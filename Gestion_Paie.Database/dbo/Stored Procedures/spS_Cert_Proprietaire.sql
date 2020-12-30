CREATE PROCEDURE [dbo].[spS_Cert_Proprietaire]
@Agence VARCHAR (10)=Null, @NO_ACT VARCHAR (10)=Null, @FournisseurID VARCHAR (15)=Null, @ReturnXML BIT=0
AS
If @ReturnXML Is Null
	Set @ReturnXML = 0

If @ReturnXML = 0
	Begin
		Select

		 [Cert_Proprietaire_Records].[Agence]
		,[Cert_Proprietaire_Records].[NO_ACT]
		,[Cert_Proprietaire_Records].[Nom]
		,[Cert_Proprietaire_Records].[Representant]
		,[Cert_Proprietaire_Records].[ADRESSE]
		,[Cert_Proprietaire_Records].[Ville]
		,[Cert_Proprietaire_Records].[CODE_POST]
		,[Cert_Proprietaire_Records].[TEL_RES]
		,[Cert_Proprietaire_Records].[TEL_BUR]
		,[Cert_Proprietaire_Records].[FournisseurID]
		,[Cert_Proprietaire_Records].[FournisseurNom]
		,[Cert_Proprietaire_Records].[Traite]
		,[Cert_Proprietaire_Records].[Methode]

		From [fnCert_Proprietaire](@Agence, @NO_ACT, @FournisseurID) As [Cert_Proprietaire_Records]
	End

Else

	Begin
		Select

		 [Cert_Proprietaire_Records].[Agence]
		,[Cert_Proprietaire_Records].[NO_ACT]
		,[Cert_Proprietaire_Records].[Nom]
		,[Cert_Proprietaire_Records].[Representant]
		,[Cert_Proprietaire_Records].[ADRESSE]
		,[Cert_Proprietaire_Records].[Ville]
		,[Cert_Proprietaire_Records].[CODE_POST]
		,[Cert_Proprietaire_Records].[TEL_RES]
		,[Cert_Proprietaire_Records].[TEL_BUR]
		,[Cert_Proprietaire_Records].[FournisseurID]
		,[Cert_Proprietaire_Records].[FournisseurNom]
		,[Cert_Proprietaire_Records].[Traite]
		,[Cert_Proprietaire_Records].[Methode]

		From [fnCert_Proprietaire](@Agence, @NO_ACT, @FournisseurID) As [Cert_Proprietaire_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)


