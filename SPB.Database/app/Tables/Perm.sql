CREATE TABLE [app].[Perm] (
    [CIE]       INT NOT NULL,
    [PermID]    INT NOT NULL,
    [PermValue] INT NOT NULL,
    CONSTRAINT [PK_Perm] PRIMARY KEY CLUSTERED ([CIE] ASC, [PermID] ASC)
);

