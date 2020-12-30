CREATE TABLE [dbo].[InstitutionBanquaire] (
    [ID]          VARCHAR (3)  NOT NULL,
    [Description] VARCHAR (50) NULL,
    [Actif]       BIT          NULL,
    CONSTRAINT [PK_InstitutionBanquaire] PRIMARY KEY CLUSTERED ([ID] ASC)
);

