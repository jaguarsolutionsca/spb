CREATE TABLE [dbo].[AjustementCalcule_Usine] (
    [ID]                INT           IDENTITY (1, 1) NOT NULL,
    [DateCalcul]        DATETIME      NULL,
    [AjustementID]      INT           NULL,
    [EssenceID]         VARCHAR (6)   NULL,
    [UniteID]           VARCHAR (6)   NULL,
    [LivraisonDetailID] INT           NULL,
    [UsineID]           VARCHAR (6)   NULL,
    [Volume]            FLOAT (53)    NULL,
    [Taux]              FLOAT (53)    NULL,
    [Montant]           FLOAT (53)    NULL,
    [Facture]           BIT           NULL,
    [FactureID]         INT           NULL,
    [ErreurCalcul]      BIT           NULL,
    [ErreurDescription] VARCHAR (300) NULL,
    [Code]              CHAR (4)      NULL,
    CONSTRAINT [PK_AjustementCalcule_Usine] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_AjustementCalcule_Usine_Ajustement_EssenceUnite] FOREIGN KEY ([AjustementID], [EssenceID], [UniteID], [Code]) REFERENCES [dbo].[Ajustement_EssenceUnite] ([AjustementID], [EssenceID], [UniteID], [Code]) ON UPDATE CASCADE,
    CONSTRAINT [FK_AjustementCalcule_Usine_FactureClient] FOREIGN KEY ([FactureID]) REFERENCES [dbo].[FactureClient] ([ID]),
    CONSTRAINT [FK_AjustementCalcule_Usine_Livraison_Detail] FOREIGN KEY ([LivraisonDetailID]) REFERENCES [dbo].[Livraison_Detail] ([ID]),
    CONSTRAINT [FK_AjustementCalcule_Usine_Usine] FOREIGN KEY ([UsineID]) REFERENCES [dbo].[Usine] ([ID])
);

