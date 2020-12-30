
CREATE Function [fnContingentement_Demande]
(
 @ID [int] = Null
,@ProducteurID [varchar](15) = Null
,@TransporteurID [varchar](15) = Null
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
,[Annee]
,[ProducteurID]
,[TransporteurID]
,[Superficie_Boisee]
,[Remarques]
,[DateModification]

From [dbo].[Contingentement_Demande]

Where

    ((@ID Is Null) Or ([ID] = @ID))
And ((@ProducteurID Is Null) Or ([ProducteurID] = @ProducteurID))
And ((@TransporteurID Is Null) Or ([TransporteurID] = @TransporteurID))
)

