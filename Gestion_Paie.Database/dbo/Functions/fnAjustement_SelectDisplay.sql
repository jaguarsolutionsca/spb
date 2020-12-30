
CREATE Function [fnAjustement_SelectDisplay]
(
 @ID [int] = Null
,@ContratID [varchar](10) = Null
)


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Returns Table

As

Return
(
Select
	 [Ajustement].[ID]
	,[Ajustement].[ContratID]
	,[Contrat1].[Display] [ContratID_Display]
	,[Ajustement].[DateAjustement]
	,[Ajustement].[Periode_Debut]
	,[Ajustement].[Periode_Fin]
	,[Ajustement].[Facture]
	,[Ajustement].[UsePeriodes]
	,[Ajustement].[Date_Debut]
	,[Ajustement].[Date_Fin]
	,[Ajustement].[ProducteurID]
	,[Ajustement].[TransporteurID]
	,[Ajustement].[IsRistourne]

From [dbo].[Ajustement]
    Inner Join [fnContrat_Display](Null, Null) [Contrat1] On [ContratID] = [Contrat1].[ID1]

Where

    ((@ID Is Null) Or ([ID] = @ID))
And ((@ContratID Is Null) Or ([ContratID] = @ContratID))
)

