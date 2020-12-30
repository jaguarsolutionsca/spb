

Create Procedure [spD_FactureUsine]

-- Delete a specific record from table [FactureUsine]

(
 @ID [int] -- for [FactureUsine].[ID] column
,@Annee [int] = Null -- for [FactureUsine].[Annee] column
,@Periode [int] = Null -- for [FactureUsine].[Periode] column
,@ContratID [varchar](10) = Null -- for [FactureUsine].[ContratID] column
)

-- Returns the number of deleted records

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Delete From [dbo].[FactureUsine]

Where
    ((@ID Is Null) Or ([ID] = @ID))
And ((@Annee Is Null) Or ([Annee] = @Annee))
And ((@Periode Is Null) Or ([Periode] = @Periode))
And ((@ContratID Is Null) Or ([ContratID] = @ContratID))

Set NoCount Off

Return(@@RowCount)


