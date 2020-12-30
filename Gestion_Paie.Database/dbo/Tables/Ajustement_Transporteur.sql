CREATE TABLE [dbo].[Ajustement_Transporteur] (
    [AjustementID]      INT          NOT NULL,
    [UniteID]           VARCHAR (6)  NOT NULL,
    [MunicipaliteID]    VARCHAR (6)  NOT NULL,
    [ContratID]         VARCHAR (10) NOT NULL,
    [Taux_transporteur] REAL         NULL,
    [Date_Modification] DATETIME     NULL,
    [ZoneID]            VARCHAR (2)  DEFAULT ('0') NOT NULL,
    CONSTRAINT [PK_Ajustement_Transporteur] PRIMARY KEY CLUSTERED ([AjustementID] ASC, [UniteID] ASC, [MunicipaliteID] ASC, [ZoneID] ASC),
    CONSTRAINT [FK_Ajustement_Transporteur_Ajustement] FOREIGN KEY ([AjustementID]) REFERENCES [dbo].[Ajustement] ([ID]) ON DELETE CASCADE,
    CONSTRAINT [FK_Ajustement_Transporteur_Contrat_Transporteur] FOREIGN KEY ([ContratID], [UniteID], [MunicipaliteID], [ZoneID]) REFERENCES [dbo].[Contrat_Transporteur] ([ContratID], [UniteID], [MunicipaliteID], [ZoneID]) ON UPDATE CASCADE
);

