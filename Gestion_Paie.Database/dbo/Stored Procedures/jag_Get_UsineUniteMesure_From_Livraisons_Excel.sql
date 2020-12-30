
create PROCEDURE [dbo].[jag_Get_UsineUniteMesure_From_Livraisons_Excel]
	(
		@DateDebut SMALLDATETIME,
		@DateFin SMALLDATETIME,
		@UsineDebut VARCHAR(6),
		@UsineFin VARCHAR(6)
	)
AS

SET NOCOUNT ON


--Declare	@DateDebut SMALLDATETIME,
--		@DateFin SMALLDATETIME,
--		@UsineDebut VARCHAR(6),
--		@UsineFin VARCHAR(6)

--set @DateDebut='2018-01-01 00:00:00'
--set @DateFin='2018-12-31 00:00:00'
--set @UsineDebut='ACER'
--set @UsineFin='TRECOP'


DECLARE @Resultats TABLE
(
	UsineID varchar(50),
	Usine varchar(50),
	UniteMesureID varchar(50),
	Unite varchar(50),
	EssenceID VARCHAR(50),
	Essence varchar(50),
	Volume_Usine FLOAT,
	Volume_Reduction FLOAT,
	Volume_M3 FLOAT,
	Montant_Usine FLOAT,
	Montant_Ajustement_Usine FLOAT,
	Montant_Producteur FLOAT,
	Montant_Ajustement_Producteur FLOAT,
	Montant_Preleve_Plan_Conjoint FLOAT,
	Montant_Preleve_Fond_Roulement FLOAT,
	Montant_Preleve_Fond_Forestier FLOAT,
	Montant_Preleve_Divers FLOAT
	, Montant_MEC FLOAT
)


DECLARE @UsineID varchar(6)
DECLARE @UniteMesureID varchar(6)

DECLARE db_cursor CURSOR FOR 
SELECT DISTINCT
C.UsineID,
L.UniteMesureID
FROM Livraison L
	INNER JOIN Contrat C ON C.[ID] = L.ContratID

where 
	( L.Facture = 1 )
AND ((@UsineDebut	is null) or (C.UsineID >= @UsineDebut))
AND ((@UsineFin 	is null) or (C.UsineID <= @UsineFin))
AND ((@DateDebut 	is null) or (DATEDIFF(day, @DateDebut, L.DatePaye) >= 0))
AND ((@DateFin 		is null) or (DATEDIFF(day, @DateFin, L.DatePaye) <= 0))

OPEN db_cursor  
FETCH NEXT FROM db_cursor INTO @UsineID, @UniteMesureID

WHILE @@FETCH_STATUS = 0  
BEGIN  
      --SET @text = @text + @UsineID + '_'  
	  insert into @Resultats
      exec jag_Rapport_Contrat_VentillationDesMontants_EXCEL @DateDebut ,@DateFin ,@UsineID ,@UniteMesureID

      FETCH NEXT FROM db_cursor INTO @UsineID, @UniteMesureID 
END 

CLOSE db_cursor  
DEALLOCATE db_cursor 


select * from @Resultats
order by UsineID, Unite
