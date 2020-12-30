CREATE PROCEDURE [dbo].[Fournisseur_Select]
(
	@_uid int,
    @ID varchar(15)
)
AS
BEGIN
SET NOCOUNT ON
;
SELECT * FROM [dbo].[fun_Fournisseur_Select] (@ID)
;
END
