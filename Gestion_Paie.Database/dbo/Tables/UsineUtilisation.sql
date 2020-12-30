CREATE TABLE [dbo].[UsineUtilisation] (
    [ID]          INT          IDENTITY (1, 1) NOT NULL,
    [Description] VARCHAR (50) NULL,
    [isPate]      BIT          CONSTRAINT [DF_UsineUtilisation_isPate] DEFAULT (0) NOT NULL,
    [Actif]       BIT          NULL,
    CONSTRAINT [PK_UsineUtilisation] PRIMARY KEY CLUSTERED ([ID] ASC)
);

