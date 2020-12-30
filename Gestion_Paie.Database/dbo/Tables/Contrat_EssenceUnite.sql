CREATE TABLE [dbo].[Contrat_EssenceUnite] (
    [ContratID]       VARCHAR (10) NOT NULL,
    [EssenceID]       VARCHAR (6)  NOT NULL,
    [UniteID]         VARCHAR (6)  NOT NULL,
    [Code]            CHAR (4)     NOT NULL,
    [Quantite_prevue] FLOAT (53)   NULL,
    [Taux_usine]      FLOAT (53)   NULL,
    [Taux_producteur] REAL         NULL,
    [Actif]           BIT          NULL,
    [Description]     VARCHAR (50) NULL,
    CONSTRAINT [PK_Contrat_EssenceUnite] PRIMARY KEY CLUSTERED ([ContratID] ASC, [EssenceID] ASC, [UniteID] ASC, [Code] ASC),
    CONSTRAINT [FK_Contrat_EssenceUnite_Contrat] FOREIGN KEY ([ContratID]) REFERENCES [dbo].[Contrat] ([ID]) ON DELETE CASCADE,
    CONSTRAINT [FK_Contrat_EssenceUnite_Essence_Unite] FOREIGN KEY ([EssenceID], [UniteID]) REFERENCES [dbo].[Essence_Unite] ([EssenceID], [UniteID]) ON UPDATE CASCADE
);

