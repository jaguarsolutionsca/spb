CREATE TABLE [dbo].[Livraison_Detail] (
    [ID]                              INT          IDENTITY (1, 1) NOT NULL,
    [LivraisonID]                     INT          NOT NULL,
    [ContratID]                       VARCHAR (10) NOT NULL,
    [EssenceID]                       VARCHAR (6)  NOT NULL,
    [UniteMesureID]                   VARCHAR (6)  NOT NULL,
    [ProducteurID]                    VARCHAR (15) NOT NULL,
    [Droit_Coupe]                     BIT          NULL,
    [VolumeBrut]                      FLOAT (53)   NULL,
    [VolumeReduction]                 FLOAT (53)   NULL,
    [VolumeNet]                       FLOAT (53)   NULL,
    [VolumeContingente]               FLOAT (53)   NULL,
    [ContingentementID]               INT          NULL,
    [DateCalcul]                      DATETIME     NULL,
    [Taux_Usine]                      FLOAT (53)   NULL,
    [Montant_Usine]                   FLOAT (53)   NULL,
    [Taux_Producteur]                 FLOAT (53)   NULL,
    [Montant_ProducteurBrut]          FLOAT (53)   NULL,
    [Taux_TransporteurMoyen]          FLOAT (53)   NULL,
    [Taux_TransporteurMoyen_Override] BIT          NULL,
    [Montant_TransporteurMoyen]       FLOAT (53)   NULL,
    [Taux_Preleve_Plan_Conjoint]      FLOAT (53)   NULL,
    [Montant_Preleve_Plan_Conjoint]   FLOAT (53)   NULL,
    [Taux_Preleve_Fond_Roulement]     FLOAT (53)   NULL,
    [Montant_Preleve_Fond_Roulement]  FLOAT (53)   NULL,
    [Taux_Preleve_Fond_Forestier]     FLOAT (53)   NULL,
    [Montant_Preleve_Fond_Forestier]  FLOAT (53)   NULL,
    [Taux_Preleve_Divers]             FLOAT (53)   NULL,
    [Montant_Preleve_Divers]          FLOAT (53)   NULL,
    [Montant_ProducteurNet]           FLOAT (53)   NULL,
    [Taux_Producteur_Override]        BIT          NULL,
    [Taux_Usine_Override]             BIT          NULL,
    [Code]                            CHAR (4)     NULL,
    [UsePreleveMontant]               BIT          NULL,
    CONSTRAINT [PK_Livraison_Detail] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Livraison_Detail_Contingentement] FOREIGN KEY ([ContingentementID]) REFERENCES [dbo].[Contingentement] ([ID]),
    CONSTRAINT [FK_Livraison_Detail_Contrat_EssenceUnite] FOREIGN KEY ([ContratID], [EssenceID], [UniteMesureID], [Code]) REFERENCES [dbo].[Contrat_EssenceUnite] ([ContratID], [EssenceID], [UniteID], [Code]) ON UPDATE CASCADE,
    CONSTRAINT [FK_Livraison_Detail_Fournisseur] FOREIGN KEY ([ProducteurID]) REFERENCES [dbo].[Fournisseur] ([ID]),
    CONSTRAINT [FK_Livraison_Detail_Livraison] FOREIGN KEY ([LivraisonID]) REFERENCES [dbo].[Livraison] ([ID]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [LivraisonID]
    ON [dbo].[Livraison_Detail]([LivraisonID] ASC);


GO
CREATE NONCLUSTERED INDEX [essence_uniteMesure]
    ON [dbo].[Livraison_Detail]([EssenceID] ASC, [UniteMesureID] ASC);


GO
CREATE NONCLUSTERED INDEX [ContingentementID]
    ON [dbo].[Livraison_Detail]([ContingentementID] ASC);

