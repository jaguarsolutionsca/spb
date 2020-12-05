﻿CREATE TABLE [app].[Lookup] (
    [ID]          INT            IDENTITY (1, 1) NOT NULL,
    [CID]         INT            NULL,
    [Groupe]      NVARCHAR (12)  NOT NULL,
    [Code]        NVARCHAR (9)   NULL,
    [Description] NVARCHAR (50)  NOT NULL,
    [Value1]      NVARCHAR (50)  NULL,
    [Value2]      NVARCHAR (50)  NULL,
    [Value3]      VARCHAR (1024) NULL,
    [Started]     DATE           CONSTRAINT [DF_Lookup_Started] DEFAULT (getdate()) NOT NULL,
    [Ended]       DATE           NULL,
    [SortOrder]   INT            NULL,
    [Created]     DATETIME       CONSTRAINT [DF_Lookup_Created] DEFAULT (getdate()) NOT NULL,
    [Updated]     DATETIME       CONSTRAINT [DF_Lookup_Updated] DEFAULT (getdate()) NOT NULL,
    [UpdatedBy]   INT            CONSTRAINT [DF_Lookup_UpdatedBy] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Lookup] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Lookup_Company] FOREIGN KEY ([CID]) REFERENCES [app].[Company] ([ID])
);
