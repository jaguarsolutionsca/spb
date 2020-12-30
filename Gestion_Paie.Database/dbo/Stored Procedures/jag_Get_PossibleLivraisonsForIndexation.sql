

CREATE PROCEDURE dbo.jag_Get_PossibleLivraisonsForIndexation
(
	@IndexationID int
)
AS

declare @Facture bit
declare @IndexationManuelle bit
declare @PeriodeDebut int
declare @AnneeDebut int
declare @PeriodeFin int
declare @AnneeFin int
declare @ContratID varchar(10)

SELECT
@Facture = Facture,
@IndexationManuelle = IndexationManuelle,
@PeriodeDebut = Periode_Debut,
@AnneeDebut = Contrat.Annee,
@PeriodeFin = Periode_Fin,
@AnneeFin = Contrat.Annee,
@ContratID = Contrat.ID
FROM Indexation
	INNER JOIN Contrat on Contrat.[ID] = Indexation.ContratID
WHERE Indexation.[ID] = @IndexationID

declare @Livraisons table
(
	Inclure bit,
	ID int,
	DateLivraison datetime
)

if @Facture = 1
BEGIN
	insert into @Livraisons
	select
	1,
	L.ID,
	L.DateLivraison
	from 
		Indexation_Livraison IL
		inner join Livraison L on L.ID = IL.LivraisonID
	where 
	IndexationID = @IndexationID
END
ELSE
BEGIN
	if @IndexationManuelle = 1
	BEGIN
		insert into @Livraisons
		select distinct
		null as Inclure,
		L.ID,
		L.DateLivraison
		from 
		Livraison L
		where 
		ContratID = @ContratID
		and ( ((convert(char(4), L.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,L.[Periode]),2)))) >= ((convert(char(4), @AnneeDebut)) + (convert(char(2),RIGHT('00'+CONVERT(VARCHAR,@PeriodeDebut),2)))) )
		AND ( ((convert(char(4), L.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,L.[Periode]),2)))) <= ((convert(char(4), @AnneeFin)) + (convert(char(2),RIGHT('00'+CONVERT(VARCHAR,@PeriodeFin),2)))) )	
		and (L.Facture = 1)
	
	
		DECLARE @LivraisonID int
		DECLARE curs CURSOR FOR SELECT [ID] FROM @Livraisons
		
		OPEN curs
		
		FETCH NEXT FROM curs INTO @LivraisonID
		
		WHILE @@FETCH_STATUS = 0
		BEGIN
			declare @Checked int
			select @Checked = count(*) from Indexation_Livraison where IndexationID = @IndexationID and LivraisonID = @LivraisonID
		
			if @Checked >= 1
			BEGIN
				select @Checked = 1
			END
			ELSE
			BEGIN
				select @Checked = 0
			END
		
			update @Livraisons
			set Inclure = @Checked
			where ID = @LivraisonID
		
			FETCH NEXT FROM curs INTO @LivraisonID
		END
		
		CLOSE curs
		DEALLOCATE curs
	END
	ELSE
	BEGIN
		insert into @Livraisons
		select distinct
		1 as Inclure,
		L.ID,
		L.DateLivraison
		from 
		Livraison L
		where 
		ContratID = @ContratID
		and ( ((convert(char(4), L.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,L.[Periode]),2)))) >= ((convert(char(4), @AnneeDebut)) + (convert(char(2),RIGHT('00'+CONVERT(VARCHAR,@PeriodeDebut),2)))) )
		AND ( ((convert(char(4), L.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,L.[Periode]),2)))) <= ((convert(char(4), @AnneeFin)) + (convert(char(2),RIGHT('00'+CONVERT(VARCHAR,@PeriodeFin),2)))) )	
		and (L.Facture = 1)
	END
END

select * from @Livraisons

