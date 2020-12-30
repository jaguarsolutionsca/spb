CREATE TABLE [dbo].[Municipalite] (
    [ID]          VARCHAR (6)  NOT NULL,
    [Description] VARCHAR (50) NULL,
    [MrcID]       VARCHAR (6)  NULL,
    [AgenceID]    VARCHAR (4)  NULL,
    [Actif]       BIT          NULL,
    CONSTRAINT [PK_Municipalite] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Municipalite_Agence] FOREIGN KEY ([AgenceID]) REFERENCES [dbo].[Agence] ([ID]),
    CONSTRAINT [FK_Municipalite_MRC] FOREIGN KEY ([MrcID]) REFERENCES [dbo].[MRC] ([ID])
);

