CREATE TABLE [dbo].[Equipment] (
    [ID]        INT             IDENTITY (1, 1) NOT NULL,
    [StaffID]   INT             NOT NULL,
    [Name]      NVARCHAR (50)   NOT NULL,
    [CatLUID]   INT             NULL,
    [Price]     DECIMAL (18, 2) NULL,
    [Active]    BIT             NOT NULL,
    [Created]   DATETIME        NOT NULL,
    [Updated]   DATETIME        NOT NULL,
    [UpdatedBy] INT             NOT NULL,
    CONSTRAINT [PK_Equipment] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Equipment_Lookup] FOREIGN KEY ([CatLUID]) REFERENCES [app].[Lookup] ([ID]),
    CONSTRAINT [FK_Equipment_Staff] FOREIGN KEY ([StaffID]) REFERENCES [dbo].[Staff] ([ID])
);



