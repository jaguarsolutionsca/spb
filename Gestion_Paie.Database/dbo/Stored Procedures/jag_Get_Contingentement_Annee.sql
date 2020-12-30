CREATE PROCEDURE [dbo].[jag_Get_Contingentement_Annee]
@Annee INT=NULL, @Periode INT=null, @ContingentUsine BIT=Null
AS
select
[Contingentement].ID,
[Contingentement].Annee,
[Contingentement].ContingentUsine,
[Contingentement].UsineID,
[EssenceRegroupement].Description as Regroupement,
[Contingentement].EssenceID + ' ' + LTRIM(RTRIM([Contingentement].Code)) AS [Essence],
[Contingentement].UniteMesureID,
[Contingentement].PeriodeContingentement as Periode,
[Contingentement].CalculAccepte,
EssenceRegroupement.Ordre
from 
Contingentement
left join EssenceRegroupement on RegroupementID = EssenceRegroupement.ID
where (@Annee is null) or ([Contingentement].Annee = @Annee)
and   (@Periode is null) or ([Contingentement].PeriodeContingentement = @Periode)
and   (@ContingentUsine is null) or ([Contingentement].ContingentUsine = @ContingentUsine)

order by EssenceRegroupement.Ordre, Periode


