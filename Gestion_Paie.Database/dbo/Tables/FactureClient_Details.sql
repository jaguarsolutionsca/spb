CREATE TABLE [dbo].[FactureClient_Details] (
    [FactureID] INT        NOT NULL,
    [Ligne]     INT        NOT NULL,
    [Compte]    INT        NULL,
    [Montant]   FLOAT (53) NULL,
    [RefID]     INT        NULL,
    CONSTRAINT [PK_FactureClient_Details] PRIMARY KEY CLUSTERED ([FactureID] ASC, [Ligne] ASC),
    CONSTRAINT [FK_FactureClient_Details_Compte] FOREIGN KEY ([Compte]) REFERENCES [dbo].[Compte] ([ID]),
    CONSTRAINT [FK_FactureClient_Details_FactureClient] FOREIGN KEY ([FactureID]) REFERENCES [dbo].[FactureClient] ([ID]) ON DELETE CASCADE
);

