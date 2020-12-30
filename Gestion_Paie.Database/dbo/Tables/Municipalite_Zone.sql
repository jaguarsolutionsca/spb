CREATE TABLE [dbo].[Municipalite_Zone] (
    [ID]             VARCHAR (2)  NOT NULL,
    [MunicipaliteID] VARCHAR (6)  NOT NULL,
    [Description]    VARCHAR (50) NULL,
    [Actif]          BIT          NULL,
    CONSTRAINT [PK_Municipalite_Zone] PRIMARY KEY CLUSTERED ([ID] ASC, [MunicipaliteID] ASC),
    CONSTRAINT [FK_Municipalite_Zone_Municipalite] FOREIGN KEY ([MunicipaliteID]) REFERENCES [dbo].[Municipalite] ([ID]) ON DELETE CASCADE ON UPDATE CASCADE
);

