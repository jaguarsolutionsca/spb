CREATE TABLE [dbo].[AjustementCalcule_Producteur] (
    [ID]                INT           IDENTITY (1, 1) NOT NULL,
    [DateCalcul]        DATETIME      NULL,
    [AjustementID]      INT           NULL,
    [EssenceID]         VARCHAR (6)   NULL,
    [UniteID]           VARCHAR (6)   NULL,
    [LivraisonDetailID] INT           NULL,
    [ProducteurID]      VARCHAR (15)  NULL,
    [Volume]            FLOAT (53)    NULL,
    [Taux]              FLOAT (53)    NULL,
    [Montant]           FLOAT (53)    NULL,
    [Facture]           BIT           NULL,
    [FactureID]         INT           NULL,
    [ErreurCalcul]      BIT           NULL,
    [ErreurDescription] VARCHAR (300) NULL,
    [Code]              CHAR (4)      NULL,
    CONSTRAINT [PK_AjustementCalcule_Producteur] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_AjustementCalcule_Producteur_Ajustement_EssenceUnite] FOREIGN KEY ([AjustementID], [EssenceID], [UniteID], [Code]) REFERENCES [dbo].[Ajustement_EssenceUnite] ([AjustementID], [EssenceID], [UniteID], [Code]) ON UPDATE CASCADE,
    CONSTRAINT [FK_AjustementCalcule_Producteur_Facture] FOREIGN KEY ([FactureID]) REFERENCES [dbo].[FactureFournisseur] ([ID]),
    CONSTRAINT [FK_AjustementCalcule_Producteur_Fournisseur] FOREIGN KEY ([ProducteurID]) REFERENCES [dbo].[Fournisseur] ([ID]),
    CONSTRAINT [FK_AjustementCalcule_Producteur_Livraison_Detail] FOREIGN KEY ([LivraisonDetailID]) REFERENCES [dbo].[Livraison_Detail] ([ID])
);


GO
CREATE NONCLUSTERED INDEX [ix_AjustementCalcule_Producteur_Facture]
    ON [dbo].[AjustementCalcule_Producteur]([Facture] ASC)
    INCLUDE([AjustementID]);

