CREATE TABLE [dbo].[Pays] (
    [ID]                   VARCHAR (2)  NOT NULL,
    [Nom]                  VARCHAR (50) NULL,
    [CodePostal_InputMask] VARCHAR (50) NULL,
    [Actif]                BIT          NULL,
    CONSTRAINT [PK_Pays] PRIMARY KEY CLUSTERED ([ID] ASC)
);

