﻿CREATE TABLE [dbo].[FactureFournisseur] (
    [ID]                     INT           IDENTITY (1, 1) NOT NULL,
    [NoFacture]              VARCHAR (12)  NOT NULL,
    [DateFacture]            SMALLDATETIME NULL,
    [Annee]                  INT           NULL,
    [TypeFactureFournisseur] CHAR (1)      NULL,
    [TypeFacture]            CHAR (1)      NULL,
    [TypeInvoiceAcomba]      INT           NULL,
    [FournisseurID]          VARCHAR (15)  NULL,
    [PayerAID]               VARCHAR (15)  NULL,
    [Montant_Total]          FLOAT (53)    NULL,
    [Montant_TPS]            FLOAT (53)    NULL,
    [Montant_TVQ]            FLOAT (53)    NULL,
    [Description]            VARCHAR (255) NULL,
    [Status]                 VARCHAR (15)  NULL,
    [StatusDescription]      VARCHAR (300) NULL,
    [NumeroCheque]           VARCHAR (20)  NULL,
    [NumeroPaiement]         VARCHAR (20)  NULL,
    [NumeroPaiementUnique]   VARCHAR (20)  NULL,
    [DateFactureAcomba]      SMALLDATETIME NULL,
    [DatePaiementAcomba]     SMALLDATETIME NULL,
    CONSTRAINT [PK_Facture] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Facture_Fournisseur] FOREIGN KEY ([FournisseurID]) REFERENCES [dbo].[Fournisseur] ([ID]),
    CONSTRAINT [FK_Facture_Fournisseur1] FOREIGN KEY ([PayerAID]) REFERENCES [dbo].[Fournisseur] ([ID]),
    CONSTRAINT [FK_Facture_TypeFacture] FOREIGN KEY ([TypeFacture]) REFERENCES [dbo].[TypeFacture] ([ID]),
    CONSTRAINT [FK_Facture_TypeInvoiceAcomba] FOREIGN KEY ([TypeInvoiceAcomba]) REFERENCES [dbo].[TypeInvoiceAcomba] ([ID]),
    CONSTRAINT [FK_FactureFournisseur_TypeFactureFournisseur] FOREIGN KEY ([TypeFactureFournisseur]) REFERENCES [dbo].[TypeFactureFournisseur] ([ID])
);

