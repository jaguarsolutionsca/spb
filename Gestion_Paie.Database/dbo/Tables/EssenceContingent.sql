CREATE TABLE [dbo].[EssenceContingent] (
    [ID]          INT          IDENTITY (1, 1) NOT NULL,
    [Description] VARCHAR (25) NULL,
    [Actif]       BIT          NULL,
    CONSTRAINT [PK_ContingentEssence] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [IX_EssenceContingent] UNIQUE NONCLUSTERED ([Description] ASC)
);

