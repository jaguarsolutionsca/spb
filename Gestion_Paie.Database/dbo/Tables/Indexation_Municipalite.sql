CREATE TABLE [dbo].[Indexation_Municipalite] (
    [ID]             INT         IDENTITY (1, 1) NOT NULL,
    [IndexationID]   INT         NULL,
    [MunicipaliteID] VARCHAR (6) NULL,
    [Montant]        REAL        NULL,
    [ZoneID]         VARCHAR (2) NULL,
    CONSTRAINT [PK_Indexation_Municipalite] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Indexation_Municipalite_Indexation] FOREIGN KEY ([IndexationID]) REFERENCES [dbo].[Indexation] ([ID]) ON DELETE CASCADE,
    CONSTRAINT [FK_Indexation_Municipalite_Municipalite_Zone] FOREIGN KEY ([ZoneID], [MunicipaliteID]) REFERENCES [dbo].[Municipalite_Zone] ([ID], [MunicipaliteID]) ON UPDATE CASCADE
);

