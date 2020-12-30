CREATE TABLE [dbo].[Essence] (
    [ID]             VARCHAR (6)  NOT NULL,
    [Description]    VARCHAR (25) NULL,
    [RegroupementID] INT          NULL,
    [ContingentID]   INT          NULL,
    [RepartitionID]  INT          NULL,
    [Actif]          BIT          NULL,
    CONSTRAINT [PK_Essence] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Essence_EssenceContingent] FOREIGN KEY ([ContingentID]) REFERENCES [dbo].[EssenceContingent] ([ID]),
    CONSTRAINT [FK_Essence_EssenceRegroupement] FOREIGN KEY ([RegroupementID]) REFERENCES [dbo].[EssenceRegroupement] ([ID]),
    CONSTRAINT [FK_Essence_EssenceRepartition] FOREIGN KEY ([RepartitionID]) REFERENCES [dbo].[EssenceRepartition] ([ID])
);

