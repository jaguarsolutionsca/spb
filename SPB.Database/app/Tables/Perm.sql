CREATE TABLE [app].[Perm] (
    [CID]       INT NOT NULL,
    [PermID]    INT NOT NULL,
    [PermValue] INT NOT NULL,
    CONSTRAINT [PK_Perm] PRIMARY KEY CLUSTERED ([CID] ASC, [PermID] ASC)
);

