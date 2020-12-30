CREATE TABLE [dbo].[Indexation_EssenceUnite] (
    [ID]           INT          IDENTITY (1, 1) NOT NULL,
    [IndexationID] INT          NULL,
    [ContratID]    VARCHAR (10) NULL,
    [EssenceID]    VARCHAR (6)  NULL,
    [Code]         CHAR (4)     NULL,
    [UniteID]      VARCHAR (6)  NULL,
    [Taux]         REAL         NULL,
    CONSTRAINT [PK_Indexation_EssenceUnite] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Indexation_EssenceUnite_Contrat_EssenceUnite] FOREIGN KEY ([ContratID], [EssenceID], [UniteID], [Code]) REFERENCES [dbo].[Contrat_EssenceUnite] ([ContratID], [EssenceID], [UniteID], [Code]) ON UPDATE CASCADE,
    CONSTRAINT [FK_Indexation_EssenceUnite_Indexation] FOREIGN KEY ([IndexationID]) REFERENCES [dbo].[Indexation] ([ID]) ON DELETE CASCADE
);

