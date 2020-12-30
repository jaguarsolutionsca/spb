








CREATE Procedure jag_ListView_Lot_Proprietaire

(
 @LotID [int] = Null -- for [Lot_Proprietaire].[Lot] column
,@ProprietaireID [varchar](15) = Null -- for [Lot_Proprietaire].[ProprietaireID] column
,@DateDebut [smalldatetime] = Null -- for [Lot_Proprietaire].[DateDebut] column
)

-- Returns the number of records found

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 

		Select

		[Lot_Proprietaire].[DateDebut]
		,[Lot_Proprietaire].[DateFin]
		,([Lot_Proprietaire].[ProprietaireID] + ' - ' + [Fournisseur].[Nom]) as [Proprietaire]
		
		from Lot_Proprietaire inner join Fournisseur on Lot_Proprietaire.ProprietaireID = Fournisseur.ID
		
		where 	((@LotID Is Null) Or ([Lot_Proprietaire].[LotID] = @LotID))
			
		ORDER BY DateDebut DESC		


Return(@@RowCount)









