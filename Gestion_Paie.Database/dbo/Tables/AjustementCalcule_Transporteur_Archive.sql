CREATE TABLE [dbo].[AjustementCalcule_Transporteur_Archive] (
    [ID]                INT           NOT NULL,
    [DateCalcul]        DATETIME      NULL,
    [AjustementID]      INT           NULL,
    [UniteID]           VARCHAR (6)   NULL,
    [MunicipaliteID]    VARCHAR (6)   NULL,
    [LivraisonID]       INT           NULL,
    [TransporteurID]    VARCHAR (15)  NULL,
    [Volume]            FLOAT (53)    NULL,
    [Taux]              FLOAT (53)    NULL,
    [Montant]           FLOAT (53)    NULL,
    [Facture]           BIT           NULL,
    [FactureID]         INT           NULL,
    [ErreurCalcul]      BIT           NULL,
    [ErreurDescription] VARCHAR (300) NULL,
    [ZoneID]            VARCHAR (2)   NULL
);

