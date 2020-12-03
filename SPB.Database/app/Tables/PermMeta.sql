CREATE TABLE [app].[PermMeta] (
    [ID]          INT           IDENTITY (1, 1) NOT NULL,
    [Groupe]      NVARCHAR (12) NOT NULL,
    [Code]        INT           NOT NULL,
    [Description] NVARCHAR (50) NOT NULL,
    [ParentID]    INT           NULL,
    [SortOrder]   INT           NULL,
    [Archive]     BIT           CONSTRAINT [DF_PermMeta_Archive] DEFAULT ((0)) NOT NULL,
    [Created]     DATETIME      CONSTRAINT [DF_PermMeta_Created] DEFAULT (getdate()) NOT NULL,
    [Updated]     DATETIME      NULL,
    [UpdatedBy]   INT           CONSTRAINT [DF_PermMeta_UpdatedBy] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_PermMeta] PRIMARY KEY CLUSTERED ([ID] ASC)
);



