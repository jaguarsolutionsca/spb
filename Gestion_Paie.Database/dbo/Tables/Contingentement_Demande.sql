CREATE TABLE [dbo].[Contingentement_Demande] (
    [ID]                INT            IDENTITY (1, 1) NOT NULL,
    [Annee]             INT            NULL,
    [ProducteurID]      VARCHAR (15)   NULL,
    [TransporteurID]    VARCHAR (15)   NULL,
    [Superficie_Boisee] REAL           NULL,
    [Remarques]         VARCHAR (2000) NULL,
    [DateModification]  SMALLDATETIME  NULL,
    CONSTRAINT [PK_Contingentement_Demande] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Contingentement_Demande_Fournisseur1] FOREIGN KEY ([ProducteurID]) REFERENCES [dbo].[Fournisseur] ([ID]),
    CONSTRAINT [FK_Contingentement_Demande_Fournisseur2] FOREIGN KEY ([TransporteurID]) REFERENCES [dbo].[Fournisseur] ([ID])
);

