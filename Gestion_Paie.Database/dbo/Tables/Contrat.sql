CREATE TABLE [dbo].[Contrat] (
    [ID]               VARCHAR (10)  NOT NULL,
    [Description]      VARCHAR (50)  NULL,
    [UsineID]          VARCHAR (6)   NULL,
    [Annee]            INT           NULL,
    [Date_debut]       SMALLDATETIME NULL,
    [Date_fin]         SMALLDATETIME NULL,
    [Actif]            BIT           NULL,
    [PaieTransporteur] BIT           NULL,
    [Taux_Surcharge]   FLOAT (53)    NULL,
    [SurchargeManuel]  BIT           NULL,
    [TxTransSameProd]  BIT           NULL,
    CONSTRAINT [PK_Contrat] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Contrat_Usine] FOREIGN KEY ([UsineID]) REFERENCES [dbo].[Usine] ([ID])
);

