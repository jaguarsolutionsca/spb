CREATE TABLE [dbo].[Essence_Unite] (
    [EssenceID]                       VARCHAR (6) NOT NULL,
    [UniteID]                         VARCHAR (6) NOT NULL,
    [Facteur_M3app]                   REAL        NULL,
    [Facteur_M3sol]                   REAL        NULL,
    [Facteur_FPBQ]                    REAL        CONSTRAINT [DF_Essence_Unite_Facteur_FPBQ] DEFAULT (0) NULL,
    [Actif]                           BIT         NULL,
    [Preleve_plan_conjoint]           REAL        NULL,
    [Preleve_plan_conjoint_Override]  BIT         NULL,
    [Preleve_fond_roulement]          REAL        NULL,
    [Preleve_fond_roulement_Override] BIT         NULL,
    [Preleve_fond_forestier]          REAL        NULL,
    [Preleve_fond_forestier_Override] BIT         NULL,
    [Preleve_divers]                  REAL        NULL,
    [Preleve_divers_Override]         BIT         NULL,
    [UseMontant]                      BIT         CONSTRAINT [DF_Essence_Unite_UseMontant] DEFAULT (1) NOT NULL,
    CONSTRAINT [PK_Essence_Unite] PRIMARY KEY CLUSTERED ([EssenceID] ASC, [UniteID] ASC),
    CONSTRAINT [FK_Essence_Unite_Essence] FOREIGN KEY ([EssenceID]) REFERENCES [dbo].[Essence] ([ID]) ON DELETE CASCADE,
    CONSTRAINT [FK_Essence_Unite_UniteMesure] FOREIGN KEY ([UniteID]) REFERENCES [dbo].[UniteMesure] ([ID]) ON UPDATE CASCADE
);

