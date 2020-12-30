CREATE TABLE [dbo].[jag_Profile] (
    [ID]       INT           NOT NULL,
    [Nom]      VARCHAR (100) NULL,
    [Password] VARCHAR (20)  NULL,
    CONSTRAINT [PK_Profil] PRIMARY KEY CLUSTERED ([ID] ASC)
);

