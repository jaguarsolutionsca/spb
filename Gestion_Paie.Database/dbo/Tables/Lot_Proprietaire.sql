CREATE TABLE [dbo].[Lot_Proprietaire] (
    [ProprietaireID] VARCHAR (15) NOT NULL,
    [DateDebut]      DATETIME     NOT NULL,
    [DateFin]        DATETIME     NULL,
    [LotID]          INT          DEFAULT (0) NOT NULL,
    CONSTRAINT [PK_Lot_Proprietaire] PRIMARY KEY CLUSTERED ([LotID] ASC, [ProprietaireID] ASC, [DateDebut] ASC),
    CONSTRAINT [FK_Lot_Proprietaire_Fournisseur] FOREIGN KEY ([ProprietaireID]) REFERENCES [dbo].[Fournisseur] ([ID]),
    CONSTRAINT [FK_Lot_Proprietaire_Lot] FOREIGN KEY ([LotID]) REFERENCES [dbo].[Lot] ([ID]) ON DELETE CASCADE
);

