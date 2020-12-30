CREATE TABLE [dbo].[Contingentement_Producteur] (
    [ContingentementID]       INT           NOT NULL,
    [ProducteurID]            VARCHAR (15)  NOT NULL,
    [Superficie_Contingentee] REAL          NULL,
    [Volume_Demande]          REAL          NULL,
    [Volume_Facteur]          REAL          NULL,
    [Volume_Fixe]             REAL          NULL,
    [Volume_Supplementaire]   REAL          NULL,
    [Volume_Accorde]          REAL          NULL,
    [Date_Modification]       DATETIME      NULL,
    [Volume_Inventaire]       REAL          NULL,
    [LastLivraison]           SMALLDATETIME NULL,
    [VolumeMaximum]           REAL          NULL,
    [Imprime]                 BIT           CONSTRAINT [DF_Contingentement_Producteur_Imprime] DEFAULT (0) NOT NULL,
    CONSTRAINT [PK_Contingentement_Producteur] PRIMARY KEY CLUSTERED ([ContingentementID] ASC, [ProducteurID] ASC),
    CONSTRAINT [FK_Contingentement_Producteur_Contingentement] FOREIGN KEY ([ContingentementID]) REFERENCES [dbo].[Contingentement] ([ID]) ON DELETE CASCADE,
    CONSTRAINT [FK_Contingentement_Producteur_Fournisseur] FOREIGN KEY ([ProducteurID]) REFERENCES [dbo].[Fournisseur] ([ID])
);


GO
CREATE NONCLUSTERED INDEX [NonClusteredIndex-20170509-141635]
    ON [dbo].[Contingentement_Producteur]([ContingentementID] ASC, [ProducteurID] ASC);

