CREATE TABLE [dbo].[AjustementCalcule_Usine_Archive] (
    [ID]                INT           NOT NULL,
    [DateCalcul]        DATETIME      NULL,
    [AjustementID]      INT           NULL,
    [EssenceID]         VARCHAR (6)   NULL,
    [UniteID]           VARCHAR (6)   NULL,
    [LivraisonDetailID] INT           NULL,
    [UsineID]           VARCHAR (6)   NULL,
    [Volume]            FLOAT (53)    NULL,
    [Taux]              FLOAT (53)    NULL,
    [Montant]           FLOAT (53)    NULL,
    [Facture]           BIT           NULL,
    [FactureID]         INT           NULL,
    [ErreurCalcul]      BIT           NULL,
    [ErreurDescription] VARCHAR (300) NULL,
    [Code]              CHAR (4)      NULL
);

