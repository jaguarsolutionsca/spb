CREATE TABLE [dbo].[Fournisseur_Camion] (
    [FournisseurID] VARCHAR (15) NOT NULL,
    [VR]            VARCHAR (10) NOT NULL,
    [MasseLimite]   FLOAT (53)   NULL,
    [Actif]         BIT          NULL,
    CONSTRAINT [PK_Fournisseur_Camion] PRIMARY KEY CLUSTERED ([FournisseurID] ASC, [VR] ASC),
    CONSTRAINT [FK_Fournisseur_Camion_Fournisseur] FOREIGN KEY ([FournisseurID]) REFERENCES [dbo].[Fournisseur] ([ID]) ON DELETE CASCADE
);

