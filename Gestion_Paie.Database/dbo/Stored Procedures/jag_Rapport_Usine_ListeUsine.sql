

CREATE PROCEDURE dbo.jag_Rapport_Usine_ListeUsine
	(		
		@UsineDebut varchar(6) = Null,
		@UsineFin varchar(6) = Null
	)
AS

SET NOCOUNT ON

select 
ID AS [Code],
Description AS [Usine],
AuSoinsDe AS [Au Soins De],
Rue,
Ville,
'Canada' AS [Pays], 
(CASE WHEN LEN(Code_postal)=6 THEN LEFT(Code_postal, 3) + ' ' + RIGHT(Code_postal, 3) ELSE Code_postal END) AS [Code Postal],
Telephone 
from Usine			
where 
		((@UsineDebut	is null) or (Usine.[ID]	>= @UsineDebut))
	AND ((@UsineFin		is null) or (Usine.[ID]	<= @UsineFin))
	
order by [Usine]

Return(@@RowCount)









