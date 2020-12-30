CREATE TABLE [dbo].[GestionVolume] (
    [ID]            INT           IDENTITY (1, 1) NOT NULL,
    [DateLivraison] DATETIME      NULL,
    [UsineID]       VARCHAR (6)   NULL,
    [UniteMesureID] VARCHAR (6)   NULL,
    [ProducteurID]  VARCHAR (15)  NULL,
    [Annee]         INT           NULL,
    [Periode]       INT           NULL,
    [LotID]         INT           NULL,
    [DateEntree]    SMALLDATETIME NULL,
    CONSTRAINT [PK_GestionVolume] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_GestionVolume_Fournisseur] FOREIGN KEY ([ProducteurID]) REFERENCES [dbo].[Fournisseur] ([ID]),
    CONSTRAINT [FK_GestionVolume_Lot] FOREIGN KEY ([LotID]) REFERENCES [dbo].[Lot] ([ID]),
    CONSTRAINT [FK_GestionVolume_UniteMesure] FOREIGN KEY ([UniteMesureID]) REFERENCES [dbo].[UniteMesure] ([ID]) ON UPDATE CASCADE,
    CONSTRAINT [FK_GestionVolume_Usine] FOREIGN KEY ([UsineID]) REFERENCES [dbo].[Usine] ([ID])
);

