

CREATE PROCEDURE dbo.jag_Rapport_Territoire_Municipalite
	(
		@Actif bit = NULL
	)
AS

SET NOCOUNT ON

DECLARE @t TABLE
(
	MuniID varchar(6), --COLLATE French_CI_AS,
	MuniDesc varchar(50), --COLLATE French_CI_AS,
	MRC varchar(50), --COLLATE French_CI_AS,
	Secteur varchar(2), --COLLATE French_CI_AS,
	Agence varchar(50), --COLLATE French_CI_AS,
	Statut varchar(10) --COLLATE French_CI_AS
)

INSERT INTO @t (MuniID, MuniDesc, MRC, Secteur, Agence, Statut)
SELECT
Municipalite.[ID],
Municipalite.[Description],
(CASE WHEN (MRC.[Description] IS NULL) THEN '' ELSE MRC.[Description] END) as [Description],
(CASE WHEN (MS.[Secteur] IS NULL) THEN '' ELSE MS.[Secteur] END) as [Description],
(CASE WHEN (Agence.[Description] IS NULL) THEN '' ELSE Agence.[Description] END) as [Description],
(CASE WHEN ((Municipalite.Actif IS NULL)OR(Municipalite.Actif = 1)) THEN 'Actif' ELSE 'Inactif' END)
FROM Municipalite
	left outer JOIN MRC ON MRC.[ID] = Municipalite.[MrcID]
	left outer JOIN Agence ON Agence.[ID] = Municipalite.[AgenceID]
	left outer join Municipalite_Secteur MS on Municipalite.[ID] = MS.MunicipaliteID
WHERE ((@Actif IS NULL) OR (Municipalite.[Actif] = @Actif))
ORDER BY Municipalite.[ID]



UPDATE @t SET
Secteur = '' where Secteur is Null or Secteur = '0'



DECLARE @Count int
DECLARE @MuniID varchar (6)
DECLARE Cur CURSOR FOR 
	SELECT [MuniID] FROM @t ORDER BY [MuniID]

OPEN Cur

FETCH NEXT FROM Cur INTO @MuniID

WHILE @@FETCH_STATUS = 0
BEGIN

	select @Count = 0
	select @Count = (select @Count + count(*) from @t where MuniID=@MuniID)

	if @Count > 1
	BEGIN
		delete from @t where Secteur = '' and MuniID=@MuniID
	END	

	FETCH NEXT FROM Cur INTO @MuniID
END

CLOSE Cur
DEALLOCATE Cur







SELECT 
[MuniID] [ID],
[MuniDesc] [Description],
[MRC],
[Secteur],
[Agence],
[Statut]
FROM @t
ORDER BY [Description]

Return(@@RowCount)



