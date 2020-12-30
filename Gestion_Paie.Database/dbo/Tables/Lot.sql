CREATE TABLE [dbo].[Lot] (
    [CantonID]              VARCHAR (6)   NULL,
    [Rang]                  VARCHAR (25)  NULL,
    [Lot]                   VARCHAR (6)   NULL,
    [MunicipaliteID]        VARCHAR (6)   NULL,
    [Superficie_total]      REAL          NULL,
    [Superficie_boisee]     REAL          NULL,
    [ProprietaireID]        VARCHAR (15)  NULL,
    [ContingentID]          VARCHAR (15)  NULL,
    [Contingent_Date]       SMALLDATETIME NULL,
    [Droit_coupeID]         VARCHAR (15)  NULL,
    [Droit_coupe_Date]      SMALLDATETIME NULL,
    [Entente_paiementID]    VARCHAR (15)  NULL,
    [Entente_paiement_Date] SMALLDATETIME NULL,
    [Actif]                 BIT           NULL,
    [ID]                    INT           IDENTITY (1, 1) NOT NULL,
    [Sequence]              VARCHAR (6)   NULL,
    [Partie]                BIT           NULL,
    [Matricule]             VARCHAR (20)  NULL,
    [ZoneID]                VARCHAR (2)   NULL,
    [Secteur]               VARCHAR (2)   NULL,
    [Cadastre]              INT           NULL,
    [Reforme]               BIT           NULL,
    [LotsComplementaires]   VARCHAR (255) NULL,
    [Certifie]              BIT           NULL,
    [NumeroCertification]   VARCHAR (50)  NULL,
    [OGC]                   BIT           NULL,
    CONSTRAINT [PK_Lot] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Lot_Canton] FOREIGN KEY ([CantonID]) REFERENCES [dbo].[Canton] ([ID]),
    CONSTRAINT [FK_Lot_Fournisseur] FOREIGN KEY ([ProprietaireID]) REFERENCES [dbo].[Fournisseur] ([ID]),
    CONSTRAINT [FK_Lot_Fournisseur1] FOREIGN KEY ([ContingentID]) REFERENCES [dbo].[Fournisseur] ([ID]),
    CONSTRAINT [FK_Lot_Fournisseur2] FOREIGN KEY ([Droit_coupeID]) REFERENCES [dbo].[Fournisseur] ([ID]),
    CONSTRAINT [FK_Lot_Fournisseur3] FOREIGN KEY ([Entente_paiementID]) REFERENCES [dbo].[Fournisseur] ([ID]),
    CONSTRAINT [FK_Lot_Municipalite_Zone] FOREIGN KEY ([ZoneID], [MunicipaliteID]) REFERENCES [dbo].[Municipalite_Zone] ([ID], [MunicipaliteID]) ON UPDATE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Lot_Droit_CoupeID]
    ON [dbo].[Lot]([Droit_coupeID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Lot_ProprietaireID]
    ON [dbo].[Lot]([ProprietaireID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Lot_Droit_Coupe_Date]
    ON [dbo].[Lot]([CantonID] ASC, [Droit_coupe_Date] ASC);

