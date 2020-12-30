CREATE PROCEDURE [dbo].[spD_Cert_Proprietaire]
@Agence VARCHAR (10), @NO_ACT VARCHAR (10), @FournisseurID VARCHAR (15)=Null
AS
Set NoCount On

Delete From [dbo].[Cert_Proprietaire]

Where
    ((@Agence Is Null) Or ([Agence] = @Agence))
And ((@NO_ACT Is Null) Or ([NO_ACT] = @NO_ACT))
And ((@FournisseurID Is Null) Or ([FournisseurID] = @FournisseurID))

Set NoCount Off

Return(@@RowCount)


