

CREATE PROCEDURE dbo.jag_Rapport_Proprietaire_ListeSommaireMontantsPayesProducteur
	(			
		@ProducteurDebut varchar(16) = Null,
		@ProducteurFin varchar(16) = Null,
		@DateDebut datetime = Null,
		@DateFin datetime = Null
	)
AS

SET NOCOUNT ON

declare @temp Table 
(
     [ID] varchar(15) NULL, 
     Nom varchar(40) NULL,
     TPS float NULL,
     TVQ float NULL,
     Montant float NULL
)

insert into @temp
SELECT
F.ID,
F.Nom,
FF.Montant_TPS As TPS,
FF.Montant_TVQ As TVQ,
FF.Montant_Total As MontantNet
FROM FactureFournisseur FF
	inner join Fournisseur F on FF.[PayerAID] = F.[ID]	
WHERE ((@ProducteurDebut IS NULL) OR (F.[ID] >= @ProducteurDebut))
AND	((@ProducteurFin IS NULL) OR (F.[ID] <= @ProducteurFin))
AND (((@DateDebut IS NULL) OR (FF.DateFacture	>= @DateDebut))
AND	((@DateFin IS NULL) OR (FF.DateFacture	<= @DateFin)))
AND (F.IsProducteur = 1)
AND (FF.TypeFactureFournisseur = 'P')

update @temp set TPS = 0 where TPS is Null
update @temp set TPS = 0 where TPS is Null
update @temp set Montant = 0 where Montant is Null

select 
[ID],
MAX(Nom) AS [Nom],
SUM(Montant) - SUM(TPS) - SUM(TVQ) AS [MontantBrut],
SUM(TPS) AS [TPS],
SUM(TVQ) AS [TVQ],
SUM(Montant) AS [MontantNet] 
FROM @temp
GROUP BY [ID]


Return(@@RowCount)


