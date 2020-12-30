

CREATE PROCEDURE dbo.jag_ClearIndexationLivraison
(
	@IndexationID int
)
AS

if @IndexationID is null
BEGIN
	Return
END

delete from Indexation_Livraison where IndexationID = @IndexationID

