CREATE TABLE [dbo].[jag_ProfileSettings] (
    [ProfileID] INT           NOT NULL,
    [Name]      VARCHAR (500) NOT NULL,
    [Value]     VARCHAR (500) NULL,
    CONSTRAINT [PK_ProfileSettings] PRIMARY KEY CLUSTERED ([ProfileID] ASC, [Name] ASC),
    CONSTRAINT [FK_ProfileSettings_Profil] FOREIGN KEY ([ProfileID]) REFERENCES [dbo].[jag_Profile] ([ID]) ON DELETE CASCADE
);

