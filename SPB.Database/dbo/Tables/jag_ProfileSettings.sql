CREATE TABLE [dbo].[jag_ProfileSettings] (
    [ProfileID] INT            NOT NULL,
    [Name]      NVARCHAR (50)  NOT NULL,
    [Value]     NVARCHAR (500) NULL,
    CONSTRAINT [PK_jag_ProfileSettings] PRIMARY KEY CLUSTERED ([ProfileID] ASC, [Name] ASC)
);

