
CREATE Function [fnAjustement]
(
 @ID [int] = Null
,@ContratID [varchar](10) = Null
)


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Returns Table

As

Return
(
Select TOP 100 PERCENT
 [ID]
,[ContratID]
,[DateAjustement]
,[Periode_Debut]
,[Periode_Fin]
,[Facture]
,[UsePeriodes]
,[Date_Debut]
,[Date_Fin]
,[ProducteurID]
,[TransporteurID]
,[IsRistourne]

From [dbo].[Ajustement]

Where

    ((@ID Is Null) Or ([ID] = @ID))
And ((@ContratID Is Null) Or ([ContratID] = @ContratID))
)

