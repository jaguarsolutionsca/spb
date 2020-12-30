CREATE TABLE [dbo].[IndexationCalcule_Transporteur] (
    [ID]                   INT           IDENTITY (1, 1) NOT NULL,
    [DateCalcul]           DATETIME      NULL,
    [TypeIndexation]       CHAR (1)      NULL,
    [IndexationID]         INT           NULL,
    [IndexationDetailID]   INT           NULL,
    [LivraisonID]          INT           NULL,
    [TransporteurID]       VARCHAR (15)  NULL,
    [MontantDejaPaye]      FLOAT (53)    NULL,
    [PourcentageDuMontant] FLOAT (53)    NULL,
    [Montant]              FLOAT (53)    NULL,
    [Facture]              BIT           NULL,
    [FactureID]            INT           NULL,
    [ErreurCalcul]         BIT           NULL,
    [ErreurDescription]    VARCHAR (300) NULL,
    CONSTRAINT [PK_IndexationCalcule_Transporteur] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_IndexationCalcule_Transporteur_FactureFournisseur] FOREIGN KEY ([FactureID]) REFERENCES [dbo].[FactureFournisseur] ([ID]),
    CONSTRAINT [FK_IndexationCalcule_Transporteur_Fournisseur] FOREIGN KEY ([TransporteurID]) REFERENCES [dbo].[Fournisseur] ([ID]),
    CONSTRAINT [FK_IndexationCalcule_Transporteur_Indexation] FOREIGN KEY ([IndexationID]) REFERENCES [dbo].[Indexation] ([ID]) ON DELETE CASCADE,
    CONSTRAINT [FK_IndexationCalcule_Transporteur_Indexation_Municipalite] FOREIGN KEY ([IndexationDetailID]) REFERENCES [dbo].[Indexation_Municipalite] ([ID]),
    CONSTRAINT [FK_IndexationCalcule_Transporteur_Livraison] FOREIGN KEY ([LivraisonID]) REFERENCES [dbo].[Livraison] ([ID]),
    CONSTRAINT [FK_IndexationCalcule_Transporteur_TypeIndexation] FOREIGN KEY ([TypeIndexation]) REFERENCES [dbo].[TypeIndexation] ([ID])
);


GO
CREATE NONCLUSTERED INDEX [ix_IndexationCalcule_Transporteur_IndexationID_Facture]
    ON [dbo].[IndexationCalcule_Transporteur]([IndexationID] ASC, [Facture] ASC);


GO
CREATE NONCLUSTERED INDEX [ix_IndexationCalcule_Transporteur_Facture]
    ON [dbo].[IndexationCalcule_Transporteur]([Facture] ASC)
    INCLUDE([IndexationID]);

