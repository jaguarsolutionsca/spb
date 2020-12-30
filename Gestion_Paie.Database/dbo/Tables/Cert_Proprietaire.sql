CREATE TABLE [dbo].[Cert_Proprietaire] (
    [Agence]         VARCHAR (10) NOT NULL,
    [NO_ACT]         VARCHAR (10) NOT NULL,
    [Nom]            VARCHAR (50) NULL,
    [Representant]   VARCHAR (35) NULL,
    [ADRESSE]        VARCHAR (50) NULL,
    [Ville]          VARCHAR (50) NULL,
    [CODE_POST]      VARCHAR (25) NULL,
    [TEL_RES]        VARCHAR (25) NULL,
    [TEL_BUR]        VARCHAR (25) NULL,
    [FournisseurID]  VARCHAR (15) NULL,
    [FournisseurNom] VARCHAR (40) NULL,
    [Traite]         BIT          DEFAULT (0) NULL,
    [Methode]        VARCHAR (25) NULL,
    CONSTRAINT [PK_Cert_Proprietaire] PRIMARY KEY CLUSTERED ([Agence] ASC, [NO_ACT] ASC),
    CONSTRAINT [FK_Cert_Proprietaire_Fournisseur] FOREIGN KEY ([FournisseurID]) REFERENCES [dbo].[Fournisseur] ([ID])
);

