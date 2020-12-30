CREATE PROCEDURE [dbo].[jag_FournisseurSearch_Import]

AS
SET NOCOUNT ON


	-- on vide la table
	Truncate table FournisseurSearch

	-- importe tous les fournisseurs
	Insert Into FournisseurSearch (FournisseurID, Nom, AuSoinsDe, Rue, Ville, TextSearch)
	select 
	ID, 
	(case when Nom is null then '' else Nom end) Nom, 
	(case when AuSoinsDe is null then '' else AuSoinsDe End) AuSoinsDe,
	(case when Rue is null then '' else Rue End) Rue,
	(case when Ville is null then '' else Ville End) Ville,

	(case when Nom is null then '' else Nom end) 
	+ ' ' +
	(case when AuSoinsDe is null then '' else AuSoinsDe End)
	+ ' ' +
	(case when Rue is null then '' else Rue End)
	+ ' ' +
	(case when Ville is null then '' else Ville End)

	from fournisseur


