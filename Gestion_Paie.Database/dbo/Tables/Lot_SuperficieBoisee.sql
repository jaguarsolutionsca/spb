CREATE TABLE [dbo].[Lot_SuperficieBoisee] (
    [Annee]             DATETIME NOT NULL,
    [Superficie_boisee] REAL     NULL,
    [LotID]             INT      DEFAULT (0) NOT NULL,
    CONSTRAINT [PK_Lot_SuperficieBoisee] PRIMARY KEY CLUSTERED ([LotID] ASC, [Annee] ASC),
    CONSTRAINT [FK_Lot_SuperficieBoisee_Lot] FOREIGN KEY ([LotID]) REFERENCES [dbo].[Lot] ([ID]) ON DELETE CASCADE
);

