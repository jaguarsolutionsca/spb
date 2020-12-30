CREATE TABLE [dbo].[Agence] (
    [ID]          VARCHAR (4)   NOT NULL,
    [Description] VARCHAR (150) NULL,
    [Actif]       BIT           NULL,
    CONSTRAINT [PK_Agence] PRIMARY KEY CLUSTERED ([ID] ASC)
);

