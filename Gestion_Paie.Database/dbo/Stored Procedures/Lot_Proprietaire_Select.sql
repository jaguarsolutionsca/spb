CREATE PROCEDURE [dbo].[Lot_Proprietaire_Select]
(
    @_uid int,
    @ID int
)
AS
BEGIN
SET NOCOUNT ON
;
SELECT * FROM [dbo].[fun_Lot_Proprietaire_Select] (@ID)
;
END