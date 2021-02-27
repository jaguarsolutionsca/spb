CREATE TABLE [app].[Lookup] (
    [ID]           INT            IDENTITY (1, 1) NOT NULL,
    [CIE]          INT            NULL,
    [Groupe]       NVARCHAR (12)  NOT NULL,
    [ParentGroupe] NVARCHAR (12)  NULL,
    [Code]         NVARCHAR (12)  NULL,
    [Description]  NVARCHAR (50)  NOT NULL,
    [Value1]       NVARCHAR (50)  NULL,
    [Value2]       NVARCHAR (50)  NULL,
    [Value3]       VARCHAR (1024) NULL,
    [Started]      INT            CONSTRAINT [DF_Lookup_Started] DEFAULT ((2020)) NOT NULL,
    [Ended]        INT            NULL,
    [SortOrder]    INT            NULL,
    [Created]      DATETIME       CONSTRAINT [DF_Lookup_Created] DEFAULT (getdate()) NOT NULL,
    [Updated]      DATETIME       CONSTRAINT [DF_Lookup_Updated] DEFAULT (getdate()) NOT NULL,
    [UpdatedBy]    INT            CONSTRAINT [DF_Lookup_UpdatedBy] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Lookup] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Lookup_Company] FOREIGN KEY ([CIE]) REFERENCES [app].[Company] ([CIE])
);













