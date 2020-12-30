

Create Procedure [spD_FactureClient]

-- Delete a specific record from table [FactureClient]

(
 @ID [int] -- for [FactureClient].[ID] column
,@TypeFacture [char](1) = Null -- for [FactureClient].[TypeFacture] column
,@TypeInvoiceClientAcomba [int] = Null -- for [FactureClient].[TypeInvoiceClientAcomba] column
,@ClientID [varchar](6) = Null -- for [FactureClient].[ClientID] column
,@PayerAID [varchar](6) = Null -- for [FactureClient].[PayerAID] column
,@Status [varchar](15) = Null -- for [FactureClient].[Status] column
)

-- Returns the number of deleted records

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Delete From [dbo].[FactureClient]

Where
    ((@ID Is Null) Or ([ID] = @ID))
And ((@TypeFacture Is Null) Or ([TypeFacture] = @TypeFacture))
And ((@TypeInvoiceClientAcomba Is Null) Or ([TypeInvoiceClientAcomba] = @TypeInvoiceClientAcomba))
And ((@ClientID Is Null) Or ([ClientID] = @ClientID))
And ((@PayerAID Is Null) Or ([PayerAID] = @PayerAID))
And ((@Status Is Null) Or ([Status] = @Status))

Set NoCount Off

Return(@@RowCount)


