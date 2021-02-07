CREATE TABLE [dbo].[_GenCore] (
    [TableName] NVARCHAR (50)  NOT NULL,
    [Node]      NVARCHAR (50)  NOT NULL,
    [KeyName]   NVARCHAR (20)  NOT NULL,
    [Value]     NVARCHAR (100) NULL,
    CONSTRAINT [PK__GenCore] PRIMARY KEY CLUSTERED ([TableName] ASC, [Node] ASC, [KeyName] ASC)
);

