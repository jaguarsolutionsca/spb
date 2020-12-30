








CREATE Procedure jag_ListView_Usine

(
 @ID [varchar](6) = Null -- for [Usine].[ID] column
,@UtilisationID [int] = Null -- for [Usine].[UtilisationID] column
,@Actif bit = null 
)

As

Select

Usine.[ID],
Usine.[Description],
UsineUtilisation.[Description] AS [Utilisation],
Usine.[UsineGestionVolume],
Usine.[Actif]

From Usine
	left outer JOIN UsineUtilisation ON UsineUtilisation.[ID] = UtilisationID

where ((@Actif is null) or (Usine.[Actif] = @Actif))
AND ((@ID is null) or (Usine.[ID] = @ID))
AND ((@UtilisationID is null) or (Usine.UtilisationID = @UtilisationID))

order by Usine.[ID]


