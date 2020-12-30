CREATE TABLE [dbo].[UniteMesure] (
    [ID]                             VARCHAR (6)  NOT NULL,
    [Description]                    VARCHAR (25) NULL,
    [Nb_decimale]                    INT          NULL,
    [Actif]                          BIT          NULL,
    [UseMontant]                     BIT          CONSTRAINT [DF_UniteMesure_UseMontant] DEFAULT (1) NULL,
    [Montant_Preleve_plan_conjoint]  FLOAT (53)   NULL,
    [Montant_Preleve_fond_roulement] FLOAT (53)   NULL,
    [Montant_Preleve_fond_forestier] FLOAT (53)   NULL,
    [Montant_Preleve_divers]         FLOAT (53)   NULL,
    [Pourc_Preleve_plan_conjoint]    FLOAT (53)   NULL,
    [Pourc_Preleve_fond_roulement]   FLOAT (53)   NULL,
    [Pourc_Preleve_fond_forestier]   FLOAT (53)   NULL,
    [Pourc_Preleve_divers]           FLOAT (53)   NULL,
    CONSTRAINT [PK_UniteMesure] PRIMARY KEY CLUSTERED ([ID] ASC)
);

