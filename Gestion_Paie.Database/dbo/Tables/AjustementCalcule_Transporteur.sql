CREATE TABLE [dbo].[AjustementCalcule_Transporteur] (
    [ID]                INT           IDENTITY (1, 1) NOT NULL,
    [DateCalcul]        DATETIME      NULL,
    [AjustementID]      INT           NULL,
    [UniteID]           VARCHAR (6)   NULL,
    [MunicipaliteID]    VARCHAR (6)   NULL,
    [LivraisonID]       INT           NULL,
    [TransporteurID]    VARCHAR (15)  NULL,
    [Volume]            FLOAT (53)    NULL,
    [Taux]              FLOAT (53)    NULL,
    [Montant]           FLOAT (53)    NULL,
    [Facture]           BIT           NULL,
    [FactureID]         INT           NULL,
    [ErreurCalcul]      BIT           NULL,
    [ErreurDescription] VARCHAR (300) NULL,
    [ZoneID]            VARCHAR (2)   NULL,
    CONSTRAINT [PK_AjustementCalcule_Transporteur] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_AjustementCalcule_Transporteur_Ajustement_Transporteur] FOREIGN KEY ([AjustementID], [UniteID], [MunicipaliteID], [ZoneID]) REFERENCES [dbo].[Ajustement_Transporteur] ([AjustementID], [UniteID], [MunicipaliteID], [ZoneID]) ON UPDATE CASCADE,
    CONSTRAINT [FK_AjustementCalcule_Transporteur_Facture] FOREIGN KEY ([FactureID]) REFERENCES [dbo].[FactureFournisseur] ([ID]),
    CONSTRAINT [FK_AjustementCalcule_Transporteur_Fournisseur] FOREIGN KEY ([TransporteurID]) REFERENCES [dbo].[Fournisseur] ([ID]),
    CONSTRAINT [FK_AjustementCalcule_Transporteur_Livraison] FOREIGN KEY ([LivraisonID]) REFERENCES [dbo].[Livraison] ([ID])
);

