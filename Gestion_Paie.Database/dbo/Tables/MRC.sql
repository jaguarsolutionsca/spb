CREATE TABLE [dbo].[MRC] (
    [ID]          VARCHAR (6)  NOT NULL,
    [Description] VARCHAR (50) NULL,
    [Actif]       BIT          NULL,
    CONSTRAINT [PK_MRC] PRIMARY KEY CLUSTERED ([ID] ASC)
);

