

CREATE PROCEDURE dbo.jag_Get_VolumeLivrePourContrat
	(
		@ContratID varchar(10),
		@EssenceID varchar(6),
		@Code char(4),
		@UniteMesureID varchar(6),
		@Volume float OUTPUT
	)
AS

SELECT
@Volume = (CASE WHEN sum(VolumeNet) IS NOT NULL THEN sum(VolumeNet) ELSE 0 END)
FROM Livraison_Detail
WHERE ContratID = @ContratID
AND Livraison_Detail.EssenceID = @EssenceID 
AND Livraison_Detail.Code = @Code 
AND Livraison_Detail.UniteMesureID = @UniteMesureID








