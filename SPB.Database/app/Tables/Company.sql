CREATE TABLE [app].[Company] (
    [CIE]       INT             NOT NULL,
    [Name]      NVARCHAR (64)   NOT NULL,
    [Features]  NVARCHAR (2048) NULL,
    [Archive]   BIT             CONSTRAINT [DF_Company_Archive] DEFAULT ((0)) NOT NULL,
    [Created]   DATETIME        CONSTRAINT [DF_Company_Created] DEFAULT (getdate()) NOT NULL,
    [Updated]   DATETIME        NOT NULL,
    [UpdatedBy] INT             CONSTRAINT [DF_Company_UpdatedBy] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED ([CIE] ASC)
);

