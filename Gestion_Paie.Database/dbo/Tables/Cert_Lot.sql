CREATE TABLE [dbo].[Cert_Lot] (
    [Agence]           VARCHAR (10)  NOT NULL,
    [NO_ACT]           VARCHAR (10)  NOT NULL,
    [Matricule]        VARCHAR (15)  NULL,
    [Lots]             VARCHAR (255) NULL,
    [Rang]             VARCHAR (25)  NULL,
    [Canton]           VARCHAR (25)  NULL,
    [Municipalite]     VARCHAR (25)  NULL,
    [SuperficieBoisee] FLOAT (53)    NULL,
    [SuperficieTotal]  FLOAT (53)    NULL,
    [Resident]         FLOAT (53)    NULL,
    [INF_PROP#MUNICIP] VARCHAR (10)  NULL
);

