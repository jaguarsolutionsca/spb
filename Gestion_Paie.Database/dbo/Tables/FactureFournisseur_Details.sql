CREATE TABLE [dbo].[FactureFournisseur_Details] (
    [FactureID] INT        NOT NULL,
    [Ligne]     INT        NOT NULL,
    [Compte]    INT        NULL,
    [Montant]   FLOAT (53) NULL,
    [RefID]     INT        NULL,
    CONSTRAINT [PK_Facture_Details] PRIMARY KEY CLUSTERED ([FactureID] ASC, [Ligne] ASC),
    CONSTRAINT [FK_Facture_Details_Compte] FOREIGN KEY ([Compte]) REFERENCES [dbo].[Compte] ([ID]),
    CONSTRAINT [FK_Facture_Details_Facture] FOREIGN KEY ([FactureID]) REFERENCES [dbo].[FactureFournisseur] ([ID]) ON DELETE CASCADE
);

