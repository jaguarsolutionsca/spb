CREATE TABLE [dbo].[FactureUsine] (
    [ID]                 INT           NOT NULL,
    [DatePermis]         SMALLDATETIME NULL,
    [DateLivraison]      SMALLDATETIME NULL,
    [DatePaye]           SMALLDATETIME NULL,
    [Annee]              INT           NULL,
    [Periode]            INT           NULL,
    [ContratID]          VARCHAR (10)  NULL,
    [Sciage]             BIT           NULL,
    [EssenceSciage]      VARCHAR (25)  NULL,
    [NumeroFactureUsine] VARCHAR (25)  NULL,
    [ProducteurID]       VARCHAR (15)  NULL,
    [Livraison]          BIT           NULL,
    CONSTRAINT [PK_FactureUsine] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_FactureUsine_Contrat] FOREIGN KEY ([ContratID]) REFERENCES [dbo].[Contrat] ([ID]),
    CONSTRAINT [FK_FactureUsine_Periode] FOREIGN KEY ([Annee], [Periode]) REFERENCES [dbo].[Periode] ([Annee], [SemaineNo])
);

