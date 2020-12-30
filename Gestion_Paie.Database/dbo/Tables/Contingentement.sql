CREATE TABLE [dbo].[Contingentement] (
    [ID]                              INT         IDENTITY (1, 1) NOT NULL,
    [ContingentUsine]                 BIT         NULL,
    [UsineID]                         VARCHAR (6) NULL,
    [RegroupementID]                  INT         NULL,
    [Annee]                           INT         NULL,
    [PeriodeContingentement]          INT         NULL,
    [PeriodeDebut]                    INT         NULL,
    [PeriodeFin]                      INT         NULL,
    [EssenceID]                       VARCHAR (6) NULL,
    [UniteMesureID]                   VARCHAR (6) NULL,
    [Volume_Usine]                    REAL        NULL,
    [Facteur]                         REAL        NULL,
    [Volume_Fixe]                     REAL        NULL,
    [Date_Calcul]                     DATETIME    NULL,
    [CalculAccepte]                   BIT         NULL,
    [Code]                            CHAR (4)    NULL,
    [Volume_Regroupement]             REAL        NULL,
    [Volume_RegroupementPourcentage]  REAL        NULL,
    [MaxVolumeFixe_Pourcentage]       REAL        NULL,
    [MaxVolumeFixe_ContingentementID] INT         NULL,
    [UseVolumeFixeUnique]             BIT         DEFAULT (1) NOT NULL,
    [MasseContingentVoyageDefaut]     REAL        NULL,
    CONSTRAINT [PK_Contingentement] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Contingentement_Essence] FOREIGN KEY ([EssenceID]) REFERENCES [dbo].[Essence] ([ID]),
    CONSTRAINT [FK_Contingentement_EssenceRegroupement] FOREIGN KEY ([RegroupementID]) REFERENCES [dbo].[EssenceRegroupement] ([ID]),
    CONSTRAINT [FK_Contingentement_UniteMesure] FOREIGN KEY ([UniteMesureID]) REFERENCES [dbo].[UniteMesure] ([ID]) ON UPDATE CASCADE,
    CONSTRAINT [FK_Contingentement_Usine] FOREIGN KEY ([UsineID]) REFERENCES [dbo].[Usine] ([ID])
);


GO
CREATE NONCLUSTERED INDEX [NonClusteredIndex-20170509-141229]
    ON [dbo].[Contingentement]([ContingentUsine] ASC, [Annee] ASC, [PeriodeContingentement] ASC);

