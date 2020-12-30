

Create Function [fnFactureClient_SelectDisplay]
(
 @ID [int] = Null
,@TypeFacture [char](1) = Null
,@TypeInvoiceClientAcomba [int] = Null
,@ClientID [varchar](6) = Null
,@PayerAID [varchar](6) = Null
,@Status [varchar](15) = Null
)


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Returns Table

As

Return
(
Select
	 [FactureClient].[ID]
	,[FactureClient].[NoFacture]
	,[FactureClient].[DateFacture]
	,[FactureClient].[Annee]
	,[FactureClient].[TypeFacture]
	,[TypeFacture1].[Display] [TypeFacture_Display]
	,[FactureClient].[TypeInvoiceClientAcomba]
	,[TypeInvoiceClientAcomba2].[Display] [TypeInvoiceClientAcomba_Display]
	,[FactureClient].[ClientID]
	,[Usine3].[Display] [ClientID_Display]
	,[FactureClient].[PayerAID]
	,[Usine4].[Display] [PayerAID_Display]
	,[FactureClient].[Montant_Total]
	,[FactureClient].[Montant_TPS]
	,[FactureClient].[Montant_TVQ]
	,[FactureClient].[Description]
	,[FactureClient].[Status]
	,[FactureStatus5].[Display] [Status_Display]
	,[FactureClient].[StatusDescription]
	,[FactureClient].[DateFactureAcomba]

From [dbo].[FactureClient]
    Left Outer Join [fnTypeFacture_Display](Null) [TypeFacture1] On [TypeFacture] = [TypeFacture1].[ID1]
        Left Outer Join [fnTypeInvoiceClientAcomba_Display](Null) [TypeInvoiceClientAcomba2] On [TypeInvoiceClientAcomba] = [TypeInvoiceClientAcomba2].[ID1]
            Left Outer Join [fnUsine_Display](Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null) [Usine3] On [ClientID] = [Usine3].[ID1]
                Left Outer Join [fnUsine_Display](Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null) [Usine4] On [PayerAID] = [Usine4].[ID1]
                    Left Outer Join [fnFactureStatus_Display](Null) [FactureStatus5] On [Status] = [FactureStatus5].[ID1]

Where

    ((@ID Is Null) Or ([ID] = @ID))
And ((@TypeFacture Is Null) Or ([TypeFacture] = @TypeFacture))
And ((@TypeInvoiceClientAcomba Is Null) Or ([TypeInvoiceClientAcomba] = @TypeInvoiceClientAcomba))
And ((@ClientID Is Null) Or ([ClientID] = @ClientID))
And ((@PayerAID Is Null) Or ([PayerAID] = @PayerAID))
And ((@Status Is Null) Or ([Status] = @Status))
)


