CREATE PROCEDURE [dbo].[jag_Get_ContingentementProducteur_AnneePeriode]
@Annee INT=null, @Periode INT=Null, @ContingentementID INT=null, @ProducteurID VARCHAR (15)=null, @ContingentUsine BIT=Null
AS
select 
	c.Annee,
	p.ContingentementID,
	c.PeriodeContingentement as Periode,
	p.ProducteurID,
	p.Superficie_Contingentee,
	p.Volume_Demande,
	p.Volume_inventaire,
	p.Volume_Facteur,
	p.Volume_Fixe,
	p.Volume_Supplementaire,
	p.Volume_Accorde,
	
	(CASE WHEN dbo.jag_GetVolumeLivrePourContingentementParProducteur (c.[ID], p.ProducteurID) IS NOT NULL THEN dbo.jag_GetVolumeLivrePourContingentementParProducteur (c.[ID], p.ProducteurID) ELSE 0 END) AS [Volume_Livre],
	(CASE WHEN (p.Volume_Accorde - dbo.jag_GetVolumeLivrePourContingentementParProducteur (c.[ID], p.ProducteurID)) IS NOT NULL THEN (p.Volume_Accorde - dbo.jag_GetVolumeLivrePourContingentementParProducteur (c.[ID], p.ProducteurID)) ELSE 0 END) AS [Volume_A_Livre],
	
	c.CalculAccepte,
	c.ContingentUsine,
	c.UsineID,
	[EssenceRegroupement].Description as Regroupement,
	c.EssenceID + ' ' + LTRIM(RTRIM(c.Code)) AS [Essence],
	c.UniteMesureID

	
	from 
	Contingentement_Producteur as p
	left join Contingentement as c on c.ID = p.ContingentementID
	left join EssenceRegroupement on RegroupementID = EssenceRegroupement.ID
	where ((@ContingentementID is null) or (@ContingentementID = p.ContingentementID))
	 and  ((@ProducteurID is null) or (@ProducteurID = p.ProducteurID))
	 and  ((@Annee is null) or (@Annee = c.Annee))
	 and  ((@Periode is null) or (@Periode = c.PeriodeContingentement))
	 and   (@ContingentUsine is null) or (c.ContingentUsine = @ContingentUsine)


