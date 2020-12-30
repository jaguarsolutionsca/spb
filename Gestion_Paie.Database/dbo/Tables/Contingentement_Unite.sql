CREATE TABLE [dbo].[Contingentement_Unite] (
    [ContingentementID] INT         NOT NULL,
    [UniteID]           VARCHAR (6) NOT NULL,
    [Facteur]           FLOAT (53)  NULL,
    CONSTRAINT [PK_Contingentement_Unite] PRIMARY KEY CLUSTERED ([ContingentementID] ASC, [UniteID] ASC),
    CONSTRAINT [FK_Contingentement_Unite_Contingentement] FOREIGN KEY ([ContingentementID]) REFERENCES [dbo].[Contingentement] ([ID]) ON DELETE CASCADE,
    CONSTRAINT [FK_Contingentement_Unite_UniteMesure] FOREIGN KEY ([UniteID]) REFERENCES [dbo].[UniteMesure] ([ID]) ON UPDATE CASCADE
);

