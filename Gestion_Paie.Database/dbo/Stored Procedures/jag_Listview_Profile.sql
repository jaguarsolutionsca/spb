



CREATE Procedure [jag_Listview_Profile]
(
 @ID [int] = Null 
)


As

Select

 [jag_Profile].[ID]
,[jag_Profile].[Nom]
,MotPasse = (case when len(password) > 0 then 'Existant' else 'Non spécifié' end)

From [jag_Profile]

where ((@ID is null) or (@ID = jag_Profile.[ID]))




