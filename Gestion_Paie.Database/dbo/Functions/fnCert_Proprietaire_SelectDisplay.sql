CREATE FUNCTION [dbo].[fnCert_Proprietaire_SelectDisplay]
(@Agence VARCHAR (10)=Null, @NO_ACT VARCHAR (10)=Null, @FournisseurID VARCHAR (15)=Null)
RETURNS TABLE 
AS
RETURN 
    (
Select
	 [Cert_Proprietaire].[Agence]
	,[Cert_Proprietaire].[NO_ACT]
	,[Cert_Proprietaire].[Nom]
	,[Cert_Proprietaire].[Representant]
	,[Cert_Proprietaire].[ADRESSE]
	,[Cert_Proprietaire].[Ville]
	,[Cert_Proprietaire].[CODE_POST]
	,[Cert_Proprietaire].[TEL_RES]
	,[Cert_Proprietaire].[TEL_BUR]
	,[Cert_Proprietaire].[FournisseurID]
	,[Fournisseur1].[Display] [FournisseurID_Display]
	,[Cert_Proprietaire].[FournisseurNom]
	,[Cert_Proprietaire].[Traite]
	,[Cert_Proprietaire].[Methode]

From [dbo].[Cert_Proprietaire]
    Left Outer Join [fnFournisseur_Display](Null, Null, Null) [Fournisseur1] On [FournisseurID] = [Fournisseur1].[ID1]

Where

    ((@Agence Is Null) Or ([Agence] = @Agence))
And ((@NO_ACT Is Null) Or ([NO_ACT] = @NO_ACT))
And ((@FournisseurID Is Null) Or ([FournisseurID] = @FournisseurID))
)



