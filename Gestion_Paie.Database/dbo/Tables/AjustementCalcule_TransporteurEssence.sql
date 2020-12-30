CREATE TABLE [dbo].[AjustementCalcule_TransporteurEssence] (
    [ID]                INT           IDENTITY (1, 1) NOT NULL,
    [DateCalcul]        DATETIME      NULL,
    [AjustementID]      INT           NULL,
    [EssenceID]         VARCHAR (6)   NULL,
    [UniteID]           VARCHAR (6)   NULL,
    [LivraisonDetailID] INT           NULL,
    [TransporteurID]    VARCHAR (15)  NULL,
    [Volume]            FLOAT (53)    NULL,
    [Taux]              FLOAT (53)    NULL,
    [Montant]           FLOAT (53)    NULL,
    [Facture]           BIT           NULL,
    [FactureID]         INT           NULL,
    [ErreurCalcul]      BIT           NULL,
    [ErreurDescription] VARCHAR (300) NULL,
    [Code]              CHAR (4)      NULL,
    CONSTRAINT [PK_AjustementCalcule_TransporteurEssence] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_AjustementCalcule_TransporteurEssence_Ajustement_EssenceUnite] FOREIGN KEY ([AjustementID], [EssenceID], [UniteID], [Code]) REFERENCES [dbo].[Ajustement_EssenceUnite] ([AjustementID], [EssenceID], [UniteID], [Code]) ON UPDATE CASCADE,
    CONSTRAINT [FK_AjustementCalcule_TransporteurEssence_Facture] FOREIGN KEY ([FactureID]) REFERENCES [dbo].[FactureFournisseur] ([ID]),
    CONSTRAINT [FK_AjustementCalcule_TransporteurEssence_Fournisseur] FOREIGN KEY ([TransporteurID]) REFERENCES [dbo].[Fournisseur] ([ID]),
    CONSTRAINT [FK_AjustementCalcule_TransporteurEssence_Livraison_Detail] FOREIGN KEY ([LivraisonDetailID]) REFERENCES [dbo].[Livraison_Detail] ([ID])
);

