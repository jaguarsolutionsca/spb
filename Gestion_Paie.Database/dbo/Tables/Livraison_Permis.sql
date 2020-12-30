CREATE TABLE [dbo].[Livraison_Permis] (
    [LivraisonID]        INT          NOT NULL,
    [PermisID]           INT          NOT NULL,
    [NumeroFactureUsine] VARCHAR (25) NULL,
    CONSTRAINT [PK_Livraison_Permis] PRIMARY KEY CLUSTERED ([LivraisonID] ASC, [PermisID] ASC),
    CONSTRAINT [FK_Livraison_Permis_Livraison] FOREIGN KEY ([LivraisonID]) REFERENCES [dbo].[Livraison] ([ID]) ON DELETE CASCADE,
    CONSTRAINT [FK_Livraison_Permis_Permit] FOREIGN KEY ([PermisID]) REFERENCES [dbo].[Permit] ([ID])
);

