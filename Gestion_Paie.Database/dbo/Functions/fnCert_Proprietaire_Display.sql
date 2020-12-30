CREATE FUNCTION [dbo].[fnCert_Proprietaire_Display]
(@Agence VARCHAR (10)=Null, @NO_ACT VARCHAR (10)=Null, @FournisseurID VARCHAR (15)=Null)
RETURNS TABLE 
AS
RETURN 
    (
Select TOP 100 PERCENT
 [Agence] As [ID1]
,[NO_ACT] As [ID2]
,[NO_ACT] As [Display]
	
From [dbo].[Cert_Proprietaire]

Where
    ((@Agence Is Null) Or ([Agence] = @Agence))
And ((@NO_ACT Is Null) Or ([NO_ACT] = @NO_ACT))
And ((@FournisseurID Is Null) Or ([FournisseurID] = @FournisseurID))

Order By [Display]
)



