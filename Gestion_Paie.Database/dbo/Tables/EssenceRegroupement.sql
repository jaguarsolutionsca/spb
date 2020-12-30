CREATE TABLE [dbo].[EssenceRegroupement] (
    [ID]          INT          IDENTITY (1, 1) NOT NULL,
    [Description] VARCHAR (25) NULL,
    [Actif]       BIT          NULL,
    [Ordre]       INT          CONSTRAINT [DF_EssenceRegroupement_Ordre] DEFAULT (0) NOT NULL,
    CONSTRAINT [PK_RegroupementEssence] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [IX_EssenceRegroupement] UNIQUE NONCLUSTERED ([Description] ASC)
);

