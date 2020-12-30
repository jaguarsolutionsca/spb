CREATE TABLE [dbo].[Ajustement_EssenceUnite] (
    [AjustementID]      INT          NOT NULL,
    [EssenceID]         VARCHAR (6)  NOT NULL,
    [UniteID]           VARCHAR (6)  NOT NULL,
    [ContratID]         VARCHAR (10) NOT NULL,
    [Taux_usine]        REAL         NULL,
    [Taux_producteur]   REAL         NULL,
    [Taux_transporteur] REAL         NULL,
    [Date_Modification] DATETIME     NULL,
    [Code]              CHAR (4)     NOT NULL,
    CONSTRAINT [PK_Ajustement_EssenceUnite] PRIMARY KEY CLUSTERED ([AjustementID] ASC, [EssenceID] ASC, [UniteID] ASC, [Code] ASC),
    CONSTRAINT [FK_Ajustement_EssenceUnite_Ajustement] FOREIGN KEY ([AjustementID]) REFERENCES [dbo].[Ajustement] ([ID]) ON DELETE CASCADE,
    CONSTRAINT [FK_Ajustement_EssenceUnite_Contrat_EssenceUnite] FOREIGN KEY ([ContratID], [EssenceID], [UniteID], [Code]) REFERENCES [dbo].[Contrat_EssenceUnite] ([ContratID], [EssenceID], [UniteID], [Code]) ON UPDATE CASCADE
);

