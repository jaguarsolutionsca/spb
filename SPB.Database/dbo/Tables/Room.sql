CREATE TABLE [dbo].[Room] (
    [ID]        INT           IDENTITY (1, 1) NOT NULL,
    [OfficeID]  INT           NOT NULL,
    [Name]      NVARCHAR (50) NOT NULL,
    [Floor]     INT           NOT NULL,
    [Number]    INT           NULL,
    [Archive]   BIT           NOT NULL,
    [Created]   DATETIME      NOT NULL,
    [Updated]   DATETIME      NOT NULL,
    [UpdatedBy] INT           NOT NULL,
    CONSTRAINT [PK_Room] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Room_Office] FOREIGN KEY ([OfficeID]) REFERENCES [dbo].[Office] ([ID])
);

