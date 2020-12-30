CREATE FUNCTION [dbo].[fnCert_Proprietaire]
(@Agence VARCHAR (10)=Null, @NO_ACT VARCHAR (10)=Null, @FournisseurID VARCHAR (15)=Null)
RETURNS TABLE 
AS
RETURN 
    (
Select TOP 100 PERCENT
 [Agence]
,[NO_ACT]
,[Nom]
,[Representant]
,[ADRESSE]
,[Ville]
,[CODE_POST]
,[TEL_RES]
,[TEL_BUR]
,[FournisseurID]
,[FournisseurNom]
,[Traite]
,[Methode]

From [dbo].[Cert_Proprietaire]

Where

    ((@Agence Is Null) Or ([Agence] = @Agence))
And ((@NO_ACT Is Null) Or ([NO_ACT] = @NO_ACT))
And ((@FournisseurID Is Null) Or ([FournisseurID] = @FournisseurID))
)



