CREATE PROCEDURE [dbo].[spI_Contingentement_Producteur]
@ContingentementID INT, @ProducteurID VARCHAR (15), @Superficie_Contingentee REAL=Null, @Volume_Demande REAL=Null, @Volume_Facteur REAL=Null, @Volume_Fixe REAL=Null, @Volume_Supplementaire REAL=Null, @Volume_Accorde REAL=Null, @Date_Modification DATETIME=Null, @Volume_Inventaire REAL=Null, @LastLivraison SMALLDATETIME=Null, @VolumeMaximum REAL=Null, @Imprime BIT=Null
AS
Set NoCount On

If @Imprime Is Null
	Set @Imprime = (0)

Insert Into [dbo].[Contingentement_Producteur]
(
	  [ContingentementID]
	, [ProducteurID]
	, [Superficie_Contingentee]
	, [Volume_Demande]
	, [Volume_Facteur]
	, [Volume_Fixe]
	, [Volume_Supplementaire]
	, [Volume_Accorde]
	, [Date_Modification]
	, [Volume_Inventaire]
	, [LastLivraison]
	, [VolumeMaximum]
	, [Imprime]
)

Values
(
	  @ContingentementID
	, @ProducteurID
	, @Superficie_Contingentee
	, @Volume_Demande
	, @Volume_Facteur
	, @Volume_Fixe
	, @Volume_Supplementaire
	, @Volume_Accorde
	, @Date_Modification
	, @Volume_Inventaire
	, @LastLivraison
	, @VolumeMaximum
	, @Imprime
)

Set NoCount Off

Return(0)


