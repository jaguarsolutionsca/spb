CREATE TABLE [dbo].[GestionVolume_Detail] (
    [ID]              INT         IDENTITY (1, 1) NOT NULL,
    [GestionVolumeID] INT         NULL,
    [EssenceID]       VARCHAR (6) NULL,
    [UniteMesureID]   VARCHAR (6) NULL,
    [VolumeBrut]      FLOAT (53)  NULL,
    [VolumeReduction] FLOAT (53)  NULL,
    [VolumeNet]       FLOAT (53)  NULL,
    CONSTRAINT [PK_GestionVolume_Detail] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_GestionVolume_Detail_Essence_Unite] FOREIGN KEY ([EssenceID], [UniteMesureID]) REFERENCES [dbo].[Essence_Unite] ([EssenceID], [UniteID]) ON UPDATE CASCADE,
    CONSTRAINT [FK_GestionVolume_Detail_GestionVolume] FOREIGN KEY ([GestionVolumeID]) REFERENCES [dbo].[GestionVolume] ([ID]) ON DELETE CASCADE
);

