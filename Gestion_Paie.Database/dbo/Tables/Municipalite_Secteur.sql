CREATE TABLE [dbo].[Municipalite_Secteur] (
    [MunicipaliteID] VARCHAR (6) NOT NULL,
    [Secteur]        VARCHAR (2) NOT NULL,
    [Actif]          BIT         NULL,
    CONSTRAINT [PK_Municipalite_Secteur] PRIMARY KEY CLUSTERED ([MunicipaliteID] ASC, [Secteur] ASC),
    CONSTRAINT [FK_Municipalite_Secteur_Municipalite] FOREIGN KEY ([MunicipaliteID]) REFERENCES [dbo].[Municipalite] ([ID]) ON DELETE CASCADE ON UPDATE CASCADE
);

