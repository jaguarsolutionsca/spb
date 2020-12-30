CREATE TABLE [dbo].[Contingentement_VolumeFixe] (
    [ContingentementID] INT  NOT NULL,
    [Superficie_Min]    REAL NOT NULL,
    [Volume_Fixe]       REAL NULL,
    [NombreMois]        INT  NULL,
    [UseNombreMois]     BIT  DEFAULT (1) NOT NULL,
    CONSTRAINT [PK_Contingentement_VolumeFixe] PRIMARY KEY CLUSTERED ([ContingentementID] ASC, [Superficie_Min] ASC),
    CONSTRAINT [FK_Contingentement_VolumeFixe_Contingentement] FOREIGN KEY ([ContingentementID]) REFERENCES [dbo].[Contingentement] ([ID])
);

