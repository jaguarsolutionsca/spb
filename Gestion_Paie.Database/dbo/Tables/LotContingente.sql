CREATE TABLE [dbo].[LotContingente] (
    [LotID]                  INT          NOT NULL,
    [Annee]                  INT          NOT NULL,
    [SuperficieContingentee] REAL         NOT NULL,
    [Override]               BIT          NOT NULL,
    [FournisseurID]          VARCHAR (15) NOT NULL,
    CONSTRAINT [PK_LotContingente] PRIMARY KEY CLUSTERED ([LotID] ASC, [Annee] ASC, [FournisseurID] ASC),
    CONSTRAINT [FK_LotContingente_Fournisseur] FOREIGN KEY ([FournisseurID]) REFERENCES [dbo].[Fournisseur] ([ID]),
    CONSTRAINT [FK_LotContingente_Lot] FOREIGN KEY ([LotID]) REFERENCES [dbo].[Lot] ([ID]) ON DELETE CASCADE
);

