CREATE TABLE [dbo].[FactureClient_Sommaire] (
    [FactureID]   INT          NOT NULL,
    [Ligne]       INT          NOT NULL,
    [Compte]      INT          NULL,
    [Montant]     FLOAT (53)   NULL,
    [Description] VARCHAR (90) NULL,
    [isTaxe]      BIT          NULL,
    CONSTRAINT [PK_FactureClient_Sommaire] PRIMARY KEY CLUSTERED ([FactureID] ASC, [Ligne] ASC),
    CONSTRAINT [FK_FactureClient_Sommaire_Compte] FOREIGN KEY ([Compte]) REFERENCES [dbo].[Compte] ([ID]),
    CONSTRAINT [FK_FactureClient_Sommaire_FactureClient] FOREIGN KEY ([FactureID]) REFERENCES [dbo].[FactureClient] ([ID]) ON DELETE CASCADE
);

