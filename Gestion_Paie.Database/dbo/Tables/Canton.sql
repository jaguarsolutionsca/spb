CREATE TABLE [dbo].[Canton] (
    [ID]          VARCHAR (6)  NOT NULL,
    [Description] VARCHAR (50) NULL,
    [Actif]       BIT          NULL,
    CONSTRAINT [PK_Canton] PRIMARY KEY CLUSTERED ([ID] ASC)
);

