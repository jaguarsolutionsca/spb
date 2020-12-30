

Create Function [fnIndexation]
(
 @ID [int] = Null
,@ContratID [varchar](10) = Null
,@TypeIndexation [char](1) = Null
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
,[DateIndexation]
,[ContratID]
,[Periode_Debut]
,[Periode_Fin]
,[TypeIndexation]
,[PourcentageDuMontant]
,[Facture]
,[IndexationTransporteur]
,[Date_Debut]
,[Date_Fin]
,[IndexationManuelle]

From [dbo].[Indexation]

Where

    ((@ID Is Null) Or ([ID] = @ID))
And ((@ContratID Is Null) Or ([ContratID] = @ContratID))
And ((@TypeIndexation Is Null) Or ([TypeIndexation] = @TypeIndexation))
)


