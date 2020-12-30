

Create Function [fnIndexation_Municipalite_Full]

(
 @ID [int] = Null
,@IndexationID [int] = Null
,@MunicipaliteID [varchar](6) = Null
,@ZoneID [varchar](2) = Null
)


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Returns Table

As

Return
(
Select TOP 100 PERCENT
 [Indexation_Municipalite].[ID]
,[Indexation_Municipalite].[IndexationID]
,[Indexation_Municipalite].[MunicipaliteID]
,[Indexation_Municipalite].[Montant]
,[Indexation_Municipalite].[ZoneID]
,[Indexation1].[ID] [IndexationID_ID]
,[Indexation1].[DateIndexation] [IndexationID_DateIndexation]
,[Indexation1].[ContratID] [IndexationID_ContratID]
,[Indexation1].[Periode_Debut] [IndexationID_Periode_Debut]
,[Indexation1].[Periode_Fin] [IndexationID_Periode_Fin]
,[Indexation1].[TypeIndexation] [IndexationID_TypeIndexation]
,[Indexation1].[PourcentageDuMontant] [IndexationID_PourcentageDuMontant]
,[Indexation1].[Facture] [IndexationID_Facture]
,[Indexation1].[IndexationTransporteur] [IndexationID_IndexationTransporteur]
,[Indexation1].[Date_Debut] [IndexationID_Date_Debut]
,[Indexation1].[Date_Fin] [IndexationID_Date_Fin]
,[Indexation1].[IndexationManuelle] [IndexationID_IndexationManuelle]
,[Municipalite_Zone2].[ID] [MunicipaliteID_ID]
,[Municipalite_Zone2].[MunicipaliteID] [MunicipaliteID_MunicipaliteID]
,[Municipalite_Zone2].[Description] [MunicipaliteID_Description]
,[Municipalite_Zone2].[Actif] [MunicipaliteID_Actif]
,[Municipalite_Zone3].[ID] [ZoneID_ID]
,[Municipalite_Zone3].[MunicipaliteID] [ZoneID_MunicipaliteID]
,[Municipalite_Zone3].[Description] [ZoneID_Description]
,[Municipalite_Zone3].[Actif] [ZoneID_Actif]

From [dbo].[Indexation_Municipalite] [Indexation_Municipalite]
    Left Outer Join [dbo].[Indexation] [Indexation1] On [Indexation_Municipalite].[IndexationID] = [Indexation1].[ID]
        Left Outer Join [dbo].[Municipalite_Zone] [Municipalite_Zone2] On [Indexation_Municipalite].[MunicipaliteID] = [Municipalite_Zone2].[MunicipaliteID]
            Left Outer Join [dbo].[Municipalite_Zone] [Municipalite_Zone3] On [Indexation_Municipalite].[ZoneID] = [Municipalite_Zone3].[ID]

Where

    ((@ID Is Null) Or ([Indexation_Municipalite].[ID] = @ID))
And ((@IndexationID Is Null) Or ([Indexation_Municipalite].[IndexationID] = @IndexationID))
And ((@MunicipaliteID Is Null) Or ([Indexation_Municipalite].[MunicipaliteID] = @MunicipaliteID))
And ((@ZoneID Is Null) Or ([Indexation_Municipalite].[ZoneID] = @ZoneID))
)



