CREATE TABLE [dbo].[Job] (
    [ID]        INT           IDENTITY (1, 1) NOT NULL,
    [Title]     NVARCHAR (50) NOT NULL,
    [KindLUID]  INT           NULL,
    [Archive]   BIT           CONSTRAINT [DF_Job_Archive] DEFAULT ((0)) NOT NULL,
    [Created]   DATETIME      NOT NULL,
    [Updated]   DATETIME      NOT NULL,
    [UpdatedBy] INT           NOT NULL,
    CONSTRAINT [PK_Job] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Job_Lookup] FOREIGN KEY ([KindLUID]) REFERENCES [app].[Lookup] ([ID])
);

