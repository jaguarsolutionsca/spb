

CREATE PROCEDURE dbo.jag_Get_Fournisseurs
	(		
		@TypeFournisseur varchar(1) = Null
	)
AS

SET NOCOUNT ON

SELECT
*
from Fournisseur f
where 
((@TypeFournisseur IS NULL) OR 
((@TypeFournisseur = 'P') and (f.IsProducteur = 1)) OR
((@TypeFournisseur = 'T') and (f.IsTransporteur = 1)) OR
((@TypeFournisseur = 'C') and (f.IsChargeur = 1)) OR
((@TypeFournisseur = 'A') and (f.IsAutre = 1)))


