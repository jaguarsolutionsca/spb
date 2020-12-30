CREATE TABLE [dbo].[TypeFacture] (
    [ID]                     CHAR (1)      NOT NULL,
    [Description]            VARCHAR (25)  NULL,
    [FactureDescriptionMask] VARCHAR (200) NULL,
    CONSTRAINT [PK_TypeFacture] PRIMARY KEY CLUSTERED ([ID] ASC)
);

