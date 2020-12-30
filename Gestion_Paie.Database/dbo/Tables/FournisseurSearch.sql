CREATE TABLE [dbo].[FournisseurSearch] (
    [FournisseurID] VARCHAR (15)  NOT NULL,
    [Nom]           VARCHAR (40)  NULL,
    [AuSoinsDe]     VARCHAR (30)  NULL,
    [Rue]           VARCHAR (30)  NULL,
    [Ville]         VARCHAR (30)  NULL,
    [TextSearch]    VARCHAR (255) NULL,
    CONSTRAINT [PK_FournisseurSearch] PRIMARY KEY CLUSTERED ([FournisseurID] ASC)
);

