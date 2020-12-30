

CREATE Procedure jag_ListView_Permit
(
 @ID [int] = Null -- for [Permit].[ID] column
,@ContratID [varchar](10) = Null -- for [Permit].[ContratID] column
,@EssenceID [varchar](6) = Null -- for [Permit].[EssenceID] column
,@TransporteurID [varchar](15) = Null -- for [Permit].[TransporteurID] column
,@LotID [int] = Null -- for [Permit].[Lot] column
,@ProducteurDroitCoupeID [varchar](15) = Null -- for [Permit].[ProducteurDroitCoupeID] column
,@ProducteurEntentePaiementID [varchar](15) = Null -- for [Permit].[ProducteurEntentePaiementID] column
)

-- Returns the number of records found

As

declare @Years table
(
	YearID int
)

declare @YearList varchar(1000)
select @YearList = [Value] from jag_SystemEX where [Name] = 'ShowYearsInPermisListview'

INSERT INTO @Years
select * from Split(@YearList,',')

Select

 [Permit].[ID]
, CONVERT(varchar,[Permit].[DatePermit],103) AS [DatePermit]
--,[Permit].[DateDebut]
--,[Permit].[DateFin]
,[Permit].[Annee]
,[Permit].[Periode]
--,[Canton].[Description] as [Canton]
--,[Permit].[Rang]
--,[Permit].[Lot]
,[Permit].[ContratID] as [Contrat]
,(CASE WHEN PermitSciage<>1 THEN ([Essence].[Description] + ' ' + LTRIM(RTRIM(Code))) ELSE 'Sciage' END) as [Essence]
--,[Transporteur].[Nom] as Transporteur
--,[Permit].[VR]
,[DroitCoupe].[Nom] as DroitCoupe
--,[EntentePaiement].[Nom] as EntentePaiement
--,[Permit].[PermitSciage]
--,[Permit].[PermitLivre]
--,[Permit].[PermitImprime]
--,[Permit].[PermitAnnule]


From [dbo].[Permit] 
		left outer join [dbo].[Fournisseur] as [Transporteur] on ([Permit].[TransporteurID] = [Transporteur].[ID])
			left outer join [dbo].[Fournisseur] as [DroitCoupe] on ([Permit].[ProducteurDroitCoupeID] = [DroitCoupe].[ID])
				left outer join [dbo].[Fournisseur] as [EntentePaiement] on ([Permit].[ProducteurEntentePaiementID] = [EntentePaiement].[ID])
						left outer join [dbo].[Essence] on ([Permit].[EssenceID] = [Essence].[ID])
							left outer join [dbo].[Lot] on ([Permit].[LotID] = [Lot].[ID])
								left outer join [dbo].[Canton] on ([Lot].[CantonID] = [Canton].[ID])
				
Where

    ((@ID Is Null) Or ([Permit].[ID] = @ID))
And ((@ContratID Is Null) Or ([Permit].[ContratID] = @ContratID))
And ((@EssenceID Is Null) Or ([Permit].[EssenceID] = @EssenceID))
And ((@TransporteurID Is Null) Or ([Permit].[TransporteurID] = @TransporteurID))
And ((@LotID Is Null) Or ([Lot].[ID] = @LotID))
And ((@ProducteurDroitCoupeID Is Null) Or ([Permit].[ProducteurDroitCoupeID] = @ProducteurDroitCoupeID))
And ((@ProducteurEntentePaiementID Is Null) Or ([Permit].[ProducteurEntentePaiementID] = @ProducteurEntentePaiementID))

And [Permit].[Annee] in (select YearID from @Years)

Return(@@RowCount)

