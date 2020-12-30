CREATE TABLE [dbo].[Indexation] (
    [ID]                     INT           IDENTITY (1, 1) NOT NULL,
    [DateIndexation]         DATETIME      NULL,
    [ContratID]              VARCHAR (10)  NULL,
    [Periode_Debut]          INT           NULL,
    [Periode_Fin]            INT           NULL,
    [TypeIndexation]         CHAR (1)      NULL,
    [PourcentageDuMontant]   REAL          NULL,
    [Facture]                BIT           NULL,
    [IndexationTransporteur] BIT           NULL,
    [Date_Debut]             SMALLDATETIME NULL,
    [Date_Fin]               SMALLDATETIME NULL,
    [IndexationManuelle]     BIT           NULL,
    CONSTRAINT [PK_Indexation] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Indexation_Contrat] FOREIGN KEY ([ContratID]) REFERENCES [dbo].[Contrat] ([ID]),
    CONSTRAINT [FK_Indexation_TypeIndexation] FOREIGN KEY ([TypeIndexation]) REFERENCES [dbo].[TypeIndexation] ([ID])
);

