﻿CREATE TABLE [app].[Account] (
    [UID]          INT              IDENTITY (0, 1) NOT NULL,
    [CIE]          INT              NOT NULL,
    [Email]        NVARCHAR (50)    NOT NULL,
    [Password]     NVARCHAR (50)    NULL,
    [RoleLUID]     INT              NOT NULL,
    [ResetGuid]    UNIQUEIDENTIFIER NULL,
    [ResetExpiry]  DATETIME         NULL,
    [LastActivity] DATETIME         NULL,
    [IsAdminReset] BIT              CONSTRAINT [DF_Account_IsReset] DEFAULT ((0)) NOT NULL,
    [FirstName]    NVARCHAR (128)   NOT NULL,
    [LastName]     NVARCHAR (128)   NOT NULL,
    [UseRealEmail] BIT              CONSTRAINT [DF_Account_UseRealEmail] DEFAULT ((1)) NOT NULL,
    [ArchiveDays]  INT              CONSTRAINT [DF_Account_AutoArchive] DEFAULT ((0)) NULL,
    [CurrentYear]         INT              NULL,
    [Comment]      NVARCHAR (1024)  NULL,
    [Archive]      BIT              CONSTRAINT [DF_Account_Archive] DEFAULT ((0)) NOT NULL,
    [Created]      DATETIME         CONSTRAINT [DF_Account_Created] DEFAULT (getdate()) NOT NULL,
    [Updated]      DATETIME         NOT NULL,
    [UpdatedBy]    INT              CONSTRAINT [DF_Account_ModifiedBy] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED ([UID] ASC),
    CONSTRAINT [FK_Account_Company] FOREIGN KEY ([CIE]) REFERENCES [app].[Company] ([CIE])
);







