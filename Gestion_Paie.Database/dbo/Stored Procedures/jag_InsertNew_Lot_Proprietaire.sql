








CREATE Procedure jag_InsertNew_Lot_Proprietaire

-- Update an existing record in [Lot_Proprietaire] table

(
  @LotID [int] -- for [Lot_Proprietaire].[Lot] column
, @newProprietaireID [varchar](15) -- for [Lot_Proprietaire].[ProprietaireID] column
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On


UPDATE Lot_Proprietaire SET
DateFin = GetDate()
WHERE (LotID = @LotID) and DateFin is NULL

INSERT INTO Lot_Proprietaire (LotID, ProprietaireID, DateDebut) values (@LotID, @newProprietaireID, GetDate())

Set NoCount Off

Return(0)




