CREATE TABLE [dbo].[FactureClient] (
    [ID]                      INT           IDENTITY (1, 1) NOT NULL,
    [NoFacture]               VARCHAR (12)  NULL,
    [DateFacture]             SMALLDATETIME NULL,
    [Annee]                   INT           NULL,
    [TypeFacture]             CHAR (1)      NULL,
    [TypeInvoiceClientAcomba] INT           NULL,
    [ClientID]                VARCHAR (6)   NULL,
    [PayerAID]                VARCHAR (6)   NULL,
    [Montant_Total]           FLOAT (53)    NULL,
    [Montant_TPS]             FLOAT (53)    NULL,
    [Montant_TVQ]             FLOAT (53)    NULL,
    [Description]             VARCHAR (255) NULL,
    [Status]                  VARCHAR (15)  NULL,
    [StatusDescription]       VARCHAR (300) NULL,
    [DateFactureAcomba]       SMALLDATETIME NULL,
    CONSTRAINT [PK_FactureClient] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_FactureClient_FactureStatus] FOREIGN KEY ([Status]) REFERENCES [dbo].[FactureStatus] ([ID]),
    CONSTRAINT [FK_FactureClient_TypeFacture] FOREIGN KEY ([TypeFacture]) REFERENCES [dbo].[TypeFacture] ([ID]),
    CONSTRAINT [FK_FactureClient_TypeInvoiceClientAcomba] FOREIGN KEY ([TypeInvoiceClientAcomba]) REFERENCES [dbo].[TypeInvoiceClientAcomba] ([ID]),
    CONSTRAINT [FK_FactureClient_Usine] FOREIGN KEY ([ClientID]) REFERENCES [dbo].[Usine] ([ID]),
    CONSTRAINT [FK_FactureClient_Usine1] FOREIGN KEY ([PayerAID]) REFERENCES [dbo].[Usine] ([ID])
);

