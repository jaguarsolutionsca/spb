CREATE TABLE [dbo].[Office] (
    [ID]        INT           IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (50) NOT NULL,
    [Location]  NVARCHAR (50) NOT NULL,
    [OpenedOn]  DATE          NULL,
    [Archive]   BIT           CONSTRAINT [DF_Office_Archive] DEFAULT ((0)) NOT NULL,
    [Created]   DATETIME      NOT NULL,
    [Updated]   DATETIME      NOT NULL,
    [UpdatedBy] INT           NOT NULL,
    CONSTRAINT [PK_Office] PRIMARY KEY CLUSTERED ([ID] ASC)
);

