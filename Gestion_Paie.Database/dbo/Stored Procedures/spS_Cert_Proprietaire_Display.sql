CREATE PROCEDURE [dbo].[spS_Cert_Proprietaire_Display]
@Agence VARCHAR (10)=Null, @NO_ACT VARCHAR (10)=Null, @FournisseurID VARCHAR (15)=Null
AS
Select
 [Cert_Proprietaire_Records].[ID1]
,[Cert_Proprietaire_Records].[ID2]
,[Cert_Proprietaire_Records].[Display]

From [fnCert_Proprietaire_Display](@Agence, @NO_ACT, @FournisseurID) As [Cert_Proprietaire_Records]

Return(@@RowCount)


