

Create Function [fnFactureClient_Display]
(
 @ID [int] = Null
,@TypeFacture [char](1) = Null
,@TypeInvoiceClientAcomba [int] = Null
,@ClientID [varchar](6) = Null
,@PayerAID [varchar](6) = Null
,@Status [varchar](15) = Null
)


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Returns Table

As

Return
(
Select TOP 100 PERCENT
 [ID] As [ID1]
,[Description] As [Display]
	
From [dbo].[FactureClient]

Where
    ((@ID Is Null) Or ([ID] = @ID))
And ((@TypeFacture Is Null) Or ([TypeFacture] = @TypeFacture))
And ((@TypeInvoiceClientAcomba Is Null) Or ([TypeInvoiceClientAcomba] = @TypeInvoiceClientAcomba))
And ((@ClientID Is Null) Or ([ClientID] = @ClientID))
And ((@PayerAID Is Null) Or ([PayerAID] = @PayerAID))
And ((@Status Is Null) Or ([Status] = @Status))

Order By [Display]
)


