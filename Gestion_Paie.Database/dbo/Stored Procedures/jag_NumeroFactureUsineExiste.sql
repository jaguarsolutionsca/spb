

CREATE PROCEDURE dbo.jag_NumeroFactureUsineExiste
(
	@LivraisonID int,
	@ContratID varchar(10),
	@NumeroFactureUsine varchar(25)
)
AS

SET NOCOUNT ON

SELECT L.NumeroFactureUsine
FROM 
	Livraison L
WHERE 
	L.ContratID = @ContratID and 
	L.NumeroFactureUsine = @NumeroFactureUsine and
	L.ID <> @LivraisonID
		 
UNION

select LP.NumeroFactureUsine
from 
	Livraison_Permis LP
	inner join Permit P on LP.PermisID = P.ID
where 
	P.ContratID = @ContratID and
	LP.NumeroFactureUsine = @NumeroFactureUsine and
	LP.LivraisonID <> @LivraisonID   


