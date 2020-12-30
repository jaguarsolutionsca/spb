CREATE TABLE [dbo].[Periode] (
    [Annee]                  INT           NOT NULL,
    [SemaineNo]              INT           NOT NULL,
    [DateDebut]              SMALLDATETIME NULL,
    [DateFin]                SMALLDATETIME NULL,
    [PeriodeContingentement] INT           NULL,
    CONSTRAINT [PK_Periode] PRIMARY KEY CLUSTERED ([Annee] ASC, [SemaineNo] ASC)
);

