CREATE TABLE [dbo].[FactureFournisseur_Sommaire] (
    [FactureID]   INT          NOT NULL,
    [Ligne]       INT          NOT NULL,
    [Compte]      INT          NULL,
    [Montant]     FLOAT (53)   NULL,
    [Description] VARCHAR (90) NULL,
    [isTaxe]      BIT          NULL,
    CONSTRAINT [PK_FactureFournisseur_Sommaire] PRIMARY KEY CLUSTERED ([FactureID] ASC, [Ligne] ASC),
    CONSTRAINT [FK_FactureFournisseur_Sommaire_Compte] FOREIGN KEY ([Compte]) REFERENCES [dbo].[Compte] ([ID]),
    CONSTRAINT [FK_FactureFournisseur_Sommaire_FactureFournisseur] FOREIGN KEY ([FactureID]) REFERENCES [dbo].[FactureFournisseur] ([ID]) ON DELETE CASCADE
);

