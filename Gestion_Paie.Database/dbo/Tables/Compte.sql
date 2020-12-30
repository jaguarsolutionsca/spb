CREATE TABLE [dbo].[Compte] (
    [ID]          INT          NOT NULL,
    [Description] VARCHAR (50) NULL,
    [CategoryID]  INT          NULL,
    [isTaxe]      BIT          NULL,
    [Actif]       BIT          NULL,
    CONSTRAINT [PK_Compte] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Compte_CompteCategory] FOREIGN KEY ([CategoryID]) REFERENCES [dbo].[CompteCategory] ([ID])
);

