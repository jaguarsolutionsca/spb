CREATE TABLE [dbo].[Indexation_Livraison] (
    [IndexationID] INT NOT NULL,
    [LivraisonID]  INT NOT NULL,
    CONSTRAINT [PK_Indexation_Livraison] PRIMARY KEY CLUSTERED ([IndexationID] ASC, [LivraisonID] ASC),
    CONSTRAINT [FK_Indexation_Livraison_Indexation] FOREIGN KEY ([IndexationID]) REFERENCES [dbo].[Indexation] ([ID]) ON DELETE CASCADE
);

