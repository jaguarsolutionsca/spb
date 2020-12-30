CREATE TABLE [dbo].[EssenceRepartition] (
    [ID]          INT          IDENTITY (1, 1) NOT NULL,
    [Description] VARCHAR (25) NULL,
    [Actif]       BIT          NULL,
    CONSTRAINT [PK_EssenceRepartition] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [IX_EssenceRepartition] UNIQUE NONCLUSTERED ([Description] ASC)
);

