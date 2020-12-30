

Create Function [fnIndexation_SelectDisplay]
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
Select
	 [Indexation].[ID]
	,[Indexation].[DateIndexation]
	,[Indexation].[ContratID]
	,[Contrat1].[Display] [ContratID_Display]
	,[Indexation].[Periode_Debut]
	,[Indexation].[Periode_Fin]
	,[Indexation].[TypeIndexation]
	,[TypeIndexation2].[Display] [TypeIndexation_Display]
	,[Indexation].[PourcentageDuMontant]
	,[Indexation].[Facture]
	,[Indexation].[IndexationTransporteur]
	,[Indexation].[Date_Debut]
	,[Indexation].[Date_Fin]
	,[Indexation].[IndexationManuelle]

From [dbo].[Indexation]
    Left Outer Join [fnContrat_Display](Null, Null) [Contrat1] On [ContratID] = [Contrat1].[ID1]
        Left Outer Join [fnTypeIndexation_Display](Null) [TypeIndexation2] On [TypeIndexation] = [TypeIndexation2].[ID1]

Where

    ((@ID Is Null) Or ([ID] = @ID))
And ((@ContratID Is Null) Or ([ContratID] = @ContratID))
And ((@TypeIndexation Is Null) Or ([TypeIndexation] = @TypeIndexation))
)


