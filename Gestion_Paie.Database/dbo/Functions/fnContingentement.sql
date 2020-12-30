
CREATE Function [fnContingentement]
(
 @ID [int] = Null
,@UsineID [varchar](6) = Null
,@RegroupementID [int] = Null
,@EssenceID [varchar](6) = Null
,@UniteMesureID [varchar](6) = Null
)


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Returns Table

As

Return
(
Select TOP 100 PERCENT
 [ID]
,[ContingentUsine]
,[UsineID]
,[RegroupementID]
,[Annee]
,[PeriodeContingentement]
,[PeriodeDebut]
,[PeriodeFin]
,[EssenceID]
,[UniteMesureID]
,[Volume_Usine]
,[Facteur]
,[Volume_Fixe]
,[Date_Calcul]
,[CalculAccepte]
,[Code]
,[Volume_Regroupement]
,[Volume_RegroupementPourcentage]
,[MaxVolumeFixe_Pourcentage]
,[MaxVolumeFixe_ContingentementID]
,[UseVolumeFixeUnique]
,[MasseContingentVoyageDefaut]

From [dbo].[Contingentement]

Where

    ((@ID Is Null) Or ([ID] = @ID))
And ((@UsineID Is Null) Or ([UsineID] = @UsineID))
And ((@RegroupementID Is Null) Or ([RegroupementID] = @RegroupementID))
And ((@EssenceID Is Null) Or ([EssenceID] = @EssenceID))
And ((@UniteMesureID Is Null) Or ([UniteMesureID] = @UniteMesureID))
)

