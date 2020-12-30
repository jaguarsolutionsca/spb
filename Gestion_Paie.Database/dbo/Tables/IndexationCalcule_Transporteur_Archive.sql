CREATE TABLE [dbo].[IndexationCalcule_Transporteur_Archive] (
    [ID]                   INT           NOT NULL,
    [DateCalcul]           DATETIME      NULL,
    [TypeIndexation]       CHAR (1)      NULL,
    [IndexationID]         INT           NULL,
    [IndexationDetailID]   INT           NULL,
    [LivraisonID]          INT           NULL,
    [TransporteurID]       VARCHAR (15)  NULL,
    [MontantDejaPaye]      FLOAT (53)    NULL,
    [PourcentageDuMontant] FLOAT (53)    NULL,
    [Montant]              FLOAT (53)    NULL,
    [Facture]              BIT           NULL,
    [FactureID]            INT           NULL,
    [ErreurCalcul]         BIT           NULL,
    [ErreurDescription]    VARCHAR (300) NULL
);

