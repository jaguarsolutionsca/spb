CREATE TABLE [dbo].[Lot_Proprietaire] (
    [ID]             INT          IDENTITY (1, 1) NOT NULL,
    [ProprietaireID] VARCHAR (15) NOT NULL,
    [DateDebut]      DATE         NOT NULL,
    [DateFin]        DATE         NULL,
    [LotID]          INT          CONSTRAINT [DF__Lot_Propr__LotID__67CBBCEF] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Lot_Proprietaire_1] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Lot_Proprietaire_Fournisseur] FOREIGN KEY ([ProprietaireID]) REFERENCES [dbo].[Fournisseur] ([ID]),
    CONSTRAINT [FK_Lot_Proprietaire_Lot] FOREIGN KEY ([LotID]) REFERENCES [dbo].[Lot] ([ID]) ON DELETE CASCADE
);



