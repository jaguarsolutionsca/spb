CREATE TABLE [dbo].[Staff] (
    [ID]        INT           IDENTITY (1, 1) NOT NULL,
    [FirstName] NVARCHAR (50) NOT NULL,
    [LastName]  NVARCHAR (50) NOT NULL,
    [OfficeID]  INT           NULL,
    [JobID]     INT           NULL,
    [Archive]   BIT           NOT NULL,
    [Created]   DATETIME      NOT NULL,
    [Updated]   DATETIME      NOT NULL,
    [UpdatedBy] INT           NOT NULL,
    CONSTRAINT [PK_Staff] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Staff_Job] FOREIGN KEY ([JobID]) REFERENCES [dbo].[Job] ([ID]),
    CONSTRAINT [FK_Staff_Office] FOREIGN KEY ([OfficeID]) REFERENCES [dbo].[Office] ([ID])
);

