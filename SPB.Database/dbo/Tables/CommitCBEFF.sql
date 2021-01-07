CREATE TABLE [dbo].[CommitCBEFF] (
    [ID]         INT           IDENTITY (1, 1) NOT NULL,
    [Year]       INT           NOT NULL,
    [RegionLUID] INT           NOT NULL,
    [Details]    NVARCHAR (50) NULL,
    [MonthPaid]  NVARCHAR (25) NULL,
    [Paid]       BIT           NOT NULL,
    [Amount]     MONEY         NOT NULL,
    [Comment]    NVARCHAR (50) NULL,
    [Archive]    BIT           NOT NULL,
    [Created]    DATETIME      NOT NULL,
    [Updated]    DATETIME      NOT NULL,
    [UpdatedBy]  INT           NOT NULL,
    CONSTRAINT [PK_CommitCBEFF] PRIMARY KEY CLUSTERED ([ID] ASC)
);

