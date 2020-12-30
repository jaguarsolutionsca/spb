CREATE TABLE [dbo].[Contrat_Transporteur] (
    [ContratID]         VARCHAR (10) NOT NULL,
    [UniteID]           VARCHAR (6)  NOT NULL,
    [MunicipaliteID]    VARCHAR (6)  NOT NULL,
    [Taux_transporteur] REAL         NULL,
    [Taux_producteur]   REAL         NULL,
    [Actif]             BIT          NULL,
    [ZoneID]            VARCHAR (2)  DEFAULT ('0') NOT NULL,
    CONSTRAINT [PK_Contrat_Transporteur] PRIMARY KEY CLUSTERED ([ContratID] ASC, [UniteID] ASC, [MunicipaliteID] ASC, [ZoneID] ASC),
    CONSTRAINT [FK_Contrat_Transporteur_Contrat] FOREIGN KEY ([ContratID]) REFERENCES [dbo].[Contrat] ([ID]) ON DELETE CASCADE,
    CONSTRAINT [FK_Contrat_Transporteur_Municipalite_Zone] FOREIGN KEY ([ZoneID], [MunicipaliteID]) REFERENCES [dbo].[Municipalite_Zone] ([ID], [MunicipaliteID]) ON UPDATE CASCADE,
    CONSTRAINT [FK_Contrat_Transporteur_UniteMesure] FOREIGN KEY ([UniteID]) REFERENCES [dbo].[UniteMesure] ([ID]) ON UPDATE CASCADE
);

