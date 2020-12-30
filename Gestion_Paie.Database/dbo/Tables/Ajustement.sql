CREATE TABLE [dbo].[Ajustement] (
    [ID]             INT           IDENTITY (1, 1) NOT NULL,
    [ContratID]      VARCHAR (10)  NOT NULL,
    [DateAjustement] DATETIME      NULL,
    [Periode_Debut]  INT           NULL,
    [Periode_Fin]    INT           NULL,
    [Facture]        BIT           NULL,
    [UsePeriodes]    BIT           NULL,
    [Date_Debut]     SMALLDATETIME NULL,
    [Date_Fin]       SMALLDATETIME NULL,
    [ProducteurID]   VARCHAR (15)  NULL,
    [TransporteurID] VARCHAR (15)  NULL,
    [IsRistourne]    BIT           DEFAULT (0) NOT NULL,
    CONSTRAINT [PK_Ajustement] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Ajustement_Contrat] FOREIGN KEY ([ContratID]) REFERENCES [dbo].[Contrat] ([ID])
);

